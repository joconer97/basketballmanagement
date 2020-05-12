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
    public partial class frmAddGameOfficial : Form
    {
        GameOfficial official = null;
        public frmAddGameOfficial(GameOfficial official = null)
        {
            InitializeComponent();
            this.official = official;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(textBox1.Text.Length <= 0 || textBox2.Text.Length <= 0)
            {
                MessageBox.Show("Please fill up the blank");
                return;
            }
            official.firstName = textBox1.Text;
            official.lastName = textBox2.Text;

            try
            {
                GameOfficialHelper.SaveGameOfficial(official);
            }
            catch
            {
                MessageBox.Show("Error saving game official");
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void frmAddGameOfficial_Load(object sender, EventArgs e)
        {
            if(official != null)
            {
                textBox1.Text = official.firstName;
                textBox2.Text = official.lastName;
            }
        }
    }
}
