using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;

namespace BooksAnyplace
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtISBN;
		private System.Windows.Forms.ComboBox cmbCurrency;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ColumnHeader colISBN;
		private System.Windows.Forms.ColumnHeader colUS;
		private System.Windows.Forms.ColumnHeader colAmount;
		private System.Windows.Forms.ColumnHeader colCurrency;
		private System.Windows.Forms.Button btnGet;
		private System.Windows.Forms.ListView lvwBooks;
		private System.Windows.Forms.MainMenu mainMenu1;

		public frmMain()
		{

			InitializeComponent();

			// Add countries to combobox
			this.cmbCurrency.Items.Add("australia");
			this.cmbCurrency.Items.Add("austria");
			this.cmbCurrency.Items.Add("brazil");
			this.cmbCurrency.Items.Add("england");
			this.cmbCurrency.Items.Add("united kingdom");
			this.cmbCurrency.Items.Add("china");
			this.cmbCurrency.Items.Add("denmark");
			this.cmbCurrency.Items.Add("euro");
			this.cmbCurrency.Items.Add("hong kong");
			this.cmbCurrency.Items.Add("india");
			this.cmbCurrency.Items.Add("indonesia");
			this.cmbCurrency.Items.Add("israel");
			this.cmbCurrency.Items.Add("korea");
			this.cmbCurrency.Items.Add("norway");
			this.cmbCurrency.Items.Add("russia");
			this.cmbCurrency.Items.Add("sweden");
			
			// Make euro default
			this.cmbCurrency.SelectedIndex=7;

		}
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			base.Dispose( disposing );
		}
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.lvwBooks = new System.Windows.Forms.ListView();
			this.colISBN = new System.Windows.Forms.ColumnHeader();
			this.colUS = new System.Windows.Forms.ColumnHeader();
			this.colAmount = new System.Windows.Forms.ColumnHeader();
			this.colCurrency = new System.Windows.Forms.ColumnHeader();
			this.txtISBN = new System.Windows.Forms.TextBox();
			this.cmbCurrency = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnGet = new System.Windows.Forms.Button();
			// 
			// lvwBooks
			// 
			this.lvwBooks.Columns.Add(this.colISBN);
			this.lvwBooks.Columns.Add(this.colUS);
			this.lvwBooks.Columns.Add(this.colAmount);
			this.lvwBooks.Columns.Add(this.colCurrency);
			this.lvwBooks.Location = new System.Drawing.Point(0, 80);
			this.lvwBooks.Size = new System.Drawing.Size(240, 192);
			this.lvwBooks.View = System.Windows.Forms.View.Details;
			// 
			// colISBN
			// 
			this.colISBN.Text = "ISBN";
			this.colISBN.Width = 80;
			// 
			// colUS
			// 
			this.colUS.Text = "$US";
			this.colUS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.colUS.Width = 38;
			// 
			// colAmount
			// 
			this.colAmount.Text = "Amount";
			this.colAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.colAmount.Width = 57;
			// 
			// colCurrency
			// 
			this.colCurrency.Text = "Currency";
			this.colCurrency.Width = 61;
			// 
			// txtISBN
			// 
			this.txtISBN.Location = new System.Drawing.Point(8, 24);
			this.txtISBN.Size = new System.Drawing.Size(120, 20);
			this.txtISBN.Text = "";
			// 
			// cmbCurrency
			// 
			this.cmbCurrency.Location = new System.Drawing.Point(144, 24);
			this.cmbCurrency.Size = new System.Drawing.Size(88, 21);
			this.cmbCurrency.Text = "comboBox1";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.Text = "ISBN number:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(144, 8);
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.Text = "Currency:";
			// 
			// btnGet
			// 
			this.btnGet.Location = new System.Drawing.Point(8, 48);
			this.btnGet.Size = new System.Drawing.Size(88, 24);
			this.btnGet.Text = "Get price";
			this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
			// 
			// frmMain
			// 
			this.ClientSize = new System.Drawing.Size(240, 270);
			this.Controls.Add(this.btnGet);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmbCurrency);
			this.Controls.Add(this.txtISBN);
			this.Controls.Add(this.lvwBooks);
			this.Menu = this.mainMenu1;
			this.Text = "Books Anyplace";

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>

		static void Main() 
		{
			Application.Run(new frmMain());
		}

		private void btnGet_Click(object sender, System.EventArgs e)
		{
		// Get the price and convert it!
		// Known bugs:
		// Version   Date   Who Comment
		// 00.00.000 020808 ASJ Created
		// *****************************

			// Start the hourglass 
			WaitCursor.Show(true);
			
			try
			{
			
				// Declare the Book Web Service
				net.xmethods.www.BNQuoteService BNQuote = new net.xmethods.www.BNQuoteService();

				// Get the price
				float price = BNQuote.getPrice(txtISBN.Text);

				// Declare the Currency Web Service
				net.xmethods.www1.CurrencyExchangeService Currency = new net.xmethods.www1.CurrencyExchangeService();

				// Get the converted price.
				float rate = Currency.getRate("us", cmbCurrency.Items[cmbCurrency.SelectedIndex].ToString());

				// Multiply the $US price with the exchange rate.
				decimal convertedPrice = (decimal) (price * rate);

				// Round the results
				convertedPrice = Math.Round(convertedPrice, 2);

				// Add to ListView
				ListViewItem lvi = new ListViewItem(txtISBN.Text);
				lvi.SubItems.Add(price.ToString());
				lvi.SubItems.Add(convertedPrice.ToString());
				lvi.SubItems.Add(cmbCurrency.Items[cmbCurrency.SelectedIndex].ToString());
				lvwBooks.Items.Add(lvi);

			}
			catch
			{
				MessageBox.Show("Could not call Web Services!", this.Text);
			}
			finally
			{
				WaitCursor.Show(false);
			}
		}
	}
}
