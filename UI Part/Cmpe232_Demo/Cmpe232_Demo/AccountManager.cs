using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;


namespace Cmpe232_Demo
{
    public partial class AccountManager : Form
    {
        string text1, text2, text3;
        string server = "localhost";
        string database = "hoteldata";
        string username = "root";
        string password = "root";
        string connectionString;
        public AccountManager()
        {
            InitializeComponent();
            connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";
        }

        public AccountManager(string text1,string text2,string text3)
        {
            this.text1 = text1;
            this.text2 = text2;
            this.text3 = text3;
            InitializeComponent();
            connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";
        }

        private void SaveNameChanges()
        {
            string email = text1;

            string query = "UPDATE Account SET Name = @Name WHERE Email = @Email";

            // Create a MySqlConnection object
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Create a MySqlCommand object
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Name", richTextBox1.Text);
                    try
                    {
                        // Open the database connection
                        connection.Open();

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Name updated successfully!");
                        }
                        else
                        {
                            MessageBox.Show("No changes made to the name.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

   
        private void SavePasswordChanges()
        {
            string email = text1;

            string query = "UPDATE Account SET Password = @Password WHERE Email = @Email";

            // Create a MySqlConnection object
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Create a MySqlCommand object
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@Password", richTextBox3.Text);
                    command.Parameters.AddWithValue("@Email", email);

                    try
                    {
                        // Open the database connection
                        connection.Open();

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Password updated successfully!");
                        }
                        else
                        {
                            MessageBox.Show("No changes made to the password.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StartPage startPage = new StartPage();
            startPage.Visible = true;
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveNameChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SavePasswordChanges();
        }
    }
}
