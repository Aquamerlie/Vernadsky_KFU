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
using System.Diagnostics;

namespace Laba_3._3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static int FindGCDEuclid(int a, int b, out long time)//метод Евклида
        {
            time = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            if (a == 0)
            {
                sw.Stop();
                time = sw.ElapsedTicks;
                return b;
            }
            while (b != 0)
            {
                if (a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }
            sw.Stop();
            time = sw.ElapsedTicks;
            return a;
        }
        static public int FindGCDStein(int u, int v, out long time)// метод Штейна
        {
            time = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int k;
            if (u == 0 || v == 0)
                return u | v;
            for (k = 0; ((u | v) & 1) == 0; ++k)
            {
                u >>= 1;
                v >>= 1;
            }
            while ((u & 1) == 0)
                u >>= 1;
            do
            {
                while ((v & 1) == 0)
                    v >>= 1;
                if (u < v)
                {
                    v -= u;
                }
                else
                {
                    int diff = u - v;
                    u = v;
                    v = diff;
                }
                v >>= 1;
            } while (v != 0);
            u <<= k;
            sw.Stop();
            time = sw.ElapsedTicks;
            return u;
        }
        public static int FindGCDEuclid(out long time, params int[] number)// перегузка метода Евклида
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int NOD = 0;
            for (int i = 0; i < number.Length; i++)
            {
                NOD = FindGCDEuclid(NOD, number[i], out time);
            }
            sw.Stop();
            time = sw.ElapsedTicks;
            return NOD;
        }
        public static int FindGCDStein(out long time, params int[] number)//перегрузка метода Штейна
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int NOD = 0;
            for (int i = 0; i < number.Length; i++)
            {
                NOD = FindGCDStein(NOD, number[i], out time);
            }
            sw.Stop();
            time = sw.ElapsedTicks;
            return NOD;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            long time;
            int [] number;
            try
            {
                number = numbers.Text.Split(' ')
                .Select(x => int.Parse(x)).ToArray();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка ввода нескольких параметров");
                return;
            }
            Res_Evclid.Content =  FindGCDEuclid(out time, number).ToString();
            Time_Evclid.Content = "Время: " + time.ToString();
            Res_Shtein.Content = FindGCDStein(out time, number).ToString();
            Time_Shtein.Content = "Время: " + time.ToString();
        }
    }
}
