namespace CarDealer.Client
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Core;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using CarDealer.Data;
    using CarDealer.Models;
    using Newtonsoft.Json;
    class Program
    {
        static void Main()
        {
            SeedData();
       }

        private static void SeedData()
        {
            SeedSuppliers();
            SeedParts();
            SeedCars();
            SeedCustomers();
            SeedSales();
        }

        private static void SeedSales()
        {
            double[] discounts = new double[] { 0, 0.05, 0.10, 0.20, 0.30, 0.40, 0.50 };
            using (var context = new CarDealerContext())
            {
                Random rnd = new Random();
                var cars = context.Cars.ToList();
                var customers = context.Customers.ToList();

                for (int i = 0; i < 50; i++)
                {
                    var car = cars[rnd.Next(cars.Count)];
                    var customer = customers[rnd.Next(customers.Count)];
                    var discount = discounts[rnd.Next(discounts.Length)];

                    if (customer.IsItYoungDriver)
                    {
                        discount += 0.05;
                    }

                    Sale sale = new Sale()
                    {
                        Car = car,
                        Customer = customer,
                        Discount = discount
                    };

                    context.Sales.Add(sale);
                }

                context.SaveChanges();
            }
        }

        private static void SeedCustomers()
        {
            var customersFile =
                File.ReadAllText("C:\\Users\\Dell\\Documents\\visual studio 2015\\Projects\\CarDealer\\customers.json");
            var customersDeserialized = JsonConvert.DeserializeObject<IEnumerable<Customer>>(customersFile);
            using (var context = new CarDealerContext())
            {
                try
                {
                    context.Customers.AddRange(customersDeserialized);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);

                    UpdateException updateException = (UpdateException)ex.InnerException;
                    SqlException sqlException = (SqlException)updateException.InnerException;

                    foreach (SqlError error in sqlException.Errors)
                    {
                        Console.WriteLine(error);
                    }
                    Console.ReadLine();
                }
            
              
        }

    }

        private static void SeedCars()
        {

            var carsText =
                File.ReadAllText("../../../datasets/cars.json");
            var cars = JsonConvert.DeserializeObject<IEnumerable<Car>>(carsText);

            using (var context = new CarDealerContext())
            {
                Random rnd = new Random();
                var parts = context.Parts.ToList();
                foreach (var car in cars)
                {
                    int randomPartsCount = rnd.Next(10, 21);
                    for (int i = 0; i < randomPartsCount; i++)
                    {
                        car.Parts.Add(parts[rnd.Next(parts.Count)]);
                    }

                    context.Cars.Add(car);
                }

                context.SaveChanges();
            }
        }


        private static void SeedParts()
        {
            var partsFile =
                File.ReadAllText("../../../datasets/parts.json");
            var parts = JsonConvert.DeserializeObject<IEnumerable<Part>>(partsFile);

            using (var context = new CarDealerContext())
            {
                Random rnd = new Random();
                var suppliers = context.Suppliers.ToList();

                foreach (var part in parts)
                {
                    part.Supplier = suppliers[rnd.Next(suppliers.Count)];
                    context.Parts.Add(part);
                }

                context.SaveChanges();
            }
        }

        private static void SeedSuppliers()
        {
            CarDealerContext context = new CarDealerContext();

            string suppliersFile =
                File.ReadAllText("../../../datasets/suppliers.json");

            IEnumerable<Supplier> supplierImported = JsonConvert.DeserializeObject<IEnumerable<Supplier>>(suppliersFile);
            context.Suppliers.AddRange(supplierImported);
            context.SaveChanges();
        }
    }
}
