using AUVA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace AUVA.Service.FileOperations
{
    public class MachineFiles
    {
        public static IEnumerable<Machine> GetFromCSV(string csv)
        {
            List<Machine> results = new List<Machine>();
            Machine machine;
            try
            {
                foreach (string s in csv.Split('\n'))
                {
                    machine = Machine.GetFromCsv(s);
                    if (machine != null)
                    {
                        results.Add(machine);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return results;
        }

        public static byte[] ExportToCSV(IEnumerable<Machine> machines)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Machine.GetCsvHeader());
            foreach (Machine machine in machines)
            {
                sb.AppendLine(machine.ToCsv());
            }

            return Encoding.ASCII.GetBytes(sb.ToString());
        }
    }
}