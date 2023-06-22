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

namespace Laba_2._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            string TextBox = inputTextBox.Text;
            bool result1 = double.TryParse(TextBox, out double numberDouble);

            if (result1)
            {
                if (numberDouble > 0)
                {
                    double squareRoot = Math.Sqrt(numberDouble);

                    frameWorkLabel.Content = string.Format("{0} (Using the .Net Framework)", squareRoot);

                }
                else
                {
                    MessageBox.Show("Please enter a positive number");
                }
            }
            else
            {
                MessageBox.Show("Please enter a double");
            }


            bool result2 = decimal.TryParse(TextBox, out decimal numberDecimal);

            if (result2)
            {
                decimal delta = Convert.ToDecimal(approach.Text);
                decimal quess = numberDecimal / 2;
                decimal result = ((numberDecimal / quess) + quess) / 2;



                while (Math.Abs(result - quess) >= delta)
                {
                    result = quess;
                    quess = ((numberDecimal / quess) + quess) / 2;
                }
                newtonLabel.Content =  quess;
            }
            return;
        }

        int i = 0;
        decimal quess ;
        decimal result;
        decimal delta;
        private void inputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            string TextBox = inputTextBox.Text;
            decimal.TryParse(TextBox, out decimal numberDecimal);
            
            if (e.Key == Key.Enter)
            {
                
                i++;
                iteration.Content = i;
                quess = numberDecimal / 2;
                result = ((numberDecimal / quess) + quess) / 2;

                for (int j = 0 ; i > j; j++) 
                {
                    result = quess;
                    quess = ((numberDecimal / quess) + quess) / 2;
                    sqrt.Content = result;
                }

                delta = result - Convert.ToDecimal( newtonLabel.Content);
                Delta.Content =  delta;
                
            }
            
        }
    }
}
