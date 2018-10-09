using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireApp.Domain
{
    public class Warning
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        // Link to the image.
        public string Symbol { get; set; }
    }
}
