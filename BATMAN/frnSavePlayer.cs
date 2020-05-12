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
    public partial class frnSavePlayer : Form
    {
        Team team = null;
        List<Player> list = null;
        public frnSavePlayer(Team team,List<Player> list = null)
        {
            InitializeComponent();
            this.team = team;
            this.list = list;
        }

        List<Player> listOfPlayer = null;


        private void frnSavePlayer_Load(object sender, EventArgs e)
        {
         
            InitPlayer();
            lblTeam.Text = team.teamName;
        }

        private void InitPlayer()
        {
         
            //FOR OLD PLAYER
            foreach (var data in list)
            {
                var player = new UCPlayer(data);
                flowLayoutPanel1.Controls.Add(player);
            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count >= 10)
            {
                btnAddPlayer.Visible = false;
                return;
            }

            var player = new UCPlayer();
            flowLayoutPanel1.Controls.Add(player);
            flowLayoutPanel1.Controls.SetChildIndex(player, flowLayoutPanel1.Controls.Count);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listOfPlayer = new List<Player>();

            int counter = 0;
            foreach (var c in flowLayoutPanel1.Controls.OfType<UCPlayer>())
            {
                if(c.txtFirstName.Text == "" || c.txtLastName.Text == "")
                {
                    MessageBox.Show("Please fill up firstname and lastname");
                    break;
                }
                else if(c.cmbNo.SelectedItem  == null)
                {
                    MessageBox.Show("Please select jersey number" + c.txtFirstName.Text);
                    break;
                }
                if(!isValid(c,counter))
                {
                    MessageBox.Show("The jersey no. of " + c.txtFirstName.Text + " " + c.txtLastName.Text + " is already taken");
                    break;
                }
                counter++;
            }

            if(counter >= flowLayoutPanel1.Controls.Count)
            {
                foreach (var c in flowLayoutPanel1.Controls.OfType<UCPlayer>())
                {
                    int id = (c.player == null) ? 0 : c.player.playerID;
                    Player player = new Player()
                    {
                        playerID = id,
                        firstName = c.txtFirstName.Text,
                        lastName = c.txtLastName.Text,
                        birthdate = c.dtpBirthDate.Value,
                        jerseyNO = short.Parse(c.cmbNo.SelectedItem.ToString()),
                        picture = c.fileName,
                        team = team,
                        position = new Position()
                        {
                            positionID = (int)c.cmbPosition.SelectedValue,
                        }


                    };

                    if (PlayerHelper.SavePlayer(player) == 0)
                    {
                        MessageBox.Show("Failed to update players");
                        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    }
                }
            }
            if(flowLayoutPanel1.Controls.Count == counter)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }

        }

        private bool isValid(UCPlayer player,int counter)
        {
            int counterCheck = 0;
            foreach (var c in flowLayoutPanel1.Controls.OfType<UCPlayer>())
            {
                if (counterCheck == counter)
                    continue;
                if(string.Equals(c.cmbNo.SelectedItem.ToString(), player.cmbNo.SelectedItem.ToString(), StringComparison.OrdinalIgnoreCase) )
                {
                    return false;

                }
                counterCheck++;
            }

            return true;
        }
    
    }

}
