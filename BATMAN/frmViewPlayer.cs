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
    public partial class frmViewPlayer : Form
    {
        Tournament tournament = null;

        List<Team> teamList = null;
        List<Player> listOfPlayer = null;
        List<Player> listByTeam = null;
        public frmViewPlayer(Tournament tournament)
        {
            InitializeComponent();
            this.tournament = tournament;
        }

        private void frmViewPlayer_Load(object sender, EventArgs e)
        {

            teamList = new List<Team>();
            GetTeam();
            GetPlayer();

            //ADD TAG
            btnUpdate.Tag = 2;
           
            //ADD CLICK EVENT
            btnUpdate.Click += Button_Click;
         
             
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            switch((int)btn.Tag)
            {
             
                case 2:
                    UpdatePlayer();
                    break;
                case 3:
                    DeletePlayer();
                    break;
            }
        }

      

        private void UpdatePlayer()
        {
            Team team = new Team()
            {
                teamName = teamList[cmbTeam.SelectedIndex].teamName,
                teamID = (int)cmbTeam.SelectedValue,
            };
            int teamID = (int)cmbTeam.SelectedValue;
            List<Player> listByTeam = Player.PlayerByTeam(listOfPlayer, teamID);

          
            using (Form f = new frnSavePlayer(team,listByTeam))
            {
                if(DialogResult.OK == f.ShowDialog())
                {
                    MessageBox.Show("Successfully Updated the player");
                    GetPlayer();
                    return;
                }

            }
        }

        private void DeletePlayer()
        {
            int si = 0;

            try
            {
                si = lsvPlayer.SelectedItems[0].Index;
            }
            catch
            {
                MessageBox.Show("Please select you wish to delete");
                return;
            }

            if (DialogResult.OK == MessageBox.Show("Do you really wish to delete [" + listByTeam[si].firstName + " " + listByTeam[si].lastName + "]", "System", MessageBoxButtons.OKCancel))
            {
                PlayerHelper.DeletePlayer(listByTeam[si]);
                MessageBox.Show("Successfuly deleted");
                GetPlayer();
            }
        }
        private int countPlayer()
        {
            return lsvPlayer.Items.Count;
        }
        private void GetTeam()
        {
            teamList = TeamHelper.GetTeam(tournament);
            cmbTeam.DataSource = teamList;
            cmbTeam.DisplayMember = "teamName";
            cmbTeam.ValueMember = "teamID";
        }
        private void InitListView()
        {
            lsvPlayer.Columns.Add("Jersey No.", 150);
            lsvPlayer.Columns.Add("Full name", 300);
            lsvPlayer.Columns.Add("Age",100);
            lsvPlayer.Columns.Add("Position", 180);
            lsvPlayer.Columns.Add("Team", 200);

            lsvPlayer.MultiSelect = false;
            lsvPlayer.GridLines = true;
            lsvPlayer.FullRowSelect = true;
            lsvPlayer.HideSelection = true;
            lsvPlayer.View = View.Details;
        }

        private void GetPlayer()
        {
            lsvPlayer.Clear();
            InitListView();
            listOfPlayer = PlayerHelper.GetPlayer(tournament);
            int teamID = (int)cmbTeam.SelectedValue;
           listByTeam = Player.PlayerByTeam(listOfPlayer, teamID);
            ListViewItem item;

            foreach(var player in listByTeam)
            {
                item = lsvPlayer.Items.Add(player.jerseyNO.ToString());
                item.SubItems.Add(player.firstName + " " + player.lastName);
                item.SubItems.Add((DateTime.Now.Year - player.birthdate.Year).ToString());
                item.SubItems.Add(player.position.positionName);
                item.SubItems.Add(player.team.teamName);
            }
        }

        private void cmbTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetPlayer();
            }
            catch { return; }
        }
    }
}
