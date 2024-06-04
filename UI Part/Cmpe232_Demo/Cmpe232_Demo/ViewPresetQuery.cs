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
    public partial class ViewPresetQuery : Form
    {
        string server = "localhost";
        string database = "hoteldata";
        string username = "root";
        string password = "root";
        string connectionString;
        public ViewPresetQuery()
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
            LoadPresetQueryResult();
        }

        private void LoadPresetQueryResult()
        {
            string queryName = richTextBox1.Text;

            string query = "SELECT * FROM preset_query WHERE QueryName=" + queryName;

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
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);

                            // Display the result in a DataGridView
                            dataGridView1.DataSource = dataTable;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
