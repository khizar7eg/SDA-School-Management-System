using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BunifuSlideMenu
{
    public partial class s : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=alkhair;Integrated Security=True; MultipleActiveResultSets=True;");
        SqlCommand cmd;
        connect conc = new connect();
        public s()
        {
            InitializeComponent();
        }
        
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            //INSERT STUDENT DATA RECORD
            try
            {
                conc.insert("insert into student ([StudentName],[G#R No],[D#O#B],[Profession],[House Position],[Income],[Family Member],[No# of Sibling],[Contact],[Address],[C#N#I#C],[Class],[Section],[Shift]) values ('" + bunifuCustomTextbox1.Text + "','" + bunifuCustomTextbox3.Text + "','" + bunifuCustomTextbox10.Text + "','" + bunifuCustomTextbox4.Text + "','" + bunifuCustomTextbox5.Text + "','" + bunifuCustomTextbox6.Text + "','" + bunifuCustomTextbox7.Text + "','" + bunifuCustomTextbox14.Text + "','" + bunifuCustomTextbox13.Text + "','" + bunifuCustomTextbox11.Text + "','" + bunifuCustomTextbox2.Text + "','" + comboBox3.Text + "','" + comboBox5.Text + "','" + comboBox2.Text + "')");
                MessageBox.Show("New Student Record Added.");
                clear();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
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

        private void s_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = "---Select---";
            comboBox4.SelectedItem = "---Select---";
            comboBox11.SelectedItem = "---Select---";
            //conc.SetPlaceholder(bunifuCustomTextbox35, "xxxxx-xxxxxxx-x");
            //conc.SetPlaceholder(bunifuCustomTextbox36, "xxxx-xxxxxxx");
            //conc.SetPlaceholder(bunifuCustomTextbox9, "dd/mm/yyyy");
            //conc.SetPlaceholder(bunifuCustomTextbox2, "xxxxx-xxxxxxx-x");
            //conc.SetPlaceholder(bunifuCustomTextbox13, "xxxx-xxxxxxx");
            //conc.SetPlaceholder(bunifuCustomTextbox10, "dd/mm/yyyy");




            conc.search("Select * from student ", bunifuCustomDataGrid2);
            //CLEAR TEXT BOXES
            clear();
            //MAXIMIZED DEFAULT
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            //INSERT DATA IN COMBO BOX
            try
            {
                comboBox9.Items.Clear();
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT DISTINCT [Shift] FROM student";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox9.Items.Add(dr["Shift"].ToString());
                    con.Close();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            //CLEAR TEX BOXES
            clear();
            //OPEN PANEL
            panel1.Hide();
            panel10.Hide();
            panel3.Hide();
            panel13.Show();
            //DON'T KNOW GR NO (DISABLE)
            comboBox9.Enabled = false;
            comboBox8.Enabled = false;
            comboBox7.Enabled = false;
            comboBox6.Enabled = false;
            comboBox10.Enabled = false;
        }

        public void clear()
        {
            //CLEAR TEX FIELD
            bunifuCustomTextbox34.Text = "";
            bunifuCustomTextbox37.Text = "";
            bunifuCustomTextbox9.Text = "";
            bunifuCustomTextbox38.Text = "";
            bunifuCustomTextbox30.Text = "";
            bunifuCustomTextbox40.Text = "";
            bunifuCustomTextbox41.Text = "";
            bunifuCustomTextbox39.Text = "";
            bunifuCustomTextbox36.Text = "";
            bunifuCustomTextbox29.Text = "";
            bunifuCustomTextbox35.Text = "";
            comboBox1.Text = "";
            comboBox4.Text = "";
            comboBox11.Text = "";
            bunifuCustomTextbox1.Text = "";
            bunifuCustomTextbox3.Text = "";
            bunifuCustomTextbox10.Text = "";
            bunifuCustomTextbox4.Text = "";
            bunifuCustomTextbox5.Text = "";
            bunifuCustomTextbox6.Text = "";
            bunifuCustomTextbox7.Text = "";
            bunifuCustomTextbox14.Text = "";
            bunifuCustomTextbox13.Text = "";
            bunifuCustomTextbox11.Text = "";
            bunifuCustomTextbox2.Text = "";
            comboBox3.Text = "";
            comboBox5.Text = "";
            comboBox2.Text = "";
            bunifuCustomTextbox8.Text = "";
            comboBox9.Text = "";
            comboBox8.Text = "";
            comboBox7.Text = "";
            comboBox6.Text = "";
            comboBox10.Text = "";
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            //CLEAR TEXT BOXES
            clear();
            //OPEN PANEL
            panel13.Hide();
            panel10.Hide();
            panel3.Hide();
            panel1.Show();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            //CLEAR TEX BOXES
            clear();
            //OPEN PANEL
            panel3.Hide();
            panel10.Hide();
            panel1.Hide();
            panel13.Show();
            //DON'T KNOW GR NO (DISABLE)
            comboBox9.Enabled = false;
            comboBox8.Enabled = false;
            comboBox7.Enabled = false;
            comboBox6.Enabled = false;
            comboBox10.Enabled = false;
        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
            //SET TEXBOXES DATA WRT TO GR NO
            bunifuCustomTextbox37.Text = bunifuCustomTextbox8.Text;
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM student where [G#R No] ='"+bunifuCustomTextbox8.Text+"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                bunifuCustomTextbox34.Text = (dr[1].ToString());
                bunifuCustomTextbox37.Text = (dr["G#R No"].ToString());
                bunifuCustomTextbox9.Text = (dr["D#O#B"].ToString());
                bunifuCustomTextbox38.Text = (dr["Profession"].ToString());
                bunifuCustomTextbox30.Text = (dr["House Position"].ToString());
                bunifuCustomTextbox40.Text = (dr["Income"].ToString());
                bunifuCustomTextbox41.Text = (dr["Family Member"].ToString());
                bunifuCustomTextbox39.Text = (dr["No# of Sibling"].ToString());
                bunifuCustomTextbox36.Text = (dr["Contact"].ToString());
                bunifuCustomTextbox29.Text = (dr["Address"].ToString());
                bunifuCustomTextbox35.Text = (dr["C#N#I#C"].ToString());
                comboBox4.Text = (dr["Class"].ToString());
                comboBox11.Text = (dr["Section"].ToString());
                comboBox1.Text = (dr["Shift"].ToString());
                
            }
            con.Close();
            //OPEN PANEL
            panel13.Hide();
            panel10.Hide();
            panel1.Hide();
            panel3.Show();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            if (bunifuCustomTextbox8.Enabled == true)
            {
                conc.search("Select * from student where [G#R No]='" + bunifuCustomTextbox8.Text + "'", bunifuCustomDataGrid2);
            }
            else if (bunifuCustomTextbox8.Enabled == false)
            {
                if (comboBox10.SelectedItem == null && comboBox6.SelectedItem == null && comboBox7.SelectedItem == null && comboBox8.SelectedItem == null)
                {
                    conc.search("Select * from student where [Shift]='" + comboBox9.Text + "' ", bunifuCustomDataGrid2);
                }
                else if (comboBox10.SelectedItem == null && comboBox6.SelectedItem == null && comboBox7.SelectedItem == null)
                {
                    conc.search("Select * from student where [Shift]='" + comboBox9.Text + "' and [Class]='" + comboBox8.Text + "' ", bunifuCustomDataGrid2);
                }
                else if (comboBox10.SelectedItem == null && comboBox6.SelectedItem == null)
                {
                    conc.search("Select * from student where [Shift]='" + comboBox9.Text + "' and [Class]='" + comboBox8.Text + "'and [Section]='" + comboBox7.Text + "' ", bunifuCustomDataGrid2);
                }
                else if (comboBox10.SelectedItem == null)
                {
                    conc.search("Select * from student where [Shift]='" + comboBox9.Text + "' and [Class]='" + comboBox8.Text + "'and [Section]='" + comboBox7.Text + "' and [StudentName]='" + comboBox6.Text + "'", bunifuCustomDataGrid2);
                }
                else if (comboBox10.SelectedItem == null && comboBox6.SelectedItem == null && comboBox7.SelectedItem == null && comboBox8.SelectedItem == null && bunifuCustomTextbox8.Text == null)
                {
                    conc.search("Select * from student ", bunifuCustomDataGrid2);
                }
                else
                {
                    conc.search("Select * from student where [G#R No]='" + bunifuCustomTextbox8.Text + "'", bunifuCustomDataGrid2);
                }
            }

            //SEARCH STUDENT DATA RECORD
            //conc.search("Select * from student where [Shift]='"+comboBox9.Text+"' and [Class]='"+comboBox8.Text+"' and [Section]='"+comboBox7.Text+"' and [StudentName]='"+comboBox6.Text+"' and [G#R No]='"+comboBox10.Text+"'" , bunifuCustomDataGrid2);
            //OPEN PANEL
            panel3.Hide();
            panel13.Hide();
            panel1.Hide();
            panel10.Show();
        }

        private void vScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            this.panel9.AutoScroll = true;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            this.panel5.AutoScroll = true;
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SET COMBO BOX WRT OTHER COMBO BOX
            cmd = new SqlCommand("Select DISTINCT [Class] from student where [Shift] ='" + comboBox9.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox8.Items.Clear();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT DISTINCT [Class] FROM student where [Shift] ='" + comboBox9.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow drr in dt.Rows)
                {
                    comboBox8.Items.Add(drr["Class"].ToString());
                }
            }
            con.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (bunifuCustomTextbox8.Enabled == true)
            {
                comboBox9.Enabled = true;
                comboBox8.Enabled = true;
                comboBox7.Enabled = true;
                comboBox6.Enabled = true;
                comboBox10.Enabled = true;
                bunifuCustomTextbox8.Enabled = false;
            }
            else if (bunifuCustomTextbox8.Enabled == false)
            {
                comboBox9.Enabled = false;
                comboBox8.Enabled = false;
                comboBox7.Enabled = false;
                comboBox6.Enabled = false;
                comboBox10.Enabled = false;
                bunifuCustomTextbox8.Enabled = true;
            }
            //ENABLE OR DISABLE TEXT FIELD WRT TO GR#

        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SET COMBO BOX WRT OTHER COMBO BOX
            cmd = new SqlCommand("Select DISTINCT [Section] from student where [Shift] ='" + comboBox9.Text + "' and [Class] ='" + comboBox8.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox7.Items.Clear();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT DISTINCT [Section] FROM student where [Shift] ='" + comboBox9.Text + "' and [Class] ='" + comboBox8.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow drr in dt.Rows)
                {
                    comboBox7.Items.Add(drr["Section"].ToString());
                }
            }
            con.Close();            
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SET COMBO BOX WRT OTHER COMBO BOX
            cmd = new SqlCommand("Select DISTINCT [Section] from student where [Shift] ='" + comboBox9.Text + "' and [Class] ='" + comboBox8.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox6.Items.Clear();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT DISTINCT [StudentName] FROM student where [Shift] ='" + comboBox9.Text + "' and [Class] ='" + comboBox8.Text + "' and [Section] ='" + comboBox7.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow drr in dt.Rows)
                {
                    comboBox6.Items.Add(drr["StudentName"].ToString());
                }
            }
            con.Close();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SET COMBO BOX WRT OTHER COMBO BOX
            cmd = new SqlCommand("Select DISTINCT [G#R No] from student where [Shift] ='" + comboBox9.Text + "' and [Class] ='" + comboBox8.Text + "' and [Section] ='" + comboBox7.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox10.Items.Clear();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT [G#R No] FROM student where [Shift] ='" + comboBox9.Text + "' and [Class] ='" + comboBox8.Text + "' and [Section] ='" + comboBox7.Text + "' and [StudentName] ='" + comboBox6.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow drr in dt.Rows)
                {
                    comboBox10.Items.Add(drr["G#R No"].ToString());
                }
            }
            con.Close();
        }

        private void panel8_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SET SEARCHED RESULT IN TEXT BOX
            bunifuCustomTextbox8.Text = comboBox10.Text;            
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            //STUDENT RECORD UPDATE
            try
            {
                conc.deleteUpdate("Update student set[StudentName] ='" + bunifuCustomTextbox34.Text + "' , [C#N#I#C] ='" + bunifuCustomTextbox35.Text + "' , [G#R No] ='" + bunifuCustomTextbox37.Text + "' , [Profession] ='" + bunifuCustomTextbox38.Text + "' , [House Position] ='" + bunifuCustomTextbox30.Text + "' , [Income] ='" + bunifuCustomTextbox30.Text + "' , [Family Member] ='" + bunifuCustomTextbox41.Text + "' , [No# of Sibling] ='" + bunifuCustomTextbox39.Text + "' , [D#O#B] ='" + bunifuCustomTextbox9.Text + "' , [Address] ='" + bunifuCustomTextbox29.Text + "' , [Contact] ='" + bunifuCustomTextbox36.Text + "' , [Shift] ='" + comboBox1.Text + "' , [Class] ='" + comboBox4.Text + "' , [Section] ='" + comboBox11.Text + "' where [G#R No] ='" + bunifuCustomTextbox37.Text + "'");
                MessageBox.Show("Student Record Updated.");
                clear();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                clear();
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            //DELETE STUDET RECORD
            try
            {
                conc.deleteUpdate("Delete from student where [G#R No]='" + bunifuCustomTextbox8.Text + "'");
                MessageBox.Show("Student Record Deleted.");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void bunifuCustomTextbox8_TextChanged(object sender, EventArgs e)
        {
            //ENTER NUMBER VALIDATION
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(bunifuCustomTextbox8.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    bunifuCustomTextbox8.Text = bunifuCustomTextbox8.Text.Remove(bunifuCustomTextbox8.Text.Length - 1);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void bunifuCustomTextbox34_TextChanged(object sender, EventArgs e)
        {
            //TEXT VALIDATION
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(bunifuCustomTextbox34.Text, "^[0-9]"))
                {
                    MessageBox.Show("Please enter only alphabets.");
                    bunifuCustomTextbox34.Text = bunifuCustomTextbox34.Text.Remove(bunifuCustomTextbox34.Text.Length - 1);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void bunifuCustomTextbox35_TextChanged(object sender, EventArgs e)
        {
            //CNIC
            //ENTER NUMBER VALIDATION
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(bunifuCustomTextbox35.Text, "^[0-9,-]{16}") || (System.Text.RegularExpressions.Regex.IsMatch(bunifuCustomTextbox35.Text, "[^0-9,-]")))
                {
                    MessageBox.Show("Invalid Format!");
                    bunifuCustomTextbox35.Text = bunifuCustomTextbox35.Text.Remove(bunifuCustomTextbox35.Text.Length - 1);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void bunifuCustomTextbox37_TextChanged(object sender, EventArgs e)
        {
            //ENTER NUMBER VALIDATION
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(bunifuCustomTextbox37.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    bunifuCustomTextbox37.Text = bunifuCustomTextbox37.Text.Remove(bunifuCustomTextbox37.Text.Length - 1);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void bunifuCustomTextbox38_TextChanged(object sender, EventArgs e)
        {
            //TEXT VALIDATION
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(bunifuCustomTextbox38.Text, "^[0-9]"))
                {
                    MessageBox.Show("Please enter only alphabets.");
                    bunifuCustomTextbox38.Text = bunifuCustomTextbox38.Text.Remove(bunifuCustomTextbox38.Text.Length - 1);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void bunifuCustomTextbox30_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomTextbox40_TextChanged(object sender, EventArgs e)
        {
            //ENTER NUMBER VALIDATION
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(bunifuCustomTextbox40.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    bunifuCustomTextbox40.Text = bunifuCustomTextbox40.Text.Remove(bunifuCustomTextbox40.Text.Length - 1);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void bunifuCustomTextbox41_TextChanged(object sender, EventArgs e)
        {
            //ENTER NUMBER VALIDATION
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(bunifuCustomTextbox41.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    bunifuCustomTextbox41.Text = bunifuCustomTextbox41.Text.Remove(bunifuCustomTextbox41.Text.Length - 1);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void bunifuCustomTextbox39_TextChanged(object sender, EventArgs e)
        {
            //ENTER NUMBER VALIDATION
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(bunifuCustomTextbox39.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    bunifuCustomTextbox39.Text = bunifuCustomTextbox39.Text.Remove(bunifuCustomTextbox39.Text.Length - 1);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void bunifuCustomTextbox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomTextbox29_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomTextbox36_TextChanged(object sender, EventArgs e)
        {
            //CONTACT
            //ENTER NUMBER VALIDATION
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(bunifuCustomTextbox36.Text, "^[0-9]{12}") || (System.Text.RegularExpressions.Regex.IsMatch(bunifuCustomTextbox36.Text, "[^0-9]")))
                {
                    MessageBox.Show("Invalid Format!");
                    bunifuCustomTextbox36.Text = bunifuCustomTextbox36.Text.Remove(bunifuCustomTextbox36.Text.Length - 1);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void bunifuCustomTextbox1_TextChanged(object sender, EventArgs e)
        {
            //TEXT VALIDATION
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(bunifuCustomTextbox1.Text, "^[0-9]"))
                {
                    MessageBox.Show("Please enter only alphabets.");
                    bunifuCustomTextbox1.Text = bunifuCustomTextbox1.Text.Remove(bunifuCustomTextbox1.Text.Length - 1);
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

        private void bunifuCustomTextbox3_TextChanged(object sender, EventArgs e)
        {
            //ENTER NUMBER VALIDATION
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(bunifuCustomTextbox3.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    bunifuCustomTextbox3.Text = bunifuCustomTextbox3.Text.Remove(bunifuCustomTextbox3.Text.Length - 1);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void bunifuCustomTextbox4_TextChanged(object sender, EventArgs e)
        {
            //TEXT VALIDATION
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(bunifuCustomTextbox4.Text, "^[0-9]"))
                {
                    MessageBox.Show("Please enter only alphabets.");
                    bunifuCustomTextbox4.Text = bunifuCustomTextbox4.Text.Remove(bunifuCustomTextbox4.Text.Length - 1);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void bunifuCustomTextbox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomTextbox6_TextChanged(object sender, EventArgs e)
        {
            //ENTER NUMBER VALIDATION
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(bunifuCustomTextbox6.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    bunifuCustomTextbox6.Text = bunifuCustomTextbox6.Text.Remove(bunifuCustomTextbox6.Text.Length - 1);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void bunifuCustomTextbox7_TextChanged(object sender, EventArgs e)
        {
            //ENTER NUMBER VALIDATION
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(bunifuCustomTextbox7.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    bunifuCustomTextbox7.Text = bunifuCustomTextbox7.Text.Remove(bunifuCustomTextbox7.Text.Length - 1);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void bunifuCustomTextbox14_TextChanged(object sender, EventArgs e)
        {
            //ENTER NUMBER VALIDATION
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(bunifuCustomTextbox14.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    bunifuCustomTextbox14.Text = bunifuCustomTextbox14.Text.Remove(bunifuCustomTextbox14.Text.Length - 1);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void bunifuCustomTextbox13_TextChanged(object sender, EventArgs e)
        {
            //CONTACT
            //ENTER NUMBER VALIDATION
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(bunifuCustomTextbox13.Text, "^[0-9]{12}") || (System.Text.RegularExpressions.Regex.IsMatch(bunifuCustomTextbox13.Text, "[^0-9]")))
                {
                    MessageBox.Show("Invalid Format!");
                    bunifuCustomTextbox13.Text = bunifuCustomTextbox13.Text.Remove(bunifuCustomTextbox13.Text.Length - 1);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void bunifuCustomTextbox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomTextbox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 m = new Form1();
            m.Show();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TEXT VALIDATION
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(comboBox5.Text, "^[0-9]"))
                {
                    MessageBox.Show("Please enter only alphabets.");
                    comboBox5.Text = comboBox5.Text.Remove(comboBox5.Text.Length - 1);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TEXT VALIDATION
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(comboBox2.Text, "^[0-9]"))
                {
                    MessageBox.Show("Please enter only alphabets.");
                    comboBox2.Text = comboBox2.Text.Remove(comboBox2.Text.Length - 1);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void bunifuCustomTextbox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(bunifuCustomDataGrid2.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            //Adding Header row
            foreach (DataGridViewColumn column in bunifuCustomDataGrid2.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in bunifuCustomDataGrid2.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfTable.AddCell(cell.Value.ToString());
                }
            }

            //Exporting to PDF
            string fileName = "student.pdf";
            string path = Path.Combine(Environment.CurrentDirectory, @"print\", fileName);
            //string folderPath = "C:/Users/misbah.maju/Desktop/";
            if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory)))
            {
                Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory));
            }
            using (FileStream stream = new FileStream("C:/Users/Public/Desktop/print/"+fileName+"", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4);
                pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                Paragraph p0 = new Paragraph("STUDENT RECORD \n\n");
                pdfDoc.Add(p0);
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
                MessageBox.Show("Student Record Generated \nPath: C:/Users/Public/Desktop/print/");
            }
            conc.print("C:/Users/Public/Desktop/print/"+fileName+"");
        }

        private void comboBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                bunifuThinButton22_Click(sender, e);
            }
        }

        private void bunifuCustomTextbox40_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                bunifuThinButton26_Click(sender, e);
            }
        }
    }
}
