using System;
using System.IO;
using Newtonsoft.Json;

namespace Task3
{
   internal class RunMainClass{
        public static void Main(string[] args)
        {
            var vehls = new IVehicle[]
            {
                new Truck("Ford", "F15000", 2011, 2016,true,8,23000),
                new Truck("Ford", "F-150", 2009, 2014,false,8,13000),
                new Truck("Toyota", "Toyota Hilux",2009, 2014,true,4,91000),
                new Car("Toyota", "Corolla",2009, 2014,true,8,91000),
                new Car("Tesla", "Super charger",2014, 2017,false,4,72000)

            };


            //Serialise and store in .json file with the vehicles.json
            var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };
            var vehicles = JsonConvert.SerializeObject(vehls, settings);

            var cwd_path = Directory.GetCurrentDirectory();
            var filename = Path.Combine(cwd_path, "vehicles.json");
            File.WriteAllText(filename,vehicles);

            Console.WriteLine(File.ReadAllText(filename));


            var jsonFromFile = File.ReadAllText(filename);
            var vehiclesFromFile = JsonConvert.DeserializeObject<IVehicle[]>(jsonFromFile, settings);
            foreach (var vls in vehiclesFromFile)
            {
                Console.WriteLine($"Manufacturer: {vls.Manufacturer} --> Model: {vls.Model}");
            }



        }
    }
}