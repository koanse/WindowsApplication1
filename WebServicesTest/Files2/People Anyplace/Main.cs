using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using BusinessAnyplace.CommonServices;
using System.Runtime.InteropServices;
using People_Anyplace.net.serviceobjects.ws;

namespace People_Anyplace
{
	/// <summary>
	/// People Anyplace main form.
	/// </summary>
	/// 

	public class frmMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel pnlHeading;
		private System.Windows.Forms.Button btnFindPerson;
		private System.Windows.Forms.TextBox txtPhoneNumber;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.TextBox txtAddress;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtCity;
		private System.Windows.Forms.TextBox txtState;
		private System.Windows.Forms.TextBox txtZip;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Button btnYellowPages;
		private System.Windows.Forms.MainMenu mainMenu1;
		
		// SIP constants (as defined in SIPAPI.h)
		private const int SIPF_OFF = 0x00000000;
		private const int SIPF_ON = 0x00000001;

		[ DllImport("coredll.dll", EntryPoint="SipShowIM") ]
		private extern static bool showSIP(int dwFlag);

		public frmMain()
		{
			InitializeComponent();
			resetControls();
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
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtPhoneNumber = new System.Windows.Forms.TextBox();
			this.btnFindPerson = new System.Windows.Forms.Button();
			this.pnlHeading = new System.Windows.Forms.Panel();
			this.btnYellowPages = new System.Windows.Forms.Button();
			this.txtName = new System.Windows.Forms.TextBox();
			this.txtAddress = new System.Windows.Forms.TextBox();
			this.txtCity = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtState = new System.Windows.Forms.TextBox();
			this.txtZip = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.treeView1 = new System.Windows.Forms.TreeView();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 32);
			this.label1.Size = new System.Drawing.Size(48, 16);
			this.label1.Text = "Phone:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 5);
			this.label3.Size = new System.Drawing.Size(224, 16);
			this.label3.Text = "Enter phone number to find person!";
			// 
			// txtPhoneNumber
			// 
			this.txtPhoneNumber.Location = new System.Drawing.Point(56, 32);
			this.txtPhoneNumber.Size = new System.Drawing.Size(176, 22);
			this.txtPhoneNumber.Text = "2066827453";
			this.txtPhoneNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtPhoneNumber.LostFocus += new System.EventHandler(this.txtPhoneNumber_LostFocus);
			this.txtPhoneNumber.GotFocus += new System.EventHandler(this.txtPhoneNumber_GotFocus);
			// 
			// btnFindPerson
			// 
			this.btnFindPerson.Location = new System.Drawing.Point(128, 64);
			this.btnFindPerson.Size = new System.Drawing.Size(104, 24);
			this.btnFindPerson.Text = "Find Person";
			this.btnFindPerson.Click += new System.EventHandler(this.btnFindPerson_Click);
			// 
			// pnlHeading
			// 
			this.pnlHeading.BackColor = System.Drawing.Color.Black;
			this.pnlHeading.Location = new System.Drawing.Point(0, 24);
			this.pnlHeading.Size = new System.Drawing.Size(240, 1);
			// 
			// btnYellowPages
			// 
			this.btnYellowPages.Enabled = false;
			this.btnYellowPages.Location = new System.Drawing.Point(56, 232);
			this.btnYellowPages.Size = new System.Drawing.Size(176, 24);
			this.btnYellowPages.Text = "Find Hotels && Restaurants...";
			this.btnYellowPages.Click += new System.EventHandler(this.btnYellowPages_Click);
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(56, 104);
			this.txtName.Size = new System.Drawing.Size(176, 22);
			this.txtName.Text = "";
			// 
			// txtAddress
			// 
			this.txtAddress.Location = new System.Drawing.Point(56, 128);
			this.txtAddress.Size = new System.Drawing.Size(176, 22);
			this.txtAddress.Text = "";
			// 
			// txtCity
			// 
			this.txtCity.Location = new System.Drawing.Point(56, 152);
			this.txtCity.Size = new System.Drawing.Size(176, 22);
			this.txtCity.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 104);
			this.label2.Size = new System.Drawing.Size(48, 16);
			this.label2.Text = "Name:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(0, 128);
			this.label4.Size = new System.Drawing.Size(56, 16);
			this.label4.Text = "Address:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(24, 152);
			this.label5.Size = new System.Drawing.Size(32, 16);
			this.label5.Text = "City:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// txtState
			// 
			this.txtState.Location = new System.Drawing.Point(56, 176);
			this.txtState.Size = new System.Drawing.Size(176, 22);
			this.txtState.Text = "";
			// 
			// txtZip
			// 
			this.txtZip.Location = new System.Drawing.Point(56, 200);
			this.txtZip.Size = new System.Drawing.Size(176, 22);
			this.txtZip.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 176);
			this.label6.Size = new System.Drawing.Size(40, 16);
			this.label6.Text = "State:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(24, 200);
			this.label7.Size = new System.Drawing.Size(32, 16);
			this.label7.Text = "Zip:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// treeView1
			// 
			this.treeView1.ImageIndex = -1;
			this.treeView1.Location = new System.Drawing.Point(88, 272);
			this.treeView1.SelectedImageIndex = -1;
			// 
			// frmMain
			// 
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtZip);
			this.Controls.Add(this.txtState);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtCity);
			this.Controls.Add(this.txtAddress);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.btnYellowPages);
			this.Controls.Add(this.pnlHeading);
			this.Controls.Add(this.btnFindPerson);
			this.Controls.Add(this.txtPhoneNumber);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Menu = this.mainMenu1;
			this.MinimizeBox = false;
			this.Text = "People Anyplace";

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main() 
		{
			Application.Run(new frmMain());
		}

		private void resetControls()
		{

			this.btnYellowPages.Enabled = false;
			this.txtName.Text = "";
			this.txtAddress.Text = "";
			this.txtCity.Text = "";
			this.txtState.Text = "";
			this.txtZip.Text = "";

		}

		private void btnFindPerson_Click(object sender, System.EventArgs e)
		{
			// Instantiate Web Service
			GeoPhone geoPhone = new GeoPhone();			

			// Reset all controls to default
			resetControls();

			// Show wait cursor
			Cursor.Current = Cursors.WaitCursor;

			try
			{

				// Check that server is available over HTTP (port 80)
				if(CheckConnection.Once(geoPhone.Url))
				{
					// Get address
					Contact Person = geoPhone.GetPhoneInfo(txtPhoneNumber.Text,"0").Contacts[0];
					// Display address
					txtName.Text = Person.Name;
					txtAddress.Text = Person.Address;
					txtCity.Text = Person.City;
					txtState.Text = Person.State;
					txtZip.Text = Person.Zip;

					this.btnYellowPages.Enabled = true;
				
				}
				else
				{
					// No connection!
					MessageBox.Show("Connection to Web Service server could not be established!");
				}
			}

			catch (Exception ex)
			{
				// Disable Save As Contact button
				this.btnYellowPages.Enabled = false;

				MessageBox.Show("Could not make Web Service calls (" + ex.Message + ")!");
			}
			finally
			{
				// Restore default cursor
				Cursor.Current = Cursors.Default;
			}
		
		}

		private void btnYellowPages_Click(object sender, System.EventArgs e)
		{
		
		 Form frmYP = new YellowPages(txtZip.Text);
		 frmYP.Show();

	}

		private void txtPhoneNumber_GotFocus(object sender, System.EventArgs e)
		{
			// Show SIP
			showSIP(SIPF_ON);
		}

		private void txtPhoneNumber_LostFocus(object sender, System.EventArgs e)
		{
			// Hide SIP
			showSIP(SIPF_OFF);
		}
	}
}
	
