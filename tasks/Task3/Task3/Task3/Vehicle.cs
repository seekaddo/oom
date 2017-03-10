using System;

namespace Task3
{
    public interface Vehicle
    {
        double purchase_price();
        string vehicle_type();
        int release_year();
        int purchase_year();
        bool IsOld(int releaseYear, int purchaseYear);
        void Details();

    }








    public class Car:Vehicle
    {
        private int _wheel;
        private int _miles;
        private string _manufacturer;
        private string _model;
        private int _relYear;
        private int _purchYear;
        private readonly double  BasePrice = 7000;

        public Car(int wheel, int miles, string make, string model)
        {
            this._wheel = wheel;
            this._manufacturer = make;
            this._miles = miles;
            this._model = model;
        }


        public Car(string make, string model, int relYear,int purcYear)
        {
            this._manufacturer = make;
            this._model = model;
            this._relYear = relYear;
            this.PurchYear = purcYear;
        }

        public Car(string make, string model, int relYear, int purcYear, bool isSold) : this(make, model, relYear,
            purcYear)
        {
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
            return "Car";
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
                      $"Wheels               :{_wheel}" + Environment.NewLine +
                      $"Release Year         :${RelYear}" + Environment.NewLine +
                      $"Purchase Year        :{PurchYear}" + Environment.NewLine +
                      $"Available            :{sld}" + Environment.NewLine +
                      Environment.NewLine;


            Console.Write(str);
        }

        #endregion

    }
}