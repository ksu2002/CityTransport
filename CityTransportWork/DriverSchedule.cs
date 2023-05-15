using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CityTransportWork
{
    public partial class DriverSchedule : Form
    {

        private SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-H2QPSJ9\\SQLEXPRESS",
            InitialCatalog = "CityTransport",
            PersistSecurityInfo = false,
            TrustServerCertificate = true,
        };
       
        public DriverSchedule()
        {
            InitializeComponent();
        } 
        public int user_ID;

        private void DriverSchedule_Load(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private string date = DateTime.Now.ToString();
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        { 
            date = dateTimePicker.Value.ToString();
            sqlConnectionStringBuilder.UserID = "guest";
            sqlConnectionStringBuilder.Password = "123";
  
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
        
            try
            {
                int driver_ID = 1;
                //string data = "2023-01-01";
                string query = ($"SELECT*FROM dbo.TripsForDriverPerDay({user_ID}, '{date}')");
                SqlCommand command = new SqlCommand(query, sqlConnection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;

                // Создание объекта DataSet
                DataSet dataSet = new DataSet();

                // Открытие соединения с базой данных
                sqlConnection.Open();

                // Заполнение DataSet
                dataAdapter.Fill(dataSet);

                // Закрытие соединения с базой данных
                sqlConnection.Close();

                // Привязка DataSet к DataGridView
                dataGridView1.DataSource = dataSet.Tables[0];

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }
        
    }
}
