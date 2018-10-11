using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCR_Repair_Tracker
{
    public partial class UserSelectForm : Form
    {
        private string user; // initials of the user to pass to the repair form
        private string userFull;

        public string User
        {
            get { return user; }
        }

        public string UserFull
        {
            get { return userFull; }
        }

        public UserSelectForm()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void UserSelectForm_Load(object sender, EventArgs e)
        {
            foreach( EmployeeRow eR in ConstantsLibrary.EmployeeList)
            {
                FlowUserSelect.Controls.Add(new Button
                {
                    Name = string.Concat(eR.EmployeeName, "Btn"),
                    Text = eR.EmployeeName,
                    Width = 200,
                    Height = 25,
                    AccessibleName= eR.Initials
                                                           
                });
            }

            foreach (Control Con in FlowUserSelect.Controls)
            {
                if( Con is Button)
                {
                    Con.Click += Btn_Press;
                }
            }
        }


        private void Btn_Press(object sender, EventArgs e)
        {
            Button PressedBtn = (Button)sender;
            user = PressedBtn.AccessibleName;
            userFull = PressedBtn.Text;
            Hide();
        }

        
    }
}
