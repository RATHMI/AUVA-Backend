using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUVA.Domain
{
    public class Machine
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Type { get; set; }

        public string Description { get; set; }

        public HashSet<int> MachineAdministrators { get; set; }

        public HashSet<int> Warnings { get; set; }

        public HashSet<int> SecurityClothes { get; set; }

        // Link to the operation manual on the server.
        public string OperationManual { get; set; }

        // Link to the emergancy plan on the server.
        public string EmergencyPlan { get; set; }

        // Link to the files on the server.
        public string Files { get; set; }

        // Link to the image on the server.
        public string Picture { get; set; }

        public bool Defective { get; set; }
        public string Defects { get; set; }

        public int LastMaintainedBy { get; set; }

        public Machine()
        {
            Defective = false;
        }
    }
}
