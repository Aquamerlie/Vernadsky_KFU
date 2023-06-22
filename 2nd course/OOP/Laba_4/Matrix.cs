using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;


namespace Laba_2._3
{
    class Matrix
    {
        
        public static void initializeGrid(ref Grid grid, double[,] matrix)
        {
            if (grid != null)
            {
                
                grid.Children.Clear();
                grid.ColumnDefinitions.Clear();
                grid.RowDefinitions.Clear();
                int colums = matrix.GetLength(0);
                int rows = matrix.GetLength(1);


                for (int x = 0; x < colums; x++)
                {
                    grid.ColumnDefinitions.Add(new ColumnDefinition() { });
                }
                for (int y = 0; y < rows; y++)
                {
                    grid.RowDefinitions.Add(new RowDefinition() { });
                }
                for (int x = 0; x < colums; x++)
                {
                    for (int y = 0; y < rows; y++)
                    {
                        double cell = (double)matrix[x, y];
                        TextBox t = new TextBox();
                        t.Text = cell.ToString();
                        t.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                        t.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                        t.SetValue(Grid.RowProperty, y);
                        t.SetValue(Grid.ColumnProperty, x);
                        t.MinWidth = 40;
                        t.MinHeight = 20;
                        t.Height = 20;
                        t.Width = 40;
                        t.TextAlignment = TextAlignment.Center;
                     
                        t.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(255,255,255));



                        grid.Children.Add(t);
                        
                    }

                }
                
            }
        }
        public static double[,] getValuesFromGrid(Grid grid)
        {
            int columns = grid.ColumnDefinitions.Count;
            int rows = grid.RowDefinitions.Count;
            double[,] matrix = new double[columns, rows];
            for (int c = 0; c < grid.Children.Count; c++)
            {
                TextBox t = (TextBox)grid.Children[c];
                int row = Grid.GetRow(t);
                int column = Grid.GetColumn(t);
                matrix[column, row] = double.Parse(t.Text);

            }
            return matrix;
        }
    }
}
