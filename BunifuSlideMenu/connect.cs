using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace BunifuSlideMenu
{
    class connect
    {
        public void print(string filename)
        {
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo()
            {
                CreateNoWindow = true,
                Verb = "print",
                FileName = filename //put the correct path here
            };
            p.Start();
        }

        public Label SetPlaceholder(Control control, string text)
        {
            var placeholder = new Label
            {
                Text = text,
                Font = control.Font,
                ForeColor = Color.Gray,
                BackColor = Color.Transparent,
                Cursor = Cursors.IBeam,
                Margin = Padding.Empty,

                //get rid of the left margin that all labels have
                FlatStyle = FlatStyle.System,
                AutoSize = false,

                //Leave 1px on the left so we can see the blinking cursor
                Size = new Size(control.Size.Width - 1, control.Size.Height),
                Location = new Point(control.Location.X + 1, control.Location.Y)
            };

            //when clicking on the label, pass focus to the control
            placeholder.Click += (sender, args) => { control.Focus(); };

            //disappear when the user starts typing
            control.TextChanged += (sender, args) => {
                placeholder.Visible = string.IsNullOrEmpty(control.Text);
            };

            //stay the same size/location as the control
            EventHandler updateSize = (sender, args) => {
                placeholder.Location = new Point(control.Location.X + 1, control.Location.Y);
                placeholder.Size = new Size(control.Size.Width - 1, control.Size.Height);
            };

            control.SizeChanged += updateSize;
            control.LocationChanged += updateSize;

            control.Parent.Controls.Add(placeholder);
            placeholder.BringToFront();

            return placeholder;
        }
        public void viewSearch(string query,TextBox aa)
        {
            //SqlConnection conn = new SqlConnection("Data Source=DESKTOP-5J17O7Q;Initial Catalog=alkhair;Integrated Security=True");
            //conn.Open();
            //SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            //dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
            ////string a = (DataTable) aa;
            ////aa = dt;
            //conn.Close();
        }
        public void insert(string b)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=alkhair;Integrated Security=True");
            conn.Open();
            string command = b;
            SqlDataAdapter ad = new SqlDataAdapter(command, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            conn.Close();
        }
        public void deleteUpdate(string c)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=alkhair;Integrated Security=True");
            conn.Open();
            SqlCommand cp = new SqlCommand(c, conn);
            cp.ExecuteNonQuery();
            conn.Close();
        }
        public void view(string d, string name, string gr, string dob, string profession, string house, string income, string family, string sibling, string contact, string address, string cnic, string clas, string section, string shift)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=alkhair;Integrated Security=True");
            conn.Open();
            SqlCommand cp = new SqlCommand("SELECT * from student  where [G#R No] = '" + d + "'", conn);
            SqlDataReader dr = cp.ExecuteReader();
            while (dr.Read())
            {
                name = dr[1].ToString();
                gr = dr["G#R No"].ToString();
                dob = dr["D#O#B"].ToString();
                profession = dr["Profession"].ToString();
                house = dr["House Position"].ToString();
                income = dr["Income"].ToString();
                family = dr["Family Member"].ToString();
                sibling = dr["No# of Sibling"].ToString();
                contact = dr["Contact"].ToString();
                address = dr["Address"].ToString();
                cnic = dr["C#N#I#C"].ToString();
                clas = dr["Class"].ToString();
                section = dr["Section"].ToString();
                shift = dr["Shift"].ToString();
            }
            conn.Close();
        }
        public void clas()
        {

        }
        public void search(string querey,DataGridView dataTable)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=alkhair;Integrated Security=True");
            conn.Open();

            SqlDataAdapter sda = new SqlDataAdapter(querey, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataTable.DataSource = dt;
            conn.Close();
        }
    }
}
