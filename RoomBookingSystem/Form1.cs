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
            using (var connection = new MySqlConnection(ConnectionString))
            try
            {
                var queryString = "select * from rooms";
                connection.Open();
                var command = new MySqlCommand(queryString, connection);
                var results = command.ExecuteReader();
                while (results.Read())
                {
                    var result = String.Format($"room_id: {results[0].ToString()}, room_max_capacity: {results[1].ToString()} has_projector: {results[2].ToString()} has_toilet_facilities: {results[3].ToString()}");
                }
                connection.Close();
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
