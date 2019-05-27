using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BunifuSlideMenu
{
    public partial class Form1 : Form
    {
        connect conc = new connect();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

        }

        private void btnSlidingPanel_Click(object sender, EventArgs e)
        {
            if (slidePane.Width == 38)
            {
                slidePane.Visible = false;
                slidePane.Width = 189;
                panelAnimator.ShowSync(slidePane);
                logoAnimator.ShowSync(largeLogo);
            }
            else
            {
                logoAnimator.Hide(largeLogo);
                slidePane.Visible = false;
                slidePane.Width = 38;
                panelAnimator.ShowSync(slidePane);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            s f1 = new s();
            f1.Show();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            this.Hide();
            s f1 = new s();
            f1.Show();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            uv m = new uv();
            m.Show();            
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            t t = new t();
            t.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            t t = new t();
            t.Show();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are You Sure, You want to LogOut?","LogOut",MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                this.Hide();
                uv m = new uv();
                m.Show();
            }
            else
            {

            }

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            //at f = new at();
            //this.Hide();
            //f.Show();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            //at f = new at();
            //this.Hide();
            //f.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            
            f f = new f();
            this.Hide();
            f.Show();
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            
            f f = new f();
            this.Hide();
            f.Show();
        }
    }
}
