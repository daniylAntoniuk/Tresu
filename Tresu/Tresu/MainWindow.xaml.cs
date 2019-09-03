﻿using BLL.Interfaces;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tresu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IUserService _userService;
        public MainWindow()
        {
            InitializeComponent();
            _userService = new UserService();
        }


        private void Forgot_Password(object sender, MouseButtonEventArgs e)
        {
            ForgotPassWindow window = new ForgotPassWindow();
            window.Show();
        }

        private void ButtonReg_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow window = new RegisterWindow();
            window.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonLog_Click(object sender, RoutedEventArgs e)
        {
            int result = _userService.Login(new UserLoginModel()
            {
                Email = loginBox.Text,
                Password = passwordBox.Password
            });
            if (result >0)
            {
                
                this.Visibility = Visibility.Hidden;
                TresuMainWindow window = new TresuMainWindow(loginBox.Text);
                window.ShowDialog();
                if (window.ShowDialog() == true)
                {
                    this.Visibility = Visibility.Visible;
                    
                }
                else
                {
                    this.Close();
                }

            }
            else
            {
                int id=_userService.LoginTrue(new UserLoginModel()
                {
                    Email = loginBox.Text,
                    Password = passwordBox.Password
                });
                if(id<=0)
                {
                    MessageBox.Show("Inccorect Email or Password !");
                    loginBox.BorderBrush = Brushes.Red;
                    passwordBox.BorderBrush = Brushes.Red;
                    passwordBox.Password = "";
                    return;
                }
                string check = _userService.GetLockReason(id);

                if (check == "date")
                {
                    //this.Visibility = Visibility.Hidden;
                    TresuMainWindow window = new TresuMainWindow(loginBox.Text);
                    window.ShowDialog();
                    //if (window.ShowDialog() == true)
                    //{
                    //    this.Visibility = Visibility.Visible;

                    //}
                    //else
                    //{
                    //    this.Close();
                    //}
                    return;
                }
                if (check != null)
                {

                   // MessageBox.Show($"Your account was banned! Reason : {_userService.GetLockReason(id)}, more info : bomzpyure.pp.ua, tresu.suport@gmail.com");
                    LockWindow window = new LockWindow($"Your account was banned! Reason : {check}, more info : bomzpyure.pp.ua, tresu.suport@gmail.com");
                    window.ShowDialog();
                }
                else if(check == null)
                {
                    MessageBox.Show("Inccorect Email or Password !");
                    loginBox.BorderBrush = Brushes.Red;
                    passwordBox.BorderBrush = Brushes.Red;
                }
               
                passwordBox.Password = "";
              
            }
        }
    }
}
