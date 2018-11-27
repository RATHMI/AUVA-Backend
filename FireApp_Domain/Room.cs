using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUVA.Domain
{
    public class Room
    {
        public Room()
        {
            Machines = new HashSet<int>();
        }

        // RoomNumber
        public string Id { get; set; }

        public string Description { get; set; }

        // Link to the emergancy plan on the server.
        public string EmergencyPlan { get; set; }

        // Link to the list of first responders on the server.
        public string FirstResponders { get; set; }

        public HashSet<int> Machines { get; set; }

        // Link
        public string GuestInfo { get; set; }
    }
}
