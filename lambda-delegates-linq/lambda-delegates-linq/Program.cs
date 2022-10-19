using lambda_delegates_linq.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lambda_delegates_linq
{
    class Program
    {
        static void Main(string[] args)
        {
            Category c1 = new Category() { Id = 1, Name = "Tools", Tier = 2 };
            Category c2 = new Category() { Id = 2, Name = "Computers", Tier = 1 };
            Category c3 = new Category() { Id = 3, Name = "Electronics", Tier = 1 };

            List<Product> products = new List<Product>() {
                new Product() { Id = 1, Name = "Computer", Price = 1100.0, Category = c2 },
                new Product() { Id = 2, Name = "Hammer", Price = 90.0, Category = c1 },
                new Product() { Id = 3, Name = "TV", Price = 1700.0, Category = c3 },
                new Product() { Id = 4, Name = "Notebook", Price = 1300.0, Category = c2 },
                new Product() { Id = 5, Name = "Saw", Price = 80.0, Category = c1 },
                new Product() { Id = 6, Name = "Tablet", Price = 700.0, Category = c2 },
                new Product() { Id = 7, Name = "Camera", Price = 700.0, Category = c3 },
                new Product() { Id = 8, Name = "Printer", Price = 350.0, Category = c3 },
                new Product() { Id = 9, Name = "MacBook", Price = 1800.0, Category = c2 },
                new Product() { Id = 10, Name = "Sound Bar", Price = 700.0, Category = c3 },
                new Product() { Id = 11, Name = "Level", Price = 70.0, Category = c1 }
            };

            //Tier 1 and price < 900
            //var r1 = products.Where(p => p.Category.Tier == 1 && p.Price < 900).ToList(); //IEnumerable para List
            var r1 = from p in products where p.Category.Tier == 1 && p.Price <= 900 select p;
            Print("Tier 1 and price < 900", r1);

            //Name of all products from Tools
            //var r2 = products.Where(p => p.Category.Name == "Tools").Select(p => p.Name);
            var r2 = from p in products where p.Category.Name == "Tools" select p.Name;
            Print("Name of all products from Tools", r2);

            //Names started with 'C' and anonymous object
            //var r3 = products.Where(p => p.Name[0] == 'C' || p.Name[0] == 'c').Select(p => new { p.Name, p.Price, CategoryName = p.Category.Name }); //Cria um objeto anônimo, com a ideia de exibir apenas alguns dos atributos. 'Alias' utilizado para nome de categoria
            var r3 = from p in products where p.Name[0] == 'C' || p.Name[0] == 'c' select new { p.Name, p.Price, CategoryName = p.Category.Name };
            Print("Names started with 'C' and anonymous object", r3);

            //Tier 1 order by price then by name
            //var r4 = products.Where(p => p.Category.Tier == 1).OrderBy(p => p.Name).OrderBy(p => p.Price); //Ordena primeiro por nome, depois por preço, de forma que a última ordenação é sempre a priorizada
            var r4 = from p in products where p.Category.Tier == 1 orderby p.Name orderby p.Price select p;
            Print("Tier 1 order by price then by name", r4);

            //Tier 1 order by price then by name, skip 2 and take 4
            //var r5 = r4.Skip(2).Take(4);
            var r5 = (from p in r4 select p).Skip(2).Take(4);
            Print("Tier 1 order by price then by name, skip 2 and take 4", r5);

            //First product
            //var r6 = products.First();
            var r6 = (from p in products select p).First();
            Console.WriteLine($"First product {r6}");

            //First or default test
            //var r7 = products.Where(p => p.Price >= 3000).FirstOrDefault(); //FirstOrDefault evita propagação de exceção, atribuindo nulo ao valor, quando não há correspondência na base de dados
            var r7 = (from p in products where p.Price > 3000 select p).FirstOrDefault();
            Console.WriteLine($"First or default test: {r7}");
            Console.WriteLine();

            //Single or default test1
            //var r8 = products.Where(p => p.Id == 3).SingleOrDefault(); //Retorna null caso haja mais de um resultado na consulta
            var r8 = (from p in products
                      where p.Id == 3
                      select p).SingleOrDefault();
            Console.WriteLine($"Single or default test1: {r8}");

            //Single or default test2
            //var r9 = products.Where(p => p.Id == 30).SingleOrDefault(); //Retorna null caso haja mais de um resultado na consulta
            var r9 = (from p in products
                               where p.Id == 30
                               select p).SingleOrDefault();
            Console.WriteLine($"Single or default test2: {r9}");

            //Max
            var r10 = products.Max(p => p.Price);
            Console.WriteLine($"Max: {r10}");

            //Min
            var r11 = products.Min(p => p.Price);
            Console.WriteLine($"Min: {r11}");

            //Category 1 sum prices
            var r12 = products.Where(p => p.Category.Id == 1).Sum(p => p.Price);
            Console.WriteLine($"Category 1 sum prices: {r12}");

            //Category 1 average prices
            var r13 = products.Where(p => p.Category.Id == 1).Average(p => p.Price);
            Console.WriteLine($"Category 1 average prices: {r13}");

            //Category 5 average prices
            var r14 = products.Where(p => p.Category.Id == 5).Select(p => p.Price).DefaultIfEmpty(0).Average();
            Console.WriteLine($"Category 1 average prices: {r14}");

            //Category 1 aggregate sum
            var r15 = products.Where(p => p.Category.Id == 1).Select(p => p.Price).Aggregate((x, y) => x + y);
            Console.WriteLine($"Category 1 aggregate sum {r15}");

            //Category 5 aggregate sum
            var r15a = products.Where(p => p.Category.Id == 5).Select(p => p.Price).Aggregate(0.0, (x, y) => x + y);
            Console.WriteLine($"Category 5 aggregate sum {r15a} \n");

            //var r16 = products.GroupBy(p => p.Category);    //retorna um IGrouping<Chave, Coleção>
            var r16 = from p in products group p by p.Category;
            foreach (IGrouping<Category, Product> group in r16)
            {
                Console.WriteLine($"Category: {group.Key.Name}");
                foreach (Product p in group)
                {
                    Console.WriteLine(p);
                }
                Console.WriteLine();
            }

        }

        static void Print<T>(string message, IEnumerable<T> Collection) //função para facilitar a exibição dos resultados
        {
            Console.WriteLine(message);
            foreach (T item in Collection)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}
