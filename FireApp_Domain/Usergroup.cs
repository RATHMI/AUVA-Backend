using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireApp.Domain
{
    public class Usergroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Usertype Usertype { get; set; }
    }

    public enum Usertype
    {
        admin=1,
        teacher=2,
        student=3,
        guest=0
    }
}
