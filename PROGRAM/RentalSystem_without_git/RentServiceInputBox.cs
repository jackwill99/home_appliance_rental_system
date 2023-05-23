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
    public partial class RentServiceInputBox : Form
    {
        public RentServiceInputBox(bool isAdd = true)
        {
            InitializeComponent();
            _isAdd = isAdd;
        }

        //  ------------------- input box attributes    ------------------
        // flash for adding or updating quantity
        bool _isAdd;

        //  ----------------------  general methods -----------------
        private bool _validate()
        {
            Console.Read();
            if (cboMonth.SelectedIndex == -1)
            {
                MessageBox.Show("Select Month to rent appliance", "Rent Selection");
                return false;
            }
            if (txtCount.Text == "")
            {
                MessageBox.Show("Enter the count of appliance to rent", "Rent Selection");
                return false;
            }
            if (!txtCount.Text.All(char.IsDigit))
            {
                MessageBox.Show("Enter valid number in count", "Rent Selection");
                return false;
            }

            return true;
        }

        public void addToInputBox(int month, string count)
        {
            txtCount.Text = count;
            cboMonth.SelectedIndex = month - 1;
        }


        //  ----------------------  form action ------------------------

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (_validate())
            {
                this.Hide();
                if (_isAdd)
                {
                    RentService._applianceList.rentServiceInput = new RentServiceInputValue(cboMonth.SelectedIndex + 1, txtCount.Text);
                }
                else {
                    RentServiceAppliance.rentServiceInput = new RentServiceInputValue(cboMonth.SelectedIndex + 1, txtCount.Text); 
                }
                
                //return new RentServiceInputValue(cboMonth.SelectedIndex, txtCount.Text);
            }
            
        }
        
    }

    public class RentServiceInputValue
    {
        public int month;
        public string count;

        public RentServiceInputValue(int _month, string _count)
        {
            month = _month;
            count = _count;
        }
    }
}
