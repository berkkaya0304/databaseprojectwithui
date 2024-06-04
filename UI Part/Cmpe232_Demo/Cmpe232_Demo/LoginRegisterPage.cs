using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Cmpe232_Demo
{
    public partial class LoginRegisterPage : Form
    {

        string server = "localhost";
        string database = "hoteldata";
        string username = "root";
        string password = "root";
        string connectionString;

        public LoginRegisterPage()
        {
            InitializeComponent();
            connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";
        }

        private void VerifyUser(string email, string password)
        {
            string query = "SELECT UserType FROM account WHERE Email = @Email AND Password = @Password";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            string userType = result.ToString();

                            if (userType.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                            {
                                // AdminPage'e yönlendir
                                AdminPage adminPage = new AdminPage();
                                adminPage.Show();
                            }
                            else if (userType.Equals("User", StringComparison.OrdinalIgnoreCase))
                            {
                                string query2 = "SELECT Name FROM account WHERE Email = @Email AND Password = @Password";
                                MySqlConnection connection2 = new MySqlConnection(connectionString);
                                MySqlCommand command2 = new MySqlCommand(query2, connection2);

                                command2.Parameters.AddWithValue("@Email", email);
                                command2.Parameters.AddWithValue("@Password", password);
                                connection2.Open();
                                object result2 = command2.ExecuteScalar();
                                string name = result2.ToString();

                                // StartPage'e yönlendir
                                StartPage startPage = new StartPage(email,password, name);
                                startPage.Show();
                            }
                            else if (userType.Equals("Employee", StringComparison.OrdinalIgnoreCase))
                            {
                                // EmployeePage'e yönlendir
                                EmployeePage employeePage = new EmployeePage();
                                employeePage.Show();
                            }
                            else
                            {
                                MessageBox.Show("Unknown user type.");
                            }

                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid email or password.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private bool RegisterUser(string name,string email, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Account (Name, Email, Password, userType) VALUES (@Name, @Email, @Password,\"User\")";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email, password;
            email = richTextBox3.Text;
            password = textBox1.Text;

            VerifyUser(email, password);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String emailRegister, passwordRegister,nameRegister;
            emailRegister = richTextBox1.Text;
            passwordRegister = textBox2.Text;
            nameRegister = richTextBox5.Text;

            if (emailRegister != "" && passwordRegister != "")
            {
                RegisterUser(nameRegister, emailRegister, passwordRegister);
                MessageBox.Show("Kullanıcı başarıyla kaydedildi!");
            }
            else if(passwordRegister == "" && emailRegister != "")
            {
                MessageBox.Show("Please enter Password:");
            }
            else if (emailRegister == "" && passwordRegister != "" )
            {
                MessageBox.Show("Please enter Email:");
            }
            else
            {
                MessageBox.Show("Please enter Email and Password:");
            }
        }
    }
}
