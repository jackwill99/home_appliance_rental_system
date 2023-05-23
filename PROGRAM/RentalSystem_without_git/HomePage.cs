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
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
            _setPanelPages();
            panelPage = panelPages;
            lblUserInfo.Text = CustomerControl.isCustomer ? CustomerControl.userInfo.name : AdminControl.userInfo.name;
            _startSetup();
            _lblUserInfo = lblUserInfo;
            if (CustomerControl.isCustomer)
            {
                btnAdminList.Visible = false;
                btnCustomerList.Visible = false;
                btnApplianceType.Visible = false;
            }
        }

        // ------------------------------- Home page Attributes --------------------

        // panel pages
        public static Panel panelPage;


        public static RentList _rentList;
        static AdminList _adminList;
        static CustomerList _customerList;
        static ApplianceTypeList _applianceTypeList;
        public static ApplianceList _applianceList;
        public static RentService _rentService;

        private static Label _lblUserInfo;

        // ------------------------------- General methods of home page --------------------

        public static void updateUserInfo(string value)
        {
            _lblUserInfo.Text = value;
        }

        // start and run first panel
        private void _startSetup()
        {
            panelPage.Controls.Add(_applianceList);
            _applianceList.Show();
            btnApplianceList.BackColor = Color.CadetBlue;
        }

        // set up all home pages panel form
        private void _setPanelPages()
        {
            setRentListPage();

            setAdminListPage();

            setCustomerListPage();

            setApplianceTypeListPage();

            setApplianceListPage();

            setRentServicePage();
        }

        public static RentList setRentListPage()
        {
            _rentList = new RentList() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, };
            _rentList.FormBorderStyle = FormBorderStyle.None;
            return _rentList;
        }

        public static AdminList setAdminListPage()
        {
            _adminList = new AdminList() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, };
            _adminList.FormBorderStyle = FormBorderStyle.None;
            return _adminList;
        }

        public static CustomerList setCustomerListPage()
        {
            _customerList = new CustomerList() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, };
            _customerList.FormBorderStyle = FormBorderStyle.None;
            return _customerList;
        }

        public static ApplianceTypeList setApplianceTypeListPage()
        {
            _applianceTypeList = new ApplianceTypeList() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, };
            _applianceTypeList.FormBorderStyle = FormBorderStyle.None;
            return _applianceTypeList;
        }

        public static ApplianceList setApplianceListPage()
        {
            _applianceList = new ApplianceList(null) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, };
            _applianceList.FormBorderStyle = FormBorderStyle.None;
            return _applianceList;
        }

        public static RentService setRentServicePage()
        {
            _rentService = new RentService() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, };
            _rentService.FormBorderStyle = FormBorderStyle.None;
            return _rentService;
        }

        // clear all the background color of side panel button
        private void _clearSidePanelColor()
        {
            btnAdminList.BackColor = Color.Transparent;
            btnRentList.BackColor = Color.Transparent;
            btnApplianceList.BackColor = Color.Transparent;
            btnCustomerList.BackColor = Color.Transparent;
            btnApplianceType.BackColor = Color.Transparent;
            btnRentService.BackColor = Color.Transparent;
        }

        // set the background color of clicked side panel button
        private void _setBackColor(object sender)
        {
            var button = (Button)sender;
            button.BackColor = Color.CadetBlue;
        }
        

        // ------------------------------- Form actions of home page --------------------


        private void btnRentList_Click(object sender, EventArgs e)
        {
            _clearSidePanelColor();
            _setBackColor(sender);

            panelPage.Controls.Clear();
            panelPage.Controls.Add(_rentList);
            _rentList.Show();
        }

        private void btnAdminList_Click(object sender, EventArgs e)
        {
            _clearSidePanelColor();
            _setBackColor(sender);

            panelPage.Controls.Clear();
            panelPage.Controls.Add(_adminList);
            _adminList.Show();
        }

        private void btnApplianceList_Click(object sender, EventArgs e)
        {
            _clearSidePanelColor();
            _setBackColor(sender);

            panelPage.Controls.Clear();
            panelPage.Controls.Add(_applianceList);
            _applianceList.Show();
            _applianceList.refreshDataTable();
        }

        private void btnRentService_Click(object sender, EventArgs e)
        {
            _clearSidePanelColor();
            _setBackColor(sender);

            panelPage.Controls.Clear();
            panelPage.Controls.Add(_rentService);
            _rentService.Show();

            _rentService.setupPanelAndConfig();
        }

        private void btnCustomerList_Click(object sender, EventArgs e)
        {
            _clearSidePanelColor();
            _setBackColor(sender);

            panelPage.Controls.Clear();
            panelPage.Controls.Add(_customerList);
            _customerList.Show();
        }

        private void btnApplianceType_Click(object sender, EventArgs e)
        {
            _clearSidePanelColor();
            _setBackColor(sender);

            panelPage.Controls.Clear();
            panelPage.Controls.Add(_applianceTypeList);
            _applianceTypeList.Show();

            _applianceTypeList.btndelete.Visible = false;
            _applianceTypeList.btnupdate.Visible = false;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (CustomerControl.isCustomer)
            {
                CustomerControl.isCustomer = false;
                CustomerControl.removeStoreData();
            }
            else {
                AdminControl.removeStoreData();
            }
            RentService.rentServiceControl.userName = null;
            RentService.rentServiceControl.userId = null;
            StartForm start = new StartForm();
            this.Hide();
            start.Show();
        }

        

        private void btnUserInfo_MouseHover(object sender, EventArgs e)
        {
            lblUserInfo.BackColor = Color.CadetBlue;
        }

        private void btnUserInfo_MouseLeave(object sender, EventArgs e)
        {
            lblUserInfo.BackColor = Color.LightBlue;
        }

        private void btnUserInfo_MouseEnter(object sender, EventArgs e)
        {
            lblUserInfo.BackColor = Color.CadetBlue;
        }

        private void lblUserInfo_MouseEnter(object sender, EventArgs e)
        {
            lblUserInfo.BackColor = Color.CadetBlue;
            btnUserInfo.BackColor = Color.CadetBlue;
        }

        private void lblUserInfo_MouseLeave(object sender, EventArgs e)
        {
            lblUserInfo.BackColor = Color.LightBlue;
            btnUserInfo.BackColor = Color.LightBlue;
        }

        



        
    }
}
