namespace HotelManagementSystem
{
    //Charge for using the bar/lounge area or for specific drinks/snacks.
    internal class Bar_Fee : RoomChargeDecorator
    {
        private double _value;

        public Bar_Fee(IRoomCharge roomCharge, double value) : base(roomCharge)
        {
            _value = value;
        }

        public override double calculateCharge()
        {
            return base.calculateCharge() + _value;
        }
    }
}
