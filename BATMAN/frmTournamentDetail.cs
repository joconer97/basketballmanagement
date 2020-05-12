using BATMAN.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OfficeOpenXml.Drawing;
using OfficeOpenXml;

namespace BATMAN
{
    public partial class frmTournamentDetail : Form
    {
        Tournament tournamentDetails = null;
        public frmTournamentDetail(Tournament tournament = null)
        {
            InitializeComponent();
            tournamentDetails = tournament;
        }

      

        private void Print_PrintPage(object sender, PrintPageEventArgs e)
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

        private void frmTournamentDetail_Load(object sender, EventArgs e)
        {
            InitTournament();
            //ADD TAG IN BUTTON
            btnActivate.Tag = 1;
            btnClose.Tag = 2;
            btnPrint.Tag = 3;
            //ADD CLICK EVENT IN BUTTON
            btnActivate.Click += Button_Click;
            btnPrint.Click += Button_Click;
            btnClose.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;

            switch((int)b.Tag)
            {
                case 1:
                    ActivateStatus();
                    break;
                case 2:
                    CloseStatus();
                    break;
                case 3:
                    PrintRegisterForm();
                    break;
            }
        }

        private void PrintRegisterForm()
        {
            PrintDocument print = new PrintDocument();

            print.PrintPage += Print_PrintPage;


            PrintPreviewDialog preview = new PrintPreviewDialog();
            ((Form)preview).WindowState = FormWindowState.Maximized;
            preview.Document = print;
            preview.ShowDialog();
        }
        private void ActivateStatus()
        {
            tournamentDetails.tournamentStatus = 2;
            List<Team> team = TeamHelper.GetTeam(tournamentDetails);
            List<GameOfficial> gameofficial = GameOfficialHelper.GetAllGameOfficial(tournamentDetails);
            List<Player> player = PlayerHelper.GetPlayer(tournamentDetails);
            List<Venue> venue = VenueHelper.GetVenue();
           /* if(tournamentDetails.ValidationOfActivation(team,gameofficial,player) != true)
            {
                MessageBox.Show("Error Activating");
                return;
            }
            */
            
            List<Match> match = Match.GenerateMatch(team,venue,tournamentDetails);

            foreach(Match m in match)
            {
                MatchHelper.SaveMatch(m);
            }

            if (TournamentHelper.UpdateTournamentStatus(tournamentDetails) == 0)
            {
                //report an error
                MessageBox.Show("Error activating tournament");
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;

        }

        private void CloseStatus()
        {
            tournamentDetails.tournamentStatus = 3;


            if (TournamentHelper.UpdateTournamentStatus(tournamentDetails) == 0)
            {
                //report an error
                MessageBox.Show("Error activating tournament");
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;

        }
        private void InitTournament()
        {
            if (tournamentDetails.tournamentStatus == 1)
                btnClose.Visible = false;
            else if (tournamentDetails.tournamentStatus == 2)
            {
                btnActivate.Visible = false;
                btnPrint.Visible = false;
            }

            txtMotto.Text = tournamentDetails.tournamentMotto;
            txtTitle.Text = tournamentDetails.tournamentTitle;
            txtStart.Text = tournamentDetails.tournamentStart.ToShortDateString();
            txtEnd.Text = tournamentDetails.tournamentEnd.ToShortDateString();
            
        }

        private void ExportTeamRooster()
        {
            ExcelPackage ExcelPkg = new ExcelPackage();
            ExcelWorksheet wsSheet1 = ExcelPkg.Workbook.Worksheets.Add("Sheet1");
            wsSheet1.Cells.Style.Font.Name = "Arial Narrow";
            wsSheet1.Cells.Style.Font.Size = 15;
            //Title Of tournament
            wsSheet1.Cells["G" + 3].Value = "Basketball Tournament 2018";
            //Date of tournament
            wsSheet1.Cells["G" + 4].Value = "April 15, 2018 - April 25, 2018";
            wsSheet1.Cells["G9"].Value = "Official Team Rooster";
            wsSheet1.Cells["G9"].Style.Font.Name = "Times New Roman";
            wsSheet1.Cells["G9"].Style.Font.Size = 25;
            //Header of Tournament
            wsSheet1.Cells["A11"].Value = "NO.1";
            wsSheet1.Cells["C11"].Value = "Team name";
            wsSheet1.Cells["G11"].Value = "Head Coach";
            wsSheet1.Cells["K11"].Value = "Jersey No.";
            wsSheet1.Cells["N11"].Value = "Players";

            int rowIndex = 0;
            int colIndex = 0;



            int Height = 250;
            int Width = 180;

            Image img = Image.FromFile(@"C:\Users\JOSHUA\Documents\Visual Studio 2015\Projects\BATMAN\Images\seal.jpg");
            ExcelPicture pic = wsSheet1.Drawings.AddPicture("Sample", img);

            pic.SetPosition(rowIndex, 0, colIndex, 0);
            //pic.SetPosition(PixelTop, PixelLeft);
            pic.SetSize(Height, Width);

            string fileName =  @"C:\Users\JOSHUA\Documents\Visual Studio 2015\Projects\BATMAN\" + wsSheet1.Cells["G" + 3].Value.ToString() +".xls";
             

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
            ExportTeamRooster();
        }
    }
}
