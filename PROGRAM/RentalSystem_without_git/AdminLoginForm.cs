using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalSystem
{
    public partial class AdminLoginForm : Form
    {
        public AdminLoginForm()
        {
            InitializeComponent();
        }

        // ------------------------------- Admin Attributes --------------------
        HomeApplianceTableAdapters.adminTableAdapter adminDataObj = new HomeApplianceTableAdapters.adminTableAdapter();
        private int count = 0;

        // -------------------------------  General Methods of Admin Login --------------------

        // Clear the admin information form
        private void _clearForm()
        {
            txtPassword.Clear();
            txtUserName.Clear();
        }

        // add user information
        public static void addDataToAdminUserInfo(DataTable dt)
        {
            AdminControl.userInfo = User.addDataToUser(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString(), dt.Rows[0][5].ToString(), dt.Rows[0][4].ToString(), dt.Rows[0][7].ToString(), dt.Rows[0][6].ToString());
            CustomerControl.isCustomer = false;
        }

        // -------------------------------  Form Actions of Admin Login --------------------

        //  go to the register form
        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AdminRegisterForm registerForm = new AdminRegisterForm(() => {
                AdminLoginForm loginForm = new AdminLoginForm();
                loginForm.Show();
            } ,true);
            registerForm.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {   
            //  1.  check the invalid login times and if over 3 times, show message
            //  2.  check validate inputs
            //  3.  check user is authenticated or not
            if (count == 3)
            {
                MessageBox.Show("You have reached your limit of three times!", "Admin Login", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else if (txtUserName.Text == "")
            {
                MessageBox.Show("Please Enter your User Name", "Admin Login", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Please Enter your Password", "Admin Login", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                DataTable dt = new DataTable();
                dt= adminDataObj.LogIn(txtUserName.Text, txtPassword.Text);
                if (dt.Rows.Count == 1)
                {
                    MessageBox.Show("Login Successfully", "Admin Login", MessageBoxButtons.OK);
                    // store the logined data in file and user information
                    AdminControl.storeAdminData(txtUserName.Text, txtPassword.Text);
                    addDataToAdminUserInfo(dt);
                    _clearForm();
                    this.Hide();

                  
                    // go to the home page
                    HomePage home = new HomePage();
                    home.Show();
                }
                else
                {
                    count += 1;
                    MessageBox.Show("Invalid Login Attempt: " + count, "Admin Login", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _clearForm();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            StartForm startForm = new StartForm();
            Close();
            startForm.Show();
        }

       
    }
}
