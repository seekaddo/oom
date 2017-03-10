using System;

namespace Task3
{
    public class Truck :Vehicle
    {

        private int _wheel;
        private int _miles;
        private string _manufacturer;
        private string _model;
        private int _relYear;
        private int _purchYear;
        private readonly double  BasePrice = 7000;

        public Truck(int wheel, int miles, string manufacturer, string model)
        {
            this._wheel = wheel;
            this._manufacturer = manufacturer;
            this._miles = miles;
            this._model = model;
        }


        public Truck(string manufacturer, string model, int relYear,int purcYear)
        {
            this._manufacturer = manufacturer;
            this._model = model;
            this._relYear = relYear;
            this.PurchYear = purcYear;
        }

        public Truck(int wheel, int miles,string make, string model,int relYear,
                     int purcYear, bool isSold) : this(wheel, miles, make,model)
        {
            this._relYear = relYear;
            this._purchYear = purcYear;
            this.IsSold = isSold;
        }



        public bool IsSold { get; set; }



        public int RelYear
        {
            get { return _relYear; }
            set { _relYear = value; }
        }

        public int PurchYear
        {
            get { return _purchYear; }
            set { _purchYear = value; }
        }

        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }
        public string Manufacturer
        {
            get { return _manufacturer; }
            set { _manufacturer = value; }
        }
        public int Miles
        {
            get { return _miles; }
            set { _miles = value; }
        }
        public int Wheel
        {
            get { return _wheel; }
            set { _wheel = value; }
        }





        #region Vehicle Implementation


        public double purchase_price()
        {
            if (!IsSold)
                return 0.0;
            return BasePrice - (0.10 * _miles);
        }

        public string vehicle_type()
        {
            return "Truck";
        }

        public int release_year()
        {
            return _relYear;
        }

        public int purchase_year()
        {
            return _purchYear;
        }

        public bool IsOld(int releaseYear, int purchaseYear)
        {
            try
            {
                if(releaseYear < 0 || purchaseYear < 0) throw new ArgumentException("Years are not negative values");
                if(releaseYear > purchaseYear ) throw new ArgumentException("This car isn't made yet");

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
        public bool Equal(Truck o)
        {
            return this._manufacturer.Equals(o._manufacturer) &&
                   this._model.Equals(o._model) &&
                   this._relYear == o._relYear;
        }


        public double purchase_price(Truck o)
        {
            if (!o.IsSold)
                return 0.0;
            return o.BasePrice - (0.10 * o._miles);
        }
        */

        public void Details()
        {
            var sld = this.IsSold ? "Yes" : "No";
            var str = $"Vehicle Type     :{Manufacturer}" + Environment.NewLine +
                      $"Manufacturer         :{Manufacturer}" + Environment.NewLine +
                      $"Model                :{Model}" + Environment.NewLine +
                      $"Miles                :{Miles}" + Environment.NewLine +
                      $"Wheels               :{_wheel}" + Environment.NewLine +
                      $"Release Year         :${RelYear}" + Environment.NewLine +
                      $"Purchase Year        :{PurchYear}" + Environment.NewLine +
                      $"Purchase Year        :{PurchYear}" + Environment.NewLine +
                      $"Available            :{sld}" + Environment.NewLine +
                      Environment.NewLine;


            Console.Write(str);
        }

        #endregion


       public static void Main(string[] args)
       {

           var vehls = new Vehicle[]
           {
               new Truck(8, 1000, "Ford", "Transit", 2011, 2016, false),
               new Truck(4, 13000, "Ford", "F-150", 2009, 2014, false),
               new Car("Ford", "Super Duty", 2012, 2017, false),
           };

           Car c1 = (Car) vehls[2];
           c1.Wheel = 4;
           c1.Miles = 12000;

           c1.Details();


       }
    }
}