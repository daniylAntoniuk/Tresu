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
    /// Interaction logic for AddFriendPage.xaml
    /// </summary>
    public partial class AddFriendPage : Page
    {
        private readonly IUserService _userService;
        public AddFriendPage()
        {
            InitializeComponent();

            _userService = new UserService();
            List<ViewItem> l = new List<ViewItem>();
            foreach(Users el in  _userService.GetUsers())
            {
                ViewItem lvi = new ViewItem();
                lvi.PlayerName = el.Login;
                l.Add(lvi);
            }
            listView.ItemsSource = l;
        }
    }
}
