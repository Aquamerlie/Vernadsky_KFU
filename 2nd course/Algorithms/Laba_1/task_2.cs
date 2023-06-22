using System;

namespace Simpson_Rynge
{
    class Program
    {
        static double Simpson(double a, double b, int N)
        {
            double f(double x) => Math.Sin(x);/*(x * x * x * x) * Math.Log10(x + Math.Sqrt((x * x) - 0.36));// функция*/

            double h = (b - a) / N;
            double sum = f(a) + f(b);
            double xi = a + h;
            double sum4 = 0;
            double sum2 = 0;
                
            while (xi < b)
            {
                sum4 += f(xi);
                xi += h * 2;
            }
            xi = a + h * 2;
            while (xi < b - h)
            {
                sum2 += f(xi);
                xi += h * 2;
            }

            sum = h / 3 * (sum + 4 * sum4 + 2 * sum2);

            return sum;
        }
        static void Main(string[] args)
        {
            double a, b, e;
            int N, N1;
            Console.Write("Введите a: ");
            a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите b: ");
            b = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите число разбиений: ");
            N = Convert.ToInt32(Console.ReadLine());// Число разбиений для 1 прохода
            N1 = N * 2;// Число разюиений для 2 прохода

            Console.WriteLine("");
            var result = Simpson(a, b, N);
            Console.WriteLine("Первый проход: " + result);

            var result_run = Simpson(a, b, N1);
            e = (result_run - result) / 15;
            Console.WriteLine("Погрешность по Рунге: " + e);

            result_run += e;
            Console.WriteLine("Второй проход: " + result_run);
 

        }
    }
}
