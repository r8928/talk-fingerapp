namespace TalkUareU
{
    partial class Form1
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
            this.employeeEntry1 = new TalkUareU.EmployeeEntry();
            this.SuspendLayout();
            // 
            // employeeEntry1
            // 
            this.employeeEntry1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.employeeEntry1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.employeeEntry1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeEntry1.Location = new System.Drawing.Point(12, 12);
            this.employeeEntry1.Name = "employeeEntry1";
            this.employeeEntry1.Size = new System.Drawing.Size(500, 50);
            this.employeeEntry1.TabIndex = 0;
            this.employeeEntry1.Click += new System.EventHandler(this.employeeEntry1_Click);
            this.employeeEntry1.Paint += new System.Windows.Forms.PaintEventHandler(this.employeeEntry1_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.employeeEntry1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private EmployeeEntry employeeEntry1;
    }
}