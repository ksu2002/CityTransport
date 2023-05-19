using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
        public DriverSchedule()
        {
            InitializeComponent();
        } 
        public int user_ID;

        private void DriverSchedule_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["bdConnectionString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private string date = DateTime.Now.ToString();
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        { 
            date = dateTimePicker.Value.ToString();
            string connectionString = ConfigurationManager.ConnectionStrings["bdConnectionString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
        
            try
            {
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
