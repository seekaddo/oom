using System;

namespace Task3
{
    public class Truck : IVehicle
    {
        private static readonly double BasePrice = 7000;

        public Truck(int wheel, int miles, string manufacturer, string model)
        {
            Wheels = wheel;
            Manufacturer = manufacturer;
            Miles = miles;
            Model = model;
        }


        public Truck(string manufacturer, string model, int relYear, int purcYear)
        {
            Manufacturer = manufacturer;
            Model = model;
            ReleaseYear = relYear;
            PurchaseYear = purcYear;
        }

        public Truck(int wheel, int miles, string make, string model, int relYear,
            int purcYear, bool isSold) : this(wheel, miles, make, model)
        {
            ReleaseYear = relYear;
            ReleaseYear = purcYear;
            IsSold = isSold;
        }


        #region IVehicle Implementation

        public bool IsSold { get; set; }
        public int Wheels { get; set; }
        public int Miles { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string VehicleType { get; set; }
        public int ReleaseYear { get; set; }
        public int PurchaseYear { get; set; }

        public double PurchasePrice
        {
            get
            {
                if (!IsSold)
                    return 0.0;
                return BasePrice - (0.10 * ReleaseYear);
            }
        }

        public bool IsOld(int releaseYear, int purchaseYear)
        {
            try
            {
                if (releaseYear < 0 || purchaseYear < 0) throw new ArgumentException("Years are not negative values");
                if (releaseYear > purchaseYear) throw new ArgumentException("This car isn't made yet");

                if (releaseYear - purchaseYear < 10)
                {
                    return false;
                }
                if (releaseYear - purchaseYear > 30)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }

            return false;
        }


        public void Details()
        {
            var sld = IsSold ? "No" : "Yes";
            var str =
                $"Manufacturer         :{Manufacturer}" + Environment.NewLine +
                $"Model                :{Model}" + Environment.NewLine +
                $"Miles                :{Miles}" + Environment.NewLine +
                $"Wheels               :{Wheels}" + Environment.NewLine +
                $"Release Year         :{ReleaseYear}" + Environment.NewLine +
                $"Purchase Year        :{PurchaseYear}" + Environment.NewLine +
                $"Available            :{sld}" + Environment.NewLine +
                Environment.NewLine;


            Console.Write(str);
        }

        #endregion


        public static void Main(string[] args)
        {
            var vehls = new IVehicle[]
            {
                new Truck(8, 1000, "Ford", "F15000", 2011, 2016, false),
                new Truck(4, 13000, "Ford", "F-150", 2009, 2014, false),
                new Car("Ford", "Super Duty", 2012, 2017, true)
            };

            var car1 = vehls[2];
            car1.Miles = 12000;
            car1.Wheels = 4;
            Console.WriteLine("The Purchase Price is: {0}",car1.PurchasePrice);
            car1.Details();


            foreach (var vehl in vehls)
            {
                vehl.Details();
                Console.WriteLine();
            }
        }
    }
}