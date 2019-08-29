using BLL.Interfaces;
using BLL.Services;
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
    /// Interaction logic for ForgotPassWindow.xaml
    /// </summary>
    public partial class ForgotPassWindow : Window
    {
        private readonly IUserService _userService;
        public ForgotPassWindow()
        {
            InitializeComponent();
            _userService = new UserService();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        int Code;
        private void ButtonSubmit(object sender, RoutedEventArgs e)
        {
            try
            {
               
                
                Random rand = new Random();
                Code = rand.Next(10000, 99999);
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("tresu.suport@gmail.com");
                mail.To.Add(EmailBox.Text);
                mail.Subject = "Tresu support";
                mail.Body = "Hello, you're changing password. " +
                    "Your code is : " + Code.ToString();

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("tresu.suport@gmail.com", "Tresu8834");
                SmtpServer.EnableSsl = true;
                //Tresu8834s&
                SmtpServer.Send(mail);
                //MessageBox.Show("Mail Sent");
                ForgotPassWindow2 window = new ForgotPassWindow2(Code,EmailBox.Text);
                window.ShowDialog();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bad email !");
                MessageBox.Show(ex.Message);
            }
        }
    }
}
