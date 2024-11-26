namespace HotelManagementSystem
{
    //Charge for providing parking spaces, especially in urban or high-demand areas.
    internal class ParkingFee : RoomChargeDecorator
    {
        private double _value;

        public ParkingFee(IRoomCharge roomCharge, double value) : base(roomCharge)
        {
            _value = value;
        }

        public override double calculateCharge()
        {
            return base.calculateCharge() + _value;
        }
    }
}
