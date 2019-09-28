using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Tresu
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var lang = ConfigurationManager.AppSettings["setLang"];
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
        }
    }
}
