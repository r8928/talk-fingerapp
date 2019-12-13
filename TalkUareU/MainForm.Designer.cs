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
            this.listView1 = new System.Windows.Forms.ListView();
            this.list_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.list_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.list_status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.list_clock = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.list_lunchin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.list_lunchout = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.list_clockout = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_PunchIn = new System.Windows.Forms.Button();
            this.btn_ChecinDetails = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btn_getToken = new System.Windows.Forms.Button();
            this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_ModuleName = new System.Windows.Forms.Label();
            this.lbl_SapName = new System.Windows.Forms.Label();
            this.btn_Admin = new System.Windows.Forms.Button();
            this.pic_logo = new System.Windows.Forms.PictureBox();
            this.btn_refresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.list_id,
            this.list_name,
            this.list_status,
            this.list_clock,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.list_lunchin,
            this.list_lunchout,
            this.list_clockout});
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 126);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(776, 305);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.Visible = false;
            // 
            // list_id
            // 
            this.list_id.Text = "ID";
            this.list_id.Width = 0;
            // 
            // list_name
            // 
            this.list_name.Text = "Name";
            this.list_name.Width = 250;
            // 
            // list_status
            // 
            this.list_status.Text = "Status";
            this.list_status.Width = 150;
            // 
            // list_clock
            // 
            this.list_clock.Text = "Clockin Time";
            this.list_clock.Width = 170;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 0;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 0;
            // 
            // list_lunchin
            // 
            this.list_lunchin.Text = "Lunch In";
            this.list_lunchin.Width = 170;
            // 
            // list_lunchout
            // 
            this.list_lunchout.Text = "Lunch Out";
            this.list_lunchout.Width = 170;
            // 
            // list_clockout
            // 
            this.list_clockout.Text = "Clock Out";
            this.list_clockout.Width = 170;
            // 
            // id
            // 
            this.id.Text = "id";
            this.id.Width = 1;
            // 
            // btn_PunchIn
            // 
            this.btn_PunchIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_PunchIn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_PunchIn.Location = new System.Drawing.Point(664, 437);
            this.btn_PunchIn.Name = "btn_PunchIn";
            this.btn_PunchIn.Size = new System.Drawing.Size(124, 31);
            this.btn_PunchIn.TabIndex = 0;
            this.btn_PunchIn.Text = "New Punch In";
            this.btn_PunchIn.UseVisualStyleBackColor = false;
            this.btn_PunchIn.Click += new System.EventHandler(this.btn_PunchIn_Click);
            // 
            // btn_ChecinDetails
            // 
            this.btn_ChecinDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_ChecinDetails.AutoSize = true;
            this.btn_ChecinDetails.Location = new System.Drawing.Point(12, 552);
            this.btn_ChecinDetails.Name = "btn_ChecinDetails";
            this.btn_ChecinDetails.Size = new System.Drawing.Size(278, 42);
            this.btn_ChecinDetails.TabIndex = 12;
            this.btn_ChecinDetails.Text = "GET CHECKING DETAILS";
            this.btn_ChecinDetails.UseVisualStyleBackColor = true;
            this.btn_ChecinDetails.Click += new System.EventHandler(this.GetCheckinDetails);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 474);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(776, 83);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "";
            // 
            // btn_getToken
            // 
            this.btn_getToken.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_getToken.AutoSize = true;
            this.btn_getToken.Location = new System.Drawing.Point(12, 663);
            this.btn_getToken.Name = "btn_getToken";
            this.btn_getToken.Size = new System.Drawing.Size(124, 42);
            this.btn_getToken.TabIndex = 15;
            this.btn_getToken.Text = "getToken";
            this.btn_getToken.UseVisualStyleBackColor = true;
            this.btn_getToken.Click += new System.EventHandler(this.btnGetToken_Click);
            // 
            // flowPanel
            // 
            this.flowPanel.Location = new System.Drawing.Point(12, 126);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Size = new System.Drawing.Size(776, 305);
            this.flowPanel.TabIndex = 17;
            // 
            // lbl_ModuleName
            // 
            this.lbl_ModuleName.AutoSize = true;
            this.lbl_ModuleName.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ModuleName.Location = new System.Drawing.Point(4, 9);
            this.lbl_ModuleName.Name = "lbl_ModuleName";
            this.lbl_ModuleName.Size = new System.Drawing.Size(302, 45);
            this.lbl_ModuleName.TabIndex = 8;
            this.lbl_ModuleName.Text = "Attendance Module";
            // 
            // lbl_SapName
            // 
            this.lbl_SapName.AutoSize = true;
            this.lbl_SapName.Location = new System.Drawing.Point(8, 54);
            this.lbl_SapName.Name = "lbl_SapName";
            this.lbl_SapName.Size = new System.Drawing.Size(295, 21);
            this.lbl_SapName.TabIndex = 18;
            this.lbl_SapName.Text = "No location signed in, please click refresh";
            // 
            // btn_Admin
            // 
            this.btn_Admin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Admin.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Admin.BackgroundImage = global::TalkUareU.Properties.Resources.gear;
            this.btn_Admin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Admin.Location = new System.Drawing.Point(757, 92);
            this.btn_Admin.Name = "btn_Admin";
            this.btn_Admin.Size = new System.Drawing.Size(31, 28);
            this.btn_Admin.TabIndex = 0;
            this.btn_Admin.UseVisualStyleBackColor = false;
            this.btn_Admin.Click += new System.EventHandler(this.btn_Admin_Click);
            // 
            // pic_logo
            // 
            this.pic_logo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_logo.Image = global::TalkUareU.Properties.Resources.talk_logo;
            this.pic_logo.Location = new System.Drawing.Point(588, 9);
            this.pic_logo.Name = "pic_logo";
            this.pic_logo.Size = new System.Drawing.Size(200, 67);
            this.pic_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pic_logo.TabIndex = 7;
            this.pic_logo.TabStop = false;
            // 
            // btn_refresh
            // 
            this.btn_refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_refresh.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_refresh.BackgroundImage = global::TalkUareU.Properties.Resources.refresh;
            this.btn_refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_refresh.Location = new System.Drawing.Point(720, 92);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(31, 28);
            this.btn_refresh.TabIndex = 19;
            this.btn_refresh.UseVisualStyleBackColor = false;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 732);
            this.Controls.Add(this.btn_Admin);
            this.Controls.Add(this.lbl_SapName);
            this.Controls.Add(this.flowPanel);
            this.Controls.Add(this.btn_getToken);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btn_ChecinDetails);
            this.Controls.Add(this.lbl_ModuleName);
            this.Controls.Add(this.pic_logo);
            this.Controls.Add(this.btn_PunchIn);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.listView1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attendance Module | Talk Mobile";
            ((System.ComponentModel.ISupportInitialize)(this.pic_logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader list_id;
        private System.Windows.Forms.ColumnHeader list_name;
        private System.Windows.Forms.ColumnHeader list_clock;
        private System.Windows.Forms.ColumnHeader list_status;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader list_lunchin;
        private System.Windows.Forms.ColumnHeader list_lunchout;
        private System.Windows.Forms.ColumnHeader list_clockout;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Button btn_PunchIn;
        private System.Windows.Forms.PictureBox pic_logo;
        private System.Windows.Forms.Label lbl_ModuleName;
        private System.Windows.Forms.Button btn_ChecinDetails;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btn_getToken;
        private System.Windows.Forms.FlowLayoutPanel flowPanel;
        private System.Windows.Forms.Label lbl_SapName;
        private System.Windows.Forms.Button btn_Admin;
    }
}