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
    public partial class t : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=alkhair;Integrated Security=True; MultipleActiveResultSets=True;");
        SqlCommand cmd;
        connect conc = new connect();
        public t()
        {
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            //INSERT TEACHER DATA RECORD
            try
            {
                conc.insert("insert into teacher ([Name of Staff (Mr / Ms#)],[NIC No #],[Qualification],[D-O-J],[Contact No#],[Address],[E-Mail Address],[Post ],[Shift]) values ('" + bunifuCustomTextbox1.Text + "','" + bunifuCustomTextbox2.Text + "','" + bunifuCustomTextbox3.Text + "','" + bunifuCustomTextbox4.Text + "','" + bunifuCustomTextbox5.Text + "','" + bunifuCustomTextbox6.Text + "','" + bunifuCustomTextbox7.Text + "','" + bunifuCustomTextbox16.Text + "','" + comboBox3.Text +"')");
                MessageBox.Show("New Teacher Record Added.");
                clear();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                clear();
            }
        }

        public void clear()
        {
            bunifuCustomTextbox1.Text = "";
            bunifuCustomTextbox2.Text = "";
            bunifuCustomTextbox3.Text = "";
            bunifuCustomTextbox4.Text = "";
            bunifuCustomTextbox5.Text = "";
            bunifuCustomTextbox6.Text = "";
            bunifuCustomTextbox7.Text = "";
            bunifuCustomTextbox16.Text = "";
            comboBox3.Text = "";
            bunifuCustomTextbox18.Text = "";
            bunifuCustomTextbox17.Text = "";
            bunifuCustomTextbox14.Text = "";
            bunifuCustomTextbox13.Text = "";
            bunifuCustomTextbox12.Text = "";
            bunifuCustomTextbox11.Text = "";
            bunifuCustomTextbox10.Text = "";
            comboBox4.Text = "";
            bunifuCustomTextbox8.Text = "";


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

        private void t_Load(object sender, EventArgs e)
        {
            comboBox4.SelectedItem = "---Select---";
            comboBox3.SelectedItem = "---Select---";
            //conc.SetPlaceholder(bunifuCustomTextbox2, "xxxxx-xxxxxxx-x");
            //conc.SetPlaceholder(bunifuCustomTextbox5, "xxxx-xxxxxxx");
            //conc.SetPlaceholder(bunifuCustomTextbox4, "dd/mm/yyyy");
            //conc.SetPlaceholder(bunifuCustomTextbox17, "xxxxx-xxxxxxx-x");
            //conc.SetPlaceholder(bunifuCustomTextbox12, "xxxx-xxxxxxx");
            //conc.SetPlaceholder(bunifuCustomTextbox13, "dd/mm/yyyy");
            //conc.SetPlaceholder(bunifuCustomTextbox21, "xxxxx-xxxxxxx-x");


            conc.search("Select * from teacher ", bunifuCustomDataGrid2);
            // TODO: This line of code loads data into the 'alkhairDataSet4.teacher' table. You can move, or remove it, as needed.
            this.teacherTableAdapter.Fill(this.alkhairDataSet4.teacher);
            //MAXIMIZED DEFAULT
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            //DON'T KNOW GR NO (DISABLE)
            comboBox2.Enabled = false;
            comboBox6.Enabled = false;
            comboBox1.Enabled = false;
            //INSERT DATA IN COMBO BOX
            try
            {
                comboBox2.Items.Clear();
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT DISTINCT [Shift] FROM teacher";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox2.Items.Add(dr["Shift"].ToString());
                    con.Close();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (bunifuCustomTextbox21.Enabled == false)
            {
                comboBox2.Enabled = false;
                comboBox6.Enabled = false;
                comboBox1.Enabled = false;
                bunifuCustomTextbox21.Enabled = true;
            }
            else if (bunifuCustomTextbox21.Enabled == true)
            {
                comboBox2.Enabled = true;
                comboBox6.Enabled = true;
                comboBox1.Enabled = true;
                bunifuCustomTextbox21.Enabled = false;
            }
            //ENABLE OR DISABLE TEXT FIELD WRT TO GR#            
            
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            panel3.Hide();
            panel1.Hide();
            panel10.Hide();
            this.teacherTableAdapter.Fill(this.alkhairDataSet4.teacher);
            panel7.Show();
        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
            //SET TEXBOXES DATA WRT TO GR NO
            bunifuCustomTextbox17.Text = bunifuCustomTextbox21.Text;
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM teacher where [NIC No #] ='" + bunifuCustomTextbox21.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                //bunifuCustomTextbox18.Text = (dr[1].ToString());
                bunifuCustomTextbox18.Text = (dr["Name of Staff (Mr / Ms#)"].ToString());
                bunifuCustomTextbox17.Text = (dr["NIC No #"].ToString());
                bunifuCustomTextbox14.Text = (dr["Qualification"].ToString());
                bunifuCustomTextbox13.Text = (dr["D-O-J"].ToString());
                bunifuCustomTextbox12.Text = (dr["Contact No#"].ToString());
                bunifuCustomTextbox11.Text = (dr["Address"].ToString());
                bunifuCustomTextbox10.Text = (dr["E-Mail Address"].ToString());
                comboBox4.Text = (dr["Shift"].ToString());
                bunifuCustomTextbox8.Text = (dr["Post "].ToString());
            }
            con.Close();
            //Panel
            panel7.Hide();
            panel1.Hide();
            panel10.Hide();
            panel3.Show();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            if (bunifuCustomTextbox21.Enabled == false)
            {
                if (comboBox1.SelectedItem == null && comboBox6.SelectedItem == null)
                {
                    conc.search("Select * from teacher where [Shift]='" + comboBox2.Text + "' ", bunifuCustomDataGrid2);
                }
                else if (comboBox1.SelectedItem == null)
                {
                    conc.search("Select * from teacher where [Shift]='" + comboBox2.Text + "' and [Name of Staff (Mr / Ms#)]='" + comboBox6.Text + "' ", bunifuCustomDataGrid2);
                }
                else if (comboBox1.SelectedItem == null && comboBox6.SelectedItem == null && comboBox2.SelectedItem == null)
                {
                    conc.search("Select * from teacher where [NIC No #]='" + bunifuCustomTextbox21.Text + "' ", bunifuCustomDataGrid2);
                }
                else if (comboBox1.SelectedItem == null && comboBox6.SelectedItem == null && comboBox2.SelectedItem == null && bunifuCustomTextbox21.Text == null)
                {
                    conc.search("Select * from teacher  ", bunifuCustomDataGrid2);
                }
                else
                {
                    conc.search("Select * from teacher where [NIC No #]='" + bunifuCustomTextbox21.Text + "' ", bunifuCustomDataGrid2);
                }
            }
            else if (bunifuCustomTextbox21.Enabled == true)
            {
                conc.search("Select * from teacher where [NIC No #]='" + bunifuCustomTextbox21.Text + "' ", bunifuCustomDataGrid2);
            }
            
            //else if (comboBox6.SelectedIndex.Equals(""))
            //{
            //    conc.search("Select * from teacher where [Shift]='" + comboBox2.Text + "' ", bunifuCustomDataGrid2);
            //}
            //SEARCH STUDENT DATA RECORD
            //conc.search("Select * from teacher where [Shift]='" + comboBox2.Text + "' and [Name of Staff (Mr / Ms#)]='" + comboBox6.Text + "' and [NIC No #]='" + comboBox1.Text + "'", bunifuCustomDataGrid2);
            //panel
            panel7.Hide();
            panel3.Hide();
            panel1.Hide();
            panel10.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SET COMBO BOX WRT OTHER COMBO BOX
            cmd = new SqlCommand("Select [Name of Staff (Mr / Ms#)] from teacher where [Shift] ='" + comboBox2.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox6.Items.Clear();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT [Name of Staff (Mr / Ms#)] FROM teacher where [Shift] ='" + comboBox2.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow drr in dt.Rows)
                {
                    comboBox6.Items.Add(drr["Name of Staff (Mr / Ms#)"].ToString());
                }
            }
            con.Close();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SET COMBO BOX WRT OTHER COMBO BOX
            cmd = new SqlCommand("Select [NIC No #] from teacher where [Name of Staff (Mr / Ms#)] ='" + comboBox6.Text + "' and [Shift] ='" + comboBox2.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Clear();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT [NIC No #] FROM teacher where [Name of Staff (Mr / Ms#)] ='" + comboBox6.Text + "' and [Shift] ='" + comboBox2.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow drr in dt.Rows)
                {
                    comboBox1.Items.Add(drr["NIC No #"].ToString());
                }
            }
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SET SEARCHED RESULT IN TEXT BOX
            bunifuCustomTextbox21.Text = comboBox1.Text;
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            //TEACHER RECORD UPDATE
            try
            {
                conc.deleteUpdate("Update teacher set[Name of Staff (Mr / Ms#)] ='" + bunifuCustomTextbox18.Text + "' , [NIC No #] ='" + bunifuCustomTextbox17.Text + "' , [Qualification] ='" + bunifuCustomTextbox14.Text + "' , [D-O-J] ='" + bunifuCustomTextbox13.Text + "' , [Contact No#] ='" + bunifuCustomTextbox12.Text + "' , [Address] ='" + bunifuCustomTextbox11.Text + "' , [E-Mail Address] ='" + bunifuCustomTextbox10.Text + "' , [Post ] ='" + bunifuCustomTextbox8.Text + "' , [Shift] ='" + comboBox4.Text + "' where [NIC No #] ='" + bunifuCustomTextbox17.Text + "'");
                MessageBox.Show("Teacher Record Updated.");
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
                if (bunifuCustomTextbox21.Text.Equals(""))
                {
                    MessageBox.Show("Please Enter Information.");
                }
                else
                {
                    conc.deleteUpdate("Delete from teacher where [NIC No #]='" + bunifuCustomTextbox21.Text + "'");
                    MessageBox.Show("Teacher Record Deleted.");
                    clear();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                clear();
            }
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            this.panel5.AutoScroll = true;
        }

        private void vScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            this.panel6.AutoScroll = true;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            panel7.Hide();
            panel3.Hide();
            panel10.Hide();
            panel1.Show();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel3.Hide();
            panel10.Hide();
            this.teacherTableAdapter.Fill(this.alkhairDataSet4.teacher);
            panel7.Show();
        }

        private void bunifuCustomTextbox17_TextChanged(object sender, EventArgs e)
        {
            //CNIC
            //ENTER NUMBER VALIDATION
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(bunifuCustomTextbox17.Text, "^[0-9,-]{16}") || (System.Text.RegularExpressions.Regex.IsMatch(bunifuCustomTextbox17.Text, "[^0-9,-]")))
                {
                    MessageBox.Show("Invalid Format!");
                    bunifuCustomTextbox17.Text = bunifuCustomTextbox17.Text.Remove(bunifuCustomTextbox17.Text.Length - 1);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void bunifuCustomTextbox12_TextChanged(object sender, EventArgs e)
        {
            //CONTACT
            //ENTER NUMBER VALIDATION
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(bunifuCustomTextbox12.Text, "^[0-9]{12}") || (System.Text.RegularExpressions.Regex.IsMatch(bunifuCustomTextbox12.Text, "[^0-9]")))
                {
                    MessageBox.Show("Invalid Format!");
                    bunifuCustomTextbox12.Text = bunifuCustomTextbox12.Text.Remove(bunifuCustomTextbox12.Text.Length - 1);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void bunifuCustomTextbox21_TextChanged(object sender, EventArgs e)
        {
            //ENTER NUMBER VALIDATION
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(bunifuCustomTextbox21.Text, "^[0-9]{16}"))
                {
                    MessageBox.Show("Invalid Format!");
                    bunifuCustomTextbox21.Text = bunifuCustomTextbox21.Text.Remove(bunifuCustomTextbox21.Text.Length - 1);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void bunifuCustomTextbox5_TextChanged(object sender, EventArgs e)
        {
            //CONTACT
            //ENTER NUMBER VALIDATION
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(bunifuCustomTextbox5.Text, "^[0-9]{12}") || (System.Text.RegularExpressions.Regex.IsMatch(bunifuCustomTextbox5.Text, "[^0-9]")))
                {
                    MessageBox.Show("Invalid Format!");
                    bunifuCustomTextbox5.Text = bunifuCustomTextbox5.Text.Remove(bunifuCustomTextbox5.Text.Length - 1);
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

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 m = new Form1();
            m.Show();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
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

        private void bunifuCustomTextbox1_TextChanged(object sender, EventArgs e)
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

        private void bunifuCustomTextbox18_TextChanged(object sender, EventArgs e)
        {
            //TEXT VALIDATION
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(bunifuCustomTextbox18.Text, "^[0-9]"))
                {
                    MessageBox.Show("Please enter only alphabets.");
                    bunifuCustomTextbox18.Text = bunifuCustomTextbox18.Text.Remove(bunifuCustomTextbox18.Text.Length - 1);
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

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TEXT VALIDATION
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(comboBox4.Text, "^[0-9]"))
                {
                    MessageBox.Show("Please enter only alphabets.");
                    comboBox4.Text = comboBox4.Text.Remove(comboBox4.Text.Length - 1);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void bunifuCustomTextbox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomTextbox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomTextbox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomTextbox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
            string fileName = "teacher.pdf";
            string path = Path.Combine(Environment.CurrentDirectory, @"print\", fileName);
            //string folderPath = "C:/Users/misbah.maju/Desktop/";
            if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory)))
            {
                Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory));
            }
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4);
                pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                Paragraph p0 = new Paragraph("TEACHER RECORD \n\n");
                pdfDoc.Add(p0);
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
                MessageBox.Show("Teacher Record Generated \nPath: " + Path.Combine(Environment.CurrentDirectory) + "");
            }


        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
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
            string fileName = "teacher.pdf";
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
                Paragraph p0 = new Paragraph("TEACHER RECORD \n\n");
                pdfDoc.Add(p0);
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
                MessageBox.Show("Teacher Record Generated \nPath: C:/Users/Public/Desktop/print/ ");
            }
            conc.print("C:/Users/Public/Desktop/print/"+fileName+"");

        }

        private void bunifuCustomLabel9_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomTextbox17_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void bunifuCustomTextbox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                bunifuThinButton21_Click(sender, e);
            }
        }

        private void panel9_Enter(object sender, EventArgs e)
        {

        }

        private void panel9_MouseEnter(object sender, EventArgs e)
        {

        }

        private void bunifuCustomTextbox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomTextbox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                bunifuThinButton22_Click(sender, e);
            }
        }
    }
}
