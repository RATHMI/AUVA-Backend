using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUVA.Domain {
    public class User {

        public User()
        {
            SafetyInstructions = new HashSet<SafetyInstruction>();
        }
        // Username.
        public string Id { get; set; }        

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public Usertype Type { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }

        // A list of all SafetyInstructions.
        public HashSet<SafetyInstruction> SafetyInstructions { get; set; }
    }

    public enum Usertype
    {
        guest = 0,
        student = 1,
        teacher = 2,
        admin = 3
    }
}
