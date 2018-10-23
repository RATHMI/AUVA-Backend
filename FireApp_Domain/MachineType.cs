using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUVA.Domain
{
    public class MachineType
    {
        public int Id { get; set; }

        // e.g. Standbohrmaschine, Fräsmaschine, Schweißgerät, ...
        public string Type { get; set; }

        // Link to the safety instructions.
        public string SafetyInstructions { get; set; }
    }
}
