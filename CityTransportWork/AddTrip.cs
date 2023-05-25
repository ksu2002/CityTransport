using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
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
        public int update = 3;
     
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void getTransportType()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            try
            {
                number = Int32.Parse(routeNumber.SelectedItem.ToString());
                SqlCommand command = new SqlCommand("dbo.[getTransportTypeName]", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
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

        private void getRouteNumber() {
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
        private void getDrivers()
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
        private void getCars()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                SqlCommand command3 = new SqlCommand("dbo.getFreeCars", sqlConnection);
                command3.CommandType = CommandType.StoredProcedure;
                command3.Parameters.AddWithValue("@data", dtime);
                command3.Parameters.AddWithValue("@routeNumber", number);
                command3.Parameters.AddWithValue("@transportType", transportTypeName);
                command3.Parameters.AddWithValue("@routeName", direction);
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
        private void getCarAndDrivers()
        {
            if (number != -1 && transportTypeName != null && depTime != null && driverName != null && carName != null && direction != null && update == 1)
            {
                for (int i = 0; i < dir.Items.Count; i++)
                    if (dir.Items[i].ToString() == direction)
                        dir.SelectedIndex = i;
                dtime = dateTimePicker1.Value;
            
                getDrivers();

                for (int i = 0; i < driver.Items.Count; i++)
                    if (driver.Items[i].ToString() == driverName)
                        driver.SelectedIndex = i;
                car.Items.Clear();
                getCars();
                for (int i = 0; i < car.Items.Count; i++)
                    if (car.Items[i].ToString() == carName)
                        car.SelectedIndex = i;


            }
            else
            {

                car.SelectedItem = null;
                car.Items.Clear();
                driver.SelectedItem = null;
                driver.Items.Clear();
                dtime = dateTimePicker1.Value;
                if (number != -1 && transportTypeName != null && direction != null)
                {
                    getDrivers();
                    getCars();
                }
            }
        }
        private void getDirection()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                transportTypeName = transportType.SelectedIndex != -1 ? transportType.SelectedItem.ToString() : null;
                SqlCommand command = new SqlCommand("dbo.[getDir]", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@number", number);
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
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           getCarAndDrivers();

        }
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["bdConnectionString"].ConnectionString;


        private void AddTrip_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = " HH:mm:ss dd.MM.yyyy";
            dateTimePicker1.Value = new DateTime(year, month, day); // устанавливаем дату
            getRouteNumber();
            if (number != -1 && transportTypeName != null && depTime != null && driverName != null && carName != null && direction != null && update == 1)
            {
                    for (int i = 0; i < routeNumber.Items.Count; i++)
                    if (routeNumber.Items[i].ToString() == number.ToString())
                        routeNumber.SelectedIndex = i;
                    
            
    //        getTransportType();
            if (transportType.SelectedIndex != -1)
            {
                getDirection();

            }

            dateTimePicker1.Value = DateTime.ParseExact(depTime, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                update = 2;

            }
           
        }
        public int number = -1;
        public string transportTypeName;
        public string driverName;
        public string carName;
        public string direction;
        public string depTime; 


        private void routeNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            transportType.Items.Clear();
            getTransportType();
            if (number != -1 && transportTypeName != null && depTime != null && driverName != null && carName != null && direction != null)
            {
                for (int i = 0; i < transportType.Items.Count; i++)
                    if (transportType.Items[i].ToString() == transportTypeName)
                        transportType.SelectedIndex = i;
            }
            else
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                driver.SelectedItem = null;
                driver.Items.Clear();
                transportType.SelectedItem = null;
                transportType.Items.Clear();
                dir.SelectedItem = null;
                transportType.Items.Clear();
                dir.Items.Clear();
                getTransportType();
            }
            
        }

        private void transportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (number != -1 && transportTypeName != null && depTime != null && driverName != null && carName != null && direction != null && update==1)
            {
                for (int i = 0; i < dir.Items.Count; i++)
                    if (dir.Items[i].ToString() == direction)
                        dir.SelectedIndex = i;
            }
            else {
                car.SelectedItem = null;
            car.Items.Clear();
                if (transportType.SelectedIndex != -1)
                {
                    getDirection();

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

        private void insertTrip()
        {
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

                this.Close();
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            insertTrip();
        }

        private void dir_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            direction = dir.SelectedIndex != -1 ? dir.SelectedItem.ToString() : null;
            getCarAndDrivers();
        }

        private void AddTrip_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if(update == 2)
                    insertTrip();
            }
            if (e.CloseReason == CloseReason.ApplicationExitCall)
            {
                
            }
        }
    }
}
