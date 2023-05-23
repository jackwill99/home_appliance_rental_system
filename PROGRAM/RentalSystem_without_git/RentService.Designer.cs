namespace RentalSystem
{
    partial class RentService
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RentService));
            this.panelStep = new System.Windows.Forms.Panel();
            this.divider3 = new System.Windows.Forms.Label();
            this.divider2 = new System.Windows.Forms.Label();
            this.divider1 = new System.Windows.Forms.Label();
            this.btnRent = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnRentAppliance = new System.Windows.Forms.Button();
            this.btnChooseUser = new System.Windows.Forms.Button();
            this.btnChooseAppliance = new System.Windows.Forms.Button();
            this.panelPage = new System.Windows.Forms.Panel();
            this.panelStep.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelStep
            // 
            this.panelStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStep.Controls.Add(this.divider3);
            this.panelStep.Controls.Add(this.divider2);
            this.panelStep.Controls.Add(this.divider1);
            this.panelStep.Controls.Add(this.btnRent);
            this.panelStep.Controls.Add(this.btnRentAppliance);
            this.panelStep.Controls.Add(this.btnChooseUser);
            this.panelStep.Controls.Add(this.btnChooseAppliance);
            this.panelStep.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStep.Location = new System.Drawing.Point(0, 0);
            this.panelStep.Name = "panelStep";
            this.panelStep.Size = new System.Drawing.Size(1036, 82);
            this.panelStep.TabIndex = 0;
            // 
            // divider3
            // 
            this.divider3.BackColor = System.Drawing.Color.Silver;
            this.divider3.Location = new System.Drawing.Point(676, 33);
            this.divider3.Name = "divider3";
            this.divider3.Size = new System.Drawing.Size(191, 5);
            this.divider3.TabIndex = 5;
            // 
            // divider2
            // 
            this.divider2.BackColor = System.Drawing.Color.Silver;
            this.divider2.Location = new System.Drawing.Point(414, 34);
            this.divider2.Name = "divider2";
            this.divider2.Size = new System.Drawing.Size(191, 5);
            this.divider2.TabIndex = 4;
            // 
            // divider1
            // 
            this.divider1.BackColor = System.Drawing.Color.Silver;
            this.divider1.Location = new System.Drawing.Point(154, 34);
            this.divider1.Name = "divider1";
            this.divider1.Size = new System.Drawing.Size(191, 5);
            this.divider1.TabIndex = 0;
            // 
            // btnRent
            // 
            this.btnRent.FlatAppearance.BorderSize = 0;
            this.btnRent.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRent.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRent.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRent.ImageIndex = 0;
            this.btnRent.ImageList = this.imageList1;
            this.btnRent.Location = new System.Drawing.Point(837, 6);
            this.btnRent.Name = "btnRent";
            this.btnRent.Size = new System.Drawing.Size(123, 73);
            this.btnRent.TabIndex = 3;
            this.btnRent.Text = "Check And Rent";
            this.btnRent.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRent.UseVisualStyleBackColor = true;
            this.btnRent.Click += new System.EventHandler(this.btnRent_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8_0_percent_48px.png");
            this.imageList1.Images.SetKeyName(1, "icons8_Coc_Coc_48px.png");
            this.imageList1.Images.SetKeyName(2, "icons8_ok_48px.png");
            // 
            // btnRentAppliance
            // 
            this.btnRentAppliance.FlatAppearance.BorderSize = 0;
            this.btnRentAppliance.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRentAppliance.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRentAppliance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRentAppliance.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRentAppliance.ImageIndex = 0;
            this.btnRentAppliance.ImageList = this.imageList1;
            this.btnRentAppliance.Location = new System.Drawing.Point(315, 3);
            this.btnRentAppliance.Name = "btnRentAppliance";
            this.btnRentAppliance.Size = new System.Drawing.Size(123, 73);
            this.btnRentAppliance.TabIndex = 2;
            this.btnRentAppliance.Text = "Rent Appliance";
            this.btnRentAppliance.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRentAppliance.UseVisualStyleBackColor = true;
            this.btnRentAppliance.Click += new System.EventHandler(this.btnRentAppliance_Click);
            // 
            // btnChooseUser
            // 
            this.btnChooseUser.FlatAppearance.BorderSize = 0;
            this.btnChooseUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnChooseUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnChooseUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChooseUser.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChooseUser.ImageIndex = 0;
            this.btnChooseUser.ImageList = this.imageList1;
            this.btnChooseUser.Location = new System.Drawing.Point(579, 3);
            this.btnChooseUser.Name = "btnChooseUser";
            this.btnChooseUser.Size = new System.Drawing.Size(123, 73);
            this.btnChooseUser.TabIndex = 1;
            this.btnChooseUser.Text = "Choose User";
            this.btnChooseUser.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnChooseUser.UseVisualStyleBackColor = true;
            this.btnChooseUser.Click += new System.EventHandler(this.btnChooseUser_Click);
            // 
            // btnChooseAppliance
            // 
            this.btnChooseAppliance.FlatAppearance.BorderSize = 0;
            this.btnChooseAppliance.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnChooseAppliance.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnChooseAppliance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChooseAppliance.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChooseAppliance.ImageIndex = 0;
            this.btnChooseAppliance.ImageList = this.imageList1;
            this.btnChooseAppliance.Location = new System.Drawing.Point(60, 6);
            this.btnChooseAppliance.Name = "btnChooseAppliance";
            this.btnChooseAppliance.Size = new System.Drawing.Size(123, 73);
            this.btnChooseAppliance.TabIndex = 0;
            this.btnChooseAppliance.Text = "Choose Appliance";
            this.btnChooseAppliance.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnChooseAppliance.UseVisualStyleBackColor = true;
            this.btnChooseAppliance.Click += new System.EventHandler(this.btnChooseAppliance_Click);
            // 
            // panelPage
            // 
            this.panelPage.AutoScroll = true;
            this.panelPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPage.Location = new System.Drawing.Point(0, 82);
            this.panelPage.Name = "panelPage";
            this.panelPage.Size = new System.Drawing.Size(1036, 626);
            this.panelPage.TabIndex = 1;
            // 
            // RentService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1036, 708);
            this.Controls.Add(this.panelPage);
            this.Controls.Add(this.panelStep);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RentService";
            this.Text = "RentService";
            this.panelStep.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelStep;
        private System.Windows.Forms.Panel panelPage;
        private System.Windows.Forms.Label divider3;
        private System.Windows.Forms.Label divider2;
        private System.Windows.Forms.Label divider1;
        private System.Windows.Forms.Button btnRent;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnRentAppliance;
        private System.Windows.Forms.Button btnChooseUser;
        private System.Windows.Forms.Button btnChooseAppliance;
    }
}