namespace TalkUareU
{
    partial class EnrollmentForm
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
            this.CloseButton = new System.Windows.Forms.Button();
            this.enrollControl = new DPFP.Gui.Enrollment.EnrollmentControl();
            this.pnl_Validation = new System.Windows.Forms.Panel();
            this.btn_ValidateUser = new System.Windows.Forms.Button();
            this.lbl_Token = new System.Windows.Forms.Label();
            this.lbl_Username = new System.Windows.Forms.Label();
            this.txt_Token = new System.Windows.Forms.TextBox();
            this.txt_Username = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ListEvents = new System.Windows.Forms.ListBox();
            this.pnl_Validation.SuspendLayout();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CloseButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(10, 274);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(100, 30);
            this.CloseButton.TabIndex = 6;
            this.CloseButton.Text = "&Close";
            this.CloseButton.UseVisualStyleBackColor = false;
            // 
            // enrollControl
            // 
            this.enrollControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.enrollControl.EnrolledFingerMask = 0;
            this.enrollControl.Location = new System.Drawing.Point(2, 2);
            this.enrollControl.MaxEnrollFingerCount = 1;
            this.enrollControl.Name = "enrollControl";
            this.enrollControl.ReaderSerialNumber = "00000000-0000-0000-0000-000000000000";
            this.enrollControl.Size = new System.Drawing.Size(492, 314);
            this.enrollControl.TabIndex = 999;
            this.enrollControl.OnDelete += new DPFP.Gui.Enrollment.EnrollmentControl._OnDelete(this.EnrollmentControl_OnDelete);
            this.enrollControl.OnEnroll += new DPFP.Gui.Enrollment.EnrollmentControl._OnEnroll(this.EnrollmentControl_OnEnroll);
            this.enrollControl.OnFingerTouch += new DPFP.Gui.Enrollment.EnrollmentControl._OnFingerTouch(this.EnrollmentControl_OnFingerTouch);
            this.enrollControl.OnFingerRemove += new DPFP.Gui.Enrollment.EnrollmentControl._OnFingerRemove(this.EnrollmentControl_OnFingerRemove);
            this.enrollControl.OnComplete += new DPFP.Gui.Enrollment.EnrollmentControl._OnComplete(this.EnrollmentControl_OnComplete);
            this.enrollControl.OnReaderConnect += new DPFP.Gui.Enrollment.EnrollmentControl._OnReaderConnect(this.EnrollmentControl_OnReaderConnect);
            this.enrollControl.OnReaderDisconnect += new DPFP.Gui.Enrollment.EnrollmentControl._OnReaderDisconnect(this.EnrollmentControl_OnReaderDisconnect);
            this.enrollControl.OnSampleQuality += new DPFP.Gui.Enrollment.EnrollmentControl._OnSampleQuality(this.EnrollmentControl_OnSampleQuality);
            this.enrollControl.OnStartEnroll += new DPFP.Gui.Enrollment.EnrollmentControl._OnStartEnroll(this.EnrollmentControl_OnStartEnroll);
            this.enrollControl.OnCancelEnroll += new DPFP.Gui.Enrollment.EnrollmentControl._OnCancelEnroll(this.EnrollmentControl_OnCancelEnroll);
            // 
            // pnl_Validation
            // 
            this.pnl_Validation.Controls.Add(this.btn_ValidateUser);
            this.pnl_Validation.Controls.Add(this.lbl_Token);
            this.pnl_Validation.Controls.Add(this.lbl_Username);
            this.pnl_Validation.Controls.Add(this.txt_Token);
            this.pnl_Validation.Controls.Add(this.txt_Username);
            this.pnl_Validation.Controls.Add(this.label1);
            this.pnl_Validation.Controls.Add(this.ListEvents);
            this.pnl_Validation.Location = new System.Drawing.Point(2, 2);
            this.pnl_Validation.Name = "pnl_Validation";
            this.pnl_Validation.Size = new System.Drawing.Size(495, 314);
            this.pnl_Validation.TabIndex = 999;
            // 
            // btn_ValidateUser
            // 
            this.btn_ValidateUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ValidateUser.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_ValidateUser.Location = new System.Drawing.Point(386, 274);
            this.btn_ValidateUser.Name = "btn_ValidateUser";
            this.btn_ValidateUser.Size = new System.Drawing.Size(100, 30);
            this.btn_ValidateUser.TabIndex = 5;
            this.btn_ValidateUser.Text = "&Next";
            this.btn_ValidateUser.UseVisualStyleBackColor = false;
            this.btn_ValidateUser.Click += new System.EventHandler(this.btn_ValidateUser_Click);
            // 
            // lbl_Token
            // 
            this.lbl_Token.AutoSize = true;
            this.lbl_Token.Location = new System.Drawing.Point(26, 172);
            this.lbl_Token.Name = "lbl_Token";
            this.lbl_Token.Size = new System.Drawing.Size(140, 21);
            this.lbl_Token.TabIndex = 3;
            this.lbl_Token.Text = "Registration Token";
            // 
            // lbl_Username
            // 
            this.lbl_Username.AutoSize = true;
            this.lbl_Username.Location = new System.Drawing.Point(26, 137);
            this.lbl_Username.Name = "lbl_Username";
            this.lbl_Username.Size = new System.Drawing.Size(81, 21);
            this.lbl_Username.TabIndex = 1;
            this.lbl_Username.Text = "Username";
            // 
            // txt_Token
            // 
            this.txt_Token.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Token.Location = new System.Drawing.Point(172, 172);
            this.txt_Token.Name = "txt_Token";
            this.txt_Token.Size = new System.Drawing.Size(284, 26);
            this.txt_Token.TabIndex = 4;
            // 
            // txt_Username
            // 
            this.txt_Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Username.Location = new System.Drawing.Point(172, 137);
            this.txt_Username.Name = "txt_Username";
            this.txt_Username.Size = new System.Drawing.Size(284, 26);
            this.txt_Username.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(3, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(490, 173);
            this.label1.TabIndex = 999;
            this.label1.Text = "Please enter the username and registration token to register.\nIf you don\'t have r" +
    "egistration token please contact HR department.";
            // 
            // ListEvents
            // 
            this.ListEvents.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ListEvents.FormattingEnabled = true;
            this.ListEvents.ItemHeight = 21;
            this.ListEvents.Location = new System.Drawing.Point(3, 223);
            this.ListEvents.Name = "ListEvents";
            this.ListEvents.Size = new System.Drawing.Size(440, 46);
            this.ListEvents.TabIndex = 999;
            this.ListEvents.Visible = false;
            // 
            // EnrollmentForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.CloseButton;
            this.AcceptButton = this.btn_ValidateUser;
            this.ClientSize = new System.Drawing.Size(500, 318);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.pnl_Validation);
            this.Controls.Add(this.enrollControl);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnrollmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fingerprint Enrollment";
            this.Load += new System.EventHandler(this.EnrollmentForm_Load);
            this.pnl_Validation.ResumeLayout(false);
            this.pnl_Validation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DPFP.Gui.Enrollment.EnrollmentControl enrollControl;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Panel pnl_Validation;
        private System.Windows.Forms.TextBox txt_Username;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Token;
        private System.Windows.Forms.Button btn_ValidateUser;
        private System.Windows.Forms.Label lbl_Token;
        private System.Windows.Forms.Label lbl_Username;
        private System.Windows.Forms.ListBox ListEvents;
    }
}