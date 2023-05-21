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
    public partial class SchedulerForm : Form
    {
        public SchedulerForm()
        {
            InitializeComponent();
        }

        public int number = -1;
        public string transportTypeName = null;
        public string driverName = null;
        public string carName = null;
        public string direction = null;
        public DateTime dtime = DateTime.Now;
        public DateTime date = DateTime.Now;
        private void button1_Click(object sender, EventArgs e)
        {
            InsertForm insertForm = new InsertForm();
            insertForm.Show();
        }

        private void SchedulerForm_Load(object sender, EventArgs e)
        {
            showCondition();
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

        private void button2_Click(object sender, EventArgs e)
        {
            TripsSchedule tripsSchedule = new TripsSchedule();  
            tripsSchedule.Show();
        }

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
                DataSet dataSet = new DataSet();
                sqlConnection.Open();
                dataAdapter.Fill(dataSet);
                sqlConnection.Close();
                dataGridView1.DataSource = dataSet.Tables[0];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void showCondition()
        {
            try
            {
                comboBox1.SelectedItem = null;
                comboBox1.Items.Clear();
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["bdConnectionString"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                SqlCommand command1 = new SqlCommand("dbo.[getConditionName]", sqlConnection);
                command1.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader1 = command1.ExecuteReader();

                while (reader1.Read())
                {
                    comboBox1.Items.Add(reader1["ConditionName"].ToString());
                }
                reader1.Close();

                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["bdConnectionString"].ConnectionString;

                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                dtime = DateTime.Now;
                string query = ($"select* from [dbo].[HistoryCondition]('{date.Date}')");
                SqlCommand command = new SqlCommand(query, sqlConnection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;

                // Создание объекта DataSet
                DataSet dataSet = new DataSet();

                // Заполнение DataSet
                dataAdapter.Fill(dataSet);


                // Привязка DataSet к DataGridView
                dataGridView2.DataSource = dataSet.Tables[0];

                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            AddTrip addTrip = new AddTrip();
            addTrip.year = dateTimePicker1.Value.Year;
            addTrip.month = dateTimePicker1.Value.Month;
            addTrip.day = dateTimePicker1.Value.Day;
            addTrip.Show();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            date = dateTimePicker2.Value.Date;
            showCondition();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = dataGridView2.CurrentCell; // получаем выбранную ячейку

            string selectedValue = cell.Value.ToString();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["bdConnectionString"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            try
            {
                SqlCommand command1 = new SqlCommand("UpdateConditionHistory", sqlConnection);
                command1.CommandType = CommandType.StoredProcedure;
                string r = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                string rr = cell.Value.ToString();

                command1.Parameters.AddWithValue("@conditionName", selectedValue);
                command1.Parameters.AddWithValue("@transportNumber", r);
                command1.Parameters.AddWithValue("@conditionDate", date.Date);
                command1.CommandType = CommandType.StoredProcedure;
                command1.ExecuteNonQuery();
                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            showCondition();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) 
            {
                DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell(); 
                cell.Items.AddRange(new string[] { "исправен", "сломан" });
                dataGridView2[e.ColumnIndex, e.RowIndex] = cell;
                string selectedValue = cell.Value.ToString(); 
            }
        }
    }
}
