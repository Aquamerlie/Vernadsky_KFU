using System;

namespace Montekarlo
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, N;
            Console.Write("Введите a: ");
            a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите b: ");
            b = Convert.ToDouble(Console.ReadLine());
            Console.Write("Число разбиенний: ");
            N = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine(Montekarlo(a, b, N));

        }

        static double Montekarlo(double a, double b, double N)
        {
            double f(double x) => (x*x*x*x)*Math.Log(x+Math.Sqrt((x*x)-0.36));

            double total = 0;
            double yMax = 0;
            double x;
            double funct;

            int i = 0;
            do
            {
                x = RandomNumber(a, b);
                funct = Math.Abs(f(x));
                if (yMax > funct)
                {
                    total += funct;
                    i++;
                }
                else
                {
                    yMax = funct * 2;
                    i = 0;
                }
            } while (i < N);

            return (b - a) * total / N;
        }

        static double RandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}
