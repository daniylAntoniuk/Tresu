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
    /// Interaction logic for WindowRegister2.xaml
    /// </summary>
    public partial class WindowRegister2 : Window
    {
        int Code; 
            UserRegisterModel User;
        private readonly IUserService _userService;
        public WindowRegister2(int code,UserRegisterModel user)
        {
            Code = code;
            User = user;
            InitializeComponent();
            _userService = new UserService();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(CodeEmailBox.Text!=Code.ToString())
            {
                MessageBox.Show("Code is not correct !");
                return;
            }
            _userService.Register(User);
            this.Close();
        }
    }
}
