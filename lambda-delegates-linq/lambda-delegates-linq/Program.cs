using System;
using System.Linq;

namespace lambda_delegates_linq
{
    class Program
    {
        static void Main(string[] args)
        {
            //Data source
            int[] numbers = new int[] { 2, 3, 4, 5 };

            //Definir a query
            var result = numbers.Where(x => x % 2 == 0).Select(x=> x *= 10); //IEnumerable, caso necessário usar .ToList()

            /*
             var result = numbers
                .Where(x => x % 2 == 0)
                .Select(x => x *= 10); //outra forma de organizar
            */

            //Executa a query
            foreach (int item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
