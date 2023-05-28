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
        public DateTime dtime;
        public DateTime date;
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void SchedulerForm_Load(object sender, EventArgs e)
        {
            date = DateTime.Now;
            showCondition();
            dtime = DateTime.Now;
            showSchedule();
        }

        private void showSchedule()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["bdConnectionString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
               
                sqlConnection.Open();
                string query = ($"SELECT*FROM dbo.DaySchedule('{dtime}')");
                SqlCommand command = new SqlCommand(query, sqlConnection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
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
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dtime = dateTimePicker1.Value;
            showSchedule();
            
        }

        private void showCondition()
        {
            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["bdConnectionString"].ConnectionString;

                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string query = ($"select* from [dbo].[HistoryCondition]('{date.Date}')");
                SqlCommand command = new SqlCommand(query, sqlConnection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
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
            dtime = dateTimePicker1.Value;
            AddTrip addTrip = new AddTrip();
            addTrip.year = dtime.Year;
            addTrip.month = dtime.Month;
            addTrip.day = dtime.Day;
            addTrip.Show();
            addTrip.Closed += Form2_Closed;


        }
        private void Form2_Closed(object sender, EventArgs e)
        {
            showSchedule();
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];

                DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
                int rn = Int32.Parse(row.Cells[0].Value.ToString());
                string d = row.Cells[1].Value.ToString();
            }
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
            DataGridViewCell cell = dataGridView2.CurrentCell; 
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

                SqlParameter conditionNameParam = new SqlParameter("@conditionName", SqlDbType.VarChar, 20);
                conditionNameParam.Value = selectedValue;
                command1.Parameters.Add(conditionNameParam);
                SqlParameter transportNumberParam = new SqlParameter("@transportNumber", SqlDbType.VarChar, 6);
                transportNumberParam.Value = r;
                command1.Parameters.Add(transportNumberParam);
                SqlParameter conditionDateParam = new SqlParameter("@conditionDate", SqlDbType.Date);
                conditionDateParam.Value = date.Date;
                command1.Parameters.Add(conditionDateParam);
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
                try
                {
                    cell.Items.Clear();
                    string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["bdConnectionString"].ConnectionString;
                    SqlConnection sqlConnection = new SqlConnection(connectionString);
                    sqlConnection.Open();

                    SqlCommand command1 = new SqlCommand("dbo.[getConditionName]", sqlConnection);
                    command1.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader1 = command1.ExecuteReader();

                    while (reader1.Read())
                    {
                        cell.Items.Add(reader1["ConditionName"].ToString());
                    }
                    reader1.Close();

                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                dataGridView2[e.ColumnIndex, e.RowIndex] = cell;
                string selectedValue = cell.Value.ToString(); 
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 ) { 

                int rn = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                string d = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                string tt = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                string tdt = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                string dn = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                string tn = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
               
                    dataGridView1.Rows[e.RowIndex].Selected = true; // подсвечиваем выбранный ряд
              
            }
        }
        private void deleteTrip()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["bdConnectionString"].ConnectionString;

            DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
            int rn = Int32.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
            string d = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            string tt = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
            string tdt = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString();
            string dn = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value.ToString();
            string tn = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[6].Value.ToString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            try
            {
                SqlCommand command = new SqlCommand("DeleteTrip", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter routeNumberParam = new SqlParameter("@RouteNumber", SqlDbType.Int);
                routeNumberParam.Value = rn;
                command.Parameters.Add(routeNumberParam);
                SqlParameter dirParam = new SqlParameter("@Dir", SqlDbType.VarChar, 41);
                dirParam.Value = d;
                command.Parameters.Add(dirParam);
                SqlParameter transportTypeParam = new SqlParameter("@TransportType", SqlDbType.VarChar, 10);
                transportTypeParam.Value = tt;
                command.Parameters.Add(transportTypeParam);
                SqlParameter tripDepartureTimeParam = new SqlParameter("@TripDepartureTime", SqlDbType.DateTime);
                tripDepartureTimeParam.Value = tdt;
                command.Parameters.Add(tripDepartureTimeParam);
                SqlParameter driverNameParam = new SqlParameter("@DriverName", SqlDbType.VarChar, 40);
                driverNameParam.Value = dn;
                command.Parameters.Add(driverNameParam);
                SqlParameter transportNumberParam = new SqlParameter("@TransportNumber", SqlDbType.VarChar, 6);
                transportNumberParam.Value = tn;
                command.Parameters.Add(transportNumberParam);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            sqlConnection.Close();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            deleteTrip();
            dtime = dateTimePicker1.Value.Date;
            showSchedule();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["bdConnectionString"].ConnectionString;
                DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();


                int rn = Int32.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
                string d = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
                string tt = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
                string tdt = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString();
                string dn = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value.ToString();
                string tn = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[6].Value.ToString();

                AddTrip addTrip = new AddTrip();

                addTrip.number = rn;
                addTrip.transportTypeName = tt;
                addTrip.depTime = tdt;
                addTrip.direction = d;
                addTrip.driverName = dn;
                addTrip.carName = tn;
                dtime = dateTimePicker1.Value;
                addTrip.year = dtime.Year;
                addTrip.month = dtime.Month;
                addTrip.day = dtime.Day;
                addTrip.update = 1;
                deleteTrip();
                addTrip.Show();
               
                addTrip.Closed += Form2_Closed;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;

            }
        }
    }
}
