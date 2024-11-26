namespace HotelManagementSystem
{
    //Charge for access to fitness facilities, swimming pools, or sports areas.
    internal class GymPoolFee : RoomChargeDecorator
    {
        private double _value;

        public GymPoolFee(IRoomCharge roomCharge, double value) : base(roomCharge)
        {
            _value = value;
        }

        public override double calculateCharge()
        {
            return base.calculateCharge() + _value;
        }
    }
}
