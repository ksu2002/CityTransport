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
    public partial class DriverForm : Form
    {
       
        public DriverForm()
        {
            InitializeComponent();
        }
        public int user_ID;
        private int driver_ID;

        private void DriverForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Program.bld.ConnectionString))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand($"getDriverIDbyUserID", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter user_IDParam = new SqlParameter("@user_id", SqlDbType.Int);
                    user_IDParam.Value = user_ID;
                    sqlCommand.Parameters.Add(user_IDParam);
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        driver_ID = reader.GetInt32(0);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM";
            showSchedule();
            showReport();
            

        }
        private void showSchedule()
        {
            SqlConnection sqlConnection = new SqlConnection(Program.bld.ConnectionString);
            try
            {
                string query = ($"SELECT*FROM dbo.TripsForDriverPerDay({driver_ID}, '{date}')");
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
        private void showReport()
        {
            date = dateTimePicker1.Value;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Program.bld.ConnectionString))
                {
                    sqlConnection.Open();
                    string query = ($"SELECT*FROM dbo.MonthlyReport({driver_ID}, {Int32.Parse(date.Year.ToString())},{Int32.Parse(date.Month.ToString())})");
                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = command;
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    FIO.Text = dataSet.Tables[0].Rows[0].ItemArray[0].ToString();
                    if (dataSet.Tables[0].Rows[0].ItemArray[1].ToString() != "")
                    {
                        string r = dataSet.Tables[0].Rows[0].ItemArray[1].ToString();
                        trips.Text = dataSet.Tables[0].Rows[0].ItemArray[1].ToString();
                        time.Text = dataSet.Tables[0].Rows[0].ItemArray[2].ToString();
                        money.Text = dataSet.Tables[0].Rows[0].ItemArray[3].ToString();
                    }
                    else
                    {
                        trips.Text = "0";
                        time.Text = "0";
                        money.Text = "0";
                    }
                    label1.Text = FIO.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void schedulePage_Click(object sender, EventArgs e)
        {

        }

        private DateTime date = DateTime.Now;
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            date = dateTimePicker.Value;
            showSchedule();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            showReport();
        }
    }
}
