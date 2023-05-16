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
    public partial class PassengerForm : Form
    {

        private SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-H2QPSJ9\\SQLEXPRESS",
            InitialCatalog = "CityTransport",
            PersistSecurityInfo = false,
            TrustServerCertificate = true,
        };
        public PassengerForm()
        {
            InitializeComponent();
        }

        private void PassengerForm_Load(object sender, EventArgs e)
        {
            sqlConnectionStringBuilder.UserID = "passenger";
            sqlConnectionStringBuilder.Password = "passenger";

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();

            try
            {
               
                SqlCommand sqlCommand1 = new SqlCommand($"dbo.[getStopName]", sqlConnection);
    
                SqlDataReader reader1 = sqlCommand1.ExecuteReader();
                while (reader1.Read())
                {
                    stop1.Items.Add(reader1.GetString(0));
                }

                // Закрытие SqlDataReader
                reader1.Close();

                SqlCommand sqlCommand2 = new SqlCommand($"dbo.[getStopName]", sqlConnection);

                SqlDataReader reader2 = sqlCommand2.ExecuteReader();
                while (reader2.Read())
                {
                    stop2.Items.Add(reader2.GetString(0));
                }

                // Закрытие SqlDataReader
                reader2.Close();

                sqlConnection.Close();

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
        private int stop1_id = 1;
        private int stop2_id = 7;
        private string stop1name;
        private string stop2name;
        private void stop1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            ///   try
            // {
            //    SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            //string stop1name = stop1.SelectedItem.ToString();
        /*       SqlCommand sqlCommand = new SqlCommand($"dbo.[getStopID] {"'" + stop1name + "'"}", sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    int stop1_id = Int32.Parse(reader.GetValue(0).ToString());

                }
                reader.Close();
                sqlConnection.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }*/
            

        }

        private void stop2_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlConnectionStringBuilder.UserID = "passenger";
            sqlConnectionStringBuilder.Password = "passenger";
            try
            {
                SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
                string stop1name = stop1.SelectedItem.ToString();
                string stop2name = stop2.SelectedItem.ToString();
          /*      SqlCommand sqlCommand = new SqlCommand($"dbo.[getStopID] {"'" + stop2name + "'"}", sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    int stop2_id = Int32.Parse(reader.GetValue(0).ToString());
                }
                reader.Close();
           */
                string query = ($"SELECT*FROM dbo.RoutsFromStop1ToStop2({"'" + stop1name + "'"}, {"'" + stop2name + "'"})");
                label1.Text = stop1name;
                label2.Text = stop2name;
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
    }
}
