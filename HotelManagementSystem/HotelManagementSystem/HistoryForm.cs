using System;
using System.Collections.Generic;
using System.Data.SqlClient;using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class HistoryForm : Form
    {
        public HistoryForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            List<Customer> customers = new List<Customer>();
            DBConnection instance = DBConnection.GetInstance();
            SqlConnection conn = instance.getConnection("SANJUKA\\SQLEXPRESS", "hotel_management_system_database", "true");
            conn.Open();

            string query = "SELECT c.name, b.* FROM billing_data b INNER JOIN customers c ON b.nic = c.nic;";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                customers.Add(new Customer(reader[0].ToString(), 
                                reader[1].ToString(), 
                                reader[2].ToString(),
                                reader[3].ToString(),
                                reader[4].ToString(),
                                Convert.ToBoolean(reader[5]),  
                                Convert.ToBoolean(reader[6]), 
                                Convert.ToBoolean(reader[7]),
                                Convert.ToBoolean(reader[8]), 
                                Convert.ToBoolean(reader[9]), 
                                Convert.ToBoolean(reader[10]),
                                Convert.ToBoolean(reader[11]),
                                Convert.ToBoolean(reader[12])));
            }

            conn.Close();

            dataGridView1.DataSource = customers;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            string dateText = textBox1.Text;
            DateTime date = DateTime.Parse(dateText);
            List<Customer> customers = new List<Customer>();
            DBConnection instance = DBConnection.GetInstance();
            SqlConnection conn = instance.getConnection("SANJUKA\\SQLEXPRESS", "hotel_management_system_database", "true");
            conn.Open();

            string query = "SELECT c.name, b.* FROM billing_data b INNER JOIN customers c ON b.nic = c.nicwhere date= '"+date+"';";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                customers.Add(new Customer(reader[0].ToString(),
                                reader[1].ToString(),
                                reader[2].ToString(),
                                reader[3].ToString(),
                                reader[4].ToString(),
                                Convert.ToBoolean(reader[5]),
                                Convert.ToBoolean(reader[6]),
                                Convert.ToBoolean(reader[7]),
                                Convert.ToBoolean(reader[8]),
                                Convert.ToBoolean(reader[9]),
                                Convert.ToBoolean(reader[10]),
                                Convert.ToBoolean(reader[11]),
                                Convert.ToBoolean(reader[12])));
            }

            conn.Close();

            dataGridView1.DataSource = customers;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            string NIC = textBox2.Text;
            List<Customer> customers = new List<Customer>();
            DBConnection instance = DBConnection.GetInstance();
            SqlConnection conn = instance.getConnection("SANJUKA\\SQLEXPRESS", "hotel_management_system_database", "true");
            conn.Open();

            string query = "SELECT c.name, b.* FROM billing_data b INNER JOIN customers c ON b.nic = c.nic where b.nic= '" + NIC + "';";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                customers.Add(new Customer(reader[0].ToString(),
                                reader[1].ToString(),
                                reader[2].ToString(),
                                reader[3].ToString(),
                                reader[4].ToString(),
                                Convert.ToBoolean(reader[5]),
                                Convert.ToBoolean(reader[6]),
                                Convert.ToBoolean(reader[7]),
                                Convert.ToBoolean(reader[8]),
                                Convert.ToBoolean(reader[9]),
                                Convert.ToBoolean(reader[10]),
                                Convert.ToBoolean(reader[11]),
                                Convert.ToBoolean(reader[12])));
            }

            conn.Close();

            dataGridView1.DataSource = customers;
        }
    }
}
