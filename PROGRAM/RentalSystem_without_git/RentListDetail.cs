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
    public partial class RentListDetail : Form
    {
        public RentListDetail(Action backCallback, string id)
        {
            InitializeComponent();
            _backCallback = backCallback;
            _id = id;
            refreshDataTable();
        }

        //  ----------------- rent list detail attributes   -----------------
        private Action _backCallback;
        private string _id;
        static HomeApplianceTableAdapters.rentAppliancesDetailViewTableAdapter rentApplianceDetailDataObj = new HomeApplianceTableAdapters.rentAppliancesDetailViewTableAdapter();
        static DataTable dataTable = new DataTable();


        //  ------------------- general methods -----------------

        // Refresh the data source of customer
        public void refreshDataTable()
        {
            
            dataTable = rentApplianceDetailDataObj.GetDataDetail(_id);

            dgvRentListDetail.DataSource = dataTable;
            dgvRentListDetail.Refresh();
        }

        //  ----------------- form actions  -------------------

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
            _backCallback();
        }

        
    }
}
