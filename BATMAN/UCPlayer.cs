using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BATMAN.Classes;

namespace BATMAN
{
    public partial class UCPlayer : UserControl
    {
       public Player player = null;
        public string fileName = (@"C:\Users\JOSHUA\Documents\Visual Studio 2015\Projects\BATMAN\Images\male-shadow.jpg");
        string defaultPicture = (@"C:\Users\JOSHUA\Documents\Visual Studio 2015\Projects\BATMAN\Images\male-shadow.jpg");
        public UCPlayer(Player player = null)
        {
            InitializeComponent();
            this.player = player;
        }

        private void UCPlayer_Load(object sender, EventArgs e)
        {
            pcbImage.Image = Image.FromFile(defaultPicture);
            InitPosition();
            GenerateNumber();
            InitPlayer();
           
        }

        private void InitPosition()
        {
            cmbPosition.DataSource = PositionHelper.GetPosition();
            cmbPosition.ValueMember = "positionID";
            cmbPosition.DisplayMember = "positionName";
        }

        private void InitPlayer()
        {
           
            if (player != null)
            {
                fileName = (player.picture == "") ? defaultPicture : player.picture;
                txtFirstName.Text = player.firstName;
                txtLastName.Text = player.lastName;
                dtpBirthDate.Value = player.birthdate;
                cmbNo.Text = player.jerseyNO.ToString();
                pcbImage.Image = Image.FromFile(fileName);
            }
        }
        private void GenerateNumber()
        {
            var number = new List<short>();

            for (int i = 0; i <= 55; i++)
            {

                //Console.Write(i + " ");
                cmbNo.Items.Add(i);
                if (i % 5 == 0 && i != 0)
                {
                    //Console.WriteLine();
                 

                    i += 5;
                    if (i == 60)
                        break;
                    //Console.Write(i + " ");
                    cmbNo.Items.Add(i);
                }
            }
        }

        private void pcbImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog f = new OpenFileDialog())
            {
                f.Filter = "Images (*.jpg,*.jpeg,*.png | *.jpg;*.jpeg;*.png;)";
                if(f.ShowDialog() == DialogResult.OK)
                {
                    fileName = f.FileName;
                    pcbImage.Image = Image.FromFile(fileName);
                }
               
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string message = "Do you really wish to delete [" + player.firstName + " " + player.lastName + "]";
                if (DialogResult.Yes == MessageBox.Show(message, "System", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    PlayerHelper.DeletePlayer(player);
                    this.Dispose();
                }
            }
            catch { this.Dispose(); }
        }
    }
}
