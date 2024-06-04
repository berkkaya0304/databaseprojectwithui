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
    public partial class AddHotelData : Form
    {
        string server = "localhost";
        string database = "hoteldata";
        string username = "root";
        string password = "root";
        string connectionString;
        public AddHotelData()
        {
            InitializeComponent();
            connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";
        }

        private void AddRoom(string roomNumber, string roomType, int capacity)
        {
            string query = "INSERT INTO room (room_number, room_type, capacity) VALUES (@RoomNumber, @RoomType, @Capacity)";

            // Create a MySqlConnection object
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Create a MySqlCommand object
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@RoomNumber", roomNumber);
                    command.Parameters.AddWithValue("@RoomType", roomType);
                    command.Parameters.AddWithValue("@Capacity", capacity);

                    try
                    {
                        // Open the database connection
                        connection.Open();

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Room added successfully!");
                            // Eğer başka bir işlem yapmak istiyorsanız, buraya ekleyebilirsiniz.
                        }
                        else
                        {
                            MessageBox.Show("Failed to add room.");
                        }
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
            string roomNumber = richTextBox1.Text;
            string roomType = richTextBox2.Text;
            int capacity = Convert.ToInt32(richTextBox3.Text);

            // Yeni oda eklemek için ekleme fonksiyonunu çağır
            AddRoom(roomNumber, roomType, capacity);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManageHotelData manageHotelData = new ManageHotelData();
            manageHotelData.Visible = true;
            this.Visible = false;
        }
    }
}
