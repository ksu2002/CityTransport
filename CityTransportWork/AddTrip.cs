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
    public partial class AddTrip : Form
    {
        public AddTrip()
        {
            InitializeComponent();
        }
        public int year;
        public int month;
        public int day;
        private DateTime dtime;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            driver.SelectedItem = null;
            driver.Items.Clear();
            dtime = dateTimePicker1.Value;
            if (number != -1 && transportTypeName != null && direction != null)
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                try
                {
                    SqlCommand command1 = new SqlCommand("getFreeDrivers", sqlConnection);
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.Parameters.AddWithValue("@data", dtime);
                    command1.Parameters.AddWithValue("@routeNumber", number);
                    command1.Parameters.AddWithValue("@transportType", transportTypeName);
                    command1.Parameters.AddWithValue("@routeName", direction);
                    command1.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader1 = command1.ExecuteReader();

                    while (reader1.Read())
                    {
                        driver.Items.Add(reader1["FIO"].ToString());
                    }
                    reader1.Close();

                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
           
        }
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["bdConnectionString"].ConnectionString;


        private void AddTrip_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = new DateTime(year, month, day); // устанавливаем дату
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            try
            {

                SqlCommand command1 = new SqlCommand("dbo.[getRouteNumber]", sqlConnection);
                command1.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader1 = command1.ExecuteReader();

                while (reader1.Read())
                {
                    routeNumber.Items.Add(reader1["RouteNumber"].ToString());
                }
                reader1.Close();

                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }
        private int number = -1;
        private string transportTypeName;
        private string driverName;
        private string carName;
        private string direction;

        private void routeNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            try
            {
                driver.SelectedItem = null;
                driver.Items.Clear();
                transportType.SelectedItem = null;
                dir.SelectedItem = null;
                transportType.Items.Clear();
                dir.Items.Clear();
                number = Int32.Parse(routeNumber.SelectedItem.ToString());

                SqlCommand command = new SqlCommand("dbo.[getTransportTypeName]", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;

                // Добавляем параметр @number
                command.Parameters.AddWithValue("@number", number);

                SqlDataReader reader1 = command.ExecuteReader();

                while (reader1.Read())
                {
                    transportType.Items.Add(reader1["TransportTypeName"].ToString());
                }
                reader1.Close();

                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        private void transportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            car.SelectedItem = null;
            car.Items.Clear();
            if (transportType.SelectedIndex != -1)
            {
                try
                {
                    sqlConnection.Open();
                    // (stop1.SelectedIndex != -1
                    transportTypeName = transportType.SelectedIndex != -1 ? transportType.SelectedItem.ToString() : null;

                    SqlCommand command = new SqlCommand("dbo.[getDir]", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Добавляем параметр @number
                    command.Parameters.AddWithValue("@number", number);

                    // Добавляем параметр @type
                    command.Parameters.AddWithValue("@type", transportTypeName);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        dir.Items.Add(reader["RouteName"].ToString());
                    }
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                try
                {
                    sqlConnection.Open();
                    SqlCommand command3 = new SqlCommand("dbo.[getCar]", sqlConnection);
                command3.CommandType = CommandType.StoredProcedure;
                command3.Parameters.AddWithValue("@type", transportTypeName);

                SqlDataReader reader3 = command3.ExecuteReader();

                while (reader3.Read())
                {
                    car.Items.Add(reader3["TransportNumber"].ToString());
                }
                reader3.Close();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

            }
        }

        private void driver_SelectedIndexChanged(object sender, EventArgs e)
        {
            driverName= driver.SelectedIndex != -1 ? driver.SelectedItem.ToString() : null;
        }

        private void car_SelectedIndexChanged(object sender, EventArgs e)
        {
            carName= car.SelectedIndex != -1 ? car.SelectedItem.ToString() : null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (number != -1 && transportTypeName != null && driverName != null && carName != null && direction != null)
            {
                this.Close();
                SchedulerForm schedulerForm = new SchedulerForm();
                schedulerForm.number = number;
                schedulerForm.transportTypeName = transportTypeName;
                schedulerForm.dtime = dtime;
                schedulerForm.driverName = driverName;
                schedulerForm.carName = carName;
                schedulerForm.direction = direction;
                schedulerForm.Show();
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }

        private void dir_SelectedIndexChanged(object sender, EventArgs e)
        {

            direction = dir.SelectedIndex != -1 ? dir.SelectedItem.ToString() : null;
        }
    }
}
