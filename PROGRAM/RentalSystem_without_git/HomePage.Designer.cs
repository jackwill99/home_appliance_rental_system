namespace RentalSystem
{
    partial class HomePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelSide = new System.Windows.Forms.Panel();
            this.btnRentService = new System.Windows.Forms.Button();
            this.btnApplianceType = new System.Windows.Forms.Button();
            this.btnApplianceList = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.btnAdminList = new System.Windows.Forms.Button();
            this.btnUserInfo = new System.Windows.Forms.Button();
            this.btnCustomerList = new System.Windows.Forms.Button();
            this.btnRentList = new System.Windows.Forms.Button();
            this.panelPages = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panelSide.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1171, 40);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(422, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Home Appliance Rental System";
            // 
            // panelSide
            // 
            this.panelSide.BackColor = System.Drawing.Color.LightBlue;
            this.panelSide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSide.Controls.Add(this.btnRentService);
            this.panelSide.Controls.Add(this.btnApplianceType);
            this.panelSide.Controls.Add(this.btnApplianceList);
            this.panelSide.Controls.Add(this.btnLogout);
            this.panelSide.Controls.Add(this.lblUserInfo);
            this.panelSide.Controls.Add(this.btnAdminList);
            this.panelSide.Controls.Add(this.btnUserInfo);
            this.panelSide.Controls.Add(this.btnCustomerList);
            this.panelSide.Controls.Add(this.btnRentList);
            this.panelSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSide.Location = new System.Drawing.Point(0, 40);
            this.panelSide.Name = "panelSide";
            this.panelSide.Size = new System.Drawing.Size(141, 724);
            this.panelSide.TabIndex = 1;
            // 
            // btnRentService
            // 
            this.btnRentService.FlatAppearance.BorderSize = 0;
            this.btnRentService.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnRentService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRentService.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRentService.Image = ((System.Drawing.Image)(resources.GetObject("btnRentService.Image")));
            this.btnRentService.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRentService.Location = new System.Drawing.Point(11, 103);
            this.btnRentService.Name = "btnRentService";
            this.btnRentService.Size = new System.Drawing.Size(123, 34);
            this.btnRentService.TabIndex = 5;
            this.btnRentService.Text = "Rent Service";
            this.btnRentService.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRentService.UseVisualStyleBackColor = true;
            this.btnRentService.Click += new System.EventHandler(this.btnRentService_Click);
            // 
            // btnApplianceType
            // 
            this.btnApplianceType.FlatAppearance.BorderSize = 0;
            this.btnApplianceType.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnApplianceType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplianceType.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplianceType.Image = ((System.Drawing.Image)(resources.GetObject("btnApplianceType.Image")));
            this.btnApplianceType.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApplianceType.Location = new System.Drawing.Point(13, 143);
            this.btnApplianceType.Name = "btnApplianceType";
            this.btnApplianceType.Size = new System.Drawing.Size(136, 40);
            this.btnApplianceType.TabIndex = 4;
            this.btnApplianceType.Text = "Appliance Type";
            this.btnApplianceType.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnApplianceType.UseVisualStyleBackColor = true;
            this.btnApplianceType.Click += new System.EventHandler(this.btnApplianceType_Click);
            // 
            // btnApplianceList
            // 
            this.btnApplianceList.FlatAppearance.BorderSize = 0;
            this.btnApplianceList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnApplianceList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplianceList.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplianceList.Image = ((System.Drawing.Image)(resources.GetObject("btnApplianceList.Image")));
            this.btnApplianceList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApplianceList.Location = new System.Drawing.Point(11, 8);
            this.btnApplianceList.Name = "btnApplianceList";
            this.btnApplianceList.Size = new System.Drawing.Size(129, 42);
            this.btnApplianceList.TabIndex = 2;
            this.btnApplianceList.Text = "Appliance List";
            this.btnApplianceList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnApplianceList.UseVisualStyleBackColor = true;
            this.btnApplianceList.Click += new System.EventHandler(this.btnApplianceList_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(11, 668);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(150, 40);
            this.btnLogout.TabIndex = 10;
            this.btnLogout.Text = "Logout";
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.AutoSize = true;
            this.lblUserInfo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserInfo.Location = new System.Drawing.Point(47, 628);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(64, 16);
            this.lblUserInfo.TabIndex = 9;
            this.lblUserInfo.Text = "User Info";
            this.lblUserInfo.MouseEnter += new System.EventHandler(this.lblUserInfo_MouseEnter);
            this.lblUserInfo.MouseLeave += new System.EventHandler(this.lblUserInfo_MouseLeave);
            // 
            // btnAdminList
            // 
            this.btnAdminList.FlatAppearance.BorderSize = 0;
            this.btnAdminList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnAdminList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdminList.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminList.Image = ((System.Drawing.Image)(resources.GetObject("btnAdminList.Image")));
            this.btnAdminList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdminList.Location = new System.Drawing.Point(11, 195);
            this.btnAdminList.Name = "btnAdminList";
            this.btnAdminList.Size = new System.Drawing.Size(123, 34);
            this.btnAdminList.TabIndex = 1;
            this.btnAdminList.Text = "Admin List";
            this.btnAdminList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdminList.UseVisualStyleBackColor = true;
            this.btnAdminList.Click += new System.EventHandler(this.btnAdminList_Click);
            // 
            // btnUserInfo
            // 
            this.btnUserInfo.FlatAppearance.BorderSize = 0;
            this.btnUserInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnUserInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserInfo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnUserInfo.Image")));
            this.btnUserInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserInfo.Location = new System.Drawing.Point(11, 614);
            this.btnUserInfo.Name = "btnUserInfo";
            this.btnUserInfo.Size = new System.Drawing.Size(150, 44);
            this.btnUserInfo.TabIndex = 6;
            this.btnUserInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUserInfo.UseVisualStyleBackColor = true;
            this.btnUserInfo.MouseEnter += new System.EventHandler(this.btnUserInfo_MouseEnter);
            this.btnUserInfo.MouseLeave += new System.EventHandler(this.btnUserInfo_MouseLeave);
            this.btnUserInfo.MouseHover += new System.EventHandler(this.btnUserInfo_MouseHover);
            // 
            // btnCustomerList
            // 
            this.btnCustomerList.FlatAppearance.BorderSize = 0;
            this.btnCustomerList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnCustomerList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomerList.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomerList.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomerList.Image")));
            this.btnCustomerList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomerList.Location = new System.Drawing.Point(11, 245);
            this.btnCustomerList.Name = "btnCustomerList";
            this.btnCustomerList.Size = new System.Drawing.Size(123, 34);
            this.btnCustomerList.TabIndex = 3;
            this.btnCustomerList.Text = "Customer List";
            this.btnCustomerList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCustomerList.UseVisualStyleBackColor = true;
            this.btnCustomerList.Click += new System.EventHandler(this.btnCustomerList_Click);
            // 
            // btnRentList
            // 
            this.btnRentList.FlatAppearance.BorderSize = 0;
            this.btnRentList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
            this.btnRentList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRentList.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRentList.Image = ((System.Drawing.Image)(resources.GetObject("btnRentList.Image")));
            this.btnRentList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRentList.Location = new System.Drawing.Point(11, 59);
            this.btnRentList.Name = "btnRentList";
            this.btnRentList.Size = new System.Drawing.Size(123, 34);
            this.btnRentList.TabIndex = 0;
            this.btnRentList.Text = "Rent List";
            this.btnRentList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRentList.UseVisualStyleBackColor = true;
            this.btnRentList.Click += new System.EventHandler(this.btnRentList_Click);
            // 
            // panelPages
            // 
            this.panelPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPages.Location = new System.Drawing.Point(141, 40);
            this.panelPages.Name = "panelPages";
            this.panelPages.Size = new System.Drawing.Size(1030, 724);
            this.panelPages.TabIndex = 2;
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1171, 764);
            this.Controls.Add(this.panelPages);
            this.Controls.Add(this.panelSide);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "HomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomePage";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelSide.ResumeLayout(false);
            this.panelSide.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelSide;
        private System.Windows.Forms.Panel panelPages;
        private System.Windows.Forms.Button btnRentList;
        private System.Windows.Forms.Button btnApplianceList;
        private System.Windows.Forms.Button btnAdminList;
        private System.Windows.Forms.Button btnCustomerList;
        private System.Windows.Forms.Button btnRentService;
        private System.Windows.Forms.Button btnApplianceType;
        private System.Windows.Forms.Button btnUserInfo;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Button btnLogout;
    }
}