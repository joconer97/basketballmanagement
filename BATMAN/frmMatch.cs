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
    public partial class frmMatch : Form
    {
        Tournament tournament = null;
        public frmMatch(Tournament tournament)
        {
            InitializeComponent();
            this.tournament = tournament;
        }

        private void frmMatch_Load(object sender, EventArgs e)
        {
            lblTournament.Text = tournament.tournamentTitle + " " + tournament.tournamentStart.Year;
            this.Visible = false;
            List<Match> list = MatchHelper.GetMatch(tournament);

            foreach(var m in list)
            {
                var match = new UCMatch(m,tournament);

                flowLayoutPanel1.Controls.Add(match);
            }
            this.Visible = true;
        }
    }
}
