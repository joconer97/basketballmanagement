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
    public partial class frmViewTournament : Form
    {
        public frmViewTournament()
        {
            InitializeComponent();
        }
        List<Tournament> list = null;
        private void frmViewTournament_Load(object sender, EventArgs e)
        {
            InitializeTournamentList();
            //HIDE BUTTONS
            btnPrint.Visible = false;
            btnActivate.Visible = false;
            btnClose.Visible = false;
            //Add Tag in Button
            btnCreate.Tag = 1;
            btnUpdate.Tag = 2;
            btnDelete.Tag = 3;

            //Add Click Event in button
            btnCreate.Click += Button_Click;
            btnUpdate.Click += Button_Click;
            btnDelete.Click += Button_Click;
            list = TournamentHelper.GetTournament();
            displayTournament();

            
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            switch ((int)button.Tag)
            {
                case 1:
                    SaveTournament();
                    break;
                case 2:
                    EditTournament();
                    break;
                case 3:
                    DeleteTournament();
                    break;

            }
            
        }

        private void DeleteTournament()
        {
            int si = 0;

            try
            {
                si = lvwTournaments.SelectedItems[0].Index;
            }
            catch
            {
                MessageBox.Show("Please select the tournament you want to Delete");
                return;
            }
            Tournament selectedTournament = list[si];
           /* if(selectedTournament.tournamentStatus == 3 || selectedTournament.tournamentStatus == 2)
            {
                MessageBox.Show("Sorry you cannot delete this tournament that already active or close");
                return;
            }*/
            string message = "Do you really want delete?[" + selectedTournament.tournamentTitle + "] " + "All data that have been related in this tournament will be delete";
            if (DialogResult.Yes == MessageBox.Show(message, "System", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2))
            {
                TournamentHelper.DeleteTournament(selectedTournament.tournamentID);
                displayTournament();
            }
        }

        private void InitializeTournamentList()
        {
            lvwTournaments.Columns.Add("No.", 50);
            lvwTournaments.Columns.Add("ID", 0);
            lvwTournaments.Columns.Add("Title", 250);
            lvwTournaments.Columns.Add("Year", 120);
            lvwTournaments.Columns.Add("Status", 80);



            lvwTournaments.View = View.Details;
            lvwTournaments.GridLines = true;
            lvwTournaments.FullRowSelect = true;
            lvwTournaments.HideSelection = false;
            lvwTournaments.MultiSelect = false;
        }

      

   
        private void displayTournament()
        {
            int ctr = 0;
            list = TournamentHelper.GetTournament();
            lvwTournaments.Items.Clear();
            ListViewItem item;
            foreach (Tournament tournament in list)
            {


                
                item = lvwTournaments.Items.Add((++ctr).ToString());
                item.SubItems.Add(tournament.tournamentID.ToString());
                item.SubItems.Add(tournament.tournamentTitle.Trim());
                item.SubItems.Add(tournament.tournamentStart.Year.ToString());
                item.SubItems.Add(getStatus(tournament.tournamentStatus));
            }
        }

        private void SaveTournament()
        {
            using (Form f = new frmSaveTournament())
            {
                f.StartPosition = FormStartPosition.CenterParent;
                f.ShowDialog();

                if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    //refresh the list of teams
                    displayTournament();
                }
            }
        }
        private void EditTournament()
        {

            int si = 0;
            try
            {
                si = lvwTournaments.SelectedItems[0].Index;
            }
            catch
            {
                MessageBox.Show("Please select the tournament you want to update");
                return;
            }
            Tournament selectedTournament = list[si];

            if (selectedTournament.tournamentStatus == 3 || selectedTournament.tournamentStatus == 2)
            {
                MessageBox.Show("Sorry you cannot modify this tournament that already active or close");
                return;
            }

            using (Form f = new frmSaveTournament(selectedTournament))
            {
                f.StartPosition = FormStartPosition.CenterParent;
                f.ShowDialog();

                if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    //refresh the list of teams
                    displayTournament();
                }
            }

        }
        private string getStatus(int x)
        {
            switch(x)
            {
                case 1:
                    return "Open";
                case 2:
                    return "Active";
                case 3:
                    return "Closed";
            }

            return "";
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

       
        private void lvwTournaments_DoubleClick(object sender, EventArgs e)
        {
            int si = 0;
            try
            {
                si = lvwTournaments.SelectedItems[0].Index;


            }
            catch
            {
                return;
            }

            Tournament selectedTournament = list[si];

            if (selectedTournament.tournamentStatus == 3)
            {
                MessageBox.Show("This tournament is already close [" + selectedTournament.tournamentTitle + "]");
                return;
            }
            using (Form f = new frmTournamentDetail(selectedTournament))
            {
                f.ShowDialog();
                displayTournament();
            }
        }
        private void ActivateStatus()
        {
            int si = 0;
            try
            {
                si = lvwTournaments.SelectedItems[0].Index;
            }
            catch { return; }

            Tournament selectedTournament = list[si];

            selectedTournament.tournamentStatus = 2;
            List<Team> team = TeamHelper.GetTeam(selectedTournament);
            List<GameOfficial> gameofficial = GameOfficialHelper.GetAllGameOfficial(selectedTournament);
            List<Player> player = PlayerHelper.GetPlayer(selectedTournament);
            List<Venue> venue = VenueHelper.GetVenue();
            if(selectedTournament.ValidationOfActivation(team,gameofficial,player) != true)
             {
                 MessageBox.Show("Cannot Activate because you need follow the rules activating the tourmament[2 Teams] And [2 Game Official] require");
                 return;
             }
             

            List<Match> match = Match.GenerateMatch(team, venue,selectedTournament);

            foreach (Match m in match)
            {
                MatchHelper.SaveMatch(m);
            }

            if (TournamentHelper.UpdateTournamentStatus(selectedTournament) == 0)
            {
                //report an error
                MessageBox.Show("Error activating tournament");
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
            lblStatus.Text = "Activate";
            btnActivate.Visible = false;
            btnPrint.Visible = false;
            btnExportTeamRooster.Visible = true;
            btnClose.Visible = true;
            displayTournament();

        }

        private void CloseStatus()
        {
            int si = 0;
            try
            {
                si = lvwTournaments.SelectedItems[0].Index;
            }
            catch { return; }

            Tournament selectedTournament = list[si];

            selectedTournament.tournamentStatus = 3;
            if (TournamentHelper.UpdateTournamentStatus(selectedTournament) == 0)
            {
                //report an error
                MessageBox.Show("Error activating tournament");
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
            lblStatus.Text = "Closed";
            btnClose.Visible = false;
            displayTournament();

        }
        private void lvwTournaments_SelectedIndexChanged(object sender, EventArgs e)
        {
            int si = 0;
            try
            {
                si = lvwTournaments.SelectedItems[0].Index;
            }
            catch{return;}
            
            Tournament selectedTournament = list[si];
            if(selectedTournament.tournamentStatus == 1)
            {
                btnActivate.Visible = true;
                btnPrint.Visible = true;
                btnClose.Visible = false;
                btnExportTeamRooster.Visible = false;
            }
            else if(selectedTournament.tournamentStatus == 3)
            {
                btnClose.Visible = false;
            }
            else
            {
                btnActivate.Visible = false;
                btnPrint.Visible = false;
                btnClose.Visible = true;
                btnExportTeamRooster.Visible = true;
                
            }
            lblTournamentDate.Text = selectedTournament.tournamentStart.ToShortDateString() + " - " + selectedTournament.tournamentEnd.ToShortDateString();
            lblTournamentTitle.Text = selectedTournament.tournamentTitle;
            txtTournament.Text = selectedTournament.tournamentMotto;
            lblStatus.Text = GetStatus(selectedTournament);
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

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Basketball Tournament", new Font("Courier New", 25, FontStyle.Regular), Brushes.Black, new Point(250, 100));
            e.Graphics.DrawString("Registration Form", new Font("Courier New", 25, FontStyle.Regular), Brushes.Black, new Point(250, 130));
            e.Graphics.DrawString("Team Name", new Font("Courier New", 12, FontStyle.Regular), Brushes.Black, new Point(10, 230));
            e.Graphics.DrawString("Team Slogan", new Font("Courier New", 12, FontStyle.Regular), Brushes.Black, new Point(10, 270));
            e.Graphics.DrawString("Coach", new Font("Courier New", 12, FontStyle.Regular), Brushes.Black, new Point(430, 230));
            e.Graphics.DrawString("Ass't Coach", new Font("Courier New", 12, FontStyle.Regular), Brushes.Black, new Point(430, 270));
            e.Graphics.DrawString("Manager", new Font("Courier New", 12, FontStyle.Regular), Brushes.Black, new Point(430, 300));
            e.Graphics.DrawLine(new Pen(Color.Black), 490, 250, 800, 250);  //Coach Name
            e.Graphics.DrawLine(new Pen(Color.Black), 550, 290, 800, 290);  //Assistant Coach
            e.Graphics.DrawLine(new Pen(Color.Black), 510, 320, 800, 320); // Manager
            e.Graphics.DrawLine(new Pen(Color.Black), 110, 250, 400, 250); //Team Name
            e.Graphics.DrawLine(new Pen(Color.Black), 140, 290, 400, 290); //Team Slogan


            e.Graphics.DrawRectangle(new Pen(Color.Black, 1), new Rectangle(10, 450, 830, 500));

            //Create Table 
            {
                int heightPoint = 495;
                int addHeight = 40;
                for (int i = 0; i < 10; i++)
                {
                    if (i == 0)
                    {
                        e.Graphics.DrawString("No.", new Font("Courier New", 11, FontStyle.Regular), Brushes.Black, new Point(10, 455));
                        e.Graphics.DrawString("Name", new Font("Courier New", 11, FontStyle.Regular), Brushes.Black, new Point(55, 455));
                        e.Graphics.DrawString("Jersey No", new Font("Courier New", 9, FontStyle.Regular), Brushes.Black, new Point(310, 455));
                        e.Graphics.DrawString("Position", new Font("Courier New", 11, FontStyle.Regular), Brushes.Black, new Point(410, 455));
                        e.Graphics.DrawString("Birthdate", new Font("Courier New", 9, FontStyle.Regular), Brushes.Black, new Point(530, 455));
                        e.Graphics.DrawString("Address", new Font("Courier New", 11, FontStyle.Regular), Brushes.Black, new Point(690, 455));
                    }
                    else
                    {
                        e.Graphics.DrawString(i.ToString(), new Font("Courier New", 11, FontStyle.Regular), Brushes.Black, new Point(10, 455 + addHeight));
                        addHeight += 45;
                    }
                    e.Graphics.DrawLine(new Pen(Color.Black), 10, heightPoint, 840, heightPoint);

                    heightPoint += 45;

                }
                e.Graphics.DrawString("10", new Font("Courier New", 11, FontStyle.Regular), Brushes.Black, new Point(10, 455 + addHeight));
            }

            //Draw Column Line
            e.Graphics.DrawLine(new Pen(Brushes.Black, 1), 50, 950, 50, 450); //No
            e.Graphics.DrawLine(new Pen(Brushes.Black, 1), 310, 950, 310, 450); //Name
            e.Graphics.DrawLine(new Pen(Brushes.Black, 1), 385, 950, 385, 450); // jeysey no
            e.Graphics.DrawLine(new Pen(Brushes.Black, 1), 520, 950, 520, 450); // Position
            e.Graphics.DrawLine(new Pen(Brushes.Black, 1), 620, 950, 620, 450); // Birthdate
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            ActivateStatus();
          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseStatus();
           
        }

        private void btnExportTeamRooster_Click(object sender, EventArgs e)
        {
            ExportTeamRooster();
        }
     

        private void ExportTeamRooster()
        {

            var tournament = new Tournament();

            int si = 0;
            try
            {
                si = lvwTournaments.SelectedItems[0].Index;
            }
            catch { return; }

            tournament = list[si];


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

            int rowIndex = 0;
            int colIndex = 1;



            int Height = 220;
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
                var officialByTeam = TeamOfficial.ShowByTeam(official, t.teamID);
                wsSheet1.Cells["C" + NoCounter].Value = t.teamName;
                wsSheet1.Cells["G" + NoCounter].Value = officialByTeam.firstName + " " + officialByTeam.lastName;
                wsSheet1.Cells["A" + NoCounter].Value = numberCounter++;
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
    }
}
