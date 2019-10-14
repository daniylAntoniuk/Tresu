using BLL.Interfaces;
using BLL.Models;
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
        int Id;
        string emailHelp;
        private readonly IUserService _userService;
        public TresuMainWindow()
        {
            string email = "danik22122005@gmail.com";
            InitializeComponent();
            _userService = new UserService();

            UserModel model= _userService.FindByEmail(email);
            txtLogin.Text = model.Login;
            txtBalance.Text = model.Balance.ToString();
        }
        public TresuMainWindow(string email,int id)
        {
           // email = "danik22122005@gmail.com";
            InitializeComponent();
            emailHelp = email;
            _userService = new UserService();
            Id = id;
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
            Metod();
            StorePage page = new StorePage(Id);
            frame.Content = page;
        }

        //Trade
        private void StackPanelTrade_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Metod();
            GameLibraryPage page = new GameLibraryPage(Id);
            frame.Content = page;
        }

        //Friends
        private void StackPanelFriends_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Metod();
            AddFriendPage add = new AddFriendPage();
            frame.Content = add;
        }

        //Wed Site
        private void StackPanelSite_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Metod();
            Website page1 = new Website();
            // grid.Conten = page1;
            frame.Content = page1;
            //this.Content = page1;
        }

        //Credit Catd
        private void StackPanelCredit_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Metod();
            CreditCardPage page = new CreditCardPage(Id);
            frame.Content = page;
            
        }

        //Exit
        private void StackPanel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void StackPanelFB_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Metod();
            FeedbackPage page = new FeedbackPage();
            frame.Content = page;
        }

        private void StackPanel_SettingsPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Metod();
            SettingsPage page = new SettingsPage();
            frame.Content = page;
        }
        private void Metod()
        {
            IUserService _userServiceMy = new UserService();
            UserModel model = _userServiceMy.FindByEmail(emailHelp);
            txtBalance.Text = model.Balance.ToString();
        }
    }
}
