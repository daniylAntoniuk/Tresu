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
        public ForgotPassWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSubmit(object sender, RoutedEventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("tresu.suport@gmail.com");
                mail.To.Add(loginBox.Text);
                mail.Subject = "Tresu support";
                mail.Body = "Hello, you  sent us a message with changing your " +
                    "password, if you don`t sent this write our support. Your new password :";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("tresu.suport@gmail.com", "Tresu8834");
                SmtpServer.EnableSsl = true;
                //Tresu8834s&
                SmtpServer.Send(mail);
                MessageBox.Show("Mail Sent");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Mail wasn`t Send");
            }
        }
    }
}
