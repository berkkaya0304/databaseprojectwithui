using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Cmpe232_Demo
{
    public partial class AddCustomer : Form
    {
        string server = "localhost";
        string database = "hoteldata";
        string username = "root";
        string password = "root";
        string connectionString;
        public AddCustomer()
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
            string ssn = richTextBox1.Text;
            string name = richTextBox2.Text;
            string surname = richTextBox3.Text;
            string phoneNumber = richTextBox4.Text;
            string email = richTextBox5.Text;

            // SQL INSERT komutu
            string query = "INSERT INTO Customer (SSN, Name, Surname, Phone_number, Email) VALUES (@SSN, @Name, @Surname, @PhoneNumber, @Email)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Bağlantıyı aç
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Parametreleri ekle
                        command.Parameters.AddWithValue("@SSN", ssn);
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Surname", surname);
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        command.Parameters.AddWithValue("@Email", email);

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
