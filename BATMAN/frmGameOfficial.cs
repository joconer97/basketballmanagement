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
    public partial class frmGameOfficial : Form
    {
        Tournament tournament = null;
        List<GameOfficial> listGameOfficial = null;
        List<Referee> referee = null;
        public frmGameOfficial(Tournament tournament = null)
        {
            InitializeComponent();
            this.tournament = tournament;

        }



        private void frmGameOfficial_Load(object sender, EventArgs e)
        {
            InitializeGameOfficialList();
            InitializeTournamentGameOfficial();
            DisplayGameOfficial();
            DisplayTournamentGameOfficial();
            //ADD TAG IN BUTTON
            btnAdd.Tag = 1;
            btnDelete.Tag = 2;
            btnUpdate.Tag = 3;

            //ADD CLICK EVENT IN BUTTON
            btnAdd.Click += Button_Click;
            btnDelete.Click += Button_Click;
            btnUpdate.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            switch ((int)btn.Tag)
            {
                case 1:
                    AddGameOfficial();
                    break;
                case 2:
                    DeleteGameOfficial();
                    break;
                case 3:
                    UpdateGameOfficial();
                    break;
            }
        }
        private void InitializeGameOfficialList()
        {
            lvOfficial.Columns.Add("No.", 30);
            lvOfficial.Columns.Add("ID", 0);
            lvOfficial.Columns.Add("Firstname", 200);
            lvOfficial.Columns.Add("Lastname", 200);



            lvOfficial.View = View.Details;
            lvOfficial.GridLines = true;
            lvOfficial.FullRowSelect = true;
            lvOfficial.HideSelection = false;
            lvOfficial.MultiSelect = false;
        }

        private void InitializeTournamentGameOfficial()
        {
            lsvTournamentOfficial.Columns.Add("No.", 30);
            lsvTournamentOfficial.Columns.Add("ID", 0);
            lsvTournamentOfficial.Columns.Add("Firstname", 200);
            lsvTournamentOfficial.Columns.Add("Lastname", 200);



            lsvTournamentOfficial.View = View.Details;
            lsvTournamentOfficial.GridLines = true;
            lsvTournamentOfficial.FullRowSelect = true;
            lsvTournamentOfficial.HideSelection = false;
            lsvTournamentOfficial.MultiSelect = false;
        }

        private void DisplayGameOfficial()
        {
            int ctr = 0;
            listGameOfficial = GameOfficialHelper.GetAllGameOfficial(tournament);
            lvOfficial.Items.Clear();
            ListViewItem item;
            foreach (var official in listGameOfficial)
            {
                item = lvOfficial.Items.Add((++ctr).ToString());
                item.SubItems.Add(official.officialID.ToString());
                item.SubItems.Add(official.firstName);
                item.SubItems.Add(official.lastName);
            }
        }

        private void DisplayTournamentGameOfficial()
        {
            int ctr = 0;
            referee = RefereeHelper.GetReferee(tournament);
            lsvTournamentOfficial.Items.Clear();
            ListViewItem item;
            foreach (var official in referee)
            {
                item = lsvTournamentOfficial.Items.Add((++ctr).ToString());
                item.SubItems.Add(official.official.officialID.ToString());
                item.SubItems.Add(official.official.firstName);
                item.SubItems.Add(official.official.lastName);
            }
        }
        private void AddGameOfficial()
        {
            GameOfficial official = new GameOfficial();

            using (Form f = new frmAddGameOfficial(official))
            {
                if (DialogResult.OK == f.ShowDialog())
                {
                    MessageBox.Show("Sucessfully added official");
                    DisplayGameOfficial();
                }

            }
        }

        private void UpdateGameOfficial()
        {

            int si = 0;

            try
            {
                si = lvOfficial.SelectedItems[0].Index;
            }
            catch
            {
                MessageBox.Show("Please select you want to update");
                return;
            }



            GameOfficial official = new GameOfficial()
            {
                firstName = listGameOfficial[si].firstName,
                lastName = listGameOfficial[si].lastName,
                officialID = listGameOfficial[si].officialID
            };

            using (Form f = new frmAddGameOfficial(official))
            {
                if (DialogResult.OK == f.ShowDialog())
                {
                    MessageBox.Show("Sucessfully updated official");
                    DisplayGameOfficial();
                }

            }
        }

        private void DeleteGameOfficial()
        {
            int si;
            try
            {
                si = lvOfficial.SelectedItems[0].Index;
            }
            catch
            {
                MessageBox.Show("Select you wish to delete");
                return;
            }


            GameOfficial official = new GameOfficial()
            {
                firstName = listGameOfficial[si].firstName,
                lastName = listGameOfficial[si].lastName,
                officialID = listGameOfficial[si].officialID
            };
            string message = "Do you really want to delete [" + official.firstName + " " + official.lastName + "]";
            if (MessageBox.Show(message, "System", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                GameOfficialHelper.DeleteGameOfficial(official);
                DisplayGameOfficial();
            }
        }


        private void lvOfficial_DoubleClick(object sender, EventArgs e)
        {
            int si = 0;

            try
            {
                si = lvOfficial.SelectedItems[0].Index;
            }
            catch
            {
                return;
            }

            foreach (var r in referee)
            {
                if (r.official.officialID == listGameOfficial[si].officialID)
                {
                    MessageBox.Show(r.official.firstName + " is already on the list");
                    return;
                }
            }


            Referee refereeTemp = new Referee()
            {
               official = new GameOfficial()
               {
                    officialID = listGameOfficial[si].officialID,
               },
                tournament = new Tournament()
                {
                    tournamentID = tournament.tournamentID
                }
            };

            string message = listGameOfficial[si].firstName + " " + listGameOfficial[si].lastName;
            if(MessageBox.Show("Do you want to add [ " + message + " ]", "System",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                RefereeHelper.SaveReferee(refereeTemp);
                DisplayTournamentGameOfficial();
            }
        }
    }
}
