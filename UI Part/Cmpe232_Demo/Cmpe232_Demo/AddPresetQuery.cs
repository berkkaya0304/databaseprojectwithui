using MySql.Data.MySqlClient;
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

namespace Cmpe232_Demo
{
    public partial class AddPresetQuery : Form
    {
        string server = "localhost";
        string database = "hoteldata";
        string username = "root";
        string password = "root";
        string connectionString;
        public AddPresetQuery()
        {
            InitializeComponent();
            connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ManagePresetQueries managePresetQueries = new ManagePresetQueries();
            managePresetQueries.Visible = true;
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string queryName, queryContent;
            queryName = richTextBox1.Text;
            queryContent = richTextBox2.Text;
            AddPresetQuery2(queryName, queryContent);

            ManagePresetQueries managePresetQueries = new ManagePresetQueries();
            managePresetQueries.Visible = true;
            this.Visible = false;
        }


        private void AddPresetQuery2(string queryName, string queryContent)
        {
            // INSERT sorgusu oluşturma
            string query = "INSERT INTO preset_query (QueryName, PresetText) VALUES (@QueryName, @QueryContent)";

            // Create a MySqlConnection object
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Create a MySqlCommand object
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@QueryName", queryName);
                    command.Parameters.AddWithValue("@QueryContent", queryContent);

                    try
                    {
                        // Open the database connection
                        connection.Open();

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Query added successfully!");
                            // Yeni bir sorgu ekledikten sonra, verileri temizle

                        }
                        else
                        {
                            MessageBox.Show("Failed to add query.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

    }
}
