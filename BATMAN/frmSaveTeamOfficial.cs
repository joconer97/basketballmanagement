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
    public partial class frmSaveTeamOfficial : Form
    {
        List<StaffPosition> position = null;
        List<TeamOfficial> list = null;
        TeamOfficial official = null;
        Team team = null;
        public frmSaveTeamOfficial(Team team = null,List<TeamOfficial> listOfficial  = null,TeamOfficial official = null)
        {
            InitializeComponent();
            this.team = team;
            list = listOfficial;
            this.official = official;
   
        }

        private void frmTeamOfficial_Load(object sender, EventArgs e)
        {
            GetStaffPosition();
            InitUpdateTeamOfficial();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TeamOfficial official1 = new TeamOfficial()
            {
                id = (official == null) ? 0 : official.id,
                firstName = txtFirstName1.Text,
                lastName = txtLastName1.Text,
                position = new StaffPosition()
                {
                    positionID = (short)cmbPosition.SelectedValue,
                    positionDetail = cmbPosition.SelectedItem.ToString(),
                },
                team = team
                
            };

            if(TeamOfficialHelper.SaveTeamOfficial(official1) == 0)
            {
                MessageBox.Show("Error Saving Team Official");
                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void InitUpdateTeamOfficial()
        {
            if (official != null)
            {
                txtFirstName1.Text = official.firstName;
                txtLastName1.Text = official.lastName;
                cmbPosition.DisplayMember = "official.position";
            }
        }
        private void GetStaffPosition()
        {
            position = StaffPositionHelper.GetAllPosition();
            position  = TeamOfficial.listOfPositionAvailable(position, list);
            cmbPosition.DataSource = position;
            cmbPosition.DisplayMember = "positionDetail";
            cmbPosition.ValueMember = "positionID";
        }

      
    }
}

