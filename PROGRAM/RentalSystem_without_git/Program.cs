using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var data = AdminControl.getStoreAdminData();
            var customerData = CustomerControl.getStoreCustomerData();
            if (data.Count > 0)
            {
                HomeApplianceTableAdapters.adminTableAdapter adminDataObj = new HomeApplianceTableAdapters.adminTableAdapter();
                DataTable dt = new DataTable();
                dt = adminDataObj.LogIn(data[0], data[1]);
                if (dt.Rows.Count == 1)
                {
                    AdminLoginForm.addDataToAdminUserInfo(dt);
                    Application.Run(new HomePage());

                }
                else {
                    Application.Run(new StartForm());

                }
            }
            else if (customerData.Count > 0)
            {
                HomeApplianceTableAdapters.customerTableAdapter customerDataObj = new HomeApplianceTableAdapters.customerTableAdapter();
                DataTable dt = new DataTable();
                dt = customerDataObj.LogIn(customerData[0], customerData[1]);
                if (dt.Rows.Count == 1)
                {
                    CustomerLoginForm.addDataToCustomerUserInfo(dt);
                    Application.Run(new HomePage());

                }
                else
                {
                    Application.Run(new StartForm());

                }
            }
            else
            {
                Application.Run(new StartForm());

            }
            
        }
    }
}