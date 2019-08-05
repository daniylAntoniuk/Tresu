using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
        
        int Code;
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Register(object sender, RoutedEventArgs e)
        {
            try
            {
                
                if(PasswordBox.Password.Length<8)
                {
                    MessageBox.Show("Password must contains 8 symbols !");
                    return;
                }
                if(PasswordBox.Password!=RepeatPasswordBox.Password)
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
                    Password=PasswordBox.Password,
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
    }
}
