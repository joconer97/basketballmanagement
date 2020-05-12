namespace BATMAN
{
    partial class UCMatch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCMatch));
            this.pcbHome = new System.Windows.Forms.PictureBox();
            this.pcbGuest = new System.Windows.Forms.PictureBox();
            this.lblHomeTeam = new System.Windows.Forms.Label();
            this.lblGuestTeam = new System.Windows.Forms.Label();
            this.lblHomeBrgy = new System.Windows.Forms.Label();
            this.lblGuestBrgy = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pcbHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbGuest)).BeginInit();
            this.SuspendLayout();
            // 
            // pcbHome
            // 
            this.pcbHome.Location = new System.Drawing.Point(113, 12);
            this.pcbHome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pcbHome.Name = "pcbHome";
            this.pcbHome.Size = new System.Drawing.Size(155, 155);
            this.pcbHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbHome.TabIndex = 0;
            this.pcbHome.TabStop = false;
            // 
            // pcbGuest
            // 
            this.pcbGuest.Location = new System.Drawing.Point(809, 12);
            this.pcbGuest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pcbGuest.Name = "pcbGuest";
            this.pcbGuest.Size = new System.Drawing.Size(155, 155);
            this.pcbGuest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbGuest.TabIndex = 1;
            this.pcbGuest.TabStop = false;
            // 
            // lblHomeTeam
            // 
            this.lblHomeTeam.AutoSize = true;
            this.lblHomeTeam.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHomeTeam.Location = new System.Drawing.Point(57, 178);
            this.lblHomeTeam.Name = "lblHomeTeam";
            this.lblHomeTeam.Size = new System.Drawing.Size(123, 33);
            this.lblHomeTeam.TabIndex = 2;
            this.lblHomeTeam.Text = "label1";
            // 
            // lblGuestTeam
            // 
            this.lblGuestTeam.AutoSize = true;
            this.lblGuestTeam.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuestTeam.Location = new System.Drawing.Point(759, 178);
            this.lblGuestTeam.Name = "lblGuestTeam";
            this.lblGuestTeam.Size = new System.Drawing.Size(123, 33);
            this.lblGuestTeam.TabIndex = 3;
            this.lblGuestTeam.Text = "label2";
            // 
            // lblHomeBrgy
            // 
            this.lblHomeBrgy.AutoSize = true;
            this.lblHomeBrgy.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHomeBrgy.Location = new System.Drawing.Point(60, 242);
            this.lblHomeBrgy.Name = "lblHomeBrgy";
            this.lblHomeBrgy.Size = new System.Drawing.Size(82, 22);
            this.lblHomeBrgy.TabIndex = 4;
            this.lblHomeBrgy.Text = "label1";
            // 
            // lblGuestBrgy
            // 
            this.lblGuestBrgy.AutoSize = true;
            this.lblGuestBrgy.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuestBrgy.Location = new System.Drawing.Point(884, 242);
            this.lblGuestBrgy.Name = "lblGuestBrgy";
            this.lblGuestBrgy.Size = new System.Drawing.Size(82, 22);
            this.lblGuestBrgy.TabIndex = 5;
            this.lblGuestBrgy.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(460, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 85);
            this.label1.TabIndex = 6;
            this.label1.Text = "VS";
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Location = new System.Drawing.Point(1057, 178);
            this.btnView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(217, 70);
            this.btnView.TabIndex = 7;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(1107, 31);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(96, 27);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Status";
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(1057, 97);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(217, 70);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // UCMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblGuestBrgy);
            this.Controls.Add(this.lblHomeBrgy);
            this.Controls.Add(this.lblGuestTeam);
            this.Controls.Add(this.lblHomeTeam);
            this.Controls.Add(this.pcbGuest);
            this.Controls.Add(this.pcbHome);
            this.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.Name = "UCMatch";
            this.Size = new System.Drawing.Size(1322, 284);
            this.Load += new System.EventHandler(this.UCMatch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbGuest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pcbHome;
        private System.Windows.Forms.PictureBox pcbGuest;
        private System.Windows.Forms.Label lblHomeTeam;
        private System.Windows.Forms.Label lblGuestTeam;
        private System.Windows.Forms.Label lblHomeBrgy;
        private System.Windows.Forms.Label lblGuestBrgy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnPrint;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}
