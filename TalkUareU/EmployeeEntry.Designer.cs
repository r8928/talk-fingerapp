namespace TalkUareU
{
    partial class EmployeeEntry
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_Name = new System.Windows.Forms.Label();
            this.lbl_timeString = new System.Windows.Forms.Label();
            this.pic_Icon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Icon)).BeginInit();
            this.SuspendLayout();
            //
            // lbl_Name
            //
            this.lbl_Name.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Name.Location = new System.Drawing.Point(50, 0);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(440, 23);
            this.lbl_Name.TabIndex = 0;
            this.lbl_Name.Text = "Jose Hernandez";
            //
            // lbl_timeString
            //
            this.lbl_timeString.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_timeString.Location = new System.Drawing.Point(50, 25);
            this.lbl_timeString.Name = "lbl_timeString";
            this.lbl_timeString.Size = new System.Drawing.Size(440, 23);
            this.lbl_timeString.TabIndex = 0;
            this.lbl_timeString.Text = "label1";
            //
            // pic_Icon
            //
            this.pic_Icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_Icon.Location = new System.Drawing.Point(10, 10);
            this.pic_Icon.Name = "pic_Icon";
            this.pic_Icon.Size = new System.Drawing.Size(30, 30);
            this.pic_Icon.TabIndex = 0;
            this.pic_Icon.TabStop = false;
            //
            // EmployeeEntry
            //
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Size = new System.Drawing.Size(380, 50);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Icon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Label lbl_timeString;
        private System.Windows.Forms.PictureBox pic_Icon;
    }
}