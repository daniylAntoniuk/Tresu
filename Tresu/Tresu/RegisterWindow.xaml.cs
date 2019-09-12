using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {


        public RegisterWindow()
        {
            InitializeComponent();
        }

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

        int Code;
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Register(object sender, RoutedEventArgs e)
        {
            try
            {
                
                if(passwordBox.Password.Length<8)
                {
                    MessageBox.Show("Password must contains 8 symbols !");
                    return;
                }
                if(passwordBox.Password!=RepeatPasswordBox.Password)
                {
                    MessageBox.Show("Repeated password don`t correct !");
                    return;
                }
                Random rand=new Random(); 
                Code = rand.Next(10000, 99999);
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("tresu.suport@gmail.com");
                mail.To.Add(EmailBox.Text);
                mail.Subject = "Tresu support";
                mail.Body = "Hello, you registering in the Tresu. " +
                    "Your code is : "+Code.ToString();

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("tresu.suport@gmail.com", "Tresu8834");
                SmtpServer.EnableSsl = true;
                //Tresu8834s&
                SmtpServer.Send(mail);
                //MessageBox.Show("Mail Sent");
                WindowRegister2 windowRegister2 = new WindowRegister2(Code,new BLL.Models.UserRegisterModel {
                    Email=EmailBox.Text,
                    Password= (Encrypt(passwordBox.Password)),
                    Login=LoginBox.Text
                });
                windowRegister2.ShowDialog();
                this.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Bad email !");
                MessageBox.Show(ex.Message);
            }
        }
        public static string Encrypt(string strData)
        {

            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(strData)));

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
    }
}
