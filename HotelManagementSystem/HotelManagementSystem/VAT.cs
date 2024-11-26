namespace HotelManagementSystem
{
    public class VAT : RoomChargeDecorator
    {
        private readonly double vatRate;

        public VAT(IRoomCharge roomCharge, double rate) : base(roomCharge)
        {
            vatRate = rate;
        }

        public override double calculateCharge()
        {
            return base.calculateCharge() * (1 + vatRate);
        }
    }

}
