using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
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
    /// Логика взаимодействия для SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(comboBox.SelectedIndex==0)
            {
               
                    SetLang("en");
                
            }
            if(comboBox.SelectedIndex == 1)
            {
               
                    SetLang("uk");
                
            }
        }
        private void SetLang(string lang)
        {
            MessageBoxResult result = MessageBox.Show("It should restart application", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["setLang"].Value = lang;
                config.Save(ConfigurationSaveMode.Modified);

                Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            }
            else
                return;
        }
    }
}
