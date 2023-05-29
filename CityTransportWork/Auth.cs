using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CityTransportWork
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }
        private void Auth_Load(object sender, EventArgs e)
        {
         
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void authButton_Click(object sender, EventArgs e)
        {
            Program.bld.ConnectionString = Properties.Settings.Default.CityTransportConnectionString;
            Program.bld.UserID = "guest";
            Program.bld.Password = "guest";
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(Program.bld.ConnectionString))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("auth", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter loginParam = new SqlParameter("@login", SqlDbType.VarChar, 30);
                    loginParam.Value = loginBox.Text;
                    sqlCommand.Parameters.Add(loginParam);
                    SqlParameter passwordParam = new SqlParameter("@pass", SqlDbType.VarChar, 30);
                    passwordParam.Value = passwordBox.Text;
                    sqlCommand.Parameters.Add(passwordParam);
                    SqlDataReader auth = sqlCommand.ExecuteReader();
                    if (auth.Read())
                    {
                        Program.bld.UserID = auth.GetValue(0).ToString();
                        Program.bld.Password = auth.GetValue(1).ToString();
                        Program.user_ID = Int32.Parse(auth.GetValue(2).ToString());
                        statusAuth.Text = "Подключение успешно";
                    }
                    else
                    {
                        statusAuth.Text = "Неверен логин или пароль";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            if (Program.bld.UserID == "driver")
            {
                DriverForm driverForm = new DriverForm(this);
                driverForm.user_ID= Program.user_ID;
                this.Hide();
                driverForm.Show();

            }
            if (Program.bld.UserID == "passenger")
            {
                PassengerForm passengerForm = new PassengerForm(this);
                this.Hide();
                passengerForm.Show();
            }
            if (Program.bld.UserID == "scheduler")
            {
                SchedulerForm schedulerForm = new SchedulerForm(this);
                this.Hide();
                schedulerForm.Show();
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void statusAuth_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
