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

namespace Laba_2._2_IntegerToBinary
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
        StringBuilder binary = new StringBuilder();
        private void convertButton_Click(object sender, RoutedEventArgs e)
        {
            string content = inputTextBox.Text;
            bool error = int.TryParse(content, out int i);

            if (error)
            {
                if (i >= 0)
                {
                    int remainder = 0;
                  
                    do
                    {

                        remainder = i % 2;
                        i = i / 2;

                        binary.Insert(0, remainder);
                        binaryLabel.Content = binary.ToString();
                    }
                    while (i > 0);
                    return;
                }
                else
                {
                    MessageBox.Show("Please enter a positive number or zero");
                }
            }
            else
            {
                MessageBox.Show("TextBox does not contain an integer");
            }
        }
    }
}
