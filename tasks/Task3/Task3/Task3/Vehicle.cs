using System;

namespace Task3
{
    public interface Vehicle
    {
        int Wheels { get; set; }

        int Miles { get; set; }
        string Model { get; set; }
        string Manufacturer { get; set; }
        double PurchasePrice { get; }
        string VehicleType { get; set; }
        int ReleaseYear { get; set; }
        int PurchaseYear { get; set; }
        bool IsOld(int releaseYear, int purchaseYear);
        bool IsSold { get; set; }
        void Details();
    }


    public class Car : Vehicle
    {

        private readonly double BasePrice = 7000;

        public Car(int wheels, int miles, string make, string model)
        {
            this.Wheels = wheels;
            this.Manufacturer = make;
            this.Miles = miles;
            this.Model = model;
        }


        public Car(string make, string model, int relYear, int purcYear)
        {
            this.Manufacturer = make;
            this.Model = model;
            this.ReleaseYear = relYear;
            this.PurchaseYear = purcYear;
        }

        public Car(string make, string model, int relYear, int purcYear, bool isSold) : this(make, model, relYear,
            purcYear)
        {
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
                return BasePrice - (0.10 * Miles);
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
    }
}