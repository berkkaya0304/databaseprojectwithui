using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Cmpe232_Demo
{
    public partial class StartPage : Form
    {
        string server = "localhost";
        string database = "hoteldata";
        string username = "root";
        string password = "root";
        string connectionString;

        string text1, text2, text3;

        public StartPage()
        {
            InitializeComponent();
            connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";
            LoadTotalRooms();
            LoadTotalEmployees();
            LoadAverageAge();
            LoadTotalPet();
            LoadTotalChild();
            LoadTotalUserWithGroupBy();
        }

        public StartPage(string text1,string text2,string text3)
        {
            this.text1 = text1;
            this.text2 = text2;
            this.text3 = text3;
            InitializeComponent();
            label13.Text = text3 + "!";
            connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";
            LoadTotalRooms();
            LoadTotalEmployees();
            LoadAverageAge();
            LoadTotalPet();
            LoadTotalChild();
            LoadTotalUserWithGroupBy();
        }

        private void LoadTotalRooms()
        {
            string query = "SELECT COUNT(*) FROM rooms";

            // Create a MySqlConnection object
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Create a MySqlCommand object
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        // Open the database connection
                        connection.Open();

                        // Execute the query and get the result
                        int totalRooms = Convert.ToInt32(command.ExecuteScalar());

                        // Display the total number of rooms in a label
                        label6.Text = $"{totalRooms}";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void LoadTotalPet()
        {
            string query = "SELECT COUNT(*) FROM pet";

            // Create a MySqlConnection object
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Create a MySqlCommand object
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        // Open the database connection
                        connection.Open();

                        // Execute the query and get the result
                        int totalPets = Convert.ToInt32(command.ExecuteScalar());

                        // Display the total number of rooms in a label
                        label8.Text = $"{totalPets}";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void LoadTotalUserWithGroupBy()
        {
            string query = "SELECT COUNT(*) AS UserCount\r\nFROM account\r\nWhere Usertype = \"User\"\r\nGROUP BY Usertype;";

            // Create a MySqlConnection object
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Create a MySqlCommand object
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        // Open the database connection
                        connection.Open();

                        // Execute the query and get the result
                        int TotalUsers = Convert.ToInt32(command.ExecuteScalar());

                        // Display the total number of rooms in a label
                        label14.Text = $"{TotalUsers}";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void LoadTotalChild()
        {
            string query = "SELECT COUNT(*) FROM child";

            // Create a MySqlConnection object
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Create a MySqlCommand object
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        // Open the database connection
                        connection.Open();

                        // Execute the query and get the result
                        int totalChildren = Convert.ToInt32(command.ExecuteScalar());

                        // Display the total number of rooms in a label
                        label9.Text = $"{totalChildren}";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void LoadTotalEmployees()
        {
            string query = "SELECT COUNT(*) FROM employee";

            // Create a MySqlConnection object
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Create a MySqlCommand object
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        // Open the database connection
                        connection.Open();

                        // Execute the query and get the result
                        int totalEmployees = Convert.ToInt32(command.ExecuteScalar());

                        // Display the total number of rooms in a label
                        label7.Text = $"{totalEmployees}";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void LoadAverageAge()
        {
            string query = "SELECT AVG(age) FROM employee";

            // Create a MySqlConnection object
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Create a MySqlCommand object
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                        // Open the database connection
                        connection.Open();

                        // Execute the query and get the result
                        object result = command.ExecuteScalar();

                        // Check if result is not null and convert it to double
                        double averageAge = result != DBNull.Value ? Convert.ToDouble(result) : 0;

                        // Display the average age in a label
                        label11.Text = $"{averageAge}";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
            {
            LoginRegisterPage loginRegisterPage = new LoginRegisterPage();
            loginRegisterPage.Visible = true;
            this.Visible = false;
            }

        private void button2_Click(object sender, EventArgs e)
        {
            AccountManager accountManager = new AccountManager(text1,text2,text3);
            accountManager.Visible = true;
            this.Visible = false;
        }
    }
}
