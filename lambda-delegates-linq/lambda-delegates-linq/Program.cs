using System;
using System.Collections.Generic;
using lambda_delegates_linq.Entities;
using lambda_delegates_linq.Services;

namespace lambda_delegates_linq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();
            list.Add(new Product("Tv", 900.00));
            list.Add(new Product("Mouse", 50.00));
            list.Add(new Product("Tablet", 350.50));
            list.Add(new Product("HD Case", 80.90));


            Action<Product> act = (p => p.Price += p.Price * 0.1);
            Action<Product> act2 = p => { p.Price += p.Price * 0.1; }; //outra formatação

            list.ForEach(act);
            //list.ForEach(UpdatePrice);  //segunda forma, com funções
            //list.ForEach(p => p.Price += p.Price * 0.1); //terceira forma, com expressão lambda

            foreach (Product p in list)
            {
                Console.WriteLine(p);
            }

        }

        static void UpdatePrice(Product p)
        {
            p.Price += p.Price * 0.1;
        }
    }
}
