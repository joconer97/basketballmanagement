namespace BATMAN
{
    partial class frmViewTeamOfficial
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
            this.cmbTeam = new System.Windows.Forms.ComboBox();
            this.lsvTeamOfficial = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // cmbTeam
            // 
            this.cmbTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTeam.Font = new System.Drawing.Font("Courier New", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTeam.FormattingEnabled = true;
            this.cmbTeam.Location = new System.Drawing.Point(21, 114);
            this.cmbTeam.Name = "cmbTeam";
            this.cmbTeam.Size = new System.Drawing.Size(238, 33);
            this.cmbTeam.TabIndex = 0;
            this.cmbTeam.SelectedIndexChanged += new System.EventHandler(this.cmbTeam_SelectedIndexChanged);
            // 
            // lsvTeamOfficial
            // 
            this.lsvTeamOfficial.Font = new System.Drawing.Font("Courier New", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvTeamOfficial.Location = new System.Drawing.Point(21, 153);
            this.lsvTeamOfficial.Name = "lsvTeamOfficial";
            this.lsvTeamOfficial.Size = new System.Drawing.Size(1101, 250);
            this.lsvTeamOfficial.TabIndex = 1;
            this.lsvTeamOfficial.UseCompatibleStateImageBehavior = false;
            // 
            // frmViewTeamOfficial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 537);
            this.Controls.Add(this.lsvTeamOfficial);
            this.Controls.Add(this.cmbTeam);
            this.Name = "frmViewTeamOfficial";
            this.Text = "frmVIewTeamOfficial";
            this.Load += new System.EventHandler(this.frmVIewTeamOfficial_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTeam;
        private System.Windows.Forms.ListView lsvTeamOfficial;
    }
}