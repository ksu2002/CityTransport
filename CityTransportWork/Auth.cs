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

namespace CityTransportWork
{
    public partial class Auth : Form
    {
        private SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-H2QPSJ9\\SQLEXPRESS",
            InitialCatalog = "CityTransport",
            PersistSecurityInfo = false,
            TrustServerCertificate = true,
        };

        public Auth()
        {
            InitializeComponent();
        }

        private void Auth_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private int user_ID;
        private void authButton_Click(object sender, EventArgs e)
        {
            sqlConnectionStringBuilder.UserID = "guest";
            sqlConnectionStringBuilder.Password = "123";

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
     
            try
            {
                SqlCommand sqlCommand = new SqlCommand($"dbo.[auth] {loginBox.Text},{passwordBox.Text}", sqlConnection);
                sqlConnection.Open();
                SqlDataReader auth = sqlCommand.ExecuteReader();
                if (auth.Read())
                {
                    sqlConnectionStringBuilder.UserID = auth.GetValue(0).ToString();
                    sqlConnectionStringBuilder.Password = auth.GetValue(1).ToString();
                    user_ID = Int32.Parse(auth.GetValue(2).ToString());
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
            finally
            {
                sqlConnection.Close();
            }
            if(sqlConnectionStringBuilder.UserID == "driver")
            {
                DriverForm driverForm = new DriverForm();
                driverForm.user_ID= user_ID;
                driverForm.Show();
              //  this.Close();
            }
            if (sqlConnectionStringBuilder.UserID == "passenger")
            {
                statusAuth.Text = "passenger";
            }
            if (sqlConnectionStringBuilder.UserID == "scheduler")
            {
                statusAuth.Text = "scheduler";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void statusAuth_Click(object sender, EventArgs e)
        {

        }
    }
}
