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
    public partial class TripsSchedule : Form
    {
        public TripsSchedule()
        {
            InitializeComponent();
        }
        private string date = DateTime.Now.ToString();
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
              date = dateTimePicker1.Value.ToString();
              string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["bdConnectionString"].ConnectionString;
              SqlConnection sqlConnection = new SqlConnection(connectionString);

              try
              {
                  string query = ($"SELECT*FROM dbo.DaySchedule('{date}')");
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

        private void button1_Click(object sender, EventArgs e)
        {
            AddTrip addTrip = new AddTrip();
            addTrip.year = dateTimePicker1.Value.Year;
            addTrip.month = dateTimePicker1.Value.Month;
            addTrip.day = dateTimePicker1.Value.Day;
            addTrip.Show();
        }

        private void TripsSchedule_Load(object sender, EventArgs e)
        {

        }
    }
}
