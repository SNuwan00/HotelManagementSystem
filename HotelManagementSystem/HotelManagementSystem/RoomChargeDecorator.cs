namespace HotelManagementSystem
{
    public abstract class RoomChargeDecorator : IRoomCharge
    {
        protected IRoomCharge RoomCharge;

        protected RoomChargeDecorator(IRoomCharge roomCharge)
        {
            RoomCharge = roomCharge;
        }

        public virtual double calculateCharge()
        {
            return RoomCharge.calculateCharge();
        }
    }
}
