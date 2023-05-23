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
    public partial class AdminRegisterForm : Form
    {
        public AdminRegisterForm(Action backCallback, bool showLoginLink = false, bool update = false)
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
                btnSave.Enabled = false;
                btnUpdate.Visible = true;
            }
        }


        // ------------------------------- Admin Attributes --------------------
        HomeApplianceTableAdapters.adminTableAdapter adminDataObj = new HomeApplianceTableAdapters.adminTableAdapter();
        static AdminControl adminControl = new AdminControl();
        private Action _backCallback;
        private bool _showLoginLink;
        private bool _update;


        // -------------------------------  General Methods of Admin --------------------

        // Clear the admin information form
        private void _clearInformationText()
        {
            txtName.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            txtPhoneNumber.Clear();
            txtAddress.Clear();
            picAdmin.Image = null;
            rdoFemale.Checked = false;
            rdoMale.Checked = false;
        }

        // Set automation id of admin
        private void _setAutoId()
        {
            DataTable data = adminDataObj.CountData();
            int size = data.Rows.Count;
            if (size == 0)
            {
                txtId.Text = "A_000001";
            }
            else
            {
                txtId.Text = General.autoIncrementID(data.Rows[size - 1][0].ToString(), "A");
            }
        }

        // Setter of all attributes to AdminControl
        private void _setterAdminControl()
        {
            adminControl.id = txtId.Text;
            adminControl.name = txtName.Text;
            adminControl.userName = txtUserName.Text;
            adminControl.password = txtPassword.Text;
            adminControl.phone = txtPhoneNumber.Text;
            adminControl.address = txtAddress.Text;
            if (picAdmin.Image != null)
            {
                adminControl.photo = adminControl.adminStorageLocation;
            }
            else
            {
                adminControl.photo = null;
            }
            if (rdoMale.Checked)
            {
                adminControl.gender = rdoMale.Text;
            }
            else if (rdoFemale.Checked)
            {
                adminControl.gender = rdoFemale.Text;
            }
            else
            {
                adminControl.gender = "";
            }
        }

        // Add of all attributes to AdminControl
        public void addDataToAdminControl(String id, String name, String userName, String password, String address, String phone, String gender, String image)
        {
            txtId.Text = id;
            txtName.Text = name;
            txtUserName.Text = userName;
            txtPassword.Text = password;
            txtPhoneNumber.Text = phone;
            txtAddress.Text = address;

            try
            {
                if (image.ToLower() != "null")
                {
                    picAdmin.Image = Image.FromFile(image);
                }
                else
                {
                    picAdmin.Image = null;
                }
            }
            catch (Exception Update)
            {
                picAdmin.Image = null;
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
            MessageBox.Show(message, "Admin Form Validation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }


        // Validation Form of admin
        private bool _validateForm()
        {
            if (adminControl.id == "")
            {
                _validationMessageBox("You need admin Id to continue");
                return false;
            }
            else if (adminControl.name == "")
            {
                _validationMessageBox("Please enter admin name");
                txtName.Focus();
                return false;
            }
            else if (adminControl.userName == "")
            {
                _validationMessageBox("Please enter admin user name");
                txtUserName.Focus();
                return false;
            }
            else if (adminControl.password == "")
            {
                _validationMessageBox("Please enter password for account");
                txtPassword.Focus();
                return false;
            }
            else if (adminControl.password.Length > 16 || adminControl.password.Length < 8 || !adminControl.password.Any(char.IsUpper) || !adminControl.password.Any(char.IsLower))
            {
                _validationMessageBox("Please enter password containing at least 1 lowercase, 1 uppercase and between the length of 8 and 16");
                txtPassword.Focus();
                return false;
            }
            else if (adminControl.phone == "")
            {
                _validationMessageBox("Please enter admin phone");
                txtPhoneNumber.Focus();
                return false;
            }
            else if (!adminControl.phone.All(char.IsDigit) || adminControl.phone.Length < 7 || adminControl.phone.Length > 15)
            {
                _validationMessageBox("Please enter valid phone number");
                txtPhoneNumber.Focus();
                return false;
            }
            else if (adminControl.address == "")
            {
                _validationMessageBox("Please enter admin address");
                txtAddress.Focus();
                return false;
            }
            else if (adminControl.gender == "")
            {
                _validationMessageBox("Please choose your gender");
                return false;
            }
            else if (adminControl.photo == null)
            {
                _validationMessageBox("Please choose your photo");
                return false;
            }
            else
            {
                return true;
            }
        }

        // -------------------------------  Form Actions of Admin --------------------

        private void btnClear_Click(object sender, EventArgs e)
        {
            // 1.   Clear admin information form
            _clearInformationText();

            if (!_update)
            {
                // 2.   When in update situation, replace admin id in the place of update id
                _setAutoId();

                //3.    Change button visibility and enable
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSave.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1.   Use encapsulation of admin
            _setterAdminControl();

            // 2.   check validation form
            bool validate = _validateForm();

            // 3.   if success, store data in database, refresh data table, clear form and set auto id
            if (validate)
            {
                adminDataObj.Insert(adminControl.id, adminControl.name, adminControl.userName, adminControl.password, adminControl.address, adminControl.phone, adminControl.gender, adminControl.photo);
                if (adminControl.photo != null)
                {
                    picAdmin.Image.Save(adminControl.photo);
                }
                _clearInformationText();
                _setAutoId();

                if (!_showLoginLink)
                {
                    AdminList.refreshDataTable();
                }

                MessageBox.Show("Admin register successfully");

                _backCallback();
            }

            // 4.   Close this window
            //this.Hide();
        }


        private void picAdmin_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "(*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                picAdmin.Image = Image.FromFile(open.FileName);
            }
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AdminLoginForm loginForm = new AdminLoginForm();
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
            // 1.   Use encapsulation of admin
            _setterAdminControl();

            // 2.   check validation form
            bool validate = _validateForm();

            // 3.   if success, store data in database, refresh data table, clear form and set auto id
            if (validate)
            {
                adminDataObj.UpdateQuery( adminControl.name, adminControl.userName, adminControl.password, adminControl.address, adminControl.phone, adminControl.gender, adminControl.photo,adminControl.id);
                if (adminControl.photo != null)
                {
                    picAdmin.Image.Save(adminControl.photo);
                }
                _clearInformationText();
                _setAutoId();

                MessageBox.Show("Admin update successfully");
                if (AdminList.adminRow[0].ToString().Trim() == adminControl.id.Trim())
                {
                    HomePage.updateUserInfo(adminControl.name);
                }

                if (!_showLoginLink)
                {
                    _backCallback();
                    AdminList.refreshDataTable();
                    return;
                }

                
            }

            // 4.   Close this window
            
            //this.Hide();
        }



    }
}
