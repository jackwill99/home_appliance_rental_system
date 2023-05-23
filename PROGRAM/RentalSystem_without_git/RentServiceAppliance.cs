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
    public partial class RentServiceAppliance : Form
    {
        public RentServiceAppliance(DataTable rentApplianceDataTable)
        {
            InitializeComponent();
            dgvRentAppliance = dgvRentApplianceList;
            lblPrice.Text = RentService.rentServiceControl.totalPrice.ToString();
            _lblPrice = this.lblPrice;
            _rentApplianceDataTable = rentApplianceDataTable;
            
        }

        // ------------------------ rent service appliance attributes   ---------------------------
        public DataGridView dgvRentAppliance;
        DataTable _rentApplianceDataTable;
        public  Label _lblPrice;

        public static RentServiceInputValue rentServiceInput;

        private DataGridViewCellMouseEventArgs args;
        

        //  ----------------------- general method --------------------------------

        public void publicRefresh(DataTable table)
        {
            dgvRentAppliance.DataSource = table;
            _columnHidden();
            dgvRentAppliance.Refresh();
        }


        public void setTotalPrice(double price)
        {
            
            _lblPrice.Text = price.ToString();
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


        //  --------------------    form actions    ------------------

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (General.checkDgvCellClick(args, dgvRentAppliance))
            {
                //  1. remove unit total price

                // oldprice
                double oldPrice = Convert.ToDouble(dgvRentAppliance.Rows[args.RowIndex].Cells[8].Value);

                double totalPrice = RentService.rentServiceControl.totalPrice - oldPrice;
                
                RentService.rentServiceControl.totalPrice = totalPrice;
                setTotalPrice(totalPrice);
                RentService._rentServiceFinalCheck.setPrice(totalPrice);

                //  2.  remove row
                _rentApplianceDataTable.Rows.RemoveAt(args.RowIndex);
                publicRefresh(_rentApplianceDataTable);
                RentService._rentServiceFinalCheck.publicRefresh(_rentApplianceDataTable);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (General.checkDgvCellClick(args, dgvRentAppliance))
            {
                rentServiceInput = null;
                var input = new RentServiceInputBox(false);
                
                // old price
                double oldPrice = Convert.ToDouble(dgvRentAppliance.Rows[args.RowIndex].Cells[12].Value);

                input.addToInputBox(Convert.ToInt32(dgvRentAppliance.Rows[args.RowIndex].Cells[13].Value), dgvRentAppliance.Rows[args.RowIndex].Cells[14].Value.ToString());
                input.ShowDialog();

                if (rentServiceInput != null)
                {
                    // substract the total price of selected appliance 
                    double unitTotalPrice = 0;
                    if (rentServiceInput.month == 12)
                    {
                        unitTotalPrice += Convert.ToDouble(dgvRentAppliance.Rows[args.RowIndex].Cells[5].Value) * Convert.ToInt32(rentServiceInput.count);
                    }
                    else
                    {
                        unitTotalPrice += Convert.ToDouble(dgvRentAppliance.Rows[args.RowIndex].Cells[6].Value) * Convert.ToInt32(rentServiceInput.count) * Convert.ToInt32(rentServiceInput.month);
                    }

                    // total price
                    double totalPrice = RentService.rentServiceControl.totalPrice - oldPrice + unitTotalPrice;

                    RentService.rentServiceControl.totalPrice = totalPrice;
                    setTotalPrice(totalPrice);
                    RentService._rentServiceFinalCheck.setPrice(totalPrice);

                    // cell update
                    dgvRentAppliance.Rows[args.RowIndex].Cells[12].Value = unitTotalPrice;
                    dgvRentAppliance.Rows[args.RowIndex].Cells[13].Value = rentServiceInput.month;
                    dgvRentAppliance.Rows[args.RowIndex].Cells[14].Value = rentServiceInput.count;

                    // update also for rentservicefinalcheck
                    RentService._rentServiceFinalCheck.dgvRentAppliance.Rows[args.RowIndex].Cells[12].Value = unitTotalPrice;
                    RentService._rentServiceFinalCheck.dgvRentAppliance.Rows[args.RowIndex].Cells[13].Value = rentServiceInput.month;
                    RentService._rentServiceFinalCheck.dgvRentAppliance.Rows[args.RowIndex].Cells[14].Value = rentServiceInput.count;
                }

            }
        }

        private void dgvRentApplianceList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // store clicked cell to delete
            args = e;

            if (General.checkDgvCellClick(args, dgvRentAppliance))
            {
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
            }
            else {
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
            }
        }

        
    }
}
