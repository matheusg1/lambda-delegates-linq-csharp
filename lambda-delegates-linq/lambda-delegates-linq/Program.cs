using System;
using System.Collections.Generic;
using System.Linq;
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

            Func<Product, string> func = p => p.Name.ToUpper();

            //Func<Product, string> func =  p => { return p.Name.ToUpper(); };  //Outra forma, caso use chaves é necessario usar "return"
            //Func<Product, string> func = NameUpper; //<Product, string> Recebe Product, retorna string

            List<string> result = list.Select(func).ToList();
            //List<string> result = list.Select(NameUpper).ToList(); //Segunda forma, com funções
            //List<string> result = list.Select(p => p.Name.ToUpper()).ToList(); //outra forma

            list.ForEach(p => Console.WriteLine(p.Name));
            Console.WriteLine();
            result.ForEach(p => Console.WriteLine(p));

        }

        static string NameUpper(Product p)
        {
            return p.Name.ToUpper();
        }
    }
}
