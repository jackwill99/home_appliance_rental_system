namespace RentalSystem
{
    partial class RentServiceFinalCheck
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dgvRentApplianceList = new System.Windows.Forms.DataGridView();
            this.gpPrice = new System.Windows.Forms.Label();
            this.gpCustomerInfo = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gpRentId = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gpId = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gpName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRent = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentApplianceList)).BeginInit();
            this.gpCustomerInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 16);
            this.label1.TabIndex = 38;
            this.label1.Text = "Rent Appliance Check And Rent";
            // 
            // dgvRentApplianceList
            // 
            this.dgvRentApplianceList.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvRentApplianceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRentApplianceList.Location = new System.Drawing.Point(12, 191);
            this.dgvRentApplianceList.Name = "dgvRentApplianceList";
            this.dgvRentApplianceList.Size = new System.Drawing.Size(1008, 505);
            this.dgvRentApplianceList.TabIndex = 37;
            // 
            // gpPrice
            // 
            this.gpPrice.AutoSize = true;
            this.gpPrice.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpPrice.ForeColor = System.Drawing.Color.Firebrick;
            this.gpPrice.Location = new System.Drawing.Point(146, 57);
            this.gpPrice.Name = "gpPrice";
            this.gpPrice.Size = new System.Drawing.Size(36, 16);
            this.gpPrice.TabIndex = 34;
            this.gpPrice.Text = "0000";
            // 
            // gpCustomerInfo
            // 
            this.gpCustomerInfo.Controls.Add(this.label4);
            this.gpCustomerInfo.Controls.Add(this.gpRentId);
            this.gpCustomerInfo.Controls.Add(this.label6);
            this.gpCustomerInfo.Controls.Add(this.gpId);
            this.gpCustomerInfo.Controls.Add(this.label3);
            this.gpCustomerInfo.Controls.Add(this.gpName);
            this.gpCustomerInfo.Controls.Add(this.label2);
            this.gpCustomerInfo.Controls.Add(this.gpPrice);
            this.gpCustomerInfo.Location = new System.Drawing.Point(16, 44);
            this.gpCustomerInfo.Name = "gpCustomerInfo";
            this.gpCustomerInfo.Size = new System.Drawing.Size(419, 141);
            this.gpCustomerInfo.TabIndex = 43;
            this.gpCustomerInfo.TabStop = false;
            this.gpCustomerInfo.Text = "Rent Information";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Firebrick;
            this.label4.Location = new System.Drawing.Point(7, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 17);
            this.label4.TabIndex = 41;
            this.label4.Text = "Rent Id                 -";
            // 
            // gpRentId
            // 
            this.gpRentId.AutoSize = true;
            this.gpRentId.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpRentId.ForeColor = System.Drawing.Color.Firebrick;
            this.gpRentId.Location = new System.Drawing.Point(147, 30);
            this.gpRentId.Name = "gpRentId";
            this.gpRentId.Size = new System.Drawing.Size(36, 16);
            this.gpRentId.TabIndex = 40;
            this.gpRentId.Text = "0000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Firebrick;
            this.label6.Location = new System.Drawing.Point(6, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 17);
            this.label6.TabIndex = 39;
            this.label6.Text = "Customer Id        -";
            // 
            // gpId
            // 
            this.gpId.AutoSize = true;
            this.gpId.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpId.ForeColor = System.Drawing.Color.Firebrick;
            this.gpId.Location = new System.Drawing.Point(146, 113);
            this.gpId.Name = "gpId";
            this.gpId.Size = new System.Drawing.Size(36, 16);
            this.gpId.TabIndex = 38;
            this.gpId.Text = "0000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Firebrick;
            this.label3.Location = new System.Drawing.Point(6, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 17);
            this.label3.TabIndex = 37;
            this.label3.Text = "Customer Name -";
            // 
            // gpName
            // 
            this.gpName.AutoSize = true;
            this.gpName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpName.ForeColor = System.Drawing.Color.Firebrick;
            this.gpName.Location = new System.Drawing.Point(146, 85);
            this.gpName.Name = "gpName";
            this.gpName.Size = new System.Drawing.Size(36, 16);
            this.gpName.TabIndex = 36;
            this.gpName.Text = "0000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Firebrick;
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 17);
            this.label2.TabIndex = 35;
            this.label2.Text = "Total Price           - ";
            // 
            // btnRent
            // 
            this.btnRent.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnRent.ForeColor = System.Drawing.Color.Black;
            this.btnRent.Location = new System.Drawing.Point(863, 101);
            this.btnRent.Margin = new System.Windows.Forms.Padding(2);
            this.btnRent.Name = "btnRent";
            this.btnRent.Size = new System.Drawing.Size(80, 35);
            this.btnRent.TabIndex = 44;
            this.btnRent.Text = "&Rent";
            this.btnRent.UseVisualStyleBackColor = false;
            this.btnRent.Click += new System.EventHandler(this.btnRent_Click);
            // 
            // RentServiceFinalCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1036, 708);
            this.Controls.Add(this.btnRent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvRentApplianceList);
            this.Controls.Add(this.gpCustomerInfo);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RentServiceFinalCheck";
            this.Text = "RentServiceFinalCheck";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentApplianceList)).EndInit();
            this.gpCustomerInfo.ResumeLayout(false);
            this.gpCustomerInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvRentApplianceList;
        private System.Windows.Forms.Label gpPrice;
        private System.Windows.Forms.GroupBox gpCustomerInfo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label gpId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label gpName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label gpRentId;
    }
}