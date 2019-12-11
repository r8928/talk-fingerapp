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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
            this.btn_refresh = new System.Windows.Forms.Button();
            this.btn_PunchIn = new System.Windows.Forms.Button();
            this.btn_PunchOut = new System.Windows.Forms.Button();
            this.btn_LunchOut = new System.Windows.Forms.Button();
            this.btn_LunchIn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_SAP = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.txt_token = new System.Windows.Forms.TextBox();
            this.btn_getToken = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.GotFocus += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.LostFocus += new System.EventHandler(this.list_LostFocusEvent);
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
            // btn_refresh
            // 
            this.btn_refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_refresh.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_refresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_refresh.BackgroundImage")));
            this.btn_refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_refresh.Location = new System.Drawing.Point(757, 92);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(31, 28);
            this.btn_refresh.TabIndex = 4;
            this.btn_refresh.UseVisualStyleBackColor = false;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
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
            // btn_PunchOut
            // 
            this.btn_PunchOut.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_PunchOut.Enabled = false;
            this.btn_PunchOut.Location = new System.Drawing.Point(212, 89);
            this.btn_PunchOut.Name = "btn_PunchOut";
            this.btn_PunchOut.Size = new System.Drawing.Size(94, 31);
            this.btn_PunchOut.TabIndex = 3;
            this.btn_PunchOut.Text = "Punch Out";
            this.btn_PunchOut.UseVisualStyleBackColor = false;
            this.btn_PunchOut.Click += new System.EventHandler(this.btn_PunchOut_Click);
            // 
            // btn_LunchOut
            // 
            this.btn_LunchOut.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_LunchOut.Enabled = false;
            this.btn_LunchOut.Location = new System.Drawing.Point(12, 89);
            this.btn_LunchOut.Name = "btn_LunchOut";
            this.btn_LunchOut.Size = new System.Drawing.Size(94, 31);
            this.btn_LunchOut.TabIndex = 1;
            this.btn_LunchOut.Text = "Lunch Out";
            this.btn_LunchOut.UseVisualStyleBackColor = false;
            this.btn_LunchOut.Click += new System.EventHandler(this.btn_LunchOut_Click);
            // 
            // btn_LunchIn
            // 
            this.btn_LunchIn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_LunchIn.Enabled = false;
            this.btn_LunchIn.Location = new System.Drawing.Point(112, 89);
            this.btn_LunchIn.Name = "btn_LunchIn";
            this.btn_LunchIn.Size = new System.Drawing.Size(94, 31);
            this.btn_LunchIn.TabIndex = 2;
            this.btn_LunchIn.Text = "Lunch In";
            this.btn_LunchIn.UseVisualStyleBackColor = false;
            this.btn_LunchIn.Click += new System.EventHandler(this.btn_LunchIn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(588, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 45);
            this.label1.TabIndex = 8;
            this.label1.Text = "Attendance Module";
            // 
            // txt_SAP
            // 
            this.txt_SAP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_SAP.Location = new System.Drawing.Point(12, 603);
            this.txt_SAP.Name = "txt_SAP";
            this.txt_SAP.Size = new System.Drawing.Size(100, 29);
            this.txt_SAP.TabIndex = 11;
            this.txt_SAP.Text = "2036";
            this.txt_SAP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_SAP_TextChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(12, 563);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 31);
            this.button1.TabIndex = 12;
            this.button1.Text = "GET CHECKING DETAILS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // txt_token
            // 
            this.txt_token.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_token.Location = new System.Drawing.Point(13, 639);
            this.txt_token.Name = "txt_token";
            this.txt_token.Size = new System.Drawing.Size(775, 29);
            this.txt_token.TabIndex = 14;
            this.txt_token.TextChanged += new System.EventHandler(this.txt_token_TextChanged);
            // 
            // btn_getToken
            // 
            this.btn_getToken.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_getToken.AutoSize = true;
            this.btn_getToken.Location = new System.Drawing.Point(12, 674);
            this.btn_getToken.Name = "btn_getToken";
            this.btn_getToken.Size = new System.Drawing.Size(84, 31);
            this.btn_getToken.TabIndex = 15;
            this.btn_getToken.Text = "getToken";
            this.btn_getToken.UseVisualStyleBackColor = true;
            this.btn_getToken.Click += new System.EventHandler(this.btnGetToken_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 732);
            this.Controls.Add(this.btn_getToken);
            this.Controls.Add(this.txt_token);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_SAP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_LunchIn);
            this.Controls.Add(this.btn_LunchOut);
            this.Controls.Add(this.btn_PunchOut);
            this.Controls.Add(this.btn_PunchIn);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.listView1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attendance Module | Talk Mobile";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Button btn_PunchOut;
        private System.Windows.Forms.Button btn_LunchOut;
        private System.Windows.Forms.Button btn_LunchIn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_SAP;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox txt_token;
        private System.Windows.Forms.Button btn_getToken;
    }
}

