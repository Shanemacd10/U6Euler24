/* U6Euler24
 * Shane MacDonald
 * June 19 2018
 * Program takes in number of digits and term number then calculates the value for the term
 */
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


namespace U5Lexicographic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double remainder = 1000000;
        double y;
        double digits = 10;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            y = 1;
            remainder = Convert.ToDouble(txtInput.Text);
            digits = Convert.ToDouble(txtDigits.Text);
            factorial(Convert.ToInt32(digits));
            List<int> numbers = new List<int>();
            if (remainder > y || remainder <= 0)
            {
                MessageBox.Show("Term number must be between 1 and " + y.ToString());
            }
            else if( digits > 10)
            {
                MessageBox.Show("Number of digits must be between 1 - 10");
            }
            else
            {
                lbl.Content = "";
                for( int i = 0; i <= Convert.ToInt32(digits); i++)
                {
                    numbers.Add(i);
                }
                for (int i = Convert.ToInt32(digits -1); i >= 0; i--)
                {
                    y = 1;
                    factorial(i);
                    double r = remainder / y - 0.0000000000001;
                    remainder = Math.Round((r - Math.Floor(r)) * y);
                    int stupidface = Convert.ToInt32(Math.Floor(r));
                    lbl.Content += (numbers[stupidface]).ToString();
                    numbers.RemoveAt(stupidface);
                }
            }
        }
            public void factorial(int x)
            {
            for (int i = x; i > 0; i--)
            {
                y = y * i;
            }
            }
        }
    }
