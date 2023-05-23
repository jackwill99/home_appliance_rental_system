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
    public partial class ApplianceList : Form
    {
        public ApplianceList(DataTable rentApplianceDataTable,bool isRentService = false )
        {
            InitializeComponent();
            _setApplianceType();
            _dgvApplianceList = dgvApplianceList;
            refreshDataTable();

            // only access for admin
            btnAdd.Visible = CustomerControl.isCustomer ? false : true;

            _isRentService = isRentService;
            _rentApplianceDataTable = rentApplianceDataTable;
            if (isRentService)
            {
                btnAdd.Visible = false; 
            }
        }

        //  --------------------------- Appliance Attributes    ----------------------
        static HomeApplianceTableAdapters.appliancesTableAdapter applianceDataObj = new HomeApplianceTableAdapters.appliancesTableAdapter();
        static HomeApplianceTableAdapters.applianceTypeTableAdapter applianceTypeDataObj = new HomeApplianceTableAdapters.applianceTypeTableAdapter();
        static DataTable applianceTypeDataTable = applianceTypeDataObj.GetQuery();
        static DataTable applianceDataTable = new DataTable();
        static DataGridView _dgvApplianceList;

        // about rent service
        bool _isRentService;
        DataTable _rentApplianceDataTable;
        public RentServiceInputValue rentServiceInput;

        // selected appliance
        DataGridViewRow applianceRow;


        //  --------------------------- General Methods -------------------------

        // set the appliance type in combo box
        private void _setApplianceType()
        {
            cboType.Items.Add("Choose Appliance Type");
            for (int i = 0; i < applianceTypeDataTable.Rows.Count; i++)
            {
                cboType.Items.Add(applianceTypeDataTable.Rows[i][1].ToString().Trim());
            }
            cboType.SelectedIndex = 0;
        }

        // change appliance type index to id
        private string _getApplianceTypeId(int index)
        {
            try
            {
                return applianceTypeDataTable.Rows[index][0].ToString();
            }
            catch (Exception)
            {
                
                return "";
            }
        }

        // modify data table with foreign key
        private static DataTable _dataTableForeignKey(DataTable dataTable)
        {
            applianceTypeDataTable = applianceTypeDataObj.GetQuery();
            dataTable.Columns.Add(new DataColumn("applianceType", typeof(string)));
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                var typeRow = applianceTypeDataTable.Rows.Find(dataTable.Rows[i][9]);
                
                dataTable.Rows[i][dataTable.Columns.Count - 1] = typeRow[1];
                
            }
            return dataTable;
        }

        // Refresh the data source
        public void refreshDataTable()
        {

            btnDelete.Visible = false;
            btnUpdate.Visible = false;


            applianceDataTable = applianceDataObj.GetData();
            _dgvApplianceList.DataSource = _dataTableForeignKey(applianceDataTable);
            _columnHidden();
            _dgvApplianceList.EndEdit();
            _dgvApplianceList.Refresh();
        }

        // remove the table colums un-necessary
        private static void _columnHidden()
        {
            _dgvApplianceList.AutoGenerateColumns = false;
            
            if (_dgvApplianceList.Columns.Contains("adminId"))
            {
                _dgvApplianceList.Columns.Remove("adminId");
            }
            if (_dgvApplianceList.Columns.Contains("status"))
            {
                _dgvApplianceList.Columns.Remove("status");
            }
            
             if (_dgvApplianceList.Columns.Contains("applianceTypeId"))
            {
                _dgvApplianceList.Columns.Remove("applianceTypeId");
            };
            
        }


        // ----------------------   rent service appliance section  -----------------
        private void _rentServiceAppliance(DataGridViewCellMouseEventArgs e)
        {
            if (General.checkDgvCellClick(e, dgvApplianceList))
            {
                rentServiceInput = null;
                var input = new RentServiceInputBox();
                input.ShowDialog();

                if (rentServiceInput != null)
                {
                    Console.WriteLine(rentServiceInput.count);
                    Console.Read();
                    if ((Convert.ToInt32(dgvApplianceList.Rows[e.RowIndex].Cells[10].Value) - Convert.ToInt32(rentServiceInput.count)) >= 0)
                    {
                        if (rentServiceInput != null)
                        {
                            _setRentAppliance(e);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Appliances are not available in " + rentServiceInput.count + " count");
                    }
                }
                
            }
        }

        private double _calTotalPrice(DataGridViewCellMouseEventArgs e)
        {
            // total price
            double totalPrice = 0;
            if (rentServiceInput.month == 12)
            {
                totalPrice += Convert.ToDouble(dgvApplianceList.Rows[e.RowIndex].Cells[5].Value) * Convert.ToInt32(rentServiceInput.count);
            }
            else
            {
                totalPrice += Convert.ToDouble(dgvApplianceList.Rows[e.RowIndex].Cells[6].Value) * Convert.ToInt32(rentServiceInput.count) * Convert.ToInt32(rentServiceInput.month);
            }
            return totalPrice;
        }

        private void _setRentAppliance(DataGridViewCellMouseEventArgs e)
        {
            string price = "totalPrice";
            string month = "month";
            string count = "count";
            
            // if there is no rows in rent appliance datatable, add columns headers
            if (_rentApplianceDataTable.Rows.Count == 0)
            {
                _rentApplianceDataTable.NewRow();

                for (int i = 0; i < dgvApplianceList.Columns.Count; i++)
                {
                    _rentApplianceDataTable.Columns.Add(dgvApplianceList.Columns[i].HeaderText);
                }
                _rentApplianceDataTable.Columns.Add(price);
                _rentApplianceDataTable.Columns.Add(month);
                _rentApplianceDataTable.Columns.Add(count);
                RentService.rentServiceAppliance.publicRefresh(_rentApplianceDataTable);
                RentService._rentServiceFinalCheck.publicRefresh(_rentApplianceDataTable);
            }
            var newRow = _rentApplianceDataTable.NewRow();
            for (int i = 0; i < dgvApplianceList.Columns.Count; i++)
            {
                newRow[dgvApplianceList.Columns[i].HeaderText] = dgvApplianceList.Rows[e.RowIndex].Cells[i].Value;
            }

            // set price to ui
            double unitTotalPrice = _calTotalPrice(e);
            double totalPrice = RentService.rentServiceControl.totalPrice + unitTotalPrice;
            RentService.rentServiceControl.totalPrice = totalPrice;
            
            RentService.rentServiceAppliance.setTotalPrice(totalPrice);
            RentService._rentServiceFinalCheck.setPrice(totalPrice);

            // insert new columns in row 
            newRow[price] = unitTotalPrice;
            newRow[month] = rentServiceInput.month;
            newRow[count] = rentServiceInput.count;

            _rentApplianceDataTable.Rows.Add(newRow);
            RentService.rentServiceAppliance.publicRefresh(_rentApplianceDataTable);
            RentService._rentServiceFinalCheck.publicRefresh(_rentApplianceDataTable);
            
            // show successfully message 
            MessageBox.Show("Your choosen appliance is successfully", "Rent Service",MessageBoxButtons.OK,MessageBoxIcon.Information);
            RentList.refreshDataTable();
        }


        //  ---------------------------- form actions   ---------------------------

        private void btnClear_Click(object sender, EventArgs e)
        {
            refreshDataTable();
            txtName.Clear();
            cboType.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            applianceDataTable = cboType.SelectedIndex != 0 ? applianceDataObj.Search(txtName.Text, _getApplianceTypeId(cboType.SelectedIndex - 1)) : applianceDataObj.SearchName(txtName.Text);
            _dgvApplianceList.DataSource = _dataTableForeignKey(applianceDataTable);
            _dgvApplianceList.Refresh();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ApplianceForm form = new ApplianceForm(() =>
            {
                ApplianceList applianceList = HomePage.setApplianceListPage();
                HomePage.panelPage.Controls.Clear();
                HomePage.panelPage.Controls.Add(applianceList);
                applianceList.Show();
            }) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, };
            form.FormBorderStyle = FormBorderStyle.None;

            HomePage.panelPage.Controls.Clear();
            HomePage.panelPage.Controls.Add(form);
            form.Show();
        }

        private void dgvApplianceList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_isRentService)
            {
                _rentServiceAppliance(e);
            }
            else
            {
                if (General.checkDgvCellClick(e, dgvApplianceList))
                {
                    applianceRow = dgvApplianceList.Rows[e.RowIndex];
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            applianceDataObj.DeleteAppliance(applianceRow.Cells[0].Value.ToString());
            refreshDataTable();
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ApplianceForm form = new ApplianceForm(() =>
            {
                ApplianceList applianceList = HomePage.setApplianceListPage();
                HomePage.panelPage.Controls.Clear();
                HomePage.panelPage.Controls.Add(applianceList);
                applianceList.Show();
            },true) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, };
            form.FormBorderStyle = FormBorderStyle.None;

            HomePage.panelPage.Controls.Clear();
            HomePage.panelPage.Controls.Add(form);
            form.Show();
            DataGridViewCellCollection cells = applianceRow.Cells;
            form.addDataToApplianceControl(cells[0].Value.ToString().Trim(), cells[1].Value.ToString().Trim(), cells[2].Value.ToString().Trim(), cells[3].Value.ToString().Trim(), cells[4].Value.ToString().Trim(), cells[5].Value.ToString().Trim(), cells[6].Value.ToString().Trim(), cells[7].Value.ToString().Trim(), cells[8].Value.ToString().Trim(), cells[9].Value.ToString().Trim(), cells[10].Value.ToString().Trim(), cells[11].Value.ToString().Trim(), cells[12].Value.ToString().Trim(), cells[13].Value.ToString().Trim());
        }

        

    }
}
