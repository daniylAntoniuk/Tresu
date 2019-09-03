using BLL.Interfaces;
using BLL.Services;
using DAL.Entities;
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
using Tresu.Models;

namespace Tresu
{
    /// <summary>
    /// Interaction logic for GameLibraryPage.xaml
    /// </summary>
    public partial class GameLibraryPage : Page
    {
       
        List<ViewItem> l = new List<ViewItem>();
        private readonly IUserService _userService;
        public GameLibraryPage()
        {
            InitializeComponent();

            _userService = new UserService();


            foreach (Users el in _userService.GetUsers())
            {
                ViewItem lvi = new ViewItem();
                lvi.PlayerName = el.Login;
                lvi.Id = el.Id;
                l.Add(lvi);
            }
            listView.ItemsSource = l;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var temp = _userService.GetUsers();
            l.Clear();
            listView.ItemsSource = null;
            //listView.Items.Clear();
            ViewItem lvi = new ViewItem();
            string s = _userService.GetUsers().FirstOrDefault(t => t.Login == txt.Text)?.Login;
            lvi.PlayerName = s;
            l.Add(lvi);
            listView.ItemsSource = l;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string v;
            v = listView.SelectedItems[0].ToString();
            var vie = listView.SelectedItem;
            ViewItem vi = (ViewItem)listView.SelectedItem;

            // vi = vie;
        }
    }
}
