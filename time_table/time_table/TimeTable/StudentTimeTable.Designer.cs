namespace time_table.TimeTable
{
    partial class StudentTimeTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentTimeTable));
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.closebtn4 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.labelBottom = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.home3btn = new Guna.UI2.WinForms.Guna2Button();
            this.btngenarate = new Guna.UI2.WinForms.Guna2Button();
            this.comboGroup = new Guna.UI2.WinForms.Guna2ComboBox();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportViewer2
            // 
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "time_table.ReportLect.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(274, 150);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(1199, 583);
            this.reportViewer2.TabIndex = 145;
            // 
            // closebtn4
            // 
            this.closebtn4.BackColor = System.Drawing.Color.Transparent;
            this.closebtn4.CheckedState.Parent = this.closebtn4;
            this.closebtn4.CustomBorderColor = System.Drawing.Color.White;
            this.closebtn4.CustomImages.Image = ((System.Drawing.Image)(resources.GetObject("closebtn4.CustomImages.Image")));
            this.closebtn4.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.closebtn4.CustomImages.Parent = this.closebtn4;
            this.closebtn4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.closebtn4.ForeColor = System.Drawing.Color.White;
            this.closebtn4.HoverState.Parent = this.closebtn4;
            this.closebtn4.Location = new System.Drawing.Point(1463, 2);
            this.closebtn4.Name = "closebtn4";
            this.closebtn4.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.closebtn4.ShadowDecoration.Parent = this.closebtn4;
            this.closebtn4.Size = new System.Drawing.Size(50, 44);
            this.closebtn4.TabIndex = 2;
            this.closebtn4.Click += new System.EventHandler(this.closebtn4_Click);
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.BackColor = System.Drawing.Color.Transparent;
            this.lblDateTime.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.ForeColor = System.Drawing.Color.Black;
            this.lblDateTime.Location = new System.Drawing.Point(1000, 17);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(61, 23);
            this.lblDateTime.TabIndex = 7;
            this.lblDateTime.Text = "Time";
            // 
            // guna2Button3
            // 
            this.guna2Button3.Animated = true;
            this.guna2Button3.AutoRoundedCorners = true;
            this.guna2Button3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button3.BorderRadius = 46;
            this.guna2Button3.CheckedState.Parent = this.guna2Button3;
            this.guna2Button3.CustomBorderColor = System.Drawing.Color.Transparent;
            this.guna2Button3.CustomImages.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button3.CustomImages.Image")));
            this.guna2Button3.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button3.CustomImages.ImageSize = new System.Drawing.Size(35, 35);
            this.guna2Button3.CustomImages.Parent = this.guna2Button3;
            this.guna2Button3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(219)))), ((int)(((byte)(88)))));
            this.guna2Button3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.guna2Button3.ForeColor = System.Drawing.Color.Black;
            this.guna2Button3.HoverState.Parent = this.guna2Button3;
            this.guna2Button3.Location = new System.Drawing.Point(14, 495);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.ShadowDecoration.Parent = this.guna2Button3;
            this.guna2Button3.Size = new System.Drawing.Size(179, 95);
            this.guna2Button3.TabIndex = 3;
            this.guna2Button3.Text = "    settings";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(884, 15);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(34, 35);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 6;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(822, 15);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(34, 35);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // labelBottom
            // 
            this.labelBottom.AutoSize = true;
            this.labelBottom.BackColor = System.Drawing.Color.Transparent;
            this.labelBottom.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBottom.ForeColor = System.Drawing.Color.Black;
            this.labelBottom.Location = new System.Drawing.Point(399, 17);
            this.labelBottom.Name = "labelBottom";
            this.labelBottom.Size = new System.Drawing.Size(387, 23);
            this.labelBottom.TabIndex = 1;
            this.labelBottom.Text = "2021@CodeSpace All rights reserved ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(34, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(126, 113);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // home3btn
            // 
            this.home3btn.Animated = true;
            this.home3btn.AutoRoundedCorners = true;
            this.home3btn.BackColor = System.Drawing.Color.Transparent;
            this.home3btn.BorderRadius = 57;
            this.home3btn.CheckedState.Parent = this.home3btn;
            this.home3btn.CustomBorderColor = System.Drawing.Color.Transparent;
            this.home3btn.CustomImages.Image = ((System.Drawing.Image)(resources.GetObject("home3btn.CustomImages.Image")));
            this.home3btn.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.home3btn.CustomImages.ImageSize = new System.Drawing.Size(35, 35);
            this.home3btn.CustomImages.Parent = this.home3btn;
            this.home3btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(219)))), ((int)(((byte)(88)))));
            this.home3btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.home3btn.ForeColor = System.Drawing.Color.Black;
            this.home3btn.HoverState.Parent = this.home3btn;
            this.home3btn.Location = new System.Drawing.Point(14, 155);
            this.home3btn.Name = "home3btn";
            this.home3btn.ShadowDecoration.Parent = this.home3btn;
            this.home3btn.Size = new System.Drawing.Size(179, 116);
            this.home3btn.TabIndex = 1;
            this.home3btn.Text = "    Home";
            this.home3btn.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.home3btn.Click += new System.EventHandler(this.home3btn_Click);
            // 
            // btngenarate
            // 
            this.btngenarate.BorderRadius = 20;
            this.btngenarate.CheckedState.Parent = this.btngenarate;
            this.btngenarate.CustomImages.Parent = this.btngenarate;
            this.btngenarate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(251)))), ((int)(((byte)(23)))));
            this.btngenarate.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngenarate.ForeColor = System.Drawing.Color.Black;
            this.btngenarate.HoverState.Parent = this.btngenarate;
            this.btngenarate.Location = new System.Drawing.Point(920, 65);
            this.btngenarate.Name = "btngenarate";
            this.btngenarate.ShadowDecoration.Parent = this.btngenarate;
            this.btngenarate.Size = new System.Drawing.Size(180, 60);
            this.btngenarate.TabIndex = 144;
            this.btngenarate.Text = "Genarate";
            this.btngenarate.Click += new System.EventHandler(this.btngenarate_Click);
            // 
            // comboGroup
            // 
            this.comboGroup.BackColor = System.Drawing.Color.Transparent;
            this.comboGroup.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(172)))), ((int)(((byte)(236)))));
            this.comboGroup.BorderRadius = 10;
            this.comboGroup.BorderThickness = 3;
            this.comboGroup.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGroup.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(207)))), ((int)(((byte)(236)))));
            this.comboGroup.FocusedColor = System.Drawing.Color.Empty;
            this.comboGroup.FocusedState.Parent = this.comboGroup;
            this.comboGroup.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboGroup.FormattingEnabled = true;
            this.comboGroup.HoverState.Parent = this.comboGroup;
            this.comboGroup.ItemHeight = 30;
            this.comboGroup.ItemsAppearance.Parent = this.comboGroup;
            this.comboGroup.Location = new System.Drawing.Point(384, 78);
            this.comboGroup.Name = "comboGroup";
            this.comboGroup.ShadowDecoration.Parent = this.comboGroup;
            this.comboGroup.Size = new System.Drawing.Size(259, 36);
            this.comboGroup.TabIndex = 143;
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.BackColor = System.Drawing.Color.Transparent;
            this.gunaLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel1.Location = new System.Drawing.Point(269, 78);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(70, 28);
            this.gunaLabel1.TabIndex = 142;
            this.gunaLabel1.Text = "Group";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderRadius = 20;
            this.guna2Panel1.Controls.Add(this.pictureBox1);
            this.guna2Panel1.Controls.Add(this.guna2Button3);
            this.guna2Panel1.Controls.Add(this.home3btn);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(172)))), ((int)(((byte)(236)))));
            this.guna2Panel1.Location = new System.Drawing.Point(22, 65);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.BorderRadius = 15;
            this.guna2Panel1.ShadowDecoration.Color = System.Drawing.Color.White;
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.guna2Panel1.Size = new System.Drawing.Size(206, 657);
            this.guna2Panel1.TabIndex = 141;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Controls.Add(this.lblDateTime);
            this.guna2Panel3.Controls.Add(this.pictureBox4);
            this.guna2Panel3.Controls.Add(this.pictureBox3);
            this.guna2Panel3.Controls.Add(this.labelBottom);
            this.guna2Panel3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(219)))), ((int)(((byte)(88)))));
            this.guna2Panel3.Location = new System.Drawing.Point(-3, 751);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.ShadowDecoration.Parent = this.guna2Panel3;
            this.guna2Panel3.Size = new System.Drawing.Size(1519, 59);
            this.guna2Panel3.TabIndex = 140;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.closebtn4);
            this.guna2Panel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(219)))), ((int)(((byte)(88)))));
            this.guna2Panel2.Location = new System.Drawing.Point(1, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(1516, 49);
            this.guna2Panel2.TabIndex = 139;
            // 
            // StudentTimeTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1515, 810);
            this.Controls.Add(this.reportViewer2);
            this.Controls.Add(this.btngenarate);
            this.Controls.Add(this.comboGroup);
            this.Controls.Add(this.gunaLabel1);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2Panel3);
            this.Controls.Add(this.guna2Panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StudentTimeTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StudentTimeTable";
            this.Load += new System.EventHandler(this.StudentTimeTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private Guna.UI2.WinForms.Guna2CircleButton closebtn4;
        private System.Windows.Forms.Label lblDateTime;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label labelBottom;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Button home3btn;
        private Guna.UI2.WinForms.Guna2Button btngenarate;
        private Guna.UI2.WinForms.Guna2ComboBox comboGroup;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
    }
}