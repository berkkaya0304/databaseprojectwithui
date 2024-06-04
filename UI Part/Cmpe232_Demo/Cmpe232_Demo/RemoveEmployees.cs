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


namespace Cmpe232_Demo
{
    public partial class RemoveEmployees : Form
    {
        string server = "localhost";
        string database = "hoteldata";
        string username = "root";
        string password = "root";
        string connectionString;
        public RemoveEmployees()
        {
            InitializeComponent();
            connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ssn = richTextBox5.Text;
            if (DeleteEmployee(ssn))
            {
                MessageBox.Show("Çalışan başarıyla silindi!");
                this.Visible = false;
                ManageEmployees manageEmployees = new ManageEmployees();
                manageEmployees.Visible = true;
            }
            else
            {
                MessageBox.Show("Çalışan silinirken bir hata oluştu!");
            }
        }

        private bool DeleteEmployee(string ssn)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Employee WHERE SSN = @SSN";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SSN", ssn);

                    int rowsAffected = command.ExecuteNonQuery();

                    // Eğer en az bir satır etkilendiyse, kayıt başarıyla silinmiştir.
                    return rowsAffected > 0;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ManageEmployees manageEmployees = new ManageEmployees();
            manageEmployees.Visible = true;
        }
    }
}
