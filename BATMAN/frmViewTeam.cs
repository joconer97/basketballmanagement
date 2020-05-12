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
    public partial class frmViewTeam : Form
    {
        Tournament tournament = null;
        public frmViewTeam(Tournament tournament)
        {
            InitializeComponent();
            this.tournament = tournament;
        }


        List<Team> listOfTeam = null;
        private void frmViewTeam_Load(object sender, EventArgs e)
        {

            
            DisplayData();
            //ADD TAG
            btnSave.Tag = 1;
            btnUpdate.Tag = 2;
            btnDelete.Tag = 3;

            //ADD CLICK EVENT
            btnSave.Click += Button_Click;
            btnUpdate.Click += Button_Click;
            btnDelete.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            switch((int)btn.Tag)
            {
                case 1:
                    SaveTeam();
                    break;
                case 2:
                    UpdateTeam();
                    break;
                case 3:
                    DeleteTeam();
                    break;
            }
        }

        private void SaveTeam()
        {
            using (Form f = new frmSaveTeam(tournament))
            {
                if(DialogResult.OK == f.ShowDialog())
                {
                    MessageBox.Show("Succesfully Added the team");
                    DisplayData();
                }
            }
        }
        private void UpdateTeam()
        {
            int si = 0;

            try
            {
                si = lvTeam.SelectedItems[0].Index;
            }
            catch
            {
                MessageBox.Show("Please select you want to update");
                return;
            }

            Team team = listOfTeam[si];

            using (Form f = new frmSaveTeam(tournament, team))
            {
                if(DialogResult.OK == f.ShowDialog())
                {
                    MessageBox.Show("Succesfully Update the team");
                    DisplayData();
                }
            }
            
        }
        private void DeleteTeam()
        {
            int si = 0;

            try
            {
                si = lvTeam.SelectedItems[0].Index;
            }
            catch
            {
                MessageBox.Show("Please select you want to update");
                return;
            }

            Team team = listOfTeam[si];
            string message = "[Deleting team will also delete the player who are in this team]\nDo you really want to delete this team?";
            if (DialogResult.Yes == MessageBox.Show(message, "System", MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2))
            {
                TeamHelper.DeleteTeam(team);
                DisplayData();
            }
        }
        
        private void InitListView()
        {
            lvTeam.Columns.Add("No.", 30);
            lvTeam.Columns.Add("Team Id", 0);
            lvTeam.Columns.Add("Team Name",200);
            lvTeam.Columns.Add("Slogan", 400);
            lvTeam.Columns.Add("Baranggay Id", 0);
            lvTeam.Columns.Add("Tournament", 0);
            lvTeam.Columns.Add("Baranggay", 200);
           
            lvTeam.MultiSelect = false;
            lvTeam.GridLines = true;
            lvTeam.View = View.Details;
            lvTeam.FullRowSelect = true;
        }
        private void DisplayData()
        {
            listOfTeam = TeamHelper.GetTeam(tournament);
            lvTeam.Clear();
            InitListView();
            int ctr = 0;
            ListViewItem item;
            foreach (Team team in listOfTeam)
            {
                item = lvTeam.Items.Add((++ctr).ToString());
                item.SubItems.Add(team.teamID.ToString());
                item.SubItems.Add(team.teamName);
                item.SubItems.Add(team.teamSlogan);
                item.SubItems.Add(team.barangay.id.ToString());
                item.SubItems.Add(team.tournament.tournamentID.ToString());
                item.SubItems.Add(team.barangay.name);
            }
        

        }
        

        
    }
}
