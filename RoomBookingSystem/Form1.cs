using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace RoomBookingSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var server = "127.0.0.1";
            var database = "";
            var user = "";
            var password = "";
            var port = "3306";

            ConnectionString = String.Format("server={0};port={1};user id={2}; password={3}; database={4};", server, port, user, password, database);
        }

        public string ConnectionString { get; set; } 

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            var databaseFunctions = new DatabaseFunctions.DatabaseFunctions();
            var allrooms = databaseFunctions.GetAllRooms(ConnectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var databaseFunctions = new DatabaseFunctions.DatabaseFunctions();
            int RoomCapacity = Convert.ToInt32(numRoomCapacity.Value);
            int HasProjector = Convert.ToInt32(chBxProjector.Checked);
            int HasToiletFacilities = Convert.ToInt32(chBxToiletFacilities.Checked);
            string RoomName = txBxRoomName.Text;
            databaseFunctions.InsertRoom(ConnectionString, HasProjector, RoomCapacity, HasToiletFacilities, RoomName);
        }
    }
}
