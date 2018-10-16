using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireApp.Domain {
    public class User {

        public int Id { get; set; }        

        public string Username { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }

        // A list of all MachineTypes where the user has received the safety instructions.
        public HashSet<int> MachineTypes { get; set; }
    }
}
