using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DbConnectWithCore
{
    class Main
    {
        Context context = new Context();
        MessageSender mes = new MessageSender();
        JsonFormatter jsonFormatter = new JsonFormatter();
        public Main()
        {
            DbConnect();
        }

        private void DbConnect()
        {
            using (context)
            {
                context.Database.EnsureCreated();
                //var shop = context.Shops.ToList();
                var product = context.Products.ToList();
                var customer = context.Customers.ToList();
                var shopcustomer = context.ShopCustomers.ToList();

                try
                {
                    AddData();
                }
                catch (InvalidOperationException exception)
                {
                    exception.TryAddData();
                    //context.Shops.Load();
                    context.Products.Load();
                    context.Customers.Load();
                    context.ShopCustomers.Load();
                }
                catch (Exception exception)
                {
                    exception.UnknownException();
                }
                List<Shop> shop = new List<Shop>();
                jsonFormatter.DeserializeObjectAsync(shop, "data.json");
                //foreach (var res in shop)
                //{
                //    Console.WriteLine($"ShopName : {res.shopName}, ShopRate : {res.shopRate}");
                //}

                #region LINQ
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
                #endregion
            }
        }

        private void AddData()
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
    }
}