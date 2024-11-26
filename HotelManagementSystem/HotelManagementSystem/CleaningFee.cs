using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem
{
    //Charge for additional cleaning (e.g., after parties or for extended stays).
    internal class CleaningFee : RoomChargeDecorator
    {
        private double _value;

        public CleaningFee(IRoomCharge roomCharge, double value) : base(roomCharge)
        {
            _value = value;
        }

        public override double calculateCharge()
        {
            return base.calculateCharge() + _value;
        }
    }
}
