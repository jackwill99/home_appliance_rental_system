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
    public partial class ApplianceTypeForm : Form
    {
        public ApplianceTypeForm(Action backCallback,bool update = false)
        {
            InitializeComponent();
            _setAutoId();
            _backCallback = backCallback;
            _update = update;
            if (update)
            {
                btnSave.Enabled = false;
                btnUpdate.Visible = true;
            }
        }


        // ------------------------------- Appliance type form Attributes --------------------
        HomeApplianceTableAdapters.applianceTypeTableAdapter applianceTypeDataObj = new HomeApplianceTableAdapters.applianceTypeTableAdapter();
        static ApplianceTypeControl applianceTypeControl = new ApplianceTypeControl();
        private Action _backCallback;
        private bool _update;


        // -------------------------------  General Methods --------------------

        // Clear the information form
        private void _clearInformationText()
        {
            txtName.Clear();
        }

        // Set automation id 
        private void _setAutoId()
        {
            DataTable data = applianceTypeDataObj.CountData();
            int size = data.Rows.Count;
            if (size == 0)
            {
                txtId.Text = "APT_000001";
            }
            else
            {
                txtId.Text = General.autoIncrementID(data.Rows[size - 1][0].ToString(), "APT");
            }
        }

        // Setter of all attributes to 
        private void _setterApplianceTypeControl()
        {
            applianceTypeControl.id = txtId.Text;
            applianceTypeControl.type = txtName.Text;
        }

        // Add of all attributes to AdminControl
        public void addDataToApplianceTypeControl(String id, String name)
        {
            txtId.Text = id;
            txtName.Text = name;
        }

        // Validation Message Box
        private void _validationMessageBox(String message)
        {
            MessageBox.Show(message, "Appliance Type Form Validation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }


        // Validation Form
        private bool _validateForm()
        {
            if (applianceTypeControl.id == "")
            {
                _validationMessageBox("You need appliance type Id to continue");
                return false;
            }
            else if (applianceTypeControl.type == "")
            {
                _validationMessageBox("Please enter appliance type name");
                txtName.Focus();
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
            // 1.   Clear information form
            _clearInformationText();

            if (!_update)
            {
                // 2.   When in update situation, replace id in the place of update id
                _setAutoId();

                //3.    Change button visibility and enable
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSave.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1.   Use encapsulation
            _setterApplianceTypeControl();

            // 2.   check validation form
            bool validate = _validateForm();

            // 3.   if success, store data in database, refresh data table, clear form and set auto id
            if (validate)
            {
                applianceTypeDataObj.Insert(applianceTypeControl.id, applianceTypeControl.type);
                
                _clearInformationText();
                _setAutoId();

                MessageBox.Show("Appliance Type added successfully", "Appliance Type");

                _backCallback();
                ApplianceTypeList.refreshDataTable();
            }

            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
            _backCallback();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // 1.   Use encapsulation
            _setterApplianceTypeControl();

            // 2.   check validation form
            bool validate = _validateForm();

            // 3.   if success, store data in database, refresh data table, clear form and set auto id
            if (validate)
            {
                applianceTypeDataObj.UpdateQuery( applianceTypeControl.type, applianceTypeControl.id);

                _clearInformationText();
                _setAutoId();

                MessageBox.Show("Appliance Type Update successfully", "Appliance Type");

                _backCallback();
                ApplianceTypeList.refreshDataTable();
            }
        }

        
    }
}
