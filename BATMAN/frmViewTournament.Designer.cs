namespace BATMAN
{
    partial class frmViewTournament
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewTournament));
            this.lvwTournaments = new System.Windows.Forms.ListView();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExportTeamRooster = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtTournament = new System.Windows.Forms.TextBox();
            this.btnActivate = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTournamentStatus = new System.Windows.Forms.Label();
            this.lblTournamentDate = new System.Windows.Forms.Label();
            this.lblTournamentTitle = new System.Windows.Forms.Label();
            this.lblTournamentMotto = new System.Windows.Forms.Label();
            this.lblMotto = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwTournaments
            // 
            this.lvwTournaments.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwTournaments.Location = new System.Drawing.Point(1, 0);
            this.lvwTournaments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvwTournaments.Name = "lvwTournaments";
            this.lvwTournaments.Size = new System.Drawing.Size(667, 593);
            this.lvwTournaments.TabIndex = 0;
            this.lvwTournaments.UseCompatibleStateImageBehavior = false;
            this.lvwTournaments.SelectedIndexChanged += new System.EventHandler(this.lvwTournaments_SelectedIndexChanged);
            this.lvwTournaments.DoubleClick += new System.EventHandler(this.lvwTournaments_DoubleClick);
            // 
            // btnCreate
            // 
            this.btnCreate.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(1, 611);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(205, 39);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Create Tournament....";
            this.btnCreate.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(233, 611);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(205, 39);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Update Tournament....";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(463, 611);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(205, 39);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete Tournament";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.btnExportTeamRooster);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.txtTournament);
            this.panel1.Controls.Add(this.btnActivate);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.lblTournamentStatus);
            this.panel1.Controls.Add(this.lblTournamentDate);
            this.panel1.Controls.Add(this.lblTournamentTitle);
            this.panel1.Controls.Add(this.lblTournamentMotto);
            this.panel1.Controls.Add(this.lblMotto);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Location = new System.Drawing.Point(676, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(653, 698);
            this.panel1.TabIndex = 4;
            // 
            // btnExportTeamRooster
            // 
            this.btnExportTeamRooster.Font = new System.Drawing.Font("Courier New", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportTeamRooster.Location = new System.Drawing.Point(18, 635);
            this.btnExportTeamRooster.Name = "btnExportTeamRooster";
            this.btnExportTeamRooster.Size = new System.Drawing.Size(254, 42);
            this.btnExportTeamRooster.TabIndex = 32;
            this.btnExportTeamRooster.Text = "Export Team Rooster";
            this.btnExportTeamRooster.UseVisualStyleBackColor = true;
            this.btnExportTeamRooster.Visible = false;
            this.btnExportTeamRooster.Click += new System.EventHandler(this.btnExportTeamRooster_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(281, 635);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(155, 39);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtTournament
            // 
            this.txtTournament.Font = new System.Drawing.Font("Courier New", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTournament.Location = new System.Drawing.Point(23, 278);
            this.txtTournament.Multiline = true;
            this.txtTournament.Name = "txtTournament";
            this.txtTournament.Size = new System.Drawing.Size(619, 148);
            this.txtTournament.TabIndex = 31;
            this.txtTournament.Text = "None";
            // 
            // btnActivate
            // 
            this.btnActivate.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivate.Location = new System.Drawing.Point(18, 635);
            this.btnActivate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(155, 39);
            this.btnActivate.TabIndex = 20;
            this.btnActivate.Text = "Activate";
            this.btnActivate.UseVisualStyleBackColor = true;
            this.btnActivate.Click += new System.EventHandler(this.btnActivate_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(461, 635);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(181, 37);
            this.btnPrint.TabIndex = 19;
            this.btnPrint.Text = "Print Register Form";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(200, 21);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(44, 46);
            this.lblStatus.TabIndex = 30;
            this.lblStatus.Text = "0";
            // 
            // lblTournamentStatus
            // 
            this.lblTournamentStatus.AutoSize = true;
            this.lblTournamentStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblTournamentStatus.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTournamentStatus.Location = new System.Drawing.Point(15, 21);
            this.lblTournamentStatus.Name = "lblTournamentStatus";
            this.lblTournamentStatus.Size = new System.Drawing.Size(164, 46);
            this.lblTournamentStatus.TabIndex = 23;
            this.lblTournamentStatus.Text = "Status";
            // 
            // lblTournamentDate
            // 
            this.lblTournamentDate.AutoSize = true;
            this.lblTournamentDate.BackColor = System.Drawing.Color.Transparent;
            this.lblTournamentDate.Font = new System.Drawing.Font("Courier New", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTournamentDate.Location = new System.Drawing.Point(147, 181);
            this.lblTournamentDate.Name = "lblTournamentDate";
            this.lblTournamentDate.Size = new System.Drawing.Size(97, 38);
            this.lblTournamentDate.TabIndex = 22;
            this.lblTournamentDate.Text = "None";
            // 
            // lblTournamentTitle
            // 
            this.lblTournamentTitle.AutoSize = true;
            this.lblTournamentTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTournamentTitle.Font = new System.Drawing.Font("Courier New", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTournamentTitle.Location = new System.Drawing.Point(147, 112);
            this.lblTournamentTitle.Name = "lblTournamentTitle";
            this.lblTournamentTitle.Size = new System.Drawing.Size(97, 38);
            this.lblTournamentTitle.TabIndex = 21;
            this.lblTournamentTitle.Text = "None";
            // 
            // lblTournamentMotto
            // 
            this.lblTournamentMotto.AutoSize = true;
            this.lblTournamentMotto.BackColor = System.Drawing.Color.Transparent;
            this.lblTournamentMotto.Font = new System.Drawing.Font("Courier New", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTournamentMotto.Location = new System.Drawing.Point(184, 330);
            this.lblTournamentMotto.Name = "lblTournamentMotto";
            this.lblTournamentMotto.Size = new System.Drawing.Size(0, 38);
            this.lblTournamentMotto.TabIndex = 20;
            // 
            // lblMotto
            // 
            this.lblMotto.AutoSize = true;
            this.lblMotto.BackColor = System.Drawing.Color.Transparent;
            this.lblMotto.Font = new System.Drawing.Font("Courier New", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotto.Location = new System.Drawing.Point(26, 237);
            this.lblMotto.Name = "lblMotto";
            this.lblMotto.Size = new System.Drawing.Size(117, 38);
            this.lblMotto.TabIndex = 19;
            this.lblMotto.Text = "Motto";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Courier New", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(26, 181);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(97, 38);
            this.lblDate.TabIndex = 18;
            this.lblDate.Text = "Date";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Courier New", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(26, 112);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(117, 38);
            this.lblTitle.TabIndex = 17;
            this.lblTitle.Text = "Title";
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
            // frmViewTournament
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 700);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.lvwTournaments);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmViewTournament";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmViewTournament";
            this.Load += new System.EventHandler(this.frmViewTournament_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwTournaments;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTournamentStatus;
        private System.Windows.Forms.Label lblTournamentDate;
        private System.Windows.Forms.Label lblTournamentTitle;
        private System.Windows.Forms.Label lblTournamentMotto;
        private System.Windows.Forms.Label lblMotto;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTournament;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnActivate;
        private System.Windows.Forms.Button btnPrint;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button btnExportTeamRooster;
    }
}