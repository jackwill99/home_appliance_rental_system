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
    public partial class CustomerLoginForm : Form
    {
        public CustomerLoginForm()
        {
            InitializeComponent();
        }

        // ------------------------------- Customer Attributes --------------------
        HomeApplianceTableAdapters.customerTableAdapter customerDataObj = new HomeApplianceTableAdapters.customerTableAdapter();
        private int count = 0;

        // -------------------------------  General Methods of Customer Login --------------------

        // Clear the customer information form
        private void _clearForm()
        {
            txtPassword.Clear();
            txtUserName.Clear();
        }

        // add user information
        public static void addDataToCustomerUserInfo(DataTable dt)
        {
            CustomerControl.userInfo = User.addDataToUser(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString(), dt.Rows[0][5].ToString(), dt.Rows[0][4].ToString(), dt.Rows[0][7].ToString(), dt.Rows[0][6].ToString());
            CustomerControl.isCustomer = true;
        }


        // -------------------------------  Form Actions of Customer Login --------------------

        //  go to the register form
        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CustomerRegisterForm registerForm = new CustomerRegisterForm(() => {
                CustomerLoginForm loginForm = new CustomerLoginForm();
                loginForm.Show();
            }, true);
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
                MessageBox.Show("You have reached your limit of three times!", "Customer Login", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else if (txtUserName.Text == "")
            {
                MessageBox.Show("Please Enter your User Name", "Customer Login", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Please Enter your Password", "Customer Login", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                DataTable dt = new DataTable();
                dt = customerDataObj.LogIn(txtUserName.Text, txtPassword.Text);
                if (dt.Rows.Count == 1)
                {
                    MessageBox.Show("Login Successfully", "Customer Login", MessageBoxButtons.OK);

                    // store the logined data in file and user information
                    CustomerControl.storeCustomerData(txtUserName.Text, txtPassword.Text);
                    addDataToCustomerUserInfo(dt);


                    _clearForm();
                    this.Hide();

                   


                    // go to the home page
                    HomePage home = new HomePage();
                    home.Show();
                }
                else
                {
                    count += 1;
                    MessageBox.Show("Invalid Login Attempt: " + count, "Customer Login", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
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
