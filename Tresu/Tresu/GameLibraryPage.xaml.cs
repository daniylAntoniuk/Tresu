using BLL.Interfaces;
using BLL.Services;
using DAL.Entities;
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
using Tresu.Models;

namespace Tresu
{
    /// <summary>
    /// Interaction logic for GameLibraryPage.xaml
    /// </summary>
    public partial class GameLibraryPage : Page
    {
       
        List<LibraryItem> l = new List<LibraryItem>();
        private readonly IUserService _userService;
        int Id;
        public GameLibraryPage(int id)
        {
            InitializeComponent();
            Id = id;
            _userService = new UserService();

            List<int> GameId = new List<int>();
            foreach (UserGames el in _userService.GetUserGames(id))
            {
                GameId.Add(el.GameId);
            }

            foreach (int el in GameId)
            {
                var temp = _userService.GetGames(el);
                LibraryItem lvi = new LibraryItem();
                lvi.Name = temp.Name ;
                lvi.Icon = new BitmapImage(new Uri(Environment.CurrentDirectory+@"/../../Images/" + temp.Photo ));
                lvi.Description = temp.Description;
                l.Add(lvi);
            }

            listView.ItemsSource = l;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ////var temp = _userService.GetUsers();
            //l.Clear();
            //listView.ItemsSource = null;
            ////listView.Items.Clear();
            //ViewItem lvi = new ViewItem();
            //string s = _userService.GetUserGames(id).FirstOrDefault(t => t.Login == txt.Text)?.Login;
            //lvi.PlayerName = s;
            ////l.Add(lvi);
            //listView.ItemsSource = l;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
           
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LibraryItem li = (LibraryItem)listView.SelectedItem;
            LibraryPage page = new LibraryPage(li.Description,li.Name,li.Icon);
            frame.Content = page;
        }
    }
}
