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


namespace Laba_2._3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // Рандомное заполение
        private void But1_Click(object sender, RoutedEventArgs e)
        {
            int Col1 = Convert.ToInt32(Col_1.Text);
            int Row1 = Convert.ToInt32(Row_1.Text);
            double[,] matrix1 = new double[Col1, Row1];
            

            var random = new Random();

            for(int i = 0; i < Col1; i++)
            {
                for (int j = 0; j < Row1; j++)
                {
                    matrix1[i, j] = random.Next(100);
                }
            }
            Matrix.initializeGrid(ref Matrix1, matrix1);
            
        }

        private void But2_Click(object sender, RoutedEventArgs e)
        {
            int Col2 = Convert.ToInt32(Col_2.Text);
            int Row2 = Convert.ToInt32(Row_2.Text);
            double[,] matrix2 = new double[Col2, Row2];

            var random = new Random();

            for (int i = 0; i < Col2; i++)
            {
                for (int j = 0; j < Row2; j++)
                {
                    matrix2[i, j] = random.Next(100);
                }
            }
            Matrix.initializeGrid(ref Matrix2, matrix2);
            
            
        }

        // Перемножение матриц 
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            int Col1 = Convert.ToInt32(Col_1.Text);
            int Col2 = Convert.ToInt32(Col_2.Text);
            int Row1 = Convert.ToInt32(Row_1.Text);
            int Row2 = Convert.ToInt32(Row_2.Text);

            double[,] matrix1 = Matrix.getValuesFromGrid(Matrix1);
            double[,] matrix2 = Matrix.getValuesFromGrid(Matrix2);
            double[,] matrix3 = new double[Col2,Row1];

            try
            {
                for (int i = 0; i < matrix3.GetLength(1); i++)
                {
                    for (int j = 0; j < matrix3.GetLength(0); j++)
                    {
                        matrix3[i, j] = 0;
                        for (int k = 0; k < matrix1.GetLength(0); k++)
                        {
                            matrix3[i, j] += matrix1[k, j] * matrix2[i, k];

                            
                        }
                    }
                }
                Matrix.initializeGrid(ref Result, matrix3);
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }

        }

        // заполнение нулями
        private void Zero1_Click(object sender, RoutedEventArgs e)
        {
            int Col1 = Convert.ToInt32(Col_1.Text);
            int Row1 = Convert.ToInt32(Row_1.Text);
            double[,] matrix1 = new double[Row1, Col1];


            var random = new Random();

            for (int i = 0; i < Row1; i++)
            {
                for (int j = 0; j < Col1; j++)
                {
                    matrix1[i, j] = 0;
                }
            }
            Matrix.initializeGrid(ref Matrix1, matrix1);
        }

        private void Zero2_Click(object sender, RoutedEventArgs e)
        {
            int Col2 = Convert.ToInt32(Col_2.Text);
            int Row2 = Convert.ToInt32(Row_2.Text);
            double[,] matrix2 = new double[Row2, Col2];

            var random = new Random();

            for (int i = 0; i < Row2; i++)
            {
                for (int j = 0; j < Col2; j++)
                {
                    matrix2[i, j] = 0;
                }
            }
            Matrix.initializeGrid(ref Matrix2, matrix2);
        }
    }
}
