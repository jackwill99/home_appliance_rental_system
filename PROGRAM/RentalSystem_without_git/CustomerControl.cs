using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RentalSystem
{
    class CustomerControl : User
    {
        // -------------------------    user information    -----------------------
        private static User _user;

        public static User userInfo
        {
            get { return _user; }
            set { _user = value; }
        }

        // ------------------------ storage location for customer   -----------------------------
        public String customerStorageLocation
        {
            get
            {
                String baseFolder = General.baseFolder;
                String path = Path.GetDirectoryName(baseFolder);
                String customerDir = Path.Combine(path, "Customer");
                Random rnd = new Random();
                int fileName = rnd.Next(100000);

                if (!Directory.Exists(customerDir))
                {
                    Directory.CreateDirectory(customerDir);
                }
                return Path.Combine(customerDir, fileName.ToString() + ".jpg");
            }
        }

        // -------------------------    flash for is customer or not    ------------------------
        private static bool _isCustomer = true;

        public static bool isCustomer
        {
            get { return _isCustomer; }
            set { _isCustomer = value; }
        }

        
        //  --------------------------  store customer information in local ---------------------------
        private static String _getStoreCustomerFile()
        {
            String baseFolder = General.baseFolder;
            String path = Path.GetDirectoryName(baseFolder);
            String storeFile = Path.Combine(path, "customer.txt");
            return storeFile;
        }

        public static void storeCustomerData(string userName, string password)
        {
            string fileName = _getStoreCustomerFile();
            // Check if file already exists. If yes, delete it.     
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            // Create a new file     
            using (StreamWriter sw = File.CreateText(fileName))
            {
                // Add some text to file    
                sw.WriteLine(userName);
                sw.WriteLine(password);
            }

        }

        public static List<string> getStoreCustomerData()
        {
            string fileName = _getStoreCustomerFile();

            var data = new List<string>();

            // if there is no file, return empty
            if (!File.Exists(fileName))
            {
                return data;
            }

            // Open the stream and read it back.    
            using (StreamReader sr = File.OpenText(fileName))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    data.Add(s);
                }
            }

            return data;
        }

        public static void removeStoreData()
        {
            string fileName = _getStoreCustomerFile();
            File.Delete(fileName);
        }

    }
}
