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
    public partial class RentServiceFinalCheck : Form
    {
        public RentServiceFinalCheck(DataTable rentApplianceDataTable)
        {
            InitializeComponent();
            dgvRentAppliance = dgvRentApplianceList;
            _rentApplianceDataTable = rentApplianceDataTable;
            _setAutoId();
        }

        // ------------------------ rent service appliance attributes   ---------------------------
        static HomeApplianceTableAdapters.rentAppliancesTableAdapter rentApplianceDataObj = new HomeApplianceTableAdapters.rentAppliancesTableAdapter();
        static HomeApplianceTableAdapters.appliancesTableAdapter applianceDataObj = new HomeApplianceTableAdapters.appliancesTableAdapter();
        static HomeApplianceTableAdapters.rentTableAdapter rentDataObj = new HomeApplianceTableAdapters.rentTableAdapter();
        public DataGridView dgvRentAppliance;
        DataTable _rentApplianceDataTable;

        public void publicRefresh(DataTable table)
        {
            dgvRentAppliance.DataSource = table;
            _columnHidden();
            dgvRentAppliance.Refresh();
        }


        public void setGroupBox(double price,string userName, string userId)
        {
            gpId.Text = userId;
            gpName.Text = userName;
            gpPrice.Text = price.ToString();
        }


        public void setPrice(double price)
        {
            gpPrice.Text = price.ToString();
        }

        // remove the table colums un-necessary
        private void _columnHidden()
        {
            dgvRentAppliance.AutoGenerateColumns = false;

            if (dgvRentAppliance.Columns.Contains("quantity"))
            {
                dgvRentAppliance.Columns.Remove("quantity");
            }
            if (dgvRentAppliance.Columns.Contains("available"))
            {
                dgvRentAppliance.Columns.Remove("available");
            }


        }

        // Set automation id of Customer
        private void _setAutoId()
        {
            DataTable data = rentDataObj.GetData();
            int size = data.Rows.Count;
            if (size == 0)
            {
                gpRentId.Text = "R_000001";
            }
            else
            {
                gpRentId.Text = General.autoIncrementID(data.Rows[size - 1][0].ToString(), "R");
            }
        }


        //  --------------------    rent form actions   -------------------------

        private void btnRent_Click(object sender, EventArgs e)
        {
            rentDataObj.Insert(gpRentId.Text,gpId.Text,DateTime.Now,RentService.rentServiceControl.totalPrice,"Rent");
            for (int i = 0; i < dgvRentAppliance.Rows.Count - 1; i++)
            {
                string id = dgvRentAppliance.Rows[i].Cells[0].Value.ToString();
                int month = Convert.ToInt32(dgvRentAppliance.Rows[i].Cells[13].Value);
                int count = Convert.ToInt32(dgvRentAppliance.Rows[i].Cells[14].Value);
                double unitPrice = Convert.ToDouble(dgvRentAppliance.Rows[i].Cells[5].Value);
                double unitAnnualPrice = Convert.ToDouble(dgvRentAppliance.Rows[i].Cells[6].Value);
                double totalPrice = Convert.ToDouble(dgvRentAppliance.Rows[i].Cells[12].Value);
                rentApplianceDataObj.Insert(gpRentId.Text,id,month,unitPrice,unitAnnualPrice,totalPrice,count);
                applianceDataObj.UpdateAvailable(count,id);
            }
            MessageBox.Show("Your appliances are rent successfully!", "Rent Service");
            
            // go to start
            HomePage._rentService.setupPanelAndConfig();

            // update the data table
            RentList.refreshDataTable();
            HomePage.setApplianceListPage();
        }

    }
}
