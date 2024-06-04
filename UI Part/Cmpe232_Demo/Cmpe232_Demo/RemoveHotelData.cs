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
    public partial class RemoveHotelData : Form
    {
        string server = "localhost";
        string database = "hoteldata";
        string username = "root";
        string password = "root";
        string connectionString;
        public RemoveHotelData()
        {
            InitializeComponent();
            connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";
        }

        private bool DeleteRoom(string room_number)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Room WHERE Room_number = @room_number";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@room_number", room_number);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string roomNo = richTextBox5.Text;
            if (DeleteRoom(roomNo))
            {
                MessageBox.Show("Çalışan başarıyla silindi!");
                this.Visible = false;
                ManageHotelData manageHotel = new ManageHotelData();
                manageHotel.Visible = true;
            }
            else
            {
                MessageBox.Show("Çalışan silinirken bir hata oluştu!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ManageHotelData manageHotel = new ManageHotelData();
            manageHotel.Visible = true;
        }
    }
}
