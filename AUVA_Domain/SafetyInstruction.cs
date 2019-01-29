using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUVA.Domain
{
    public class SafetyInstruction
    {
        public SafetyInstruction() {
            this.MonthsValid = 12;
        }

        public DateTime DateOfInstruction { get; set; }

        public MachineType Maschine { get; set; }

        public int MonthsValid { get; set; }

        public bool IsValid()
        {
            return (DateTime.Now.Subtract(DateOfInstruction).TotalDays) <= (MonthsValid * 30) ? true : false;
        }
    }
}
