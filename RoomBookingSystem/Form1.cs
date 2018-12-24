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

           string[] file = System.IO.File.ReadAllLines(@"C:\tmp\info.txt");

            var server = file[0];
            var database = file[1];
            var user = file[2];
            var password = file[3];
            var port = file[4];

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
            int roomCapacity = Convert.ToInt32(numRoomCapacity.Value);
            int HasProjector = Convert.ToInt32(chBxProjector.Checked);
            int HasToiletFacilities = Convert.ToInt32(chBxToiletFacilities.Checked);
            string RoomName = txBxRoomName.Text;
            databaseFunctions.InsertRoom(ConnectionString, HasProjector, roomCapacity, HasToiletFacilities, RoomName);
        }
    }
}
