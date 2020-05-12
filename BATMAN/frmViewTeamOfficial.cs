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
    public partial class frmViewTeamOfficial : Form
    {
        List<Team> listOfTeam = null;
        List<TeamOfficial> listOfTeamOfficial = null;
        List<TeamOfficial> teamOfficialByTeam = null;
        Tournament tournament = null;
        public frmViewTeamOfficial(Tournament tournament = null)
        {
            InitializeComponent();
            this.tournament = tournament;
        }

        private void frmVIewTeamOfficial_Load(object sender, EventArgs e)
        {

        
            FillCombobox();
            listOfTeamOfficial = TeamOfficialHelper.GetAllOfficial(tournament);
            GetAllTeamOfficial();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            switch((int)btn.Tag)
            {
                case 1:
                    AddTeamOfficial();
                    break;
                case 2:
                    DeleteTeamOfficial();
                    break;
                case 3:
                    UpdateTeamOfficial();
                    break;
            }
        }

        private void AddTeamOfficial()
        {
            Team team = Team.GetTeam(listOfTeam,(int)cmbTeam.SelectedValue);

            if(teamOfficialByTeam.Count >= 3)
            {
                MessageBox.Show("There's no available slot for team official [" + team.teamName + "]");
                return;
            }
            using (Form f = new frmSaveTeamOfficial(team,teamOfficialByTeam))
            {
                if(DialogResult.OK == f.ShowDialog())
                {
                    MessageBox.Show("Sucessfully added team official");
                    listOfTeamOfficial = TeamOfficialHelper.GetAllOfficial(tournament);
                    GetAllTeamOfficial();
                }
            }
        }

        private void UpdateTeamOfficial()
        {
            int si = 0;
            TeamOfficial temp = null;
            try
            {
                si = lsvTeamOfficial.SelectedItems[0].Index;
                temp = teamOfficialByTeam[si];
            }
            catch
            {
                MessageBox.Show("Please select you wish to update");
                return;
            }

            Team team = Team.GetTeam(listOfTeam, (int)cmbTeam.SelectedValue);

            using (Form f = new frmSaveTeamOfficial(team, teamOfficialByTeam,temp))
            {
                if (DialogResult.OK == f.ShowDialog())
                {
                    MessageBox.Show("Sucessfully updated team official");
                    listOfTeamOfficial = TeamOfficialHelper.GetAllOfficial(tournament);
                    GetAllTeamOfficial();
                }
            }
        }
        private void DeleteTeamOfficial()
        {
            int si = 0;
            TeamOfficial temp = null;
            try
            {
                si = lsvTeamOfficial.SelectedItems[0].Index;
                temp = teamOfficialByTeam[si];
            }
            catch
            {
                MessageBox.Show("Please select you wish to delete");
                return;
            }
            
            if(DialogResult.Yes == MessageBox.Show("Do you really wish to delete[" + temp.firstName + " " + temp.lastName + "]","System",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2))
            {
                if (TeamOfficialHelper.DeleteTeamOfficial(temp) == 1)
                {
                    MessageBox.Show("Sucessfully deleted team official");
                    listOfTeamOfficial = TeamOfficialHelper.GetAllOfficial(tournament);
                    GetAllTeamOfficial();
                }
                else
                    MessageBox.Show("Error Deleting team official");
                
            }

        }
        private void FillCombobox()
        {
            listOfTeam = TeamHelper.GetTeam(tournament);
            cmbTeam.DataSource = listOfTeam;
            cmbTeam.DisplayMember = "teamName";
            cmbTeam.ValueMember = "teamID";
        }
        private void ShowByTeam()
        {
            int ci = (int)cmbTeam.SelectedValue;
            var data = from st in listOfTeamOfficial
                       where st.team.teamID == ci
                       select st;
            teamOfficialByTeam = new List<TeamOfficial>();
            foreach(var dr in data.AsEnumerable())
            {
                TeamOfficial official = new TeamOfficial()
                {
                    id = dr.id,
                    firstName = dr.firstName,
                    lastName = dr.lastName,
                    position = new StaffPosition()
                    {
                        positionID = dr.position.positionID,
                        positionDetail = dr.position.positionDetail,
                    },
                    team = new Team()
                    {
                        teamID = dr.team.teamID,
                        teamLogo = dr.team.teamName
                    }
                    
                };

                teamOfficialByTeam.Add(official);
            }

      
        }
        private void GetAllTeamOfficial()
        {
            
            lsvTeamOfficial.Clear();
            InitListView();
            ShowByTeam();
            ListViewItem item;
            int ctr = 0;
            foreach(var dr in teamOfficialByTeam)
            {
                item = lsvTeamOfficial.Items.Add(ctr++.ToString());
                item.SubItems.Add(dr.firstName + " " + dr.lastName);
                item.SubItems.Add(dr.position.positionDetail);
                item.SubItems.Add(dr.team.teamName);
            }

        }

        private void InitListView()
        {
            lsvTeamOfficial.Columns.Add("No.1", 30);
            lsvTeamOfficial.Columns.Add("Fullname", 300);
            lsvTeamOfficial.Columns.Add("Position", 200);
            lsvTeamOfficial.Columns.Add("Team", 200);

            lsvTeamOfficial.MultiSelect = false;
            lsvTeamOfficial.GridLines = true;
            lsvTeamOfficial.FullRowSelect = true;
            lsvTeamOfficial.HideSelection = true;
            lsvTeamOfficial.View = View.Details;
        }

        private void cmbTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetAllTeamOfficial();
            }
            catch
            {
                return;
            }
        }
    }
}
