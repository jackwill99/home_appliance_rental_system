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
    public partial class ApplianceTypeList : Form
    {
        public ApplianceTypeList()
        {
            InitializeComponent();
            _dgvApplianceType = dgvApplianceType;
            refreshDataTable();
            btndelete = btnDelete;
            btnupdate = btnUpdate;
        }

        // ------------------------------- Appliance type list Attributes --------------------
        static HomeApplianceTableAdapters.applianceTypeTableAdapter applianceTypeDataObj = new HomeApplianceTableAdapters.applianceTypeTableAdapter();
        static DataTable dataTable = new DataTable();
        static DataGridView _dgvApplianceType;

        public Button btnupdate;
        public Button btndelete;

        // selected appliance
        DataRow applianceRow;

        // -------------------------------  General Methods of Admin --------------------

        // Refresh the data source of admin
        public static void refreshDataTable()
        {
            dataTable = applianceTypeDataObj.GetData();
            _dgvApplianceType.DataSource = dataTable;
            _columnHidden();
            _dgvApplianceType.Refresh();
        }


        // remove the table colums un-necessary
        private static void _columnHidden()
        {
            _dgvApplianceType.AutoGenerateColumns = false;
            if (_dgvApplianceType.Columns.Contains("ApplianceTypeId"))
            {
                _dgvApplianceType.Columns.Remove("ApplianceTypeId");
            };
        }

        // -------------------------------  Form Actions of Admin --------------------

        private void btnClear_Click(object sender, EventArgs e)
        {
            refreshDataTable();
            txtType.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            dataTable = applianceTypeDataObj.Search(txtType.Text);
            _dgvApplianceType.DataSource = dataTable;
            _dgvApplianceType.Refresh();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ApplianceTypeForm _appTypeForm = new ApplianceTypeForm(() =>
            {
                ApplianceTypeList applianceTypeList = HomePage.setApplianceTypeListPage();
                HomePage.panelPage.Controls.Clear();
                HomePage.panelPage.Controls.Add(applianceTypeList);
                applianceTypeList.Show();
            }) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, };
            _appTypeForm.FormBorderStyle = FormBorderStyle.None;

            HomePage.panelPage.Controls.Clear();
            HomePage.panelPage.Controls.Add(_appTypeForm);
            _appTypeForm.Show();
        }

        private void dgvApplianceType_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (General.checkDgvCellClick(e, dgvApplianceType))
            {
                applianceRow = dataTable.Rows[e.RowIndex];
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
            }
            else {
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ApplianceTypeForm _appTypeForm = new ApplianceTypeForm(() =>
            {
                ApplianceTypeList applianceTypeList = HomePage.setApplianceTypeListPage();
                HomePage.panelPage.Controls.Clear();
                HomePage.panelPage.Controls.Add(applianceTypeList);
                applianceTypeList.Show();
            },true) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, };
            _appTypeForm.FormBorderStyle = FormBorderStyle.None;

            HomePage.panelPage.Controls.Clear();
            HomePage.panelPage.Controls.Add(_appTypeForm);
            _appTypeForm.Show();
            _appTypeForm.addDataToApplianceTypeControl(applianceRow[0].ToString(), applianceRow[1].ToString().Trim());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            applianceTypeDataObj.DeleteApplianceType(applianceRow[0].ToString());
            refreshDataTable();
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
        }

    }
}
