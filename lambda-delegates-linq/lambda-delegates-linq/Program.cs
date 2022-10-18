using System;
using lambda_delegates_linq.Services;

namespace lambda_delegates_linq
{
    delegate double BinaryNumericOperation(double n1, double n2); //type safety
    class Program
    {
        static void Main(string[] args)
        {
            double a = 10;
            double b = 12;
            
            BinaryNumericOperation op = CalculationService.Sum;

            double result = op.Invoke(a, b);    //Chama a função que foi atribuída ao BNO
            //double result = CalculationService.Sum(a, b); Equivalente ao mostrado acima


            Console.WriteLine(result);

        }
    }
}
