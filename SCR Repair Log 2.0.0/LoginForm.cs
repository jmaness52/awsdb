using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCR_Repair_Tracker
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {

            // validate the login to say that username, password are not blank, and that user is not trying to login with "sa"
            if (TxtPassword.Text != "")
            {


                //test login will attempt to open a db connection with info provided
                
                if (ConnStringBuilder.TestLogin(TxtPassword.Text))
                {


                    DataAccess SqlConn = new DataAccess();
                    SqlConn.StoreStaticTables();  // stores the list of employees, device types, status types from the db to the constansts library
                    OpenRepairs WelcomeForm = new OpenRepairs(); 
                    WelcomeForm.MdiParent = this.MdiParent;
                    Dispose();
                    WelcomeForm.Show();
                }
               else
                {
                    MessageBox.Show("Login Failed!");
                    TxtPassword.Text = "";

                }
                
            }
            else
            {
                MessageBox.Show("Error. Please Check Password!");
            }
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
