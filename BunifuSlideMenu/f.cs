using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data.SqlClient;
using System.Globalization;

namespace BunifuSlideMenu
{
    public partial class f : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=alkhair;Integrated Security=True; MultipleActiveResultSets=True;");
        SqlCommand cmd;

        connect conc = new connect();
        public f()
        {
            InitializeComponent();
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
            //this.Close();
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

        private void f_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView2.Columns.Clear();
            dataGridView2.Rows.Clear();
            dataGridView1.Columns.Add("GR", "GR");
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView2.Columns.Add("GR", "GR");
            dataGridView2.Columns.Add("Name", "Name");
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            //conc.search("SELECT * FROM stFees", bunifuCustomDataGrid3);

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();

        }

        private void slidePane_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            uv f = new uv();
            this.Hide();
            f.Show();
        }

        private void bunifuCustomDataGrid3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuCustomDataGrid3_SelectionChanged(object sender, EventArgs e)
        {
            //textBox1.Text = bunifuCustomDataGrid3.CurrentCell.Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //(bunifuCustomDataGrid3.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Student Name ] LIKE '{0}%'", textBox2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int month = dateTimePicker1.Value.Month;
            int year = dateTimePicker1.Value.Year;
            conc.insert("insert into fee (gr,fees,month,year) values ('" + textBox3.Text + "','" + textBox1.Text + "','" + month + "','" + year + "')");
            MessageBox.Show("Fees Inserted");
            
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            panel3.Hide();
            panel4.Hide();
            panel5.Hide();
            panel8.Hide();
            panel1.Show();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string a, b, c, d, f, g, h, i, j, k, l, m, n, o;
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM fee where [gr] ='" + textBox4.Text + "' and year ='"+textBox5.Text+"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                a = (dr["month"].ToString());
                
            }

            con.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {





        }

        private void button5_Click(object sender, EventArgs e)
        {
            string fileName = "student.pdf";
            string path = Path.Combine(Environment.CurrentDirectory, @"print\", fileName);
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(Path.Combine(Environment.CurrentDirectory) + textBox4.Text + "'.pdf", FileMode.Create));
            doc.Open();
            Paragraph p6 = new Paragraph("Fees Record of '" + textBox4.Text + "'\n");

            Paragraph p0 = new Paragraph(label5.Text);
            doc.Add(p6);
            doc.Add(p0);

            doc.Close();
            MessageBox.Show("Fee Record Slip Generated \nPath: "+Path.Combine(Environment.CurrentDirectory)+"");
            conc.print(Path.Combine(Environment.CurrentDirectory) + textBox4.Text + "'.pdf");

        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel5.Hide();
            panel3.Hide();
            panel8.Hide();
            panel4.Show();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            panel4.Hide();
            panel1.Hide();
            panel3.Hide();
            panel8.Hide();
            panel5.Show();
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            panel4.Hide();
            panel1.Hide();
            panel5.Hide();
            panel8.Hide();
            panel3.Show();
        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            int month = dateTimePicker2.Value.Month;
            int year = dateTimePicker2.Value.Year;
            string month2 = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(month);
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            string strqr = "SELECT SUM(fees) as total FROM fee where month='" + month2 + "' and year = '" + year + "'";
            SqlCommand cmdd = new SqlCommand(strqr, con);
            adapter.SelectCommand = cmdd;
            adapter.Fill(ds);
            SqlDataReader readers = cmdd.ExecuteReader();
            while (readers.Read())
            {
                label6.Text = readers["total"].ToString();
            }
            readers.Close();
            con.Close();
        }

        string gr1, gr2, gr3, gr4;
        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            //label1.Text = "GR#      Name";
            //label14.Text = "GR#      Name";
            int mon2 = dateTimePicker3.Value.Month;
            string month2 = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(mon2);
            int year = dateTimePicker3.Value.Year;
            using (SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=alkhair;Integrated Security=True; MultipleActiveResultSets=True;"))
            {
                connection.Open();
                using (SqlCommand command1 = new SqlCommand("select stFees.name,fee.gr from stFees INNER JOIN fee on stFees.gr=fee.gr where month = '" + month2 + "' and year = '" + year + "'", connection))
                {
                    SqlDataReader dr1 = command1.ExecuteReader();
                    while (dr1.Read())
                    {
                        gr1 = dr1["gr"].ToString();
                        gr2 = dr1["name"].ToString();
                        //dataGridView1.DataBind();
                        //dataGridView1.DataSource = gr1;
                        //label1.Text += "\n" + gr1 + "          " + gr2;

                        dataGridView1.Rows.Add(gr1,gr2);
                    }
                }
                using (SqlCommand command2 = new SqlCommand("select name,gr from stFees where gr in (select gr from stFees Except select gr  from fee where month = '" + month2 + "' and year = " + year + ")", connection))
                {
                    SqlDataReader dr = command2.ExecuteReader();

                    while (dr.Read())
                    {
                        gr3 = dr["name"].ToString();
                        gr4 = dr["gr"].ToString();
                        //dataGridView2.DataSource = gr2;
                        //label14.Text += "\n" + gr4 + "          " + gr3;

                        dataGridView2.Rows.Add(gr4, gr3);

                    }
                }
                connection.Close();
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            int fee = 0;




            using (SqlCommand cmd4 = new SqlCommand("SELECT fees FROM fee where [gr] ='" + textBox3.Text + "'", con))
            {
                con.Open();
                SqlDataReader dr = cmd4.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        string temp = dr["fees"].ToString();
                        fee = int.Parse(temp);
                    }
                }
                con.Close();
            }
            int month = dateTimePicker1.Value.Month;
            string month2 = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(month);
            int year = dateTimePicker1.Value.Year;
            string a, b, c, d, f, g, h, i, j, k, l, m, n, o;
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM student where [G#R No] ='" + textBox3.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                a = (dr[1].ToString());
                b = (dr["G#R No"].ToString());
                c = (dr["D#O#B"].ToString());
                f = (dr["House Position"].ToString());
                h = (dr["Family Member"].ToString());
                i = (dr["No# of Sibling"].ToString());
                j = (dr["Contact"].ToString());
                k = (dr["Address"].ToString());
                l = (dr[11].ToString());
                m = (dr["Class"].ToString());
                n = (dr["Section"].ToString());
                o = (dr["Shift"].ToString());
                Document doc = new Document();
                string fileName = "student.pdf";
                string path = Path.Combine(Environment.CurrentDirectory, @"print\", fileName);
                PdfWriter.GetInstance(doc, new FileStream("C:/Users/Public/Desktop/print/" + a + "'.pdf", FileMode.Create));
                doc.Open();
                Paragraph p6 = new Paragraph("                               FEE RECEIPT\r\n");

                Paragraph p0 = new Paragraph("\r\n__________________________________________\r\n----------RECEIPT----------");
                Paragraph p1 = new Paragraph("Month = " + month2 + "\r\nFees = " + textBox1.Text + "\r\nPaid = " + fee + "\r\nName = " + a + "\r\nGR Number = " + b + "\r\nDate Of Birth = " + c + "r\nContact = " + j + "\r\nAddress" +
                    " = " + k + "\r\nCNIC = " + l + "\r\nClass = " + m + "\r\nSection = " + n + "\r\nShift = " + o + "");
                //Paragraph p3 = new Paragraph("\r\n\r\n\r\n----------SELLER INFO----------");
                //Paragraph p4 = new Paragraph("Seller ID = " + sID + "\r\nName = " + sName + "\r\nAddress = " + sAddress + "\r\nContact = " + scontact + "\r\nCNIC = " + snic + "\r\nEmail = " + sEmail + "\r\n__________________________________________\r\n\r\n\r\n          Thanks For Buying\r\n          GOOD LUCK :-)");
                doc.Add(p6);
                doc.Add(p0);
                doc.Add(p1);
                //doc.Add(p3);
                //doc.Add(p4);

                doc.Close();
                con.Close();
                MessageBox.Show("Slip Generated \nPath: C:/Users/Public/Desktop/print/ ");
                conc.print("C:/Users/Public/Desktop/print/" + a + "'.pdf");
                //textBox1.Text = "";
                //textBox3.Text = "";

            }
        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
            int mon = dateTimePicker1.Value.Month;

            string month = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(mon);
            int year = dateTimePicker1.Value.Year;
            int paid_fees = int.Parse(textBox1.Text);
            int total_fees = 0;
            int fee = 0;
            int c = 0;

            using (SqlCommand cmd3 = new SqlCommand("SELECT Fees FROM stFees where [gr] ='" + textBox3.Text + "'", con))
            {
                con.Open();
                SqlDataReader dr = cmd3.ExecuteReader();

                while (dr.Read())
                {
                    string temp = dr["Fees"].ToString();
                    total_fees = int.Parse(temp);

                }

                con.Close();
            }

            using (SqlCommand cmd4 = new SqlCommand("SELECT fees FROM fee where [gr] ='" + textBox3.Text + "' and month = '" + month + "'", con))
            {
                con.Open();
                SqlDataReader dr = cmd4.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        string temp = dr["fees"].ToString();
                        fee = int.Parse(temp);
                    }

                    c = fee + paid_fees;
                    if (fee == 0)
                    {
                        conc.insert("insert into fee (gr,fees,month,year) values ('" + textBox3.Text + "','" + paid_fees + "','" + month + "','" + year + "')");
                        MessageBox.Show("Fees Inserted");

                    }
                    else if (total_fees >= c)
                    {
                        conc.insert("update fee set fees = '" + c + "' where gr = '" + textBox3.Text + "' and month = '" + month + "' and year = '" + year + "'");
                        MessageBox.Show("Fees Inserted");
                    }
                    else if (paid_fees > (total_fees - fee) && fee < total_fees)
                    {
                        int temp = total_fees - fee;
                        MessageBox.Show("Only " + temp + " rupees has to be submitted");
                    }
                    else
                    {
                        MessageBox.Show("Fees is Already paid");
                    }

                }
                else
                {
                    if (paid_fees <= total_fees)
                    {
                        conc.insert("insert into fee (gr,fees,month,year) values ('" + textBox3.Text + "','" + paid_fees + "','" + month + "','" + year + "')");
                        MessageBox.Show("Fees Inserted");
                    }
                    else
                    {
                        MessageBox.Show("Invalid Input");
                    }

                }
                con.Close();
            }

        }


        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            int month = dateTimePicker3.Value.Month;
            int year = dateTimePicker3.Value.Year;
            string month2 = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(month);
            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 30;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            //Adding Header row
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfTable.AddCell(cell.Value.ToString());
                }
            }

            //Exporting to PDF
            string folderPath = Path.Combine(Environment.CurrentDirectory);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream("C:/Users/Public/Desktop/print/paid.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                Paragraph p0 = new Paragraph("FEES PAID RECORD OF '" + year + month2 + "'\n\n");
                pdfDoc.Add(p0);
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
                MessageBox.Show("Fee Record Slip Generated \nPath: C:/Users/Public/Desktop/print/paid.pdf");
            }
            conc.print("C:/Users/Public/Desktop/print/paid.pdf");

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            int month = dateTimePicker3.Value.Month;
            int year = dateTimePicker3.Value.Year;
            string month2 = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(month);

            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(dataGridView2.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 30;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            //Adding Header row
            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfTable.AddCell(cell.Value.ToString());
                }
            }

            //Exporting to PDF
            string folderPath = Path.Combine(Environment.CurrentDirectory);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream("C:/Users/Public/Desktop/print/paid.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                Paragraph p0 = new Paragraph("FEES DUE RECORD OF '" + year + month2 + "'\n\n");
                pdfDoc.Add(p0);
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
                MessageBox.Show("Fee Record Slip Generated \nPath: C:/Users/Public/Desktop/print/paid.pdf");
            }
            conc.print("C:/Users/Public/Desktop/print/paid.pdf");

        }
        public string a,b;
        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            string[] month = new string[12];
            int count = 0;
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT month FROM fee where [gr] ='" + textBox4.Text + "' and year ='" + textBox5.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {

                month[count] = (row["month"].ToString());

                count++;
            }

            for (int i = 0; i < month.Length; i++)
            {

                string a = month[i];
                int total_fees = 0;
                int fee = 0;


                using (SqlCommand cmd3 = new SqlCommand("SELECT Fees FROM stFees where [gr] ='" + textBox4.Text + "'", con))
                {
                    //con.Open();
                    SqlDataReader dr = cmd3.ExecuteReader();

                    while (dr.Read())
                    {
                        string temp = dr["Fees"].ToString();
                        total_fees = int.Parse(temp);

                    }

                    //con.Close();
                }

                using (SqlCommand cmd4 = new SqlCommand("SELECT fees FROM fee where [gr] ='" + textBox4.Text + "' and month = '" + a + "' and year = '" + textBox5.Text + "'", con))
                {
                    //con.Open();
                    SqlDataReader dr = cmd4.ExecuteReader();

                    while (dr.Read())
                    {
                        string temp = dr["fees"].ToString();
                        fee = int.Parse(temp);
                    }
                }


                if (total_fees == fee)
                {
                    if (a == "Jan" || a == "Feb" || a == "Mar" || a == "Apr" || a == "May" || a == "Jun" || a == "Jul" || a == "Aug" || a == "Sep" || a == "Oct" || a == "Nov" || a == "Dec")
                    {
                        label5.Text += "\n" + a + " :Full Paid";
                    }
                }
                else if (fee > 0 && total_fees > fee)
                {
                    if (a == "Jan" || a == "Feb" || a == "Mar" || a == "Apr" || a == "May" || a == "Jun" || a == "Jul" || a == "Aug" || a == "Sep" || a == "Oct" || a == "Nov" || a == "Dec")
                    {
                        label5.Text += "\n" + a + " :Half Paid";
                    }
                }
                else
                {
                    if (a == null)
                    {
                        a = i.ToString();
                    }
                    int temp = int.Parse(a);
                    string c = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(temp);
                    label5.Text += "\n" + c + ": Not Paid";
                }

                //}


            }

            con.Close();

        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            panel1.Hide();
            panel5.Hide();
            panel3.Hide();
            panel4.Hide();
            panel8.Show();
        }

        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {
            //INSERT STUDENT DATA RECORD
            try
            {
                conc.insert("insert into stFees ([name],gr,Fees) values((select [StudentName ] from student where [G#R No] = "+textBox2.Text+"),"+ textBox2.Text + ","+ textBox6.Text + ")");
                MessageBox.Show("New Student Record Added.");
                textBox2.Text = "";
                textBox6.Text = "";
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                bunifuThinButton28_Click(sender, e);
            }
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream("C:/Users/misbah.maju/Desktop/'" + textBox4.Text + "'.pdf", FileMode.Create));
            doc.Open();
            Paragraph p6 = new Paragraph("Fees Record of '" + textBox4.Text + "'\n");

            Paragraph p0 = new Paragraph(label5.Text);
            doc.Add(p6);
            doc.Add(p0);

            doc.Close();
            MessageBox.Show("Fee Record Slip Generated \nPath: C:/Users/misbah.maju/Desktop/");
            conc.print("C:/Users/misbah.maju/Desktop/'" + textBox4.Text + "'.pdf");
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
