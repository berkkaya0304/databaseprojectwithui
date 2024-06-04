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

namespace Cmpe232_Demo
{
    public partial class RemovePresetQuery : Form
    {
        string server = "localhost";
        string database = "hoteldata";
        string username = "root";
        string password = "root";
        string connectionString;
        public RemovePresetQuery()
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

        private void ExecuteDeleteQuery()
        {
            string queryName = richTextBox1.Text;
            string query = "DELETE FROM preset_query WHERE QueryName=\"" + queryName + "\"";
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

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        MessageBox.Show("Removed Successfully!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExecuteDeleteQuery();
            ManagePresetQueries managePresetQueries = new ManagePresetQueries();
            managePresetQueries.Visible = true;
            this.Visible = false;
        }
    }
}
