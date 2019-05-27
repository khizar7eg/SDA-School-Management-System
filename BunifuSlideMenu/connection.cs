using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunifuSlideMenu
{
    class connection
    {
        public void view(string a)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-5J17O7Q;Initial Catalog=alkhair;Integrated Security=True");
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(a, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        public void insert(string b)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-5J17O7Q;Initial Catalog=alkhair;Integrated Security=True");
            conn.Open();
            string command = b;
            SqlDataAdapter ad = new SqlDataAdapter(command, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds);
        }
        public void deleteUpdate(string c)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-5J17O7Q;Initial Catalog=info;Integrated Security=True");
            conn.Open();
            SqlCommand cp = new SqlCommand(c, conn);
            cp.ExecuteNonQuery();
            conn.Close();
        }
        public void search(string d)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-5J17O7Q;Initial Catalog=info;Integrated Security=True");
            conn.Open();

            SqlDataAdapter sda = new SqlDataAdapter(d, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();
        }
    }
}
