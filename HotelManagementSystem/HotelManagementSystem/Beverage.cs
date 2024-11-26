namespace HotelManagementSystem
{
    //Charge for drinks, such as water, coffee, tea, soft drinks, or alcoholic beverages.
    public class Beverage : RoomChargeDecorator
    {
        private double _value;

        public Beverage(IRoomCharge roomCharge, double value) : base(roomCharge) 
        {
            _value = value;
        }

        public override double calculateCharge()
        {
            return base.calculateCharge() + _value;
        }
    }
}
