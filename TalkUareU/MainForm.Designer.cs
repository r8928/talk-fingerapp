namespace TalkUareU
{
    partial class MainForm
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
            this.btn_CheckinDetails = new System.Windows.Forms.Button();
            this.btn_getToken = new System.Windows.Forms.Button();
            this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_ModuleName = new System.Windows.Forms.Label();
            this.lbl_SapName = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btn_Admin = new System.Windows.Forms.Button();
            this.btn_PunchIn = new System.Windows.Forms.Button();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.pic_logo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_CheckinDetails
            // 
            this.btn_CheckinDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CheckinDetails.AutoSize = true;
            this.btn_CheckinDetails.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_CheckinDetails.Location = new System.Drawing.Point(411, 44);
            this.btn_CheckinDetails.Name = "btn_CheckinDetails";
            this.btn_CheckinDetails.Size = new System.Drawing.Size(188, 31);
            this.btn_CheckinDetails.TabIndex = 5;
            this.btn_CheckinDetails.Text = "GET CHECKING DETAILS";
            this.btn_CheckinDetails.UseVisualStyleBackColor = true;
            this.btn_CheckinDetails.Click += new System.EventHandler(this.GetCheckinDetails);
            // 
            // btn_getToken
            // 
            this.btn_getToken.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_getToken.AutoSize = true;
            this.btn_getToken.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_getToken.Location = new System.Drawing.Point(515, 7);
            this.btn_getToken.Name = "btn_getToken";
            this.btn_getToken.Size = new System.Drawing.Size(84, 31);
            this.btn_getToken.TabIndex = 3;
            this.btn_getToken.Text = "getToken";
            this.btn_getToken.UseVisualStyleBackColor = true;
            this.btn_getToken.Click += new System.EventHandler(this.btnGetToken_Click);
            // 
            // flowPanel
            // 
            this.flowPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowPanel.AutoScroll = true;
            this.flowPanel.Location = new System.Drawing.Point(12, 150);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Size = new System.Drawing.Size(793, 300);
            this.flowPanel.TabIndex = 2;
            // 
            // lbl_ModuleName
            // 
            this.lbl_ModuleName.AutoSize = true;
            this.lbl_ModuleName.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ModuleName.Location = new System.Drawing.Point(4, 9);
            this.lbl_ModuleName.Name = "lbl_ModuleName";
            this.lbl_ModuleName.Size = new System.Drawing.Size(302, 45);
            this.lbl_ModuleName.TabIndex = 6;
            this.lbl_ModuleName.Text = "Attendance Module";
            // 
            // lbl_SapName
            // 
            this.lbl_SapName.AutoSize = true;
            this.lbl_SapName.Location = new System.Drawing.Point(8, 54);
            this.lbl_SapName.Name = "lbl_SapName";
            this.lbl_SapName.Size = new System.Drawing.Size(295, 21);
            this.lbl_SapName.TabIndex = 1;
            this.lbl_SapName.Text = "No location signed in, please click refresh";
            // 
            // btn_Admin
            // 
            this.btn_Admin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Admin.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Admin.BackgroundImage = global::TalkUareU.Properties.Resources.gear;
            this.btn_Admin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Admin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Admin.Location = new System.Drawing.Point(774, 82);
            this.btn_Admin.Name = "btn_Admin";
            this.btn_Admin.Size = new System.Drawing.Size(31, 28);
            this.btn_Admin.TabIndex = 0;
            this.btn_Admin.TabStop = false;
            this.toolTip1.SetToolTip(this.btn_Admin, "Administrative options");
            this.btn_Admin.UseVisualStyleBackColor = true;
            this.btn_Admin.Click += new System.EventHandler(this.btn_Admin_Click);
            // 
            // btn_PunchIn
            // 
            this.btn_PunchIn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_PunchIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_PunchIn.Image = global::TalkUareU.Properties.Resources.checkin32;
            this.btn_PunchIn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_PunchIn.Location = new System.Drawing.Point(12, 84);
            this.btn_PunchIn.Name = "btn_PunchIn";
            this.btn_PunchIn.Size = new System.Drawing.Size(114, 60);
            this.btn_PunchIn.TabIndex = 8;
            this.btn_PunchIn.Text = "New Punch In";
            this.btn_PunchIn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btn_PunchIn, "Punch in another employee");
            this.btn_PunchIn.UseVisualStyleBackColor = true;
            this.btn_PunchIn.Click += new System.EventHandler(this.btn_PunchIn_Click);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_refresh.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_refresh.BackgroundImage = global::TalkUareU.Properties.Resources.refresh;
            this.btn_refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_refresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_refresh.Location = new System.Drawing.Point(774, 116);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(31, 28);
            this.btn_refresh.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btn_refresh, "Refresh punched employees list");
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // pic_logo
            // 
            this.pic_logo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_logo.Image = global::TalkUareU.Properties.Resources.talk_logo;
            this.pic_logo.Location = new System.Drawing.Point(605, 9);
            this.pic_logo.Name = "pic_logo";
            this.pic_logo.Size = new System.Drawing.Size(200, 67);
            this.pic_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pic_logo.TabIndex = 7;
            this.pic_logo.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(817, 462);
            this.Controls.Add(this.btn_Admin);
            this.Controls.Add(this.lbl_SapName);
            this.Controls.Add(this.flowPanel);
            this.Controls.Add(this.btn_getToken);
            this.Controls.Add(this.btn_CheckinDetails);
            this.Controls.Add(this.lbl_ModuleName);
            this.Controls.Add(this.pic_logo);
            this.Controls.Add(this.btn_PunchIn);
            this.Controls.Add(this.btn_refresh);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attendance Module | Talk Mobile";
            ((System.ComponentModel.ISupportInitialize)(this.pic_logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Button btn_PunchIn;
        private System.Windows.Forms.PictureBox pic_logo;
        private System.Windows.Forms.Label lbl_ModuleName;
        private System.Windows.Forms.Button btn_CheckinDetails;
        private System.Windows.Forms.Button btn_getToken;
        private System.Windows.Forms.FlowLayoutPanel flowPanel;
        private System.Windows.Forms.Label lbl_SapName;
        private System.Windows.Forms.Button btn_Admin;
        private System.Windows.Forms.ToolTip toolTip1;

    }
}