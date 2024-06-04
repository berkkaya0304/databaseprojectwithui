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
    public partial class RunSQLScreen : Form
    {
        string server = "localhost";
        string database = "hoteldata";
        string username = "root";
        string password = "root";
        string connectionString;
        public RunSQLScreen()
        {
            InitializeComponent();
            connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RunSQLCommands runSQLCommands = new RunSQLCommands();
            runSQLCommands.Visible = true;
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = richTextBox1.Text.Trim();

            if (string.IsNullOrEmpty(query))
            {
                MessageBox.Show("Please enter a SQL query.");
                return;
            }

            ExecuteQuery(query);
        }

        private void ExecuteQuery(string query)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        if (query.Trim().StartsWith("SELECT", StringComparison.OrdinalIgnoreCase))
                        {
                            // SELECT sorgusu ise, sonuçları göster
                            using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                            {
                                DataTable dataTable = new DataTable();
                                adapter.Fill(dataTable);
                                dataGridView1.DataSource = dataTable;
                            }
                        }
                        else
                        {
                            // SELECT sorgusu değilse, sorguyu çalıştır
                            int rowsAffected = command.ExecuteNonQuery();
                            MessageBox.Show($"{rowsAffected} rows affected. Query executed successfully.");
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
