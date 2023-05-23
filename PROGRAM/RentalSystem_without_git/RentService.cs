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
    public partial class RentService : Form
    {
        public RentService()
        {
            InitializeComponent();
            if (CustomerControl.isCustomer)
            {
                btnRent.Location = btnChooseUser.Location;
                divider3.Visible = false;
                btnChooseUser.Visible = false;
                rentServiceControl.userId = CustomerControl.userInfo.id;
                rentServiceControl.userName = CustomerControl.userInfo.name;
            }
            

        }

        //  --------------------- rent service attributes   ----------------------
        public static ApplianceList _applianceList;
        public static RentServiceAppliance rentServiceAppliance;
        public static CustomerList _customerList;
        public static RentServiceFinalCheck _rentServiceFinalCheck;

        DataTable rentApplianceDataTable = new DataTable();
        public static RentServiceControl rentServiceControl = new RentServiceControl();

        

        //  ------------------- general methods -------------------

        // restart panel and configuration
        public void setupPanelAndConfig()
        {
            _setupPanelPages();
            _stepOne();
            rentApplianceDataTable = new DataTable();

            if (!CustomerControl.isCustomer)
            {
                RentService.rentServiceControl.userId = null;
                RentService.rentServiceControl.userName = null;
            }
            RentService.rentServiceControl.totalPrice = 0;
            rentServiceAppliance._lblPrice.Text = 0.ToString();
        }

        private void _stepOne()
        {
            btnChooseAppliance.ImageIndex = 1;
            divider1.BackColor = Color.ForestGreen;

            btnRentAppliance.ImageIndex = 0;
            divider2.BackColor = Color.Silver;
            btnChooseUser.ImageIndex = 0;
            divider3.BackColor = Color.Silver;
            btnRent.ImageIndex = 0;

            panelPage.Controls.Clear();
            panelPage.Controls.Add(_applianceList);
            _applianceList.Show();
        }

        private void _stepTwo()
        {
            btnChooseAppliance.ImageIndex = 2;
            divider1.BackColor = Color.ForestGreen;

            btnRentAppliance.ImageIndex = 1;
            divider2.BackColor = Color.ForestGreen;

            btnChooseUser.ImageIndex = 0;
            divider3.BackColor = Color.Silver;
            btnRent.ImageIndex = 0;

            panelPage.Controls.Clear();
            panelPage.Controls.Add(rentServiceAppliance);
            rentServiceAppliance.Show();
        }

        private void _stepThree()
        {
            btnChooseAppliance.ImageIndex = 2;
            divider1.BackColor = Color.ForestGreen;
            btnRentAppliance.ImageIndex = 2;
            divider2.BackColor = Color.ForestGreen;

            btnChooseUser.ImageIndex = 1;
            divider3.BackColor = Color.ForestGreen;

            btnRent.ImageIndex = 0;

            panelPage.Controls.Clear();
            panelPage.Controls.Add(_customerList);
            _customerList.Show();

        }

        private void _stepFour()
        {
            btnChooseAppliance.ImageIndex = 2;
            divider1.BackColor = Color.ForestGreen;
            btnRentAppliance.ImageIndex = 2;
            divider2.BackColor = Color.ForestGreen;

            btnChooseUser.ImageIndex = 2;
            divider3.BackColor = Color.ForestGreen;

            btnRent.ImageIndex = 1;

            panelPage.Controls.Clear();
            panelPage.Controls.Add(_rentServiceFinalCheck);
            _rentServiceFinalCheck.Show();
        }

        // setup panel pages
        private void _setupPanelPages()
        {
             setApplianceList();
            setRentServiceAppliance();
            setCustomerList();
            setRentServiceFinalCheck();
        }

        public ApplianceList setApplianceList()
        {
            _applianceList = new ApplianceList(rentApplianceDataTable, true) { Dock = DockStyle.Fill, TopLevel = false, TopMost = false, AutoScroll = true, };
            _applianceList.FormBorderStyle = FormBorderStyle.None;
            return _applianceList;
        }

        public  RentServiceAppliance setRentServiceAppliance()
        {
            rentServiceAppliance = new RentServiceAppliance(rentApplianceDataTable) { Dock = DockStyle.Fill, TopLevel = false, TopMost = false, AutoScroll = true, };
            rentServiceAppliance.FormBorderStyle = FormBorderStyle.None;
            return rentServiceAppliance;
        }

        public CustomerList setCustomerList()
        {
            _customerList = new CustomerList(true) { Dock = DockStyle.Fill, TopLevel = false, TopMost = false, AutoScroll = true, };
            _customerList.FormBorderStyle = FormBorderStyle.None;
            return _customerList;
        }

        public RentServiceFinalCheck setRentServiceFinalCheck()
        {
            _rentServiceFinalCheck = new RentServiceFinalCheck(rentApplianceDataTable) { Dock = DockStyle.Fill, TopLevel = false, TopMost = false, AutoScroll = true, };
            _rentServiceFinalCheck.FormBorderStyle = FormBorderStyle.None;
            if (CustomerControl.isCustomer)
            {
                _rentServiceFinalCheck.setGroupBox(0.0, rentServiceControl.userName, rentServiceControl.userId);
            }
            
            return _rentServiceFinalCheck;
        }

        //  ------------------- form action --------------------
        private void btnChooseAppliance_Click(object sender, EventArgs e)
        {
            _stepOne();
        }

        private void btnRentAppliance_Click(object sender, EventArgs e)
        {
            _stepTwo();
        }

        private void btnChooseUser_Click(object sender, EventArgs e)
        {
            if (rentServiceControl.totalPrice == 0)
            {
                MessageBox.Show("You have no appliances to rent. Choose appliances to continue!", "Rent Service");
            }
            else {
                _stepThree();
            }
            
        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            if (CustomerControl.isCustomer)
            {
                if (rentServiceControl.totalPrice == 0)
                {
                    MessageBox.Show("You have no appliances to rent. Choose appliances to continue!", "Rent Service");
                    return;
                }
            }
            if (rentServiceControl.userId == null || rentServiceControl.userName == null)
            {
                MessageBox.Show("You have no customer to rent. Choose user to continue!", "Rent Service");
            }
            else
            {
                _stepFour();
            }
        }
    }
}
