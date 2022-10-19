using System;
using System.Collections.Generic;
using lambda_delegates_linq.Entities;
using lambda_delegates_linq.Services;

namespace lambda_delegates_linq
{
    delegate void BinaryNumericOperation(double n1, double n2); //type safety
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();
            list.Add(new Product("Tv", 900.00));
            list.Add(new Product("Mouse", 50.00));
            list.Add(new Product("Tablet", 350.50));
            list.Add(new Product("HD Case", 80.90));

            list.RemoveAll(p => p.Price >= 100);
            foreach(Product p in list)
            {
                Console.WriteLine(p);
            }
        }
    }
}
