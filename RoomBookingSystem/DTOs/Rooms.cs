using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingSystem.DTOs
{
    public class Rooms
    {
        public int RoomId { get; set; }

        public int RoomMaxCapacity { get; set; }

        public bool HasProjector { get; set; }

        public bool HasToilet { get; set; }

        public string RoomName { get; set; }
    }
}
