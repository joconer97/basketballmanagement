using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BATMAN.Classes;

namespace BATMAN
{
    public partial class UCMatch : UserControl
    {
        Match match = null;
        Tournament tournament = null;
        public UCMatch(Match match = null,Tournament tournament = null)
        {
            InitializeComponent();
            this.match = match;
            this.tournament = tournament;
        }

        private void UCMatch_Load(object sender, EventArgs e)
        {
            lblHomeBrgy.Text = match.homeTeam.barangay.name;
            lblHomeTeam.Text = match.homeTeam.teamName;
            pcbHome.Image = Image.FromFile(match.homeTeam.teamLogo);
            lblGuestBrgy.Text = match.guestTeam.barangay.name;
            lblGuestTeam.Text = match.guestTeam.teamName;
            pcbGuest.Image = Image.FromFile(match.guestTeam.teamLogo);
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Image image = Image.FromFile(@"F:\Generic Basketball Score Sheet-1.png");

            List<Player> listPlayer = PlayerHelper.GetPlayer(tournament);
            List<Player> playerByTeam = Player.PlayerByTeam(listPlayer, match.homeTeam.teamID);
            List<TeamOfficial> listOfficial = TeamOfficialHelper.GetAllOfficial(tournament);
            var official = TeamOfficial.ShowByTeam(listOfficial, match.homeTeam.teamID);

            //HEADER GAMESCORESHEET
            e.Graphics.DrawImage(image, e.PageBounds);
            e.Graphics.DrawString("Abella Vs Tinago", new Font("Courier New", 24, FontStyle.Bold), Brushes.Black, new Point(250, 25));
            e.Graphics.DrawString(match.venue.venueName, new Font("Courier New", 11, FontStyle.Regular), Brushes.Black, new Point(700, 85));
            //TEAM 1
            int counter = 250;
            e.Graphics.DrawString(match.homeTeam.teamName, new Font("Courier New", 14, FontStyle.Bold), Brushes.Black, new Point(90, 80));
            e.Graphics.DrawString(official.firstName + " " + official.lastName, new Font("Courier New", 14, FontStyle.Bold), Brushes.Black, new Point(80, 215));
            foreach (var pl in playerByTeam)
            {
                e.Graphics.DrawString(pl.firstName + " " + pl.lastName, new Font("Courier New", 11, FontStyle.Bold), Brushes.Black, new Point(25, counter));
                e.Graphics.DrawString(pl.jerseyNO.ToString(), new Font("Courier New", 11, FontStyle.Bold), Brushes.Black, new Point(290, counter));
                counter += 20;
            }

            //TEAM 2
            counter = 725;
            playerByTeam = Player.PlayerByTeam(listPlayer, match.guestTeam.teamID);
            foreach (var pl in playerByTeam)
            {
                e.Graphics.DrawString(pl.firstName + " " + pl.lastName, new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new Point(25, counter));
                e.Graphics.DrawString(pl.jerseyNO.ToString(), new Font("Courier New", 11, FontStyle.Bold), Brushes.Black, new Point(290, counter));
                counter += 18;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
