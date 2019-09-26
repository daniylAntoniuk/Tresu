using BLL.Interfaces;
using BLL.Models;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
        public static class Global
        {
            // set password
            public const string strPassword = "LetMeIn99$";

            // set permutations
            public const String strPermutation = "ouiveyxaqtd";
            public const Int32 bytePermutation1 = 0x19;
            public const Int32 bytePermutation2 = 0x59;
            public const Int32 bytePermutation3 = 0x17;
            public const Int32 bytePermutation4 = 0x41;
        }
        public static string Encrypt(string strData)
        {

            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(strData)));
            // reference https://msdn.microsoft.com/en-us/library/ds4kkd55(v=vs.110).aspx

        }
        // encrypt
        public static byte[] Encrypt(byte[] strData)
        {
            PasswordDeriveBytes passbytes =
            new PasswordDeriveBytes(Global.strPermutation,
            new byte[] { Global.bytePermutation1,
                         Global.bytePermutation2,
                         Global.bytePermutation3,
                         Global.bytePermutation4
            });

            MemoryStream memstream = new MemoryStream();
            Aes aes = new AesManaged();
            aes.Key = passbytes.GetBytes(aes.KeySize / 8);
            aes.IV = passbytes.GetBytes(aes.BlockSize / 8);

            CryptoStream cryptostream = new CryptoStream(memstream,
            aes.CreateEncryptor(), CryptoStreamMode.Write);
            cryptostream.Write(strData, 0, strData.Length);
            cryptostream.Close();
            return memstream.ToArray();
        }
        private readonly IUserService _userService;
        public MainWindow()
        {
            InitializeComponent();
            _userService = new UserService();
           // Process.Start("http://www.google.com");
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
                Password = (Encrypt(passwordBox.Password))
            });
            if (result >0)
            {
                
                this.Visibility = Visibility.Hidden;
                TresuMainWindow window = new TresuMainWindow(loginBox.Text,result);
                window.ShowDialog();
                
                    this.Close();
               

            }
            else
            {
                int id=_userService.LoginTrue(new UserLoginModel()
                {
                    Email = loginBox.Text,
                    Password = (Encrypt(passwordBox.Password))
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
                    TresuMainWindow window = new TresuMainWindow(loginBox.Text,id);
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
