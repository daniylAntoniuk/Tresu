using BLL.Interfaces;
using BLL.Models;
using BLL.Services;
using DAL.Entities;
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
using System.Windows.Shapes;

namespace Tresu
{
    /// <summary>
    /// Interaction logic for ForgotPassWindow2.xaml
    /// </summary>
    /// 
    public partial class ForgotPassWindow2 : Window
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
                Password=Encrypt(passwordbox.Password)

            });

            this.Close();
        }
    }
}
