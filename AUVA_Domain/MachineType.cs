using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUVA.Domain
{
    public class MachineType
    {
        public MachineType(){}
        public MachineType(int id, string type, string safetyInstructions)
        {
            this.Id = id;
            this.Type = type;
            this.SafetyInstructions = safetyInstructions;
        }

        public int Id { get; set; }

        // e.g. Standbohrmaschine, Fräsmaschine, Schweißgerät, ...
        public string Type { get; set; }

        // Link to the safety instructions.
        public string SafetyInstructions { get; set; }

        public static string GetCsvHeader()
        {
            return "Id;Type;SafetyInstructions";
        }

        public static MachineType GetFromCsv(string csv)
        {
            MachineType mt;

            try
            {
                mt = new MachineType(Convert.ToInt32(csv.Split(';')[0]), csv.Split(';')[1], csv.Split(';')[2]);
            }
            catch
            {
                mt = null;
            }


            return mt;
        }

        public string ToCsv()
        {
            return Id.ToString() + ";" + Type + ";" + SafetyInstructions;
        }
    }
}
