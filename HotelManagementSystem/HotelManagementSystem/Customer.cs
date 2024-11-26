using System;

namespace HotelManagementSystem
{
    internal class Customer
    {
        private static Customer _instance;
        // Properties
        public string NIC { get; set; }
        public string Name { get; set; }
        public string RoomType { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public bool HasBeverage { get; set; } = false;
        public bool HasCleaningFee { get; set; } = false;
        public bool HasGymFee { get; set; } = false;
        public bool HasPoolFee { get; set; } = false;
        public bool HasLuggageFee { get; set; } = false;
        public bool HasParkingFee { get; set; } = false;
        public bool HasRoomServiceFee { get; set; } = false;
        public bool HasSpaFee { get; set; } = false;
        public bool HasWellnessFee { get; set; } = false;
        public string[] Beverages { get; set; } = null;

        private const double VAT_RATE = 0.08;

        public static Customer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Customer();
                }
                return _instance;
            }
        }

        public Customer()
        {
        }

        public Customer(string name,string nIC, string date, string time, string roomType, bool hasParkingFee, bool hasLuggageFee, bool hasCleaningFee, bool hasRoomServiceFee, bool hasGymFee, bool hasPoolFee, bool hasSpaFee, bool hasWellnessFee)
        {
            Name = name;
            NIC = nIC;
            RoomType = roomType;
            HasCleaningFee = hasCleaningFee;
            HasGymFee = hasGymFee;
            HasPoolFee = hasPoolFee;
            HasLuggageFee = hasLuggageFee;
            HasParkingFee = hasParkingFee;
            HasRoomServiceFee = hasRoomServiceFee;
            HasSpaFee = hasSpaFee;
            HasWellnessFee = hasWellnessFee;
            this.date = date;
            this.time = time;
        }

        // Method to Calculate Total Cost
        public double CalculateTotalCost(double baseRoomRate)
        {
            double total = baseRoomRate;

            if (HasBeverage) total += 15.0;
            if (HasCleaningFee) total += 10.0;
            if (HasGymFee) total += 25.0;
            if (HasPoolFee) total += 30.0;
            if (HasLuggageFee) total += 5.0;
            if (HasParkingFee) total += 10.0;
            if (HasRoomServiceFee) total += 20.0;
            if (HasSpaFee) total += 50.0;
            if (HasWellnessFee) total += 40.0;

            total += total * VAT_RATE; // Apply VAT
            return total;
        }
    }
}
