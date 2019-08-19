using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization.Json;
using System.IO;

namespace DbConnectWithCore
{
    class Program
    {
        public static event Action SendMessage;
        public static Context context = new Context();
        static void Main(string[] args)
        {
            using (context)
            {
                context.Database.EnsureCreated();
                //AddData();     

                var shop = context.Shops.ToList();
                var product = context.Products.ToList();
                var customer = context.Customers.ToList();
                var shopcustomer = context.ShopCustomers.ToList();

                context.Shops.Load();
                context.Products.Load();
                context.Customers.Load();
                context.ShopCustomers.Load();

                var result = DeserializeObject(customer, "data.json");
                //foreach(var res in result)
                //{
                //    Console.WriteLine($"FName : {res.fName}, LName : {res.lName}");
                //}


                //var result2 = from customers in customer
                //              join shopcustomers in shopcustomer on customers.customerId equals shopcustomers.customerId
                //              join shops in shop on shopcustomers.shopId equals shops.shopId
                //              select new { ShopName = shops.shopName, FName = customers.fName, LName = customers.lName };

                //foreach (var res in result2)
                //{
                //    Console.WriteLine($"ShopName : {res.ShopName}, FName : {res.FName}, LName : {res.LName}");
                //}

                //var result = from shops in shop
                //             from products in product
                //             where products.shopId == shops.shopId
                //             select new { ShopName = shops.shopName, ProductName = products.productName };

                //foreach (var res in result)
                //{
                //    Console.WriteLine($"ShopName : {res.ShopName}, ProductName : {res.ProductName}");
                //}
            }
        }

        static void AddData()
        {
            var shop = new List<Shop>
            {
                    new Shop() { shopName = "Дикси", shopRate = 7, shopId = 1},
                    new Shop() { shopName = "Пятёрочка", shopId = 2},
                    new Shop() { shopName = "Магнит", shopRate = 8, shopId = 3},
            };

            var product = new List<Product>
            {
                new Product() { productName = "Томаты", shopId = 1},
                new Product() { productName = "Молоко", shopId = 2},
                new Product() { productName = "Огурцы", shopId = 3},
                new Product() { productName = "Кефир", shopId = 1}
            };

            var customer = new List<Customer>
            {
                new Customer() { fName = "Фродо", lName = "Беггинс", customerEmail = "" },
                new Customer() { fName = "Перегринн", lName = "Тук", customerEmail = "" },
                new Customer() { fName = "Сэм-Уайс", lName = "Гэмджи", customerEmail = "" },
                new Customer() { fName = "Билл", lName = "Миллиган", customerEmail = "" },
                new Customer() { fName = "Том", lName = "Соер", customerEmail = "" }
            };

            var shopcustomer = new List<ShopCustomer>
            {
                new ShopCustomer() {customerId = 1, shopId = 1},
                new ShopCustomer() {customerId = 1, shopId = 2},
                new ShopCustomer() {customerId = 2, shopId = 1},
                new ShopCustomer() {customerId = 2, shopId = 3},
                new ShopCustomer() {customerId = 3, shopId = 1},
                new ShopCustomer() {customerId = 4, shopId = 2},
                new ShopCustomer() {customerId = 4, shopId = 3},
                new ShopCustomer() {customerId = 5, shopId = 1},
                new ShopCustomer() {customerId = 5, shopId = 2},
                new ShopCustomer() {customerId = 5, shopId = 3}
            };

            context.Shops.AddRange(shop);
            context.Products.AddRange(product);
            context.Customers.AddRange(customer);
            context.ShopCustomers.AddRange(shopcustomer);
            context.SaveChanges();
        }

        static void SerializeObject<T>(T fileToWrite, string path)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(T));
            using (var file = new FileStream(path, FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(file, fileToWrite);
                SendMessage?.Invoke();
            }     
        }

        static T DeserializeObject<T>(T fileFormat, string path)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(T));
            using (var file = new FileStream(path, FileMode.OpenOrCreate))
            {
                T result = (T)jsonFormatter.ReadObject(file);
                SendMessage?.Invoke();
                return result;
            }
        }
    }
}
