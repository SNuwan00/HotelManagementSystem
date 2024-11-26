namespace HotelManagementSystem
{
    //Charge for food or beverages delivered to the guest's room.
    internal class RoomService : RoomChargeDecorator
    {
        private double _value;

        public RoomService(IRoomCharge roomCharge, double value) : base(roomCharge)
        {
            _value = value;
        }

        public override double calculateCharge()
        {
            return base.calculateCharge() + _value;
        }
    }
}
