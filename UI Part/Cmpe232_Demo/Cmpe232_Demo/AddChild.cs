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
    public partial class AddChild : Form
    {
        string server = "localhost";
        string database = "hoteldata";
        string username = "root";
        string password = "root";
        string connectionString;
        public AddChild()
        {
            InitializeComponent();
            connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EmployeePage employee = new EmployeePage();
            employee.Visible = true;
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string childName = richTextBox1.Text;
            string cssn = richTextBox2.Text;
            string birthYear = richTextBox3.Text;

            // SQL INSERT komutu
            string query = "INSERT INTO Child (ChildName, Cssn, BirthYear) VALUES (@ChildName, @Cssn, @BirthYear)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Bağlantıyı aç
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Parametreleri ekle
                        command.Parameters.AddWithValue("@ChildName", childName);
                        command.Parameters.AddWithValue("@Cssn", cssn);
                        command.Parameters.AddWithValue("@BirthYear", birthYear);

                        // Komutu çalıştır
                        int result = command.ExecuteNonQuery();

                        // Sonuç kontrolü
                        if (result > 0)
                        {
                            MessageBox.Show("Kayıt başarıyla eklendi.");
                        }
                        else
                        {
                            MessageBox.Show("Kayıt eklenirken bir hata oluştu.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
    }
}
