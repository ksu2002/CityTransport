using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CityTransportWork
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
          //  string bdConnectionString = "Data Source=DESKTOP-H2QPSJ9\\SQLEXPRESS;Initial Catalog=CityTransport;User ID=guest;Password=123;";
         //   config.ConnectionStrings.ConnectionStrings["bdConnectionString"].ConnectionString = bdConnectionString;
          //  config.Save(ConfigurationSaveMode.Modified);
            Application.Run(new Auth());
        }
    }
}
