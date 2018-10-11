using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;


namespace SCR_Repair_Tracker
{
    
    public partial class MainForm : Form
    {

        private DataValidation sqlHelper = new DataValidation();
        


        public DataValidation SqlHelper
        {
            get { return sqlHelper; }
            set { sqlHelper = value; }
        }

        

        public MainForm()
        {
            InitializeComponent();
            mainMenu.Renderer = new MyRenderer();  // allows ovverrides in menu strip color table so we can change menu hover color
            

        }
        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyColors()) { }
        }

        private class MyColors : ProfessionalColorTable
        {
            public override Color MenuItemSelected  // overrides the selection color of a menu item
            {
                get { return Color.Orange; }
            }

            public override Color MenuItemBorder // same but for the border
            {
                get { return Color.White; }
            }

            public override Color MenuItemPressedGradientBegin  // the top menus so they dont appear white , set begin and end gradient the same
            { 
                get { return Color.Orange;  }
            }

            public override Color MenuItemPressedGradientEnd
            {
                get { return Color.Orange; }
            }
        }


        private void MainForm_MdiChildActivate(object sender, EventArgs e)
        {
            
            if (this.mainMenu.Enabled == false & this.MdiChildren[0].Name != "LoginForm")
                this.mainMenu.Enabled = true;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            
            LogOut(); // logout method is same code to show login form
        }

        public void LogOut()
        {
            // call the logout method to disable the menu and show the login screen
            
            ConnStringBuilder.ClearCredentials(); // wipes the validated connection string

            LoginForm initState = new LoginForm
            {
                MdiParent = this,
                

            };

            initState.StartPosition = FormStartPosition.CenterScreen;
            initState.Show();

            MainMenuStrip.Enabled = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            // load the store information from the app.config
            try
            {
                ConstantsLibrary.LocalTax = Convert.ToDecimal(ConfigurationManager.AppSettings.Get("TaxLocal"));
                ConstantsLibrary.StoreName = ConfigurationManager.AppSettings.Get("StoreName");
                ConstantsLibrary.StoreAddress = ConfigurationManager.AppSettings.Get("Address");
                ConstantsLibrary.StoreCity = ConfigurationManager.AppSettings.Get("City");
                ConstantsLibrary.StoreState = ConfigurationManager.AppSettings.Get("State");
                ConstantsLibrary.StoreZip = ConfigurationManager.AppSettings.Get("Zip");
                ConstantsLibrary.StorePhone = ConfigurationManager.AppSettings.Get("PhoneNumber");


            }
            catch (Exception)
            {

                MessageBox.Show("Error loading constants, please check the app.config file");
            }

            
        }

        private void msiOpenRepairs_Click(object sender, EventArgs e)
        {
            

            

            if (MdiChildren[0].Name != "OpenRepairs")
            {
                GotoOpenRepairs();
            }


        }

        private void msiNewRepair_Click(object sender, EventArgs e)
        {
            GotoCustSelect("Repair");
        }

        

        private void msiCompletedRepairs_Click(object sender, EventArgs e)
        {
            if (MdiChildren[0].Name != "CompletedRepairsForm")
            {
                GotoCompletedRepairs();
            }
            
        }

        private void msiCompletedOrders_Click(object sender, EventArgs e)
        {
            if (MdiChildren[0].Name != "CompletedPartsForm")
            {
                GotoCompletedParts();
            }
        }

        private void msiNewOrder_Click(object sender, EventArgs e)
        {
            GotoCustSelect("Part");
        }

        private void msiOpenOrders_Click(object sender, EventArgs e)
        {
            if (MdiChildren[0].Name != "OpenParts")
            {
                GotoOpenParts();
            }
        }

        private void GotoOpenRepairs()
        {
            MdiChildren[0].Close();
           
            
            GC.Collect();
            OpenRepairs openRep = new OpenRepairs();
            openRep.MdiParent = this;
            openRep.Dock = DockStyle.Fill;
            openRep.Show();
        }

        private void GotoCustSelect(string typeIn)
        {
            MdiChildren[0].Close();
            
            GC.Collect();
            CustomerSelectForm custSel = new CustomerSelectForm();
            custSel.OutputType = typeIn;
            custSel.MdiParent = this;
            custSel.Dock = DockStyle.Fill;
            custSel.Show();
        }

        private void GotoOpenParts()
        {
            MdiChildren[0].Close();

            GC.Collect();
            OpenParts openPartOrders = new OpenParts();
            openPartOrders.MdiParent = this;
            openPartOrders.Dock = DockStyle.Fill;
            openPartOrders.Show();
        }

        private void GotoCompletedRepairs()
        {
            MdiChildren[0].Close();

            GC.Collect();
            CompletedRepairsForm compRepairs = new CompletedRepairsForm();
            compRepairs.MdiParent = this;
            compRepairs.Dock = DockStyle.Fill;
            compRepairs.Show();
        }

        private void GotoCompletedParts()
        {
            MdiChildren[0].Close();

            GC.Collect();
            CompletedPartsForm compParts = new CompletedPartsForm();
            compParts.MdiParent = this;
            compParts.Dock = DockStyle.Fill;
            compParts.Show();

        }

        
    }
}


