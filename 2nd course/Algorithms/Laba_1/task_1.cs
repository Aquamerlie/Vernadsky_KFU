using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Laba_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        static double Simpson(double a, double b, double N)
        {
            double f(double x) =>/* Math.Sin(x)*/Math.Abs((x * x * x * x) * Math.Log(x + Math.Sqrt((x * x) - 0.36)));

            double h = (b - a) / N;
            double sum = f(a) + f(b);
            int k;
            for (int i = 1; i <= N - 1; i++)
            {
                k = 2 + 2 * (i % 2); // если нечетное -> 4, четное -> 2
                sum += k * f(a + i * h);
            }
            sum *= h / 3;

            return sum;
        }
        static double MonteKarlo(double a, double b, double N)
        {
            double f(double x) =>/* Math.Sin(x)*/Math.Abs((x * x * x * x) * Math.Log(x + Math.Sqrt((x * x) - 0.36)));

            Random random = new Random();

            double Y, F;
            double counter = 0;

            double X = random.NextDouble() * (b * a) + a;
            double max_heigth = f(X) * 2 - b * a;

            for (int i = 0; i < N; i++)
            {
                X = random.NextDouble() * (b - a) + a;
                Y = random.NextDouble() * max_heigth;
                F = f(X);

                if (F > Y)
                {
                    counter++;
                }

            }
            double area = max_heigth * (b - a);
            double hits = counter / N;

            return area * hits;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double A = double.Parse(a.Text);
            double B = double.Parse(b.Text);
            double N = double.Parse(Text_N.Text);

            result_Simpson.Content = Simpson(A, B, N);


            double N1 = N * 2;
            double f1 = Simpson(A, B, N);
            double f2 = Simpson(A, B, N1);

            double de = (f2 - f1) / 15;
            f1 += de;
            dE.Content = de;
            result_SimpsonRunge.Content = f1;
        }

        private void button_Montekarlo_Click(object sender, RoutedEventArgs e)
        {
            double A1 = double.Parse(a1.Text);
            double B1 = double.Parse(b1.Text);
            double n = double.Parse(Text_n.Text);
            double k = 0;
            double res_1 = MonteKarlo(A1, B1, n); ;


            for (int i = 0; i < n; i++)
            {
                k += res_1;
            }
            double res_2 = k / n;

            double res = Simpson(A1, B1, n);
            result_MonteKarlo.Content = res + (res_1 / n) / 10; ;
        }
    }
}
