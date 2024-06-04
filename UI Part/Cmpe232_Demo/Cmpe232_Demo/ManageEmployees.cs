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
    public partial class ManageEmployees : Form
    {
        string server = "localhost";
        string database = "hoteldata";
        string username = "root";
        string password = "root";
        string connectionString;
        public ManageEmployees()
        {
            InitializeComponent();
            connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            adminPage.Visible = true;
            this.Visible = false;
        }
        private void LoadData()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Veritabanı bağlantısını aç
                connection.Open();

                // SQL sorgusu
                string query = "SELECT * FROM employees";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Veri okuyucusunu oluştur
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        // DataTable oluştur
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);

                        // DataGridView'e verileri yükle
                        dataGridView1.DataSource = dataTable;
                    }

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RemoveEmployees removeEmployees = new RemoveEmployees();
            removeEmployees.Visible = true;
            this.Visible = false;
        }
    }
}
