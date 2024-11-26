namespace HotelManagementSystem
{
    public class BasicRoomCharge : IRoomCharge
    {
        private double roomCharge;

        public BasicRoomCharge(double roomCharge)
        {
            this.roomCharge = roomCharge;
        }

        public double calculateCharge()
        {
            return roomCharge;
        }
    }
}
