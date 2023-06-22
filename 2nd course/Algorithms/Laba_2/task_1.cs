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

namespace SLAU
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
        public static double[] Metod_GaussJordan(double[,] matrixA, double[] vectorB)
        {
            // Копирование матрицы
            double[,] A_copy = new double[3, 3];
            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for (int j = 0; j < matrixA.GetLength(1); j++)
                {
                    A_copy[i, j] = matrixA[i, j];
                }
            }

            //Прямой ход
            for(int k = 0; k < matrixA.GetLength(0); k++)
            {
                //Нули на диагонали
                if (A_copy[k, k] == 0)
                {
                    int nul = k;
                    for (int i = k + 1; i< matrixA.GetLength(1); i++)
                    {
                        if (A_copy[i,k] != 0)
                        {
                            nul = i;
                            MessageBox.Show("Диагональ");
                            break;
                            
                        }
                    }
                    if (nul != k)
                    {
                        // Выбор рабочей точки
                        double[,] new_copy = new double[3, 3];
                        for (int i = 0; i < matrixA.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrixA.GetLength(1); j++)
                            {
                                new_copy[i, j] = matrixA[i, j];
                            }
                        }
                        for (int j = 0; j < matrixA.GetLength(1); j++)
                        {
                            new_copy[nul, j] = matrixA[k, j];
                            new_copy[k, j] = matrixA[nul, j];
                        }
                        double temp = vectorB[k];
                        vectorB[k] = vectorB[nul];
                        vectorB[nul] = temp;
                        for (int i = 0; i < matrixA.GetLength(0); i++)
                        {
                            for(int j = 0; j < matrixA.GetLength(1); j++)
                            {
                                A_copy[i, j] = new_copy[i, j];
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при выборе рабочей точки");
                    }

                }

                //Приведение к теругольному ввиду
                for (int i = 0; i < matrixA.GetLength(0); i++)
                {
                    matrixA[k, i] /= A_copy[k, k];
                }
                vectorB[k] /= A_copy[k, k];
                for (int i = k + 1; i < matrixA.GetLength(0); i++)
                {
                    double K = matrixA[i, k] / matrixA[k, k];
                    for (int j = 0; j < matrixA.GetLength(1); j++)
                    {
                        matrixA[i, j] -= matrixA[k, j] * K;
                    }
                    vectorB[i] -= vectorB[k] * K;
                }
                for (int i = 0; i < matrixA.GetLength(0); i++)
                {
                    for (int j = 0; j < matrixA.GetLength(1); j++)
                    {
                        A_copy[i, j] = matrixA[i, j];
                    }
                }
            }

            // Обратный ход
            for (int k = matrixA.GetLength(0) - 1; k > -1; k--)
            {
                for (int i = matrixA.GetLength(1) - 1; i > -1; i--)
                {
                    matrixA[k, i] /= A_copy[k, k];
                }
                vectorB[k] /= A_copy[k, k];
                for (int i = k - 1; i > -1; i--)
                {
                    double K = matrixA[i, k] / matrixA[k, k];
                    for (int j = matrixA.GetLength(1) - 1; j > -1; j--)
                    {
                        matrixA[i, j] -= matrixA[k, j] * K;
                    }
                    vectorB[i] -= vectorB[k] * K;
                }
            }

            return vectorB;

        }

        public static double[] Metod_Iteration(double[,] matrixA, double[] vectorB)
        {
            double[] X = new double[3];
            double[,] C = new double[3, 3];
            double[] F = new double[3];


            //Приведение к виду
            for (int i = 0; i < C.GetLength(0); i++)
            {
                for (int j = 0; j < C.GetLength(1); j++)
                {
                    if (j != i)
                    {
                        C[i, j] = -(matrixA[i, j] / matrixA[i, i]);
                    }
                    else
                    {
                        C[i, j] = 0;
                    }
                }
                F[i] = vectorB[i] / matrixA[i, i];
            }
            //Интегрирование
            int n = 0;
            while (n < 100)
            {
                for (int i = 0; i < C.GetLength(0); i++)
                {
                    double x = 0;
                    for (int j = 0; j < C.GetLength(1); j++)
                    {
                        x += C[i, j] * X[j];
                    }
                    x += F[i];
                    X[i] = x;
                }
                n++;
            }

            //Проверка сходимости
            for (int i = 0; i < C.GetLength(0); i++)
            {               
                double E = 0;
                for (int j = 0; j < C.GetLength(1); j++)
                {
                    if (i == j) continue;
                    E += Math.Abs(C[i, j]);
                }
                if (!(E < 1))
                {
                    MessageBox.Show("Условие сходимсти");
                    break;
                }

                if (matrixA[i, i] == 0)
                {
                    MessageBox.Show("Недопустимые нули на диагонали");
                    break;
                }
            }
            return X;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double[,] matrixA = new double[3, 3];
            double[] vectorB = new double[3];

            matrixA[0, 0] = Convert.ToDouble(a1_1.Text); matrixA[0, 1] = Convert.ToDouble(a1_2.Text); matrixA[0, 2] = Convert.ToDouble(a1_3.Text); vectorB[0] = Convert.ToDouble(b_1.Text);
            matrixA[1, 0] = Convert.ToDouble(a2_1.Text); matrixA[1, 1] = Convert.ToDouble(a2_2.Text); matrixA[1, 2] = Convert.ToDouble(a2_3.Text); vectorB[1] = Convert.ToDouble(b_2.Text);
            matrixA[2, 0] = Convert.ToDouble(a3_1.Text); matrixA[2, 1] = Convert.ToDouble(a3_2.Text); matrixA[2, 2] = Convert.ToDouble(a3_3.Text); vectorB[2] = Convert.ToDouble(b_3.Text);


            double[] vectorX = Metod_GaussJordan(matrixA, vectorB);

            o_1.Content = vectorX[0].ToString();
            o_2.Content = vectorX[1].ToString();
            o_3.Content = vectorX[2].ToString();
        }

        private void but_iter_Click(object sender, RoutedEventArgs e)
        {
            double[,] matrixA = new double[3, 3];
            double[] vectorB = new double[3];

            matrixA[0, 0] = Convert.ToDouble(a1_1.Text); matrixA[0, 1] = Convert.ToDouble(a1_2.Text); matrixA[0, 2] = Convert.ToDouble(a1_3.Text); vectorB[0] = Convert.ToDouble(b_1.Text);
            matrixA[1, 0] = Convert.ToDouble(a2_1.Text); matrixA[1, 1] = Convert.ToDouble(a2_2.Text); matrixA[1, 2] = Convert.ToDouble(a2_3.Text); vectorB[1] = Convert.ToDouble(b_2.Text);
            matrixA[2, 0] = Convert.ToDouble(a3_1.Text); matrixA[2, 1] = Convert.ToDouble(a3_2.Text); matrixA[2, 2] = Convert.ToDouble(a3_3.Text); vectorB[2] = Convert.ToDouble(b_3.Text);


            double[] vectorX = Metod_Iteration(matrixA, vectorB);

            o_1.Content = vectorX[0].ToString();
            o_2.Content = vectorX[1].ToString();
            o_3.Content = vectorX[2].ToString();
        }
    }

}
