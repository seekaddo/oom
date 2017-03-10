using System;

namespace Task3
{
    public class Truck : Vehicle
    {


        private readonly double BasePrice = 7000;

        public Truck(int wheel, int miles, string manufacturer, string model)
        {
            this.Wheels = wheel;
            this.Manufacturer = manufacturer;
            this.Miles = miles;
            this.Model = model;
        }


        public Truck(string manufacturer, string model, int relYear, int purcYear)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.ReleaseYear = relYear;
            this.PurchaseYear = purcYear;
        }

        public Truck(int wheel, int miles, string make, string model, int relYear,
            int purcYear, bool isSold) : this(wheel, miles, make, model)
        {
            this.ReleaseYear = relYear;
            this.ReleaseYear = purcYear;
            this.IsSold = isSold;
        }


        #region Vehicle Implementation

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
                else if (releaseYear - purchaseYear > 30)
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


        /*
        public bool Equal(Car o)
        {
            return this._manufacturer.Equals(o._manufacturer) &&
                   this._model.Equals(o._model) &&
                   this._relYear == o._relYear;
        }

        public double purchase_price(Car o)
        {
            if (!o.IsSold)
                return 0.0;
            return o.BasePrice - (0.10 * o._miles);
        }
        */


        public void Details()
        {
            var sld = this.IsSold ? "Yes" : "No";
            var str = $"Vehicle Type         :{Manufacturer}" + Environment.NewLine +
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
            var vehls = new Vehicle[]
            {
                new Truck(8, 1000, "Ford", "F15000", 2011, 2016, false),
                new Truck(4, 13000, "Ford", "F-150", 2009, 2014, false),
                new Car("Ford", "Super Duty", 2012, 2017, false),
            };

            var car1 = vehls[2];
            car1.Miles = 12000;
            car1.Wheels = 4;
            car1.Details();
        }
    }
}