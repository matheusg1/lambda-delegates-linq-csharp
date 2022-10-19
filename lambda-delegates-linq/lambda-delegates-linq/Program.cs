using System;
using lambda_delegates_linq.Services;

namespace lambda_delegates_linq
{
    delegate void BinaryNumericOperation(double n1, double n2); //type safety
    class Program
    {
        static void Main(string[] args)
        {
            double a = 10;
            double b = 12;
            
            BinaryNumericOperation op = CalculationService.ShowSum;
            op += CalculationService.ShowMax;

            op.Invoke(a, b);    //Chama as funções que foram atribuídas ao BNO, em ordem
        }
    }
}
