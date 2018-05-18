using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Web.Services;
using BusinessAnyplace.CommonServices;
using System.Runtime.InteropServices;
using People_Anyplace.net.serviceobjects.ws2;


namespace People_Anyplace
{
	/// <summary>
	/// Summary description for YellowPages.
	/// </summary>
	public class YellowPages : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel pnlHeading;
		private System.Windows.Forms.Button btnFindBusiness;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtMiles;
		private System.Windows.Forms.TreeView tvwBusiness;
		private System.Windows.Forms.Label label3;
		private string YPZip;
		// SIP constants (as defined in SIPAPI.h)
		private const int SIPF_OFF = 0x00000000;
		private const int SIPF_ON = 0x00000001;
		[ DllImport("coredll.dll", EntryPoint="SipShowIM") ]
		private extern static bool showSIP(int dwFlag);

		public YellowPages(string Zip)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			YPZip = Zip;

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
			this.pnlHeading = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.btnFindBusiness = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtMiles = new System.Windows.Forms.TextBox();
			this.tvwBusiness = new System.Windows.Forms.TreeView();
			// 
			// pnlHeading
			// 
			this.pnlHeading.BackColor = System.Drawing.Color.Black;
			this.pnlHeading.Location = new System.Drawing.Point(0, 24);
			this.pnlHeading.Size = new System.Drawing.Size(240, 1);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 5);
			this.label3.Size = new System.Drawing.Size(224, 16);
			this.label3.Text = "Find Hotels && Restaurants";
			// 
			// btnFindBusiness
			// 
			this.btnFindBusiness.Location = new System.Drawing.Point(184, 32);
			this.btnFindBusiness.Size = new System.Drawing.Size(56, 24);
			this.btnFindBusiness.Text = "Find";
			this.btnFindBusiness.Click += new System.EventHandler(this.btnFindBusiness_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 32);
			this.label1.Size = new System.Drawing.Size(128, 16);
			this.label1.Text = "Max Distance (miles):";
			// 
			// txtMiles
			// 
			this.txtMiles.Location = new System.Drawing.Point(128, 32);
			this.txtMiles.Size = new System.Drawing.Size(40, 22);
			this.txtMiles.Text = "3";
			this.txtMiles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtMiles.LostFocus += new System.EventHandler(this.txtMiles_LostFocus);
			this.txtMiles.GotFocus += new System.EventHandler(this.txtMiles_GotFocus);
			// 
			// tvwBusiness
			// 
			this.tvwBusiness.ImageIndex = -1;
			this.tvwBusiness.Location = new System.Drawing.Point(0, 64);
			this.tvwBusiness.SelectedImageIndex = -1;
			this.tvwBusiness.Size = new System.Drawing.Size(240, 224);
			// 
			// YellowPages
			// 
			this.ClientSize = new System.Drawing.Size(242, 295);
			this.Controls.Add(this.tvwBusiness);
			this.Controls.Add(this.txtMiles);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnFindBusiness);
			this.Controls.Add(this.pnlHeading);
			this.Controls.Add(this.label3);
			this.Text = "People Anyplace";

		}
		#endregion

		private void btnFindBusiness_Click(object sender, System.EventArgs e)
		{
			DOTSYellowPages YP = new DOTSYellowPages();
			Listings HotelListings = new Listings();
			Listings RestaurantListings = new Listings();

			// Show wait cursor
			Cursor.Current = Cursors.WaitCursor;

			try
			{
				// Check that server is available over HTTP (port 80)
				if(CheckConnection.Once(YP.Url))
				{
					// Get hotels
					HotelListings = YP.GetYPListingsByCategoryID(1279, YPZip, Convert.ToInt32(txtMiles.Text), "0");	
					// Get restaurants
					RestaurantListings = YP.GetYPListingsByCategoryID(655, YPZip, Convert.ToInt32(txtMiles.Text), "0");

					// Clear treeview
					tvwBusiness.Nodes.Clear();

					// Call to fill the treeview with hotels
					FillTreeView(HotelListings);

					// Call to fill the treeview with restaurants
					FillTreeView(RestaurantListings);
				
				}
				else
				{
					// No connection!
					MessageBox.Show("Connection to Web Service server could not be established!");
				}
	
			}
			catch (Exception ex)
			{
				MessageBox.Show("Could not make Web Service calls (" + ex.Message + ")!");
			}
			finally
			{
				// Restore default cursor
				Cursor.Current = Cursors.Default;				
			}
		}

		private void FillTreeView(Listings TreeListing)
		{
			TreeNode nod;

			try
			{
				tvwBusiness.BeginUpdate();
				foreach (Listing li in TreeListing.Listing)
				{
					nod = new TreeNode(li.CompanyName);			
					nod.Nodes.Add(li.Address);
					nod.Nodes.Add(li.Phone);
					tvwBusiness.Nodes.Add(nod);
				}
				tvwBusiness.EndUpdate();
			}


			catch (Exception ex)
			{
				MessageBox.Show("Could not parse results (" + ex.Message + ")!");
			}
			finally
			{
			tvwBusiness.Nodes.Clear();
			}
	
		}

		private void txtMiles_GotFocus(object sender, System.EventArgs e)
		{
			// Show SIP
			showSIP(SIPF_ON);
		}

		private void txtMiles_LostFocus(object sender, System.EventArgs e)
		{
			// Hide SIP
			showSIP(SIPF_OFF);
		}


	}
}
