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
    public partial class RentList : Form
    {
        public RentList()
        {
            InitializeComponent();
            _dgvRentList = dgvRentList;

            refreshDataTable();
            if (CustomerControl.isCustomer)
            {
                txtCustomerId.Text = CustomerControl.userInfo.id;
                txtCustomerId.Enabled = false;
            }
        }

        //  ------------------------    rent list attributes    -----------------------
        static HomeApplianceTableAdapters.rentAppliancesViewTableAdapter rentApplianceDataObj = new HomeApplianceTableAdapters.rentAppliancesViewTableAdapter();
        static DataTable dataTable = new DataTable();
        static DataGridView _dgvRentList;

        //  --------------------------- general methods     ----------------------

        // Refresh the data source of customer
        public static void refreshDataTable()
        {
            dataTable = CustomerControl.isCustomer ? rentApplianceDataObj.GetDataByCustomer(CustomerControl.userInfo.id) : rentApplianceDataObj.GetData();
            _dgvRentList.DataSource = dataTable;
            _dgvRentList.Refresh();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtRentId.Text != "" && txtCustomerId.Text != "")
            {
                dataTable = rentApplianceDataObj.Search(txtRentId.Text, txtCustomerId.Text);
            }
            else if (txtRentId.Text == "" && txtCustomerId.Text == "")
            {
                
                dataTable = CustomerControl.isCustomer ? rentApplianceDataObj.GetDataByCustomer(CustomerControl.userInfo.id) : rentApplianceDataObj.GetData();
            }
            else
            {
                dataTable = rentApplianceDataObj.SearchOr(txtRentId.Text, txtCustomerId.Text);
            }
            
            _dgvRentList.DataSource = dataTable;
            _dgvRentList.Refresh();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCustomerId.Clear();
            txtRentId.Clear();
            dataTable = rentApplianceDataObj.GetData();
            _dgvRentList.DataSource = dataTable;
            _dgvRentList.Refresh();
        }

        private void dgvRentList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (General.checkDgvCellClick(e, _dgvRentList))
            {
                RentListDetail _form = new RentListDetail(() =>
                {
                    RentList rentList = HomePage.setRentListPage();
                    HomePage.panelPage.Controls.Clear();
                    HomePage.panelPage.Controls.Add(rentList);
                    rentList.Show();
                }, _dgvRentList.Rows[e.RowIndex].Cells[0].Value.ToString()) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, };
                _form.FormBorderStyle = FormBorderStyle.None;

                HomePage.panelPage.Controls.Clear();
                HomePage.panelPage.Controls.Add(_form);
                _form.Show();
            }
            
        }
    }
}
