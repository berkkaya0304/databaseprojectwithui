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

namespace Cmpe232_Demo
{
    public partial class AddBooking : Form
    {
        string server = "localhost";
        string database = "hoteldata";
        string username = "root";
        string password = "root";
        string connectionString;
        public AddBooking()
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
            string bookingId = richTextBox1.Text;
            string bookingDate = richTextBox2.Text;
            string exitDate = richTextBox3.Text;
            string numberOfGuests = richTextBox4.Text;
            string roomNo = richTextBox5.Text;
            string cssn = richTextBox6.Text;

            string query = "INSERT INTO Booking (BookingId, BookingDate, ExitDate, NumberOfGuests, RoomNo, Cssn) " +
                          "VALUES (@BookingId, @BookingDate, @ExitDate, @NumberOfGuests, @RoomNo, @Cssn)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Bağlantıyı aç
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Parametreleri ekle
                        command.Parameters.AddWithValue("@BookingId", bookingId);
                        command.Parameters.AddWithValue("@BookingDate", bookingDate);
                        command.Parameters.AddWithValue("@ExitDate", (object)exitDate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@NumberOfGuests", numberOfGuests);
                        command.Parameters.AddWithValue("@RoomNo", roomNo);
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
