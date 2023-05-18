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
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // dateTimePicker1.Enabled = false; // запрещаем изменение
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

        private void routeNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            try
            {
                int number = Int32.Parse(routeNumber.SelectedItem.ToString());

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

        }
    }
}
