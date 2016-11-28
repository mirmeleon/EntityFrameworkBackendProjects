namespace ProductsShop.Client
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;
    using ProductsShop.Data;
    using ProductsShop.Models;
    class Program
    {
        static void Main()
        {
            SeedData();
            QueryAndExportData();
        }

        private static void QueryAndExportData()
        {
            ProductsInRange();
            SuccessfullySoldProducts();
            CategoriesByProductCount();
            UsersAndProducts();

        }

        private static void UsersAndProducts()
        {
            //Get all users who have at least 1 sold product. Order them by the number of sold products (from highest to lowest), then by last name (ascending). Select only their first and last name, age and for each product - name and price.
            ProductsShopContext context = new ProductsShopContext();
            var query = context.Users.Where(u => u.ProductsSold.Count != null)
                .OrderByDescending(ur => ur.ProductsSold.Count)
                .ThenBy(u => u.LastName)
                .Select(user => new
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Age = user.Age,
                    SoldProducts = user.ProductsSold.Select(pr => new
                    {
                        count = user.ProductsSold.Count,
                        pr.Name,
                        pr.Price
                    })
                });

            var querySerialised = JsonConvert.SerializeObject(query, Formatting.Indented);
            File.WriteAllText("C:\\Users\\Dell\\Documents\\Visual Studio 2015\\Projects\\ProductsShop\\usersAndProducts.txt", querySerialised);
        }

        private static void CategoriesByProductCount()
        {
            //Get all categories. Order them by the number of products in that category (a product can be in many categories). For each category select its name, the number of products, the average price of those products and the total revenue (total price sum) of those products (regardless if they have a buyer or not).
            ProductsShopContext context = new ProductsShopContext();
            var query = context.Categories.OrderBy(prod => prod.Products.Count)
                .Select(cat => new
                {
                    Name = cat.Name,
                    NumberOfProducts = cat.Products.Count,
                    AveragePrice = cat.Products.Select(pr => pr.Price).Average(),
                    Sum = cat.Products.Select(pr => pr.Price).Sum()
                });


            var serialisedQuery = JsonConvert.SerializeObject(query, Formatting.Indented);
            File.WriteAllText("C:\\Users\\Dell\\Documents\\Visual Studio 2015\\Projects\\ProductsShop\\categories.txt", serialisedQuery);

            
        }

        private static void SuccessfullySoldProducts()
        {
        //    Get all users who have at least 1 sold item with a buyer. Order them by last name, then by first name. Select the person's first and last name. For each of the sold products (products with buyers), select the product's name, price and the buyer's first and last name.
         ProductsShopContext context = new ProductsShopContext();

            var query = context.Users.Where(u => u.ProductsSold.Count(b => b.Buyer != null) >= 1)
                    .OrderBy(u => u.LastName)
                    .ThenBy(u => u.FirstName)
                    .Select(p => new
                    {
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        SoldProducts = p.ProductsSold.Select(prod => new
                        {
                            SoldProductName = prod.Name,
                            SoldProductPrice = prod.Price,
                            SoldProductBuyerFirstName = prod.Buyer.FirstName,
                            SoldProductBuyerLastName = prod.Buyer.LastName

                        }),
                    });

            var querySerialize = JsonConvert.SerializeObject(query, Formatting.Indented);
    File.WriteAllText("C:\\Users\\Dell\\Documents\\Visual Studio 2015\\Projects\\ProductsShop\\soldProducts.txt", querySerialize);
       }

        private static void ProductsInRange()
        {
            //Get all products in a specified price range (e.g. 500 to 1000) which have no buyer. Order them by price (from lowest to highest).Select only the product name, price and the full name of the seller.
            ProductsShopContext context = new ProductsShopContext();
            var products = context.Products.Where(p => p.Price > 500 && p.Price < 1000 && p.Buyer == null).OrderBy(p => p.Price)
                 .Select(s => new
                 {
                     ProductName = s.Name,
                     ProductPrice = s.Price,
                     FullName = s.Seller.FirstName + " " + s.Seller.LastName,

                 });

         
            var serializedProducts = JsonConvert.SerializeObject(products, Formatting.Indented);    
            File.WriteAllText("C:\\Users\\Dell\\Documents\\Visual Studio 2015\\Projects\\ProductsShop\\serializedProducts.txt", serializedProducts);
        }

        private static void SeedData()
        {
           SeedUsers();
           SeedProducts();
           SeedCategories();
        }

        private static void SeedCategories()
        {
            ProductsShopContext context = new ProductsShopContext();
            string json = File.ReadAllText("C:\\Users\\Dell\\Downloads\\Softuni\\Pishtovi\\EntityFR\\homeworks\\08. DB-Advanced-EntityFramework-JSON-Processing-Exercises\\categories.json");
            IEnumerable<Category> categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(json);
            int countOfProducts = context.Products.Count();
            Random rnd = new Random();
            foreach (Category category in categories)
            {
                for (int i = 0; i < countOfProducts / 3; i++)
                {
                    Product product = context.Products.Find(rnd.Next(1, countOfProducts + 1));
                    category.Products.Add(product);
                }
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        private static void SeedUsers()
        {
            ProductsShopContext context = new ProductsShopContext();
            string json = File.ReadAllText("C:\\Users\\Dell\\Downloads\\Softuni\\Pishtovi\\EntityFR\\homeworks\\08. DB-Advanced-EntityFramework-JSON-Processing-Exercises\\users.json");
            IEnumerable<User> users = JsonConvert.DeserializeObject<IEnumerable<User>>(json);
            context.Users.AddRange(users);
            context.SaveChanges();
        }

        private static void SeedProducts()
        {
            ProductsShopContext context = new ProductsShopContext();
            string json = File.ReadAllText("C:\\Users\\Dell\\Downloads\\Softuni\\Pishtovi\\EntityFR\\homeworks\\08. DB-Advanced-EntityFramework-JSON-Processing-Exercises\\products.json");
            IEnumerable<Product> products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
            Random rnd = new Random();
            foreach (Product product in products)
            {
                double shouldHaveBuyer = rnd.NextDouble();
                product.SelledId = rnd.Next(1, context.Users.Count() + 1);
                if (shouldHaveBuyer <= 0.7)
                {
                    product.BuyerId = rnd.Next(1, context.Users.Count() + 1);
                }
            }

            context.Products.AddRange(products);
            context.SaveChanges();
        }

    }
}
