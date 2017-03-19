using System;
using Newtonsoft.Json;

namespace Task3
{
    public class Truck : IVehicle
    {
        private static readonly double BasePrice = 7000;

        public Truck(string maker, string model, int relYear,
            int purcYear, bool isSold, int wheels, int miles)
            : this(maker, model, relYear, purcYear, wheels, miles)

        {
            IsSold = isSold;
        }


        [JsonConstructor]
        public Truck(string manufacturer, string model, int relYear,
            int purcYear, int wheels, int miles)

        {
            if (string.IsNullOrWhiteSpace(manufacturer))
                throw new ArgumentException("Manufacture cann't be empty", nameof(manufacturer));
            if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentException("model cann't be empty", nameof(model));
            if (relYear < 0 || purcYear < 0)
                throw new ArgumentException("Years are not negative values");

            Manufacturer = manufacturer;
            Model = model;
            PurchaseYear = purcYear;
            ReleaseYear = relYear;
            Wheels = wheels;
            Miles = miles;
        }


        #region IVehicle Implementation

        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int ReleaseYear { get; set; }
        public int PurchaseYear { get; set; }

        [JsonIgnore]
        public bool IsSold { get; set; }

        public int Wheels { get; set; }
        public int Miles { get; set; }

        [JsonIgnore]
        public string VehicleType => "Truck";


        [JsonIgnore]
        public double PurchasePrice
        {
            get
            {
                if (!IsSold)
                    return 0.0;
                return BasePrice - (0.10 * ReleaseYear);
            }
        }

        public bool IsOld()
        {
            if (ReleaseYear < 0 || PurchaseYear < 0) throw new ArgumentException("Years are not negative values");
            if (ReleaseYear > PurchaseYear) throw new ArgumentException("This car isn't made yet");

            if (ReleaseYear - PurchaseYear < 10)
            {
                return false;
            }
            return ReleaseYear - PurchaseYear > 30;
        }

        #endregion
    }
}