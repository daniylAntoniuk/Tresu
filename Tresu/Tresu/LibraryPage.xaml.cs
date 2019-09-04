using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Tresu
{
    /// <summary>
    /// Interaction logic for LibraryPage.xaml
    /// </summary>
    public partial class LibraryPage : Page
    {
        string Name;
        public LibraryPage(string description,string name,BitmapImage photo)
        {
            InitializeComponent();
            txt.Text=description;
            img.Source = photo;
            Name = name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                //LibraryItem li = (LibraryItem)listView.SelectedItem;
                if (Name == "Tresu Game")
                    Process.Start(@"TresuGame\Tresu Game V1.1\Tresu Game.exe");
                else
                {
                    MessageBox.Show("You can`t start this game");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Select game");
            }
        }
    }
}
