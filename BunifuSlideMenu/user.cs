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
    public partial class user : Form
    {        
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=alkhair;Integrated Security=True; MultipleActiveResultSets=True;");
        SqlCommand cmd;
        connect conc = new connect();
        public user()
        {
            InitializeComponent();
        }

        private void user_Load(object sender, EventArgs e)
        {
            // comboBox1.DisplayMember = "hi";
            //comboBox1.
            //comboBox1.Items.Add("---Select---");
            //comboBox4.Items.Insert(0, "---Select---");
            //comboBox1.Items.Insert(0, "---Select---");
            comboBox4.SelectedText = "---Select---";
            comboBox1.SelectedText = "---Select---";
            // TODO: This line of code loads data into the 'alkhairDataSet3.user' table. You can move, or remove it, as needed.
            this.userTableAdapter.Fill(this.alkhairDataSet3.user);
            //panel1.Show();
            //MAXIMIZED DEFAULT
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            //conc.SetPlaceholder(bunifuCustomTextbox2, "xxxxx-xxxxxxx-x");
            //conc.SetPlaceholder(bunifuCustomTextbox1, "xxxx-xxxxxxx");
            //conc.SetPlaceholder(bunifuCustomTextbox4, "xxxxx-xxxxxxx-x");
            //conc.SetPlaceholder(bunifuCustomTextbox3, "xxxx-xxxxxxx");


        }



        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            conc.insert("insert into [user] ([name],[password],[cnic],[contact]) values ('" + bunifuCustomTextbox14.Text + "','" + bunifuCustomTextbox13.Text + "','" + bunifuCustomTextbox2.Text + "','" + bunifuCustomTextbox1.Text + "')");
            MessageBox.Show("Data Inserted");
            bunifuCustomTextbox1.Text = "";
            bunifuCustomTextbox2.Text = "";
            bunifuCustomTextbox13.Text = "";
            bunifuCustomTextbox14.Text = "";
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            conc.search("select * from [user] where name = '" + comboBox1.Text + "'", bunifuCustomDataGrid3);
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            conc.deleteUpdate("Update [user] set[name] ='" + comboBox4.Text + "' , [password] ='" + bunifuCustomTextbox5.Text + "' , [cnic] ='" + bunifuCustomTextbox4.Text + "' , [contact] ='" + bunifuCustomTextbox3.Text + "' where [name] ='" + comboBox4.Text + "'");
            MessageBox.Show("Data Updated");
            bunifuCustomTextbox5.Text = "";
            bunifuCustomTextbox4.Text = "";
            bunifuCustomTextbox3.Text = "";            
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

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            ////this.Hide();
            //user f = new user();
            //f.Show();
            panel3.Hide();
            panel7.Hide();
            panel1.Show();
            panel6.Show();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            this.userTableAdapter.Fill(this.alkhairDataSet3.user);
            ////this.Hide();
            //user f = new user();
            //f.Show();
            //user f = new user();
            //this.Hide();
            //f.Show();
            panel1.Hide();
            panel7.Hide();
            panel3.Show();
            panel6.Hide();
            panel4.Show();
            
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            this.userTableAdapter.Fill(this.alkhairDataSet3.user);
            //this.Hide();
            //user f = new user();
            panel1.Hide();
            panel3.Hide();

            //f.Show();
            //f.panel7.Show();
            panel7.Show();
            //panel7.Show();
            
            
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SET TEXBOXES DATA WRT TO GR NO
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [user] where [name] ='" + comboBox4.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                bunifuCustomTextbox5.Text = (dr["password"].ToString());
                bunifuCustomTextbox4.Text = (dr["cnic"].ToString());
                bunifuCustomTextbox3.Text = (dr["contact"].ToString());
            }
            con.Close();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            uv f = new uv();
            this.Hide();
            f.Show();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            uv f = new uv();
            this.Hide();
            f.Show();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            conc.deleteUpdate("Delete from [user] where [name]='" + comboBox1.Text + "'");
            MessageBox.Show("Data Deleted");
            bunifuCustomDataGrid3.Update();
            bunifuCustomDataGrid3.Refresh();
            this.userTableAdapter.Fill(this.alkhairDataSet3.user);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomTextbox14_TextChanged(object sender, EventArgs e)
        {
            //TEXT VALIDATION
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(bunifuCustomTextbox14.Text, "^[0-9]"))
                {
                    MessageBox.Show("Please enter only alphabets.");
                    bunifuCustomTextbox14.Text = bunifuCustomTextbox14.Text.Remove(bunifuCustomTextbox14.Text.Length - 1);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void bunifuCustomTextbox2_TextChanged(object sender, EventArgs e)
        {
            //CNIC
            //ENTER NUMBER VALIDATION
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(bunifuCustomTextbox2.Text, "^[0-9,-]{16}") || (System.Text.RegularExpressions.Regex.IsMatch(bunifuCustomTextbox2.Text, "[^0-9,-]")))
                {
                    MessageBox.Show("Invalid Format!");
                    bunifuCustomTextbox2.Text = bunifuCustomTextbox2.Text.Remove(bunifuCustomTextbox2.Text.Length - 1);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void bunifuCustomTextbox1_TextChanged(object sender, EventArgs e)
        {
            //CONTACT
            //ENTER NUMBER VALIDATION
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(bunifuCustomTextbox1.Text, "^[0-9]{12}") || (System.Text.RegularExpressions.Regex.IsMatch(bunifuCustomTextbox1.Text, "[^0-9]")))
                {
                    MessageBox.Show("Invalid Format!");
                    bunifuCustomTextbox1.Text = bunifuCustomTextbox1.Text.Remove(bunifuCustomTextbox1.Text.Length - 1);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void bunifuCustomTextbox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCustomTextbox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomTextbox4_TextChanged(object sender, EventArgs e)
        {
            ////CNIC
            ////ENTER NUMBER VALIDATION
            //try
            //{
            //    if (System.Text.RegularExpressions.Regex.IsMatch(bunifuCustomTextbox4.Text, "^[0-9,-]{16}") || (System.Text.RegularExpressions.Regex.IsMatch(bunifuCustomTextbox4.Text, "[^0-9,-]")))
            //    {
            //        MessageBox.Show("Invalid Format!");
            //        bunifuCustomTextbox4.Text = bunifuCustomTextbox4.Text.Remove(bunifuCustomTextbox4.Text.Length - 1);
            //    }
            //}
            //catch (Exception Ex)
            //{
            //    MessageBox.Show(Ex.Message);
            //}
        }

        private void bunifuCustomTextbox3_TextChanged(object sender, EventArgs e)
        {
            ////CONTACT
            ////ENTER NUMBER VALIDATION
            //try
            //{
            //    if (System.Text.RegularExpressions.Regex.IsMatch(bunifuCustomTextbox3.Text, "^[0-9]{12}") || (System.Text.RegularExpressions.Regex.IsMatch(bunifuCustomTextbox3.Text, "[^0-9]")))
            //    {
            //        MessageBox.Show("Invalid Format!");
            //        bunifuCustomTextbox3.Text = bunifuCustomTextbox3.Text.Remove(bunifuCustomTextbox3.Text.Length - 1);
            //    }
            //}
            //catch (Exception Ex)
            //{
            //    MessageBox.Show(Ex.Message);
            //}
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCustomTextbox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCustomTextbox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void bunifuCustomTextbox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                bunifuThinButton22_Click(sender, e);
            }
        }

        private void bunifuCustomTextbox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Enter)
            //{
            //    e.Handled = true;
            //    bunifuThinButton21_Click(sender, e);
            //}
        }

        private void bunifuCustomTextbox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                bunifuThinButton21_Click(sender, e);
            }
        }
    }
}
