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
            logotip.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            logotip.Visibility = Visibility.Hidden;
        }
        private void ItemMenu_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        //Shop
        private void StackPanelShop_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        //Trade
        private void StackPanelTrade_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        //Friends
        private void StackPanelFriends_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            AddFriendPage add = new AddFriendPage();
            frame.Content = add;
           
        }

        //Wed Site
        private void StackPanelSite_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Website page1 = new Website();
            // grid.Conten = page1;
            frame.Content = page1;
            //this.Content = page1;
        }

        //Credit Catd
        private void StackPanelCredit_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        //Exit
        private void StackPanel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
