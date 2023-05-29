using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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
        public bool update = false;
        public int number = -1;
        public string transportTypeName;
        public string driverName;
        public string carName;
        public string direction;
        public string depTime; 
        private int oldNumber;
        private string oldTransportTypeName, oldDriverName,oldCarName,oldDirection, oldDepTime;

     
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void getTransportType()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Program.bld.ConnectionString))
                {
                    sqlConnection.Open();
                    number = Int32.Parse(routeNumber.SelectedItem.ToString());
                    SqlCommand command = new SqlCommand("dbo.[getTransportTypeName]", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter numberParam = new SqlParameter("@number", SqlDbType.Int);
                    numberParam.Value = number;
                    command.Parameters.Add(numberParam);
                    SqlDataReader reader1 = command.ExecuteReader();
                    while (reader1.Read())
                    {
                        transportType.Items.Add(reader1["TransportTypeName"].ToString());
                    }
                    reader1.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void getRouteNumber() {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Program.bld.ConnectionString))
                {
                    sqlConnection.Open();
                    SqlCommand command1 = new SqlCommand("getRouteNumber", sqlConnection);
                    command1.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader1 = command1.ExecuteReader();
                    while (reader1.Read())
                    {
                        routeNumber.Items.Add(reader1["RouteNumber"].ToString());
                    }
                    reader1.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void getDrivers()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Program.bld.ConnectionString))
                {
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand("getFreeDrivers", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter dataParam = new SqlParameter("@data", SqlDbType.DateTime);
                    dataParam.Value = dtime;
                    command.Parameters.Add(dataParam);
                    SqlParameter routeNumberParam = new SqlParameter("@routeNumber", SqlDbType.Int);
                    routeNumberParam.Value = number;
                    command.Parameters.Add(routeNumberParam);
                    SqlParameter transportTypeParam = new SqlParameter("@transportType", SqlDbType.VarChar, 10);
                    transportTypeParam.Value = transportTypeName;
                    command.Parameters.Add(transportTypeParam);
                    SqlParameter routeNameParam = new SqlParameter("@routeName", SqlDbType.VarChar, 10);
                    routeNameParam.Value = direction;
                    command.Parameters.Add(routeNameParam);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        driver.Items.Add(reader["FIO"].ToString());
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void getCars()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Program.bld.ConnectionString))
                {
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand("dbo.getFreeCars", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter dataParam = new SqlParameter("@data", SqlDbType.DateTime);
                    dataParam.Value = dtime;
                    command.Parameters.Add(dataParam);
                    SqlParameter routeNumberParam = new SqlParameter("@routeNumber", SqlDbType.Int);
                    routeNumberParam.Value = number;
                    command.Parameters.Add(routeNumberParam);
                    SqlParameter transportTypeParam = new SqlParameter("@transportType", SqlDbType.VarChar, 10);
                    transportTypeParam.Value = transportTypeName;
                    command.Parameters.Add(transportTypeParam);
                    SqlParameter routeNameParam = new SqlParameter("@routeName", SqlDbType.VarChar, 10);
                    routeNameParam.Value = direction;
                    command.Parameters.Add(routeNameParam);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        car.Items.Add(reader["TransportNumber"].ToString());
                    }
                    reader.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void getCarAndDrivers()
        {
            if (update)
            {
                for (int i = 0; i < dir.Items.Count; i++)
                    if (dir.Items[i].ToString() == direction)
                        dir.SelectedIndex = i;
                dtime = dateTimePicker1.Value;
                driver.Items.Clear();
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
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Program.bld.ConnectionString))
                {
                    sqlConnection.Open();
                    transportTypeName = transportType.SelectedIndex != -1 ? transportType.SelectedItem.ToString() : null;
                    SqlCommand command = new SqlCommand("dbo.[getDir]", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter routeNumberParam = new SqlParameter("@number", SqlDbType.Int);
                    routeNumberParam.Value = number;
                    command.Parameters.Add(routeNumberParam);
                    SqlParameter typeParam = new SqlParameter("@type", SqlDbType.VarChar, 10);
                    typeParam.Value = transportTypeName;
                    command.Parameters.Add(typeParam);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        dir.Items.Add(reader["RouteName"].ToString());
                    }
                }
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
        private void AddTrip_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = new DateTime(year, month, day); 
            getRouteNumber();
            if (update)
            {
                oldNumber = number;
                oldTransportTypeName = transportTypeName;   
                oldDriverName = driverName;
                oldCarName = carName;
                oldDirection = direction;
                oldDepTime = depTime;

                    for (int i = 0; i < routeNumber.Items.Count; i++)
                    if (routeNumber.Items[i].ToString() == number.ToString())
                        routeNumber.SelectedIndex = i;

               try {
                    dateTimePicker1.Value = DateTime.ParseExact(depTime, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture); 
                }
               catch { 
                    dateTimePicker1.Value = DateTime.ParseExact(depTime, "dd.MM.yyyy H:mm:ss", CultureInfo.InvariantCulture);
                }
            }
           
        }

        private void routeNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            transportType.SelectedItem = null;
            transportType.Items.Clear();
            dir.SelectedItem = null;
            dir.Items.Clear();
            getTransportType();
            if (update)
            {
                for (int i = 0; i < transportType.Items.Count; i++)
                    if (transportType.Items[i].ToString() == transportTypeName)
                        transportType.SelectedIndex = i;
            }
            else
            {
                driver.SelectedItem = null;
                driver.Items.Clear();
            }
            
        }

        private void transportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            dir.SelectedItem = null;
            dir.Items.Clear();
            if (transportType.SelectedIndex != -1)
                {
                    getDirection();
                if (update)
                {
                    for (int i = 0; i < dir.Items.Count; i++)
                        if (dir.Items[i].ToString() == direction)
                            dir.SelectedIndex = i;
                }
                else
                {

                    driver.SelectedItem = null;
                    driver.Items.Clear();
                    car.SelectedItem = null;
                    car.Items.Clear();
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
                    using (SqlConnection sqlConnection = new SqlConnection(Program.bld.ConnectionString))
                    {
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
                        SqlParameter depTimeParam = new SqlParameter("@depTime", SqlDbType.DateTime);
                        depTimeParam.Value = dtime;
                        cmd.Parameters.Add(depTimeParam);
                        SqlParameter routeidParam = new SqlParameter("@routeid", SqlDbType.Int);
                        routeidParam.Value = routeId;
                        cmd.Parameters.Add(routeidParam);
                        SqlParameter driveridParam = new SqlParameter("@driverid", SqlDbType.Int);
                        driveridParam.Value = driverId;
                        cmd.Parameters.Add(driveridParam);
                        SqlParameter transportidParam = new SqlParameter("@carid", SqlDbType.Int);
                        transportidParam.Value = transportId;
                        cmd.Parameters.Add(transportidParam);
                        cmd.ExecuteNonQuery();
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                update = false;
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
                if(update)
                {
                    number = oldNumber;
                    driverName = oldDriverName;
                    transportTypeName = oldTransportTypeName;
                    carName = oldCarName;
                    direction = oldDirection;
                    try
                    {
                        dtime = DateTime.ParseExact(oldDepTime, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    }
                    catch
                    {
                        dtime = DateTime.ParseExact(oldDepTime, "dd.MM.yyyy H:mm:ss", CultureInfo.InvariantCulture);
                    }
                    finally
                    {
                        insertTrip();
                    }
                }
                   
            }
            
        }
    }
}
