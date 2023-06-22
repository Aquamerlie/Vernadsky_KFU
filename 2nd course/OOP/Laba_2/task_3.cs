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
            int Row12 = Convert.ToInt32(ColRow.Text);
            double[,] matrix1 = new double[Row12, Col1];
            

            var random = new Random();

            for(int i = 0; i < Row12; i++)
            {
                for (int j = 0; j < Col1; j++)
                {
                    matrix1[i, j] = random.Next(100);
                }
            }
            Matrix.initializeGrid(ref Matrix1, matrix1);
            
        }

        private void But2_Click(object sender, RoutedEventArgs e)
        {
            int Col2 = Convert.ToInt32(Col_2.Text);
            int Row12 = Convert.ToInt32(ColRow.Text);
            double[,] matrix2 = new double[Row12, Col2];

            var random = new Random();

            for (int i = 0; i < Row12; i++)
            {
                for (int j = 0; j < Col2; j++)
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
            int Row12 = Convert.ToInt32(ColRow.Text);

            double[,] matrix1 = Matrix.getValuesFromGrid(Matrix1);
            double[,] matrix2 = Matrix.getValuesFromGrid(Matrix2);
            double[,] matrix3 = new double[Row12, Col2];

            for (int i = 0; i < Row12; i++)
            {
                for (int j = 0; j < Col2; j++)
                {
                    matrix3[i,j] = 0;
                    for (int k = 0; k < Col1; k++)
                    {
                        matrix3[i, j] += matrix1[i, k] * matrix2[i, k];
                        Matrix.initializeGrid(ref Result, matrix3);
                    }   
                }
            }
            

        }

        // заполнение нулями
        private void Zero1_Click(object sender, RoutedEventArgs e)
        {
            int Col1 = Convert.ToInt32(Col_1.Text);
            int Row12 = Convert.ToInt32(ColRow.Text);
            double[,] matrix1 = new double[Row12, Col1];


            var random = new Random();

            for (int i = 0; i < Row12; i++)
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
            int Row12 = Convert.ToInt32(ColRow.Text);
            double[,] matrix2 = new double[Row12, Col2];

            var random = new Random();

            for (int i = 0; i < Row12; i++)
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
