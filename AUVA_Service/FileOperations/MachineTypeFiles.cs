using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AUVA.Domain;
using System.Text;

namespace AUVA.Service.FileOperations
{
    public static class FireAlarmSystemFiles
    {

        public static IEnumerable<MachineType> GetMachineTypeFromCSV(byte[] bytes)
        {
            string csv = System.Text.Encoding.Default.GetString(bytes);
            List<MachineType> results = new List<MachineType>();
            MachineType mt;
            try
            {
                foreach (string s in csv.Split('\n'))
                {
                    mt = MachineType.GetFromCsv(s);
                    if (mt != null)
                    {
                        results.Add(mt);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return results;
        }

        public static byte[] ExportToCSV(IEnumerable<MachineType> machinetypes)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(MachineType.GetCsvHeader());
            foreach (MachineType mt in machinetypes)
            {
                sb.AppendLine(mt.ToCsv());
            }

            return Encoding.ASCII.GetBytes(sb.ToString());
        }
    }
}