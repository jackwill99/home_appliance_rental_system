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
    public partial class CustomerList : Form
    {
        public CustomerList(bool isRentService = false)
        {
            InitializeComponent();
            _dgvCustomer = dgvCustomer;
            refreshDataTable();
            _isRentService = isRentService;
            if (isRentService)
            {
                btnAdd.Visible = false;
            }
            else
            {
                lblCustomer.Visible = false;
                lblCustomerTitle.Visible = false;
            }
        }

        // ------------------------------- Customer Attributes --------------------
        static HomeApplianceTableAdapters.customerTableAdapter customerDataObj = new HomeApplianceTableAdapters.customerTableAdapter();
        static DataTable dataTable = new DataTable();
        static DataGridView _dgvCustomer;
        bool _isRentService;

        // selected customer 
        public static DataRow customerRow;


        // -------------------------------  General Methods of Customer --------------------

        // Refresh the data source of customer
        public static void refreshDataTable()
        {
            dataTable = customerDataObj.GetData();
            _dgvCustomer.DataSource = dataTable;
            _columnHidden();
            _dgvCustomer.Refresh();
        }

        // remove the table colums un-necessary
        private static void _columnHidden()
        {
            _dgvCustomer.AutoGenerateColumns = false;
            if (_dgvCustomer.Columns.Contains("CustomerId"))
            {
                _dgvCustomer.Columns.Remove("CustomerId");
            };
        }

        // -------------------------------  Form Actions of Customer --------------------

        private void btnClear_Click(object sender, EventArgs e)
        {
            refreshDataTable();
            txtSearchPhone.Clear();
            txtSearchName.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            dataTable = customerDataObj.Search(txtSearchName.Text, txtSearchPhone.Text);
            _dgvCustomer.DataSource = dataTable;
            _dgvCustomer.Refresh();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CustomerRegisterForm _regForm = new CustomerRegisterForm(() =>
            {
                CustomerList customerList = HomePage.setCustomerListPage();
                HomePage.panelPage.Controls.Clear();
                HomePage.panelPage.Controls.Add(customerList);
                customerList.Show();
            }) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, };
            _regForm.FormBorderStyle = FormBorderStyle.None;

            HomePage.panelPage.Controls.Clear();
            HomePage.panelPage.Controls.Add(_regForm);
            _regForm.Show();
        }

        private void dgvCustomer_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_isRentService)
            {
                if (General.checkDgvCellClick(e, dgvCustomer))
                {
                    lblCustomer.Text = dataTable.Rows[e.RowIndex][1].ToString();
                    RentService.rentServiceControl.userId = dataTable.Rows[e.RowIndex][0].ToString();
                    RentService.rentServiceControl.userName = dataTable.Rows[e.RowIndex][1].ToString();
                    RentService._rentServiceFinalCheck.setGroupBox(RentService.rentServiceControl.totalPrice, dataTable.Rows[e.RowIndex][1].ToString(), dataTable.Rows[e.RowIndex][0].ToString());
                }
            }
            else {
                if (General.checkDgvCellClick(e, dgvCustomer))
                {
                    customerRow = dataTable.Rows[e.RowIndex];
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                }
                else
                {
                    btnDelete.Visible = false;
                    btnUpdate.Visible = false;
                }
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CustomerRegisterForm _regForm = new CustomerRegisterForm(() =>
            {
                CustomerList customerList = HomePage.setCustomerListPage();
                HomePage.panelPage.Controls.Clear();
                HomePage.panelPage.Controls.Add(customerList);
                customerList.Show();
            },false,true) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, };
            _regForm.FormBorderStyle = FormBorderStyle.None;

            HomePage.panelPage.Controls.Clear();
            HomePage.panelPage.Controls.Add(_regForm);
            _regForm.Show();

            _regForm.addDataToCustomerControl(customerRow[0].ToString().Trim(), customerRow[1].ToString().Trim(), customerRow[2].ToString().Trim(), customerRow[3].ToString().Trim(), customerRow[4].ToString().Trim(), customerRow[5].ToString().Trim(), customerRow[6].ToString().Trim(), customerRow[7].ToString().Trim());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            customerDataObj.DeleteCustomer(customerRow[0].ToString().Trim());
            refreshDataTable();
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
        }

       
    }
}
