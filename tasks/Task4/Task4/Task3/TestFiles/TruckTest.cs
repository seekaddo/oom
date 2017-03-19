using System;
using NUnit.Framework;



namespace Task3.TestFiles
{
     [TestFixture]
    public class TruckTest
    {

        public void CreateTrucks()
        {
            var trk = new Truck("Toyota", "Toyota Hilux",2009, 2014,true,4,91000);

            Assert.IsTrue(trk.Manufacturer == "Ford");
            Assert.IsTrue(trk.Manufacturer == "Super Duty");
            Assert.IsTrue(trk.ReleaseYear == 2012);
            Assert.IsTrue(trk.PurchaseYear == 2017);
            Assert.IsTrue(trk.IsSold);
        }


        [Test]
        public void TrucksAreNotmadeInNegativeYears()
        {
            Assert.Catch(() =>
            {
                var  x = new Truck("Tata", "Heavy Duty",-2, 2014,true,4,11000);
            });

        }
        [Test]
        public void CannotCreateTrucksWithoutManf()
        {
            Assert.Catch(() =>
            {
                var  x = new Truck(null, "500 Serie",2009, 2014,false,4,21000);
            });

        }

        [Test]
        public void TruckNotMadeYet()
        {

            Assert.Catch(() =>
            {

                var  f = new Truck("BMW", "M3 Pickup",2021, 2014,true,4,41000);
                f.IsOld(); //the release year is greater than the purchase year

            });
        }

        [Test]
        public void PurchasepricePass()
        {

            var c = new Truck("Ford", "Super Duty",2012, 2017,true,4,7000);
            Assert.IsTrue(Math.Abs(c.PurchasePrice) > 0.001);
        }

        [Test]
        public void PurchasepriceFail()
        {

            var c = new Truck("BAW", "BAW Luling",2014, 2017,false,4,72000);
            Assert.IsTrue(c.PurchasePrice.CompareTo(0.0) == 0);
        }

    }
}