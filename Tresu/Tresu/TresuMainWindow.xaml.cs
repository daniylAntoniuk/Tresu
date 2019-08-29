using BLL.Interfaces;
using BLL.Services;
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
    /// Interaction logic for TresuMainWindow.xaml
    /// </summary>
    public partial class TresuMainWindow : Window
    {
        private readonly IUserService _userService;
        public TresuMainWindow(string email)
        {
            InitializeComponent();
            _userService = new UserService();
            txtLogin.Text= _userService.GetUsers().FirstOrDefault(
               u => u.Email == email)?.Login;
            txtBalance.Text = _userService.GetUsers().FirstOrDefault(
               u => u.Email == email)?.Balance.ToString()+" $";

        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }
        private void ItemMenu_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
