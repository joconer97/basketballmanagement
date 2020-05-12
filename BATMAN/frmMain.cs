using BATMAN.Classes;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BATMAN
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        List<Tournament> listTournament = null;
        private void frmMain_Load(object sender, EventArgs e)
        {
            //LOAD TOURNAMENT
            LoadTournament();
            //ADD IMAGELOGO
            //(@"C:\Users\JOSHUA\Documents\Visual Studio 2015\Projects\BATMAN\Images\
            //Add Tag om button

            btnTournament.Tag = 1;
            btnTeam.Tag = 2;
            btnPlayer.Tag = 3;
            btnGameSchedule.Tag = 4;
            btnGameOfficial.Tag = 5;
            btnAwards.Tag = 6;
            btnTeamOficial.Tag = 7;
            //Add Click Event in Button

            btnAwards.Click += Button_Click;
            btnGameOfficial.Click += Button_Click;
            btnGameSchedule.Click += Button_Click;
            btnPlayer.Click += Button_Click;
            btnTeam.Click += Button_Click;
            btnTournament.Click += Button_Click;
            btnTeamOficial.Click += Button_Click;

        }



        private void Button_Click(object sender, EventArgs e)
        {
            var button = sender as UserControl;

            switch ((int)button.Tag)
            {
                case 1:
                    Tournament();
                    break;
                case 2:
                    Team();
                    break;
                case 3:
                    Player();
                    break;
                case 4:
                    Match();
                    break;
                case 5:
                    GameOfficial();
                    break;
                case 6:
                    break;
                case 7:
                    TeamOfficial();
                    break;
            }
        }

        private void Tournament()
        {
            using (Form form = new frmViewTournament())
            {
                form.ShowDialog();
                LoadTournament();
            }
        }

        private void GetAllTournament()
        {
            listTournament = TournamentHelper.GetTournament();
        }

        private bool isAvailable(Tournament tournament)
        {
            if (tournament == null)
            {
                return false;
            }

            return true;

        }

        private void GameOfficial()
        {
            var tournament = GetTournament();

            if (isAvailable(tournament) == false)
            {
                MessageBox.Show("No Available Tournament");
                return;
            }
            else if (tournament.tournamentStatus == 2 || tournament.tournamentStatus == 3)
            {
                MessageBox.Show("Sorry you cannot add more game official because the tournament already active or the tournament is close");
                return;

            }

            using (Form f = new frmGameOfficial(tournament))
            {
                f.ShowDialog();
            }

        }

        private void Team()
        {
            var tournament = GetTournament();

            if (isAvailable(tournament) == false)
            {
                MessageBox.Show("No Available Tournament");
                return;
            }
            else if (tournament.tournamentStatus == 2 || tournament.tournamentStatus == 3)
            {
                MessageBox.Show("Sorry you cannot add more teams because the tournament already active or the tournament is close");
                return;

            }

            using (Form f = new frmViewTeam(tournament))
            {
                f.ShowDialog();
            }
        }
        private void Player()
        {
            var tournament = GetTournament();


            if (isAvailable(tournament) == false)
            {
                MessageBox.Show("No Available Tournament");
                return;
            }
            else if (tournament.tournamentStatus == 2 || tournament.tournamentStatus == 3)
            {
                MessageBox.Show("Sorry you cannot add more player because the tournament already active or the tournament is close");
                return;

            }

            var team = TeamHelper.GetTeam(tournament);
            if (team.Count <= 0)
            {
                MessageBox.Show("Theres no team been created");
                return;
            }

            using (Form f = new frmViewPlayer(tournament))
            {
                f.ShowDialog();
            }
        }

        private void TeamOfficial()
        {
            var tournament = GetTournament();

            if (isAvailable(tournament) == false)
            {
                MessageBox.Show("No Available Tournament");
                return;
            }
            else if (tournament.tournamentStatus == 2 || tournament.tournamentStatus == 3)
            {
                MessageBox.Show("Sorry you cannot add more team fficial because the tournament already active or the tournament is close");
                return;

            }

            var team = TeamHelper.GetTeam(tournament);
            if (team.Count <= 0)
            {
                MessageBox.Show("Theres no team been created");
                return;
            }
            using (Form f = new frmViewTeamOfficial(tournament))
            {
                f.ShowDialog();
            }
        }

        private void Match()
        {
            var tournament = GetTournament();

            if (isAvailable(tournament) == false)
            {
                MessageBox.Show("No Available Tournament");
                return;
            }
            else if (tournament.tournamentStatus == 3)
            {
                MessageBox.Show("Sorry you cannot add more team fficial because the tournament already active or the tournament is close");
                return;

            }
            using (Form f = new frmMatch(tournament))
            {
                f.ShowDialog();
            }

        }

        private void LoadTournament()
        {
            var tournament = GetTournament();

            if (isAvailable(tournament) == true)
            {
                if (tournament.tournamentStatus == 2)
                    btnExportTeamRooster.Visible = true;
                lblDate.Visible = true;
                lblMotto.Visible = true;
                lblTitle.Visible = true;
                lblTournamentDate.Visible = true;
                lblTournamentMotto.Visible = true;
                lblTournamentTitle.Visible = true;
                lblTournamentStatus.Visible = true;
                lblNoGameOfficial.Visible = true;
                lblNoPlayer.Visible = true;
                lblNoTeam.Visible = true;
                lblGameOfficial.Visible = true;
                lblTeam.Visible = true;
                lblPlayer.Visible = true;

                List<GameOfficial> gameOfficial = GameOfficialHelper.GetAllGameOfficial(tournament);
                List<Team> team = TeamHelper.GetTeam(tournament);
                List<Player> player = PlayerHelper.GetPlayer(tournament);

                lblGameOfficial.Text = gameOfficial.Count.ToString();
                lblTeam.Text = team.Count.ToString();
                lblPlayer.Text = player.Count.ToString();
                lblStatus.Text = GetStatus(tournament);
                lblTournamentTitle.Text = tournament.tournamentTitle;
                lblTournamentMotto.Text = tournament.tournamentMotto;
                lblTournamentDate.Text = tournament.tournamentStart.ToShortDateString() + " - " + tournament.tournamentEnd.ToShortDateString();
                return;
            }
            else
            {

                btnExportTeamRooster.Visible = false;
                lblDate.Visible = false;
                lblMotto.Visible = false;
                lblTitle.Visible = false;
                lblTournamentDate.Visible = false;
                lblTournamentMotto.Visible = false;
                lblTournamentTitle.Visible = false;
                lblTournamentStatus.Visible = false;
                lblPlayer.Visible = false;
                lblTeam.Visible = false;
                lblGameOfficial.Visible = false;
                lblStatus.Text = "No Available Tournament";
            }
        }

        private string GetStatus(Tournament tournament)
        {
            switch (tournament.tournamentStatus)
            {
                case 1:
                    return "Open";
                case 2:
                    return "Active";
                case 3:
                    return "Closed";
                default:
                    return "";
            }
        }

        private Tournament GetTournament()
        {
            GetAllTournament();

            var tournament = from st in listTournament
                             where st.tournamentStatus == 1 || st.tournamentStatus == 2
                         select st;
            Tournament t = null;
            foreach(var st in tournament.AsEnumerable())
            {
                t = new Tournament()
                {
                    tournamentID = st.tournamentID,
                    tournamentStart = st.tournamentStart,
                    tournamentEnd = st.tournamentEnd,
                    tournamentStatus =  st.tournamentStatus,
                    tournamentMotto =  st.tournamentMotto,
                    tournamentTitle =   st.tournamentTitle
                };
            }

            return t;
        }
        private void ExportTeamRooster()
        {
            
            var tournament = GetTournament();
            List<Team> team = TeamHelper.GetTeam(tournament);
            List<Player> player = PlayerHelper.GetPlayer(tournament);
            List<TeamOfficial> official = TeamOfficialHelper.GetAllOfficial(tournament);
        

            ExcelPackage ExcelPkg = new ExcelPackage();
            ExcelWorksheet wsSheet1 = ExcelPkg.Workbook.Worksheets.Add("Sheet1");
            wsSheet1.Cells.Style.Font.Name = "Arial Narrow";
            wsSheet1.Cells.Style.Font.Size = 11;
           
            //Title Of tournament
            wsSheet1.Cells["G" + 3].Value = "Basketball Tournament 2018";
            //Date of tournament
            wsSheet1.Cells["G" + 4].Value = "April 15, 2018 - April 25, 2018";
            wsSheet1.Cells["G9"].Value = "Official Team Rooster";
            wsSheet1.Cells["G9"].Style.Font.Name = "Times New Roman";
            wsSheet1.Cells["G9"].Style.Font.Size = 14;
            //Header of Tournament
            wsSheet1.Cells["A11"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            wsSheet1.Cells["A11"].Value = "NO.1";
            wsSheet1.Cells["C11"].Value = "Team name";
            wsSheet1.Cells["G11"].Value = "Head Coach";
            wsSheet1.Cells["K11"].Value = "Jersey No.";
            wsSheet1.Cells["N11"].Value = "Players";

            int rowIndex = 1;
            int colIndex = 1;



            int Height = 180;
            int Width = 120;

            Image img = Image.FromFile(@"C:\Users\JOSHUA\Documents\Visual Studio 2015\Projects\BATMAN\Images\seal.jpg");
            ExcelPicture pic = wsSheet1.Drawings.AddPicture("Sample", img);

            pic.SetPosition(rowIndex, 0, colIndex, 0);
            //pic.SetPosition(PixelTop, PixelLeft);
            pic.SetSize(Height, Width);

           

            string fileName = @"C:\Users\JOSHUA\Documents\Visual Studio 2015\Projects\BATMAN\" + wsSheet1.Cells["G" + 3].Value.ToString() + ".xls";

            //INITIALIZING COUNTER FOR CELL
            int NoCounter = 12;
            int numberCounter = 1;
            int ctr = 12;
            foreach (var t in team)
            {
                var playerByTeam = BATMAN.Classes.Player.PlayerByTeam(player, t.teamID);
                var officialByTeam = ShowByTeam(official, t.teamID);
                wsSheet1.Cells["C" + NoCounter].Value = t.teamName;
                wsSheet1.Cells["G" + NoCounter].Value = officialByTeam.firstName + " " + officialByTeam.lastName;
                wsSheet1.Cells["A"+NoCounter].Value = numberCounter++;
                wsSheet1.Cells["A" + NoCounter].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                
                foreach (var p in playerByTeam)
                {
                    wsSheet1.Cells["K" + ctr].Value = p.jerseyNO.ToString();
                    wsSheet1.Cells["N" + ctr++].Value = p.firstName + " " + p.lastName;
                    NoCounter++;
                }
                ctr++;
                NoCounter++;
            }

            wsSheet1.Protection.IsProtected = false;
            wsSheet1.Protection.AllowSelectLockedCells = false;
            ExcelPkg.SaveAs(new FileInfo(fileName));
            MessageBox.Show("The team rooster excel file is on" + fileName);
            FileInfo fi = new FileInfo(fileName);
            if (fi.Exists)
            {

                System.Diagnostics.Process.Start(fileName);
            }
            else
            {
                MessageBox.Show("Theres a problem while opening excel,Go to " + fileName + "Manual Open");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExportTeamRooster();
        }

        private TeamOfficial ShowByTeam(List<TeamOfficial> listOfTeamOfficial,int teamID)
        {
            int ci = teamID;
            TeamOfficial official = new TeamOfficial();
            var data = from st in listOfTeamOfficial
                       where st.team.teamID == ci && st.position.positionDetail == "Coach"
                       select st;

            foreach (var dr in data.AsEnumerable())
            {

                official.id = dr.id;
                official.firstName = dr.firstName;
                official.lastName = dr.lastName;
                official.position = new StaffPosition()
                {
                         positionID = dr.position.positionID,
                         positionDetail = dr.position.positionDetail,
                };
                official.team = new Team()
                {
                    teamID = dr.team.teamID,
                    teamLogo = dr.team.teamName
                };
            }

            return official;

        }
    }
}
