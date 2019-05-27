using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BunifuSlideMenu
{
    public partial class uv : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=alkhair;Integrated Security=True; MultipleActiveResultSets=True;");
        SqlCommand cmd;
        connect conc = new connect();
        public uv()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {                
            con.Open();
                SqlCommand cmd = new SqlCommand("select name,password from [user] where name='" + bunifuCustomTextbox3.Text + "'and password='" + bunifuCustomTextbox2.Text + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    this.Hide();
                    Form1 f = new Form1();
                    f.Show();

                }
                else
                {
                    MessageBox.Show("Invalid Login please check username and password");
                }
                con.Close();

                bunifuCustomTextbox2.Clear();
                bunifuCustomTextbox2.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            panel3.Hide();
            panel2.Show();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            panel3.Show();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            if (bunifuCustomTextbox21.Text.Equals("admin") && bunifuCustomTextbox1.Text.Equals("123"))
            {
                user u = new user();
                this.Hide();
                u.Show();
            }
            else
            {
                MessageBox.Show("Invalid Entry!");
            }
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            m u = new m();
            this.Hide();
            u.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //MINIMIZE
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //MINIMIZE AND MAXIMIZE
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnSlidingPanel_Click(object sender, EventArgs e)
        {
            //SIDE PANEL TRANSITION
            try
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
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void uv_Load(object sender, EventArgs e)
        {
            
            //this.AcceptButton = bunifuThinButton21;
            //MAXIMIZED DEFAULT
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
        }

        private void bunifuCustomTextbox2_TextChanged(object sender, EventArgs e)
        {
            //bunifuCustomTextbox2.KeyUp += new KeyEventHandler(bunifuCustomTextbox2_KeyUp);

            //static void tb_KeyDown(object sender, KeyEventArgs e)
            //{
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        bunifuThinButton21_Click(sender, e);
            //    }
            //}
        }
        private void bunifuCustomTextbox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bunifuThinButton21_Click(sender, e);
            }

        }

        private void bunifuCustomTextbox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                bunifuThinButton21_Click(sender,e);
            }
        }

        private void bunifuCustomTextbox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomTextbox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                bunifuThinButton24_Click(sender, e);
            }
        }
    }
}
