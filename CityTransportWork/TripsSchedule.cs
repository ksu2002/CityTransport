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
      //  private string date = DateTime.Now.ToString();
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dtime = dateTimePicker1.Value;
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["bdConnectionString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                string query = ($"SELECT*FROM dbo.DaySchedule('{dtime}')");
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
        public int number = -1;
        public string transportTypeName = null;
        public string driverName = null;
        public string carName = null;
        public string direction = null;
        public DateTime dtime = DateTime.Now;
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            AddTrip addTrip = new AddTrip();
            addTrip.year = dateTimePicker1.Value.Year;
            addTrip.month = dateTimePicker1.Value.Month;
            addTrip.day = dateTimePicker1.Value.Day;
            addTrip.Show();

        }

        private void TripsSchedule_Load(object sender, EventArgs e)
        {
           // string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["bdConnectionString"].ConnectionString;
          //  SqlConnection sqlConnection = new SqlConnection(connectionString);
            if (number != -1 && transportTypeName != null && driverName != null && carName != null && direction != null)
            {

                try
                {
                    string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["bdConnectionString"].ConnectionString;
          
                    SqlConnection sqlConnection = new SqlConnection(connectionString);
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand("getRouteInfo", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter routeNumberParam = new SqlParameter("@routeNumber", SqlDbType.Int);
                    routeNumberParam.Value = number;
                    command.Parameters.Add(routeNumberParam);

                    SqlParameter transportTypeParam = new SqlParameter("@transportType", SqlDbType.VarChar, 10);
                    transportTypeParam.Value = transportTypeName;
                    command.Parameters.Add(transportTypeParam);

                    SqlParameter routeNameParam = new SqlParameter("@routeName", SqlDbType.VarChar, 51);
                    routeNameParam.Value = direction;
                    command.Parameters.Add(routeNameParam);

                    SqlParameter driverParam = new SqlParameter("@driver", SqlDbType.VarChar, 40);
                    driverParam.Value = driverName;
                    command.Parameters.Add(driverParam);

                    SqlParameter carParam = new SqlParameter("@car", SqlDbType.VarChar, 6);
                    carParam.Value = carName;
                    command.Parameters.Add(carParam);

                    SqlParameter routeIdParam = new SqlParameter("@routeid", SqlDbType.Int);
                    routeIdParam.Direction = ParameterDirection.Output;
                    command.Parameters.Add(routeIdParam);

                    SqlParameter driverIdParam = new SqlParameter("@driverid", SqlDbType.Int);
                    driverIdParam.Direction = ParameterDirection.Output;
                    command.Parameters.Add(driverIdParam);

                    SqlParameter transportIdParam = new SqlParameter("@transportid", SqlDbType.Int);
                    transportIdParam.Direction = ParameterDirection.Output;
                    command.Parameters.Add(transportIdParam);

                    command.ExecuteNonQuery();

                    int routeId = (int)routeIdParam.Value;
                    int driverId = (int)driverIdParam.Value;
                    int transportId = (int)transportIdParam.Value;



                    SqlCommand cmd = new SqlCommand("insertTrip", sqlConnection);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@depTime", dtime);
                    cmd.Parameters.AddWithValue("@routeid", routeId);
                    cmd.Parameters.AddWithValue("@driverid", driverId);
                    cmd.Parameters.AddWithValue("@carid", transportId);

                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;


                }
            }
            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["bdConnectionString"].ConnectionString;
         
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                dtime = DateTime.Now;
                string query = ($"SELECT*FROM dbo.DaySchedule('{dtime}')");
                SqlCommand command = new SqlCommand(query, sqlConnection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;

                // Создание объекта DataSet
                DataSet dataSet = new DataSet();

                // Заполнение DataSet
                dataAdapter.Fill(dataSet);


                // Привязка DataSet к DataGridView
                dataGridView1.DataSource = dataSet.Tables[0];

                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
