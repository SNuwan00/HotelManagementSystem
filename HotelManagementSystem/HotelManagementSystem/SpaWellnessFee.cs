using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem
{
    //Charge for access to spa services like massages, sauna, jacuzzi, or yoga classes.
    internal class SpaWellnessFee : RoomChargeDecorator
    {
        private double _value;

        public SpaWellnessFee(IRoomCharge roomCharge, double value) : base(roomCharge)
        {
            _value = value;
        }

        public override double calculateCharge()
        {
            return base.calculateCharge() + _value;
        }
    }
}
