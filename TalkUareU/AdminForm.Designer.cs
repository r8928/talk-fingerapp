namespace TalkUareU
{
    partial class AdminForm
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
            this.btn_RegisterApp = new System.Windows.Forms.Button();
            this.chk_Debugging = new System.Windows.Forms.CheckBox();
            this.chk_RequireFinger = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_RegisterApp
            // 
            this.btn_RegisterApp.Location = new System.Drawing.Point(19, 19);
            this.btn_RegisterApp.Margin = new System.Windows.Forms.Padding(10);
            this.btn_RegisterApp.Name = "btn_RegisterApp";
            this.btn_RegisterApp.Size = new System.Drawing.Size(248, 29);
            this.btn_RegisterApp.TabIndex = 1;
            this.btn_RegisterApp.Text = "Register This App";
            this.btn_RegisterApp.Click += new System.EventHandler(this.btn_RegisterApp_Click);
            // 
            // chk_Debugging
            // 
            this.chk_Debugging.AutoSize = true;
            this.chk_Debugging.Location = new System.Drawing.Point(19, 61);
            this.chk_Debugging.Name = "chk_Debugging";
            this.chk_Debugging.Size = new System.Drawing.Size(181, 25);
            this.chk_Debugging.TabIndex = 0;
            this.chk_Debugging.Text = "Allow http debug logs";
            this.chk_Debugging.CheckedChanged += new System.EventHandler(this.chk_Debugging_CheckedChanged);
            // 
            // chk_RequireFinger
            // 
            this.chk_RequireFinger.AutoSize = true;
            this.chk_RequireFinger.Location = new System.Drawing.Point(19, 92);
            this.chk_RequireFinger.Name = "chk_RequireFinger";
            this.chk_RequireFinger.Size = new System.Drawing.Size(255, 25);
            this.chk_RequireFinger.TabIndex = 2;
            this.chk_RequireFinger.Text = "Fingerprint required for punches";
            this.chk_RequireFinger.CheckedChanged += new System.EventHandler(this.chk_RequireFinger_CheckedChanged);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(278, 150);
            this.Controls.Add(this.chk_RequireFinger);
            this.Controls.Add(this.chk_Debugging);
            this.Controls.Add(this.btn_RegisterApp);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AdminForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_RegisterApp;
        private System.Windows.Forms.CheckBox chk_Debugging;
        private System.Windows.Forms.CheckBox chk_RequireFinger;
    }
}