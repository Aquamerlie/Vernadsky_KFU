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

namespace Laba_4._3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int one;
        int two;
        int result;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                one = int.Parse(NumberOne.Text);              
                Result.IsEnabled = true;
            }
            catch
            {
                MessageBox.Show("Слишком большое первое число");
                Result.IsEnabled = false;
            }
            try
            {
                two = int.Parse(NumberTwo.Text);
                Result.IsEnabled = true;
            }
            catch
            {
                MessageBox.Show("Слишком большое второе число");
                Result.IsEnabled = false;
            }
            
            try
            {
                checked { result = one * two; }
                Check.IsChecked = false;
            }
            catch
            {
                result = one * two;
                Check.IsChecked = true;
            }
            Result.Text = result.ToString();
        }
    }
}
