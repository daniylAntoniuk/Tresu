using BLL.Interfaces;
using BLL.Models;
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
using System.Windows.Shapes;

namespace Tresu
{
    /// <summary>
    /// Interaction logic for ForgotPassWindow2.xaml
    /// </summary>
    public partial class ForgotPassWindow2 : Window
    {
        int Code;
        string email;
        private readonly IUserService _userService;
        public ForgotPassWindow2(int code, string Email)
        {
            Code = code;
            email = Email;
            InitializeComponent();
            _userService = new UserService();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CodeEmailBox.Text != Code.ToString())
            {
                MessageBox.Show("Code is not correct !");
                return;
            }
            if (passwordbox.Password.Length < 8)
            {
                MessageBox.Show("Password must contains 8 symbols !");
                return;
            }
            int id = _userService.GetUsers().FirstOrDefault(
               u => u.Email == email)?.Id ?? -1;
            string login = _userService.GetUsers().FirstOrDefault(
               u => u.Email == email)?.Login;
            _userService.ForgotPassword(id,new UserRegisterModel {
                Email=email,
                Login=login,
                Password=passwordbox.Password

            });

            this.Close();
        }
    }
}
