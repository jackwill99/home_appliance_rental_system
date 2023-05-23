using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;


namespace RentalSystem
{
    class General
    {

        // auto increment Id method
        public static String autoIncrementID(String lastId, String unique)
        {
            String strKey = lastId.Substring(unique.Length + 1);
            int intKey = Int32.Parse(strKey);

            int newIntKey = intKey + 1;
            String newKey = unique + "_";
            if (newIntKey <= 99999)
            {
                String newStrKey = newIntKey.ToString();
                if (newStrKey.Length < 6)
                {
                    for (int i = 0; i < (6 - newStrKey.Length); i++)
                    {
                        newKey += "0";
                    }
                }
            }
            newKey += newIntKey;

            return newKey;
        }

        // to store files in projects, define the folder location
        public static String baseFolder
        {
            get { return Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName; }
        }

        // check the user mouse click of data grid view is validate or not
        public static bool checkDgvCellClick(DataGridViewCellMouseEventArgs e, DataGridView view)
        {
            //1.    If user click multiple selection, show message box and don't do anything
            if (e.RowIndex == -1)
            {
                MessageBox.Show("Does not allow multiple select in table", "Table Selection", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return false;
            }

            //2.    Get the selected row and check this row is empty or not
            DataGridViewRow row = view.Rows[e.RowIndex];
            if (row.Cells[0].Value.ToString() == "")
            {

                return false;
            }
            return true;
        }
    }

}
