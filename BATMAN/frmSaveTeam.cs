using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BATMAN.Classes;

namespace BATMAN
{
    public partial class frmSaveTeam : Form
    {
        List<Baranggay> listOfBarangay = null;
        List<Team> listOfTeam = null;
        Tournament tournament = null;
        List<TeamOfficial> teamOfficialByTeam = null;
        Team team = null;
        public frmSaveTeam(Tournament tournament,Team team = null)
        {
            InitializeComponent();
            this.tournament = tournament;
            this.team = team;
        }
        string fileName = string.Empty;
        private void frmSaveTeam_Load(object sender, EventArgs e)
        {
            InitSaveTeam();
            listOfTeam = TeamHelper.GetTeam(tournament);
        }

        private void InitSaveTeam()
        {
            
            ShowByTeam();
            listOfBarangay = BarangayHelper.GetAllBarangay();
            cmbBarangay.DataSource = listOfBarangay;
            cmbBarangay.DisplayMember = "name";
            cmbBarangay.ValueMember = "id";

            if (team != null)
            {
                this.Text = "Updating Team";
                txtName.Text = team.teamName;
                txtSlogan.Text = team.teamSlogan;
                pcbLogo.Image = Image.FromFile(team.teamLogo);
                cmbBarangay.SelectedValue = team.barangay.id;
                fileName = team.teamLogo;
                txtFirstName1.Text = teamOfficialByTeam[0].firstName;
                txtFirstName2.Text = teamOfficialByTeam[1].firstName;
                txtFirstName3.Text = teamOfficialByTeam[2].firstName;
                txtLastName1.Text = teamOfficialByTeam[0].lastName;
                txtLastName2.Text = teamOfficialByTeam[1].lastName;
                txtLastName3.Text = teamOfficialByTeam[2].lastName;
            }
        }
        private void ShowByTeam()
        {
            List<TeamOfficial> listTeamOfficial = TeamOfficialHelper.GetAllOfficial(tournament);

            if (listTeamOfficial == null) return;
            int ci = (team == null)?0:team.teamID;
            var data = from st in listTeamOfficial
                       where st.team.teamID == ci
                       select st;
            teamOfficialByTeam = new List<TeamOfficial>();
            foreach (var dr in data.AsEnumerable())
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
        private void pcbLogo_DoubleClick(object sender, EventArgs e)
        {

            using (OpenFileDialog file = new OpenFileDialog())
            {
                file.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                if(DialogResult.OK == file.ShowDialog())
                {
                    fileName = file.FileName;
                    pcbLogo.Image = Image.FromFile(fileName);

                }
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtFirstName1.Text == "" || txtFirstName2.Text == "" || txtFirstName3.Text == "" || txtLastName1.Text == "" || txtLastName2.Text == "" || txtLastName3.Text == "")
            {
                MessageBox.Show("Fill up the empty blank");
                return;
            }

            if (!SaveTeam() )
                return;

         
            team = Team.GetTeamByName(tournament, txtName.Text);
            int id1 = 0;
            int id2 = 0;
            int id3 = 0;
            if(!(teamOfficialByTeam.Count <= 0))
            {
               id1 = (teamOfficialByTeam[0] == null) ? 0 : teamOfficialByTeam[0].id;
               id2 = (teamOfficialByTeam[1] == null) ? 0 : teamOfficialByTeam[1].id;
               id3 = (teamOfficialByTeam[2] == null) ? 0 : teamOfficialByTeam[2].id;
            }
           
            TeamOfficial coach = new TeamOfficial()
            {
                id = id1,
                firstName = txtFirstName1.Text,
                lastName = txtLastName1.Text,
                position = new StaffPosition()
                {
                    positionID = 1,
                    positionDetail = "Coach",
                },
                team = new Team()
                {
                    teamID = team.teamID
                }
            };
       
            TeamOfficial assistant_coach = new TeamOfficial()
            {
                id = id2,
                firstName = txtFirstName2.Text,
                lastName = txtLastName2.Text,
                position = new StaffPosition()
                {
                    positionID = 2,
                    positionDetail = "Assistant Coach"
                },
                team = new Team()
                {
                    teamID = team.teamID
                }
            };
      
            TeamOfficial manager = new TeamOfficial()
            {
                id = id3,
                firstName = txtFirstName3.Text,
                lastName = txtLastName3.Text,
                position = new StaffPosition()
                {
                    positionID = 3,
                    positionDetail = "Manager"
                },
                team = new Team()
                {
                    teamID = team.teamID
                }
            };

            TeamOfficialHelper.SaveTeamOfficial(coach);
            TeamOfficialHelper.SaveTeamOfficial(assistant_coach);
            TeamOfficialHelper.SaveTeamOfficial(manager);

        }
        private void SaveTeamOfficial(TeamOfficial official,int position)
        {
            TeamOfficial official1 = new TeamOfficial()
            {
                id = (official == null) ? 0 : official.id,
                firstName = txtFirstName1.Text,
                lastName = txtLastName1.Text,
                position = new StaffPosition()
                {
                    positionID = (short)position,
 
                },
                team = team

            };

            if (TeamOfficialHelper.SaveTeamOfficial(official1) == 0)
            {
                MessageBox.Show("Error Saving Team Official");
                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private bool SaveTeam()
        {
           
            int id = (team == null) ? 0 : team.teamID;
            
            Team updateTeam = new Team()
            {
                teamID = id,
                teamName = txtName.Text,
                teamLogo = fileName,
                teamSlogan = txtSlogan.Text,
                
                barangay = new Baranggay()
                {
                    id = (int)cmbBarangay.SelectedValue,
                    name = cmbBarangay.SelectedItem.ToString(),
                },
                tournament = tournament
            };
           if(fileName == "")
            {
                MessageBox.Show("Please put an logo");
                return false;
            }
           if(!Team.isValid(listOfTeam,updateTeam,team))
            {
                MessageBox.Show("The team name or baranggay are already use");
                return false;
            }
        
            if(TeamHelper.SaveTeam(updateTeam) == 0)
            {
                MessageBox.Show("Error saving team");
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            return true;
            
        }


    }
}
