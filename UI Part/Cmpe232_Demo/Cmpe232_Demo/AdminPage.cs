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
    public partial class AdminPage : Form
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoginRegisterPage loginRegisterPage = new LoginRegisterPage();
            loginRegisterPage.Visible = true;
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManageEmployees manageEmployees = new ManageEmployees();
            manageEmployees.Visible = true;
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ManageHotelData manageHotelData = new ManageHotelData();
            manageHotelData.Visible = true;
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RunSQLCommands runSQLCommands = new RunSQLCommands();
            runSQLCommands.Visible = true;
            this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ManagePresetQueries managePresetQueries = new ManagePresetQueries();
            managePresetQueries.Visible = true;
            this.Visible = false;
        }
    }
}
