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
    public partial class MonthlyReport : Form
    {
        private SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-H2QPSJ9\\SQLEXPRESS",
            InitialCatalog = "CityTransport",
            PersistSecurityInfo = false,
            TrustServerCertificate = true,
        };
        public MonthlyReport()
        {
            InitializeComponent();
        }

        private void MonthlyReport_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void time_Click(object sender, EventArgs e)
        {

        }
        public int user_ID;
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime date = e.Start;
            sqlConnectionStringBuilder.UserID = "guest";
            sqlConnectionStringBuilder.Password = "123";

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            
            try
            {
                string query = ($"SELECT*FROM dbo.MonthlyReport({user_ID}, {Int32.Parse(date.Year.ToString())},{Int32.Parse(date.Month.ToString())})");
                SqlCommand command = new SqlCommand(query, sqlConnection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;

                DataSet dataSet = new DataSet();
                sqlConnection.Open();
                dataAdapter.Fill(dataSet);
                sqlConnection.Close();
                FIO.Text =  dataSet.Tables[0].Rows[0].ItemArray[0].ToString();
                trips.Text = dataSet.Tables[0].Rows[0].ItemArray[1].ToString();
                time.Text = dataSet.Tables[0].Rows[0].ItemArray[2].ToString();  
                money.Text = dataSet.Tables[0].Rows[0].ItemArray[3].ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            
        }
    }
}
