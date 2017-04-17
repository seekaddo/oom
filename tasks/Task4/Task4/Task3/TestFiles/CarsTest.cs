using System;
using NUnit.Framework;

namespace Task3.TestFiles
{
    [TestFixture]
    public class CarsTest
    {
		[Test]
        public void CreateCar()
        {
            var car1 = new Car("Toyota", "Corolla",2009, 2014,true,4,91000);

			Assert.IsTrue(car1.Manufacturer == "Toyota");
			Assert.IsTrue(car1.Model == "Corolla");
			Assert.IsTrue(car1.ReleaseYear == 2009);
			Assert.IsTrue(car1.PurchaseYear == 2014);
            Assert.IsTrue(car1.IsSold);
        }


        [Test]
        public void CarsAreNotmadeInNegativeYears()
        {
            Assert.Catch(() =>
            {
                var  x = new Car("Tata", "Corolla",-2, 2014,true,4,11000);
            });

        }
        [Test]
        public void CannotCreateCarsWithoutManf()
        {
            Assert.Catch(() =>
            {
                var  x = new Car(null, "500 Serie",2009, 2014,false,4,21000);
            });

        }

        [Test]
        public void CarNotMadeYet()
        {

            Assert.Catch(() =>
            {

                var  f = new Car("BMW", "i320",2021, 2014,true,4,41000);
                f.IsOld(); //the release year is greater than the purchase year

            });
        }

        [Test]
        public void PurchasepricePass()
        {

            var c = new Car("Ford", "Super Duty",2012, 2017,true,4,7000);
            Assert.IsTrue(Math.Abs(c.PurchasePrice) > 0.001);
        }

        [Test]
        public void PurchasepriceFail()
        {

            var c = new Car("Tesla", "Super charger",2014, 2017,false,4,72000);
            Assert.IsTrue(c.PurchasePrice.CompareTo(0.0) == 0);
        }

    }
}