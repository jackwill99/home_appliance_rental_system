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
    public partial class AdminList : Form
    {
        public AdminList()
        {
            InitializeComponent();
            _dgvAdmin = dgvAdmin;
            refreshDataTable();
        }

        // ------------------------------- Admin Attributes --------------------
        static HomeApplianceTableAdapters.adminTableAdapter adminDataObj = new HomeApplianceTableAdapters.adminTableAdapter();
        static DataTable dataTable = new DataTable();
        static DataGridView _dgvAdmin;

        // selected admin id
        public static DataRow adminRow;


        // -------------------------------  General Methods of Admin --------------------

        // Refresh the data source of admin
        public static void refreshDataTable()
        {
            dataTable = adminDataObj.GetData();
            _dgvAdmin.DataSource = dataTable;
            _columnHidden();
            _dgvAdmin.Refresh();
        }


        // remove the table colums un-necessary
        private static void _columnHidden()
        {
            _dgvAdmin.AutoGenerateColumns = false;
            if (_dgvAdmin.Columns.Contains("AdminId"))
            {
                _dgvAdmin.Columns.Remove("AdminId");
            };
        }

        // -------------------------------  Form Actions of Admin --------------------

        private void btnClear_Click(object sender, EventArgs e)
        {
            refreshDataTable();
            txtSearchPhone.Clear();
            txtSearchName.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            dataTable = adminDataObj.Search(txtSearchName.Text, txtSearchPhone.Text);
            _dgvAdmin.DataSource = dataTable;
            _dgvAdmin.Refresh();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AdminRegisterForm _regForm = new AdminRegisterForm(() =>
            {
                AdminList adminList = HomePage.setAdminListPage();
                HomePage.panelPage.Controls.Clear();
                HomePage.panelPage.Controls.Add(adminList);
                adminList.Show();
            }) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, };
            _regForm.FormBorderStyle = FormBorderStyle.None;

            HomePage.panelPage.Controls.Clear();
            HomePage.panelPage.Controls.Add(_regForm);
            _regForm.Show();
        }

        private void dgvAdmin_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (General.checkDgvCellClick(e, dgvAdmin))
            {
                adminRow = dataTable.Rows[e.RowIndex];
                if (adminRow[0].ToString().Trim() == AdminControl.userInfo.id.Trim())
                {
                    btnDelete.Visible = false;
                    btnUpdate.Visible = true;
                    return;
                }
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
            }
            else
            {
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            adminDataObj.DeleteAdmin(adminRow[0].ToString().Trim());
            refreshDataTable();
            btnDelete.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            AdminRegisterForm _regForm = new AdminRegisterForm(() =>
            {
                AdminList adminList = HomePage.setAdminListPage();
                HomePage.panelPage.Controls.Clear();
                HomePage.panelPage.Controls.Add(adminList);
                adminList.Show();
            },false,true) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, };
            _regForm.FormBorderStyle = FormBorderStyle.None;

            HomePage.panelPage.Controls.Clear();
            HomePage.panelPage.Controls.Add(_regForm);
            _regForm.Show();
            _regForm.addDataToAdminControl(adminRow[0].ToString().Trim(), adminRow[1].ToString().Trim(), adminRow[2].ToString().Trim(), adminRow[3].ToString().Trim(), adminRow[4].ToString().Trim(), adminRow[5].ToString().Trim(), adminRow[6].ToString().Trim(), adminRow[7].ToString().Trim());
        }


    }
}
