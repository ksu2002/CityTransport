using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace CityTransportWork
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }
        string connectionString;
        private void Auth_Load(object sender, EventArgs e)
        {
         
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //private int user_ID;
       // private string role_name = "guest";
        //private string role_password = "guest";

        private void authButton_Click(object sender, EventArgs e)
        {
            /*  connectionString = "Data Source=DESKTOP-H2QPSJ9\\SQLEXPRESS;Initial Catalog=CityTransport;User ID=guest;Password=123;";
             string configPath = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath;
             var configMap = new ExeConfigurationFileMap { ExeConfigFilename = configPath };
             var config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
             config.ConnectionStrings.ConnectionStrings["bdConnectionString"].ConnectionString = connectionString;
             config.Save(ConfigurationSaveMode.Modified);
             ConfigurationManager.RefreshSection("connectionStrings");

             connectionString = ConfigurationManager.ConnectionStrings["bdConnectionString"].ConnectionString;
             SqlConnection sqlConnection = new SqlConnection(connectionString);*/
            Program.bld.ConnectionString = Properties.Settings.Default.CityTransportConnectionString;
            Program.bld.UserID = "guest";
            Program.bld.Password = "guest";
            SqlConnection sqlConnection = new SqlConnection(Program.bld.ConnectionString);
            try
            {
                SqlCommand sqlCommand = new SqlCommand($"dbo.[auth] {loginBox.Text},{passwordBox.Text}", sqlConnection);
                sqlConnection.Open();
                SqlDataReader auth = sqlCommand.ExecuteReader();
                if (auth.Read())
                {
                 Program.bld.UserID = auth.GetValue(0).ToString();
                 Program.bld.Password= auth.GetValue(1).ToString();
                 Program.user_ID = Int32.Parse(auth.GetValue(2).ToString());
                 statusAuth.Text = "Подключение успешно";
                     }
                else
                {
                    statusAuth.Text = "Неверен логин или пароль";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
          /*  finally
            {
                connectionString = connectionString.Replace(";User ID=guest;Password=123", $";User ID={role_name};Password={role_password}");
                 configPath = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath;
                configMap = new ExeConfigurationFileMap { ExeConfigFilename = configPath };
                 config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
                config.ConnectionStrings.ConnectionStrings["bdConnectionString"].ConnectionString = connectionString;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");
                sqlConnection.Close();
            }
               */ 

            if (Program.bld.UserID == "driver")
            {
                DriverForm driverForm = new DriverForm();
                driverForm.user_ID= Program.user_ID;
                driverForm.Show();

            }
            if (Program.bld.UserID == "passenger")
            {
                PassengerForm passengerForm = new PassengerForm();
                passengerForm.Show();
            }
            if (Program.bld.UserID == "scheduler")
            {
                SchedulerForm schedulerForm = new SchedulerForm();
                schedulerForm.Show();
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void statusAuth_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
