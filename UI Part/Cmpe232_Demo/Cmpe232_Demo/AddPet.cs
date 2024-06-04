using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cmpe232_Demo
{
    public partial class AddPet : Form
    {
        string server = "localhost";
        string database = "hoteldata";
        string username = "root";
        string password = "root";
        string connectionString;
        public AddPet()
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
            string petName = richTextBox1.Text;
            string specie = richTextBox2.Text;
            string cssn = richTextBox3.Text;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO Pet (PetName, Specie, Cssn) VALUES (@PetName, @Specie, @Cssn)";
                try
                {
                    // Bağlantıyı aç
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Parametreleri ekle
                        command.Parameters.AddWithValue("@PetName", petName);
                        command.Parameters.AddWithValue("@Specie", specie);
                        command.Parameters.AddWithValue("@Cssn", cssn);

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
