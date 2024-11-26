using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using RadioButton = System.Windows.Forms.RadioButton;

namespace HotelManagementSystem
{
    
    public partial class EnterUserInformation : Form
    {
        
        private Bill bill;
        private HistoryForm historyForm;
        public EnterUserInformation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime currentDateTime = DateTime.Now;
            string date = currentDateTime.ToString("yyyy-MM-dd");
            string time = currentDateTime.ToString("HH:mm:ss");

            DBConnection instance = DBConnection.GetInstance();

            //Update this space with your Serever Name.
            SqlConnection conn = instance.getConnection("Server Name", "hotel_management_system_database", "true");
            
            conn.Open();
            
            string name = textBox1.Text;
            string NIC = textBox2.Text;
            
            string query1 = "SELECT * FROM customers WHERE nic = '"+NIC+"'";
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            SqlDataReader reader = cmd1.ExecuteReader();
            
            int count = 0;
            while (reader.Read())
            {
                count++;
            }

            reader.Close();
            
            if (count == 0)
            {
                string query3 = "INSERT INTO customers(name,nic) values(@name,@nic)";
                SqlCommand cmd2 = new SqlCommand(query3, conn);
                cmd2.Parameters.AddWithValue("@name", name);
                cmd2.Parameters.AddWithValue("@nic", NIC);
                int rowAffected1 = cmd2.ExecuteNonQuery();

            }

            RadioButton selectedRadioButton = groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            string roomType = selectedRadioButton.Text;

            string query2 =     "INSERT INTO billing_data" +
                                "(nic, date, time, room_type, parking, luggage, cleaning, room_service, bar, pool, spa, wellness) VALUES" +
                                "(@nic, @date, @time, @room_type, @parking, @luggage, @cleaning, @room_service, @bar, @pool, @spa, @wellness)";


            SqlCommand cmd = new SqlCommand(query2, conn);
            
            cmd.Parameters.AddWithValue("@nic", NIC);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@time", time);
            cmd.Parameters.AddWithValue("@room_type", roomType);
            
            
            Customer customer = Customer.Instance;
            customer.Name = name;
            customer.NIC = NIC;
            customer.RoomType = roomType;
            customer.date = date;
            customer.time = time;
            cmd.Parameters.AddWithValue("@parking", 0); 
            cmd.Parameters.AddWithValue("@luggage", 0);  
            cmd.Parameters.AddWithValue("@cleaning", 0); 
            cmd.Parameters.AddWithValue("@room_service", 0);  
            cmd.Parameters.AddWithValue("@bar", 0);  
            cmd.Parameters.AddWithValue("@pool", 0); 
            cmd.Parameters.AddWithValue("@spa", 0);  
            cmd.Parameters.AddWithValue("@wellness", 0);


            Boolean beverages = false;
            RadioButton selectedRadioButton1 = groupBox2.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if(selectedRadioButton1.Text == "Used")
            {
                beverages = true;
                customer.HasBeverage = beverages;
                List<string> beverageItems = new List<string>();

                foreach (Control control in groupBox1.Controls)
                {
                    if (control is CheckBox checkBox && checkBox.Checked)
                    {
                        beverageItems.Add(checkBox.Text);
                    }
                }

                // Convert the list to an array, if needed:
                string[] beverageItemsArray = beverageItems.ToArray();
                customer.Beverages = beverageItemsArray;
            } else
            {
                //cmd.Parameters.AddWithValue("@be", roomType);
            }



            Boolean barPool = false;
            RadioButton selectedRadioButton2 = groupBox5.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (selectedRadioButton2.Text == "Used")
            {
                barPool = true;
                List<string> barPoolItems = new List<string>();

                foreach (Control control in groupBox4.Controls)
                {
                    if (control is CheckBox checkBox && checkBox.Checked)
                    {
                        barPoolItems.Add(checkBox.Text);
                    }
                }
                string[] barPoolItemsArray = barPoolItems.ToArray();
                foreach(string item in barPoolItemsArray)
                {
                    if(item == "Gym"){
                        cmd.Parameters["@bar"].Value = 1;
                        customer.HasGymFee = true;
                    }
                    if (item == "Pool"){
                        cmd.Parameters["@pool"].Value = 1;
                        customer.HasPoolFee = true;
                    }
                }
            }



