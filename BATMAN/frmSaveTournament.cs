using BATMAN.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BATMAN
{
    public partial class frmSaveTournament : Form
    {
        Tournament tournament = null;
        public frmSaveTournament(Tournament tournament = null)
        {
            InitializeComponent();
            this.tournament = tournament;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = (tournament == null) ? 0 : tournament.tournamentID;

            Tournament tournaments = new Tournament()
            {
                tournamentID = id,
                tournamentStart = dtpStart.Value,
                tournamentEnd = dtpEnd.Value,
                tournamentMotto = txtMotto.Text,
                tournamentTitle = txtTitle.Text
            };
            if (!tournaments.isValid())
            {
                MessageBox.Show("Please check the data you input");
                return;
            }


            if (TournamentHelper.SaveTournament(tournaments) == 0)
            {
                //report an error
                MessageBox.Show("Sorry you cant create tournament,One Tournament Per Year Policy");
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void frmSaveTournament_Load(object sender, EventArgs e)
        {
            if (tournament != null)
            {

                this.Text = "Updating Tournament";
                txtMotto.Text = tournament.tournamentMotto;
                txtTitle.Text = tournament.tournamentTitle;
                dtpStart.Value = tournament.tournamentStart;
                dtpEnd.Value = tournament.tournamentEnd;
                dtpStart.MinDate = tournament.tournamentStart;
                dtpEnd.MinDate = Convert.ToDateTime("1/1/" + DateTime.Now.Year);

            }
            else
            {
                dtpStart.MinDate = Convert.ToDateTime("1/1/" + DateTime.Now.Year);
                dtpEnd.MaxDate = Convert.ToDateTime("31/12/" + DateTime.Now.Year);
            }
        }

     
    }
}
