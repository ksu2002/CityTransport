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
    public partial class PassengerForm : Form
    {
        public PassengerForm(Form auth)
        {
            this.auth = auth;
            InitializeComponent();
        }
        private Form auth;
        private void ShowRoutes()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Program.bld.ConnectionString))
                {
                    sqlConnection.Open();
                    string stop1name = stop1.SelectedItem.ToString();
                    string stop2name = stop2.SelectedItem.ToString();
                    string query1 = ($"SELECT*FROM dbo.RoutsFromStop1ToStop2({"'" + stop1name + "'"}, {"'" + stop2name + "'"})");
                    SqlCommand command1 = new SqlCommand(query1, sqlConnection);
                    SqlDataAdapter dataAdapter1 = new SqlDataAdapter();
                    dataAdapter1.SelectCommand = command1;

                    DataSet dataSet = new DataSet();
                    int check = dataAdapter1.Fill(dataSet);
                    if (check != 0)
                    {
                        dataGridView1.DataSource = dataSet.Tables[0];
                    }
                    else
                    {
                        string query2 = ($"SELECT*FROM dbo.TransferFromStop1ToStop2({"'" + stop1name + "'"}, {"'" + stop2name + "'"})");
                        SqlCommand command2 = new SqlCommand(query2, sqlConnection);
                        SqlDataAdapter dataAdapter2 = new SqlDataAdapter();
                        dataAdapter2.SelectCommand = command2;
                        DataSet dataSet1 = new DataSet();
                        dataAdapter2.Fill(dataSet1);
                        dataGridView1.DataSource = dataSet1.Tables[0];
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void PassengerForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Program.bld.ConnectionString))
                {
                    sqlConnection.Open();

                    SqlCommand sqlCommand1 = new SqlCommand($"dbo.[getStopName]", sqlConnection);
                    SqlDataReader reader1 = sqlCommand1.ExecuteReader();
                    while (reader1.Read())
                    {
                        stop1.Items.Add(reader1.GetString(0));
                    }
                    reader1.Close();
                    SqlCommand sqlCommand2 = new SqlCommand($"dbo.[getStopName]", sqlConnection);
                    SqlDataReader reader2 = sqlCommand2.ExecuteReader();
                    while (reader2.Read())
                    {
                        stop2.Items.Add(reader2.GetString(0));
                    }

                    reader2.Close();
                }
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
        private void stop1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if  (stop1.SelectedIndex != -1 && stop2.SelectedIndex != -1)
            {
                ShowRoutes();
            }
        }

        private void stop2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (stop1.SelectedItem.ToString() != null && stop2.SelectedItem.ToString() != null)
            {
                ShowRoutes();
            }
        }
        private void PassengerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            auth.Show();
        }
    }
}
