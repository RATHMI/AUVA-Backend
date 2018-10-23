using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUVA.Domain
{
    public class SecurityClothes
    {
        public int Id { get; set; }

        public string Name { get; set; }

        // Link to the image on the server.
        public string Image { get; set; }
    }
}
