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

namespace Tresu
{
    /// <summary>
    /// Логика взаимодействия для StorePage.xaml
    /// </summary>
    public partial class StorePage : Page
    {
        int id;
        private readonly IUserService _userService;
        List<StoreViewItem> l = new List<StoreViewItem>();
        public StorePage(int Id)
        {
            id = Id;
            InitializeComponent();
            _userService = new UserService();


            foreach (Games el in _userService.GetGames())
            {
                StoreViewItem lvi = new StoreViewItem();
                lvi.Name = el.Name;
                lvi.Description = el.Description;
                lvi.Photo = Environment.CurrentDirectory + @"/../../Images/" + el.Photo;
                l.Add(lvi);
            }
            listView.ItemsSource = l;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
