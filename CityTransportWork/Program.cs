using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CityTransportWork
{
    internal static class Program
    {
        public static SqlConnectionStringBuilder bld = new SqlConnectionStringBuilder();
        public static int user_ID;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            Application.Run(new Auth());
        }
    }
}
