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
    public partial class ApplianceForm : Form
    {
        public ApplianceForm(Action backCallback, bool update = false)
        {
            InitializeComponent();
            _setAutoId();
            _setApplianceType();
            _backCallback = backCallback;
            _update = update;
            if (update)
            {
                btnSave.Enabled = false;
                btnUpdate.Visible = true;
                lblAvailable.Visible = true;
                txtAvailable.Visible = true;

            }
        }


        // ------------------------------- Appliance Attributes --------------------
        HomeApplianceTableAdapters.appliancesTableAdapter applianceDataObj = new HomeApplianceTableAdapters.appliancesTableAdapter();
        HomeApplianceTableAdapters.applianceTypeTableAdapter applianceTypeDataObj = new HomeApplianceTableAdapters.applianceTypeTableAdapter();
        static ApplianceControl applianceControl = new ApplianceControl();
        DataTable dataTable;
        private Action _backCallback;
        private bool _update;


        // -------------------------------  General Methods --------------------

        // set the appliance type in combo box
        private void _setApplianceType()
        {
            dataTable = applianceTypeDataObj.GetData();
            cboApplianceType.Items.Add("Choose Appliance Type");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                cboApplianceType.Items.Add(dataTable.Rows[i][1].ToString().Trim());
            }
            cboApplianceType.SelectedIndex = 0;
        }

        private string _getApplianceTypeId(int index)
        { 
           
           return dataTable.Rows[index][0].ToString();
        }

        private int _getApplianceTypeName(String id)
        {
            int ind = -1;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Console.WriteLine(dataTable.Rows[i][1].ToString().Trim());
                Console.WriteLine(id);
                if (dataTable.Rows[i][1].ToString().Trim() == id.Trim())
                {
                    ind = i;
                    break;
                }
            }
            

            return ind != -1 ? ind + 1 : 0;
        }

        // Clear the information form
        private void _clearInformationText()
        {
            txtName.Clear();
            txtAnnualCost.Clear();
            txtMonthlyFees.Clear();
            txtModel.Clear();
            txtDimension.Clear();
            txtColor.Clear();
            txtQuentity.Clear();
            txtEnergyConsumption.Clear();
            txtTypicalUsage.Clear();
            txtPowerUsage.Clear();
            picAppliance.Image = null;
            cboApplianceType.SelectedIndex = 0;
        }

        // Set automation id
        private void _setAutoId()
        {
            DataTable data = applianceDataObj.CountData();
            int size = data.Rows.Count;
            if (size == 0)
            {
                txtId.Text = "AP_000001";
            }
            else
            {
                txtId.Text = General.autoIncrementID(data.Rows[size - 1][0].ToString(), "AP");
            }
        }

        // Setter of all attributes to ApplianceControl
        private void _setterApplianceControl()
        {
            applianceControl.id = txtId.Text;
            applianceControl.name = txtName.Text;
            applianceControl.annualCost = txtAnnualCost.Text;
            applianceControl.monthlyCost = txtMonthlyFees.Text;
            applianceControl.model = txtModel.Text;
            applianceControl.dimension = txtDimension.Text.Trim();
            applianceControl.color = txtColor.Text;
            applianceControl.quentity = txtQuentity.Text;
            applianceControl.applianceType = _getApplianceTypeId(cboApplianceType.SelectedIndex - 1);
            applianceControl.energyConsumption = txtEnergyConsumption.Text;
            applianceControl.typicalUsage = txtTypicalUsage.Text;
            applianceControl.powerUsage = txtPowerUsage.Text;
            if (picAppliance.Image != null)
            {
                applianceControl.photo = applianceControl.applianceStorageLocation;
            }
            else
            {
                applianceControl.photo = null;
            }
        
        }

        // Add of all attributes to ApplianceControl
        public void addDataToApplianceControl(String id, String name, String model, String dimension, String color, String annualCost, String monthlyCost, String energyConsumption,String image, String quentity, String available,String powerUsage,  String typicalUsage,String applianceType  )
        {
            txtId.Text = id;
            txtName.Text = name;
            txtAnnualCost.Text = annualCost;
            txtMonthlyFees.Text = monthlyCost;
            txtModel.Text = model;
            txtDimension.Text = dimension;
            txtColor.Text = color;
            txtQuentity.Text = quentity;
            txtAvailable.Text = available;
            cboApplianceType.SelectedIndex = _getApplianceTypeName(applianceType);
            txtEnergyConsumption.Text = energyConsumption;
            txtTypicalUsage.Text = typicalUsage;
            txtPowerUsage.Text = powerUsage;
            txtDimension.Text = dimension;
            try
            {
                if (image.ToLower() != "null")
                {
                    picAppliance.Image = Image.FromFile(image);
                }
                else
                {
                    picAppliance.Image = null;
                }
            }
            catch (Exception Update)
            {
                picAppliance.Image = null;
                MessageBox.Show("Invalid image path", "Appliance Update");
            }
        }

        // Validation Message Box
        private void _validationMessageBox(String message)
        {
            MessageBox.Show(message, "Appliance Form Validation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }


        // Validation Form of appliance
        private bool _validateForm()
        {
            decimal number;
            if (applianceControl.id == "")
            {
                _validationMessageBox("You need appliance Id to continue");
                return false;
            }
            else if (applianceControl.name == "")
            {
                _validationMessageBox("Please enter appliance name");
                txtName.Focus();
                return false;
            }
            else if (applianceControl.annualCost == "" || !Decimal.TryParse(txtAnnualCost.Text,out number))
            {
                _validationMessageBox("Please enter valid appliance annual cost");
                txtAnnualCost.Focus();
                return false;
            }
            else if (applianceControl.monthlyCost == "" || !Decimal.TryParse(txtMonthlyFees.Text,out number))
            {
                _validationMessageBox("Please enter valid  appliance monthly cost");
                txtMonthlyFees.Focus(); 
                return false;
            }
            else if (applianceControl.model == "")
            {
                _validationMessageBox("Please enter appliance model");
                txtModel.Focus(); 
                return false;
            }
            else if (applianceControl.color == "")
            {
                _validationMessageBox("Please enter appliance color");
                txtColor.Focus(); 
                return false;
            }
            else if (applianceControl.quentity == "" || !applianceControl.quentity.All(char.IsDigit))
            {
                _validationMessageBox("Please enter valid  appliance quentity");
                txtQuentity.Focus();
                return false;
            }
            else if (applianceControl.energyConsumption == "")
            {
                _validationMessageBox("Please enter valid  appliance energy consumption");
                txtEnergyConsumption.Focus();
                return false;
            }
            else if (applianceControl.dimension == "")
            {
                _validationMessageBox("Please enter appliance  dimension");
                txtDimension.Focus();
                return false;
            }
            else if (applianceControl.typicalUsage == "")
            {
                _validationMessageBox("Please enter appliance typical usage");
                txtTypicalUsage.Focus();
                return false;
            }
            else if (applianceControl.powerUsage == "")
            {
                _validationMessageBox("Please enter appliance power usage");
                txtPowerUsage.Focus();
                return false;
            }
            else if (applianceControl.photo == null)
            {
                _validationMessageBox("Please choose appliance photo");
                return false;
            }
            else if (_update && (txtAvailable.Text == "" || !txtAvailable.Text.All(char.IsDigit)))
            {
                _validationMessageBox("Please enter available appliance for update");
                txtAvailable.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }



        // -------------------------------  Form Actions --------------------

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (_update)
            {
                _clearInformationText();
            }
            else {
                // 1.   Clear admin information form
                _clearInformationText();

                // 2.   When in update situation, replace admin id in the place of update id
                _setAutoId();

                //3.    Change button visibility and enable
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSave.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboApplianceType.SelectedIndex == 0)
            {
                _validationMessageBox("Please select appliance type");
                cboApplianceType.Focus();
                return ;
            }
            // 1.   Use encapsulation of admin
            _setterApplianceControl();

            // 2.   check validation form
            bool validate = _validateForm();

            // 3.   if success, store data in database, refresh data table, clear form and set auto id
            if (validate)
            {
                applianceDataObj.Insert(applianceControl.id, applianceControl.name, applianceControl.model, applianceControl.dimension, applianceControl.color, Convert.ToInt32(applianceControl.annualCost), Convert.ToInt32(applianceControl.monthlyCost), applianceControl.energyConsumption, AdminControl.userInfo.id, applianceControl.applianceType, applianceControl.photo, Convert.ToInt32(applianceControl.quentity), Convert.ToInt32(applianceControl.quentity), applianceControl.powerUsage, applianceControl.typicalUsage);
                if (applianceControl.photo != null)
                {
                    picAppliance.Image.Save(applianceControl.photo);
                }
                MessageBox.Show("Appliance added successfully","Appliance Form");
                _clearInformationText();
                _setAutoId();

                _backCallback();
               // ApplianceList.refreshDataTable();
            }

        }


        private void picAppliance_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "(*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                picAppliance.Image = Image.FromFile(open.FileName);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
            _backCallback();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cboApplianceType.SelectedIndex == 0)
            {
                _validationMessageBox("Please select appliance type");
                cboApplianceType.Focus();
                return;
            }
            // 1.   Use encapsulation of admin
            _setterApplianceControl();

            // 2.   check validation form
            bool validate = _validateForm();

            // 3.   if success, store data in database, refresh data table, clear form and set auto id

            if (validate)
            {
                applianceDataObj.UpdateQuery(applianceControl.id, applianceControl.name, applianceControl.model, applianceControl.dimension, applianceControl.color, Convert.ToInt32(applianceControl.annualCost), Convert.ToInt32(applianceControl.monthlyCost), applianceControl.energyConsumption, AdminControl.userInfo.id, applianceControl.applianceType, applianceControl.photo, Convert.ToInt32(applianceControl.quentity), Convert.ToInt32(txtAvailable.Text), applianceControl.powerUsage, applianceControl.typicalUsage, applianceControl.id);
                if (applianceControl.photo != null)
                {
                    picAppliance.Image.Save(applianceControl.photo);
                }
                MessageBox.Show("Appliance updated successfully", "Appliance Form");
                _clearInformationText();
                _setAutoId();

                _backCallback();
            }
        }

        
    }
}
