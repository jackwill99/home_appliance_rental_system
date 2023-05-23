using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RentalSystem
{
    class AdminControl : User
    {
        private static User _user;

        public static User userInfo
        {
            get { return _user; }
            set { _user = value; }
        }


        public String adminStorageLocation
        {
            get
            {
                
                String baseFolder = General.baseFolder;
                String path = Path.GetDirectoryName(baseFolder);
                String adminDir = Path.Combine(path, "Admin");
                Random rnd = new Random();
                int fileName = rnd.Next(100000);

                if (!Directory.Exists(adminDir))
                {
                    Directory.CreateDirectory(adminDir);
                }
                return Path.Combine(adminDir, fileName.ToString() + ".jpg");
            }
        }

        private static String _getStoreAdminFile()
        {
            String baseFolder = General.baseFolder;
            String path = Path.GetDirectoryName(baseFolder);
            String storeFile = Path.Combine(path, "admin.txt");
            return storeFile;
        }

        public static void storeAdminData(string userName,string password)
        {
            string fileName = _getStoreAdminFile();
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

        public static List<string> getStoreAdminData() {
            string fileName = _getStoreAdminFile();

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
            string fileName = _getStoreAdminFile();
            File.Delete(fileName);
        }
    }
}
