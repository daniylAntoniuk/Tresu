using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Tresu
{
    /// <summary>
    /// Interaction logic for CreditCardPage.xaml
    /// </summary>
    public partial class CreditCardPage : Page
    {
        public CreditCardPage()
        {
            InitializeComponent();
            creditChoose.SelectedIndex = 0;
        }

        private void CreditChoose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (creditChoose.SelectedIndex == 0)
            {
                donate.Visibility = Visibility.Hidden;
                LabelDonate.Visibility = Visibility.Hidden;
            }
            else
            {
                donate.Visibility = Visibility.Visible;
                LabelDonate.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string regex = "\\d{4}[\\s,\\S]\\d{4}[\\s,\\S]\\d{4}[\\s,\\S]\\d{4}";
            var match = Regex.Match(nomerCard.Text, regex, RegexOptions.IgnoreCase);

            if (creditChoose.SelectedIndex == 0)
            {

                    if (creditChoose.Text != "" && CVVCbox.Text.Length == 3 && month.Text != "" && year.Text != "")
                    {
                        if (match.Success)
                        {
                            MessageBox.Show("OK");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please fill all the fields");
                    }
                
            }
            else if (creditChoose.Text != "" && CVVCbox.Text.Length == 3 && month.Text != "" && year.Text != "" && donate.Text != "")
            {
                if (match.Success)
                {
                   MessageBox.Show("OK");
                }
            }
            else
            {
                MessageBox.Show("Please fill all the fields(Donate)");
            }
            
        }
    }
}
