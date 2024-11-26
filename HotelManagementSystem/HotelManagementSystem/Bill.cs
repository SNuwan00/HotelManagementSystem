using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    
    public partial class Bill : Form
    {
        Customer customer = Customer.Instance;
        public Bill()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Bill_Load(object sender, EventArgs e)
        {
            int[] beveragesFee = { 1,2,2,3};
            Dictionary<string, int> customerData = new Dictionary<string, int>{
                { "Single" ,50 } , { "Double",80 } , 
                { "Familly",120 } , { "parking", 16} , 
                { "luggage", 18} , { "cleaning",10 } ,
                { "service", 8}, { "gym", 35} , 
                { "pool", 10} , { "spa", 100} , { "welness", 30}
            };
            if (customer == null)
                MessageBox.Show("Check Again!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else { 
                label24.Text = customer.date+" "+customer.time;
                label2.Text = customerData[customer.RoomType].ToString() + ".00";
                IRoomCharge room = new BasicRoomCharge(customerData[customer.RoomType]);
                if (customer.HasWellnessFee){
                    label18.Text = customerData["welness"].ToString() + ".00";
                    room = new SpaWellnessFee(room, customerData["welness"]);
                }
                if (customer.HasSpaFee)
                {
                    label17.Text = customerData["spa"].ToString() + ".00";
                    room = new SpaWellnessFee(room, customerData["spa"]);
                }
                if (customer.HasPoolFee)
                {
                    label16.Text = customerData["pool"].ToString() + ".00";
                    room = new GymPoolFee(room, customerData["pool"]);
                }
                if (customer.HasGymFee)
                {
                    label15.Text = customerData["gym"].ToString() + ".00";
                    room = new GymPoolFee(room, customerData["gym"]);
                }
                if (customer.HasRoomServiceFee)
                {
                    label14.Text = customerData["service"].ToString() + ".00";
                    room = new RoomService(room, customerData["service"]);
                }
                if (customer.HasParkingFee)
                {
                    label4.Text = customerData["parking"].ToString() + ".00";
                    room = new ParkingFee(room, customerData["parking"]);
                }
                if (customer.HasLuggageFee)
                {
                    label6.Text = customerData["luggage"].ToString() + ".00";
                    room = new LuggageFee(room, customerData["luggage"]);
                }
                if (customer.HasCleaningFee)
                {
                    label8.Text = customerData["cleaning"].ToString() + ".00";
                    room = new CleaningFee(room, customerData["cleaning"]);
                }
                double vat = 0.08 * room.calculateCharge();
                label19.Text = vat.ToString();
                double total = vat + room.calculateCharge();
                label20.Text = total.ToString();
            }
        }
    }
}