            Boolean spaWellness = false;
            RadioButton selectedRadioButton3 = groupBox6.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (selectedRadioButton3.Text == "Used")
            {
                spaWellness = true;
                List<string> spaWellnessItems = new List<string>();

                foreach (Control control in groupBox7.Controls)
                {
                    if (control is CheckBox checkBox && checkBox.Checked)
                    {
                        spaWellnessItems.Add(checkBox.Text);
                    }
                }
                string[] spaWellnessItemsArray = spaWellnessItems.ToArray();
                foreach (string item in spaWellnessItemsArray)
                {
                    if (item == "Spa"){
                        cmd.Parameters["@spa"].Value = 1;
                        customer.HasSpaFee = true;
                    } 
                    if (item == "Wellness"){
                        cmd.Parameters["@wellness"].Value = 1;
                        customer.HasWellnessFee = true;
                    } 
                }
            } 


            RadioButton selectedRadioButton4 = groupBox9.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (selectedRadioButton4.Text == "Used"){
                cmd.Parameters["@parking"].Value = 1;
                customer.HasParkingFee = true;
            }
            

            RadioButton selectedRadioButton5 = groupBox10.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (selectedRadioButton5.Text == "Used"){
                cmd.Parameters["@luggage"].Value = 1;
                customer.HasLuggageFee = true;
            }
            

            RadioButton selectedRadioButton6 = groupBox8.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (selectedRadioButton6.Text == "Used"){
                cmd.Parameters["@cleaning"].Value = 1;
                customer.HasCleaningFee = true;
            }
            

            RadioButton selectedRadioButton7 = groupBox11.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (selectedRadioButton7.Text == "Used"){
                cmd.Parameters["@room_service"].Value = 1;
                customer.HasRoomServiceFee = true;
            }
            

            int rowAffected = cmd.ExecuteNonQuery();

            if (rowAffected > 0)
                MessageBox.Show("Data Entered Succssfully", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);

            conn.Close();

            bill = new Bill();
            bill.FormClosed += Form2_FormClosed;
            bill.Show();
            this.Hide();
            
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();  // Show Form1 when Form2 is closed
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // Exit the application when Form1 is closed
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton selectedRadioButton = groupBox2.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (selectedRadioButton.Text == "Used")
            {
                groupBox3.Enabled = true;
                groupBox3.Visible = true;
                foreach (Control control in groupBox3.Controls)
                {
                    control.Enabled = true;
                    control.Visible = true;
                }
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton selectedRadioButton = groupBox2.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (selectedRadioButton.Text != "Used")
            {
                groupBox3.Enabled = false;
                groupBox3.Visible = false;
                foreach (Control control in groupBox3.Controls)
                {
                    control.Enabled = false;
                    control.Visible = false;
                }
            }
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton selectedRadioButton = groupBox5.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (selectedRadioButton.Text == "Used")
            {
                groupBox4.Enabled = true;
                groupBox4.Visible = true;
                foreach (Control control in groupBox4.Controls)
                {
                    control.Enabled = true;
                    control.Visible = true;
                }
            }
        }

        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton selectedRadioButton = groupBox6.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (selectedRadioButton.Text == "Used")
            {
                groupBox7.Enabled = true;
                groupBox7.Visible = true;
                foreach (Control control in groupBox7.Controls)
                {
                    control.Enabled = true;
                    control.Visible = true;
                }
            }
        }

        private void radioButton17_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton selectedRadioButton = groupBox6.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (selectedRadioButton.Text != "Used")
            {
                groupBox7.Enabled = false;
                groupBox7.Visible = false;
                foreach (Control control in groupBox7.Controls)
                {
                    control.Enabled = false;
                    control.Visible = false;
                }
            }
        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton selectedRadioButton = groupBox5.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (selectedRadioButton.Text != "Used")
            {
                groupBox4.Enabled = false;
                groupBox4.Visible = false;
                foreach (Control control in groupBox4.Controls)
                {
                    control.Enabled = false;
                    control.Visible = false;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            historyForm = new HistoryForm();
            historyForm.FormClosed += Form2_FormClosed;
            historyForm.Show();
            this.Hide();
        }

        
    }
}
