namespace HotelManagementSystem
{
    //Charge for handling or storing luggage during check-in or after check-out.
    internal class LuggageFee : RoomChargeDecorator
    {
        private double _value;

        public LuggageFee(IRoomCharge roomCharge, double value) : base(roomCharge)
        {
            _value = value;
        }

        public override double calculateCharge()
        {
            return base.calculateCharge() + _value;
        }
    }
}
