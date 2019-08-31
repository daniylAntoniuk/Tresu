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
using System.Windows.Shapes;

namespace Tresu
{
    /// <summary>
    /// Interaction logic for LockWindow.xaml
    /// </summary>
    public partial class LockWindow : Window
    {
        
        public LockWindow(string reason)
        {
            InitializeComponent();
            txt.Text = reason;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
