namespace TalkUareU
{
    partial class ClockSelectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClockSelectionForm));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_LunchOut = new System.Windows.Forms.Button();
            this.btn_LunchIn = new System.Windows.Forms.Button();
            this.btn_ClockOut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Message = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(0, 0);
            // 
            // btn_LunchOut
            // 
            this.btn_LunchOut.Image = global::TalkUareU.Properties.Resources.lunchout32;
            this.btn_LunchOut.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_LunchOut.Location = new System.Drawing.Point(10, 10);
            this.btn_LunchOut.Margin = new System.Windows.Forms.Padding(10);
            this.btn_LunchOut.Name = "btn_LunchOut";
            this.btn_LunchOut.Size = new System.Drawing.Size(65, 65);
            this.btn_LunchOut.Text = "Lunch Out";
            this.btn_LunchOut.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btn_LunchIn
            // 
            this.btn_LunchIn.Image = global::TalkUareU.Properties.Resources.checkin32;
            this.btn_LunchIn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_LunchIn.Location = new System.Drawing.Point(95, 10);
            this.btn_LunchIn.Margin = new System.Windows.Forms.Padding(10);
            this.btn_LunchIn.Name = "btn_LunchIn";
            this.btn_LunchIn.Size = new System.Drawing.Size(65, 65);
            this.btn_LunchIn.Text = "Lunch In";
            this.btn_LunchIn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btn_ClockOut
            // 
            this.btn_ClockOut.Image = global::TalkUareU.Properties.Resources.checkout32;
            this.btn_ClockOut.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_ClockOut.Location = new System.Drawing.Point(180, 10);
            this.btn_ClockOut.Margin = new System.Windows.Forms.Padding(10);
            this.btn_ClockOut.Name = "btn_ClockOut";
            this.btn_ClockOut.Size = new System.Drawing.Size(65, 65);
            this.btn_ClockOut.Text = "ClockOut";
            this.btn_ClockOut.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            // 
            // lbl_Message
            // 
            this.lbl_Message.Location = new System.Drawing.Point(27, 0);
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.Size = new System.Drawing.Size(264, 74);
            this.lbl_Message.Text = "";
            // 
            // ClockSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(283, 114);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ClockSelectionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Message;
        private System.Windows.Forms.Button btn_LunchOut;
        private System.Windows.Forms.Button btn_LunchIn;
        private System.Windows.Forms.Button btn_ClockOut;
    }
}