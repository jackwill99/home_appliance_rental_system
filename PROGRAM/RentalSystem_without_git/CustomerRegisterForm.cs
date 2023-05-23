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
    public partial class CustomerRegisterForm : Form
    {
        public CustomerRegisterForm(Action backCallback , bool showLoginLink = false, bool update = false)
        {
            InitializeComponent();
            _setAutoId();
            _backCallback = backCallback;
            _showLoginLink = showLoginLink;

            if (showLoginLink)
            {
                lblLogin.Visible = true;
                linkLogin.Visible = true;
            }
            else
            {
                lblLogin.Visible = false;
                linkLogin.Visible = false;
            }

            _update = update;
            if (update)
            {
                btnUpdate.Visible = true;
                btnSave.Enabled = false;
            }
        }

        // ------------------------------- Customer Attributes --------------------
        HomeApplianceTableAdapters.customerTableAdapter customerDataObj = new HomeApplianceTableAdapters.customerTableAdapter();
        static CustomerControl customerControl = new CustomerControl();
        private Action _backCallback;
        private bool _showLoginLink;

        private bool _update;


        // -------------------------------  General Methods of Customer --------------------

        // Clear the customer information form
        private void _clearInformationText()
        {
            txtName.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            txtPhoneNumber.Clear();
            txtAddress.Clear();
            picCustomer.Image = null;
            rdoFemale.Checked = false;
            rdoMale.Checked = false;
        }

        // Set automation id of Customer
        private void _setAutoId()
        {
            DataTable data = customerDataObj.CountData();
            int size = data.Rows.Count;
            if (size == 0)
            {
                txtId.Text = "C_000001";
            }
            else
            {
                txtId.Text = General.autoIncrementID(data.Rows[size - 1][0].ToString(), "C");
            }
        }

        // Setter of all attributes to CustomerControl
        private void _setterCustomerControl()
        {
            customerControl.id = txtId.Text;
            customerControl.name = txtName.Text;
            customerControl.userName = txtUserName.Text;
            customerControl.password = txtPassword.Text;
            customerControl.phone = txtPhoneNumber.Text;
            customerControl.address = txtAddress.Text;
            if (picCustomer.Image != null)
            {
                customerControl.photo = customerControl.customerStorageLocation;
            }
            else
            {
                customerControl.photo = null;
            }
            if (rdoMale.Checked)
            {
                customerControl.gender = rdoMale.Text;
            }
            else if (rdoFemale.Checked)
            {
                customerControl.gender = rdoFemale.Text;
            }
            else
            {
                customerControl.gender = "";
            }
        }

        // Add of all attributes to CustomerControl
        public void addDataToCustomerControl(String id, String name, String userName, String password, String address, String phone, String gender, String image)
        {
            txtId.Text = id;
            txtName.Text = name;
            txtUserName.Text = userName;
            txtPassword.Text = password;
            txtPhoneNumber.Text = phone;
            txtAddress.Text = address;

            try
            {
                if (image != "Null")
                {
                    picCustomer.Image = Image.FromFile(image);
                }
                else
                {
                    picCustomer.Image = null;
                }
            }
            catch (Exception Update)
            {
                picCustomer.Image = null;
                MessageBox.Show("Invalid image path", "Admin Update");
            }
            
            if (gender == "Male")
            {
                rdoMale.Checked = true;
            }
            else
            {
                rdoFemale.Checked = true;
            }
        }

        // Validation Message Box
        private void _validationMessageBox(String message)
        {
            MessageBox.Show(message, "Customer Form Validation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }


        // Validation Form of Customer
        private bool _validateForm()
        {
            if (customerControl.id == "")
            {
                _validationMessageBox("You need customer Id to continue");
                return false;
            }
            else if (customerControl.name == "")
            {
                _validationMessageBox("Please enter customer name");
                txtName.Focus();
                return false;
            }
            else if (customerControl.userName == "")
            {
                _validationMessageBox("Please enter customer user name");
                txtUserName.Focus();
                return false;
            }
            else if (customerControl.password == "")
            {
                _validationMessageBox("Please enter password for account");
                txtPassword.Focus();
                return false;
            }
            else if (customerControl.password.Length > 16 || customerControl.password.Length < 8 || !customerControl.password.Any(char.IsUpper) || !customerControl.password.Any(char.IsLower))
            {
                _validationMessageBox("Please enter password containing at least 1 lowercase, 1 uppercase and between the length of 8 and 16");
                txtPassword.Focus();
                return false;
            }
            else if (customerControl.phone == "")
            {
                _validationMessageBox("Please enter customer phone");
                txtPhoneNumber.Focus();
                return false;
            }
            
            else if (customerControl.address == "")
            {
                _validationMessageBox("Please enter customer address");
                txtAddress.Focus();
                return false;
            }
            else if (!customerControl.phone.All(char.IsDigit) || customerControl.phone.Length < 7 || customerControl.phone.Length > 15)
            {
                _validationMessageBox("Please enter valid phone number");
                txtPhoneNumber.Focus();
                return false;
            }
            else if (customerControl.gender == "")
            {
                _validationMessageBox("Please choose your gender");
                return false;
            }
            else if (customerControl.photo == null)
            {
                _validationMessageBox("Please choose photo");
                return false;
            }
            else
            {
                return true;
            }
        }

        // -------------------------------  Form Actions of Customer --------------------

        private void btnClear_Click(object sender, EventArgs e)
        {
            // 1.   Clear Customer information form
            _clearInformationText();

            if (!_update)
            {
                // 2.   When in update situation, replace Customer id in the place of update id
                _setAutoId();

                //3.    Change button visibility and enable
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSave.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1.   Use encapsulation of Customer
            _setterCustomerControl();

            // 2.   check validation form
            bool validate = _validateForm();

            // 3.   if success, store data in database, refresh data table, clear form and set auto id
            if (validate)
            {
                customerDataObj.Insert(customerControl.id, customerControl.name, customerControl.userName, customerControl.password, customerControl.address, customerControl.phone, customerControl.gender, customerControl.photo);
                if (customerControl.photo != null)
                {
                    picCustomer.Image.Save(customerControl.photo);
                }
                _clearInformationText();
                _setAutoId();

                if (!_showLoginLink)
                {
                    CustomerList.refreshDataTable();
                }
                MessageBox.Show("Register successfully");
                _backCallback();
            }

            // 4.   Close this window
            //this.Hide();
        }


        private void picCustomer_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "(*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                picCustomer.Image = Image.FromFile(open.FileName);
            }
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CustomerLoginForm loginForm = new CustomerLoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
            _backCallback();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // 1.   Use encapsulation of Customer
            _setterCustomerControl();

            // 2.   check validation form
            bool validate = _validateForm();

            // 3.   if success, store data in database, refresh data table, clear form and set auto id
            if (validate)
            {
                customerDataObj.UpdateQuery( customerControl.name, customerControl.userName, customerControl.password, customerControl.address, customerControl.phone, customerControl.gender, customerControl.photo,customerControl.id);
                if (customerControl.photo != null)
                {
                    picCustomer.Image.Save(customerControl.photo);
                }
                MessageBox.Show("Admin update successfully");
                _clearInformationText();
                _setAutoId();

                if (!_showLoginLink)
                {
                    CustomerList.refreshDataTable();
                }
                
                _backCallback();
            }
        }

    }
}
