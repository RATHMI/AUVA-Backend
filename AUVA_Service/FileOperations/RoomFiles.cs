using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AUVA.Domain;
using System.Text;

namespace AUVA.Service.FileOperations
{
    public static class RoomFiles
    {

        public static IEnumerable<Room> GetFromCSV(string csv)
        {
            List<Room> results = new List<Room>();
            Room room;
            try
            {
                foreach (string s in csv.Split('\n'))
                {
                    room = Room.GetFromCsv(s);
                    if (room != null)
                    {
                        results.Add(room);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return results;
        }

        public static byte[] ExportToCSV(IEnumerable<Room> rooms)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Room.GetCsvHeader());
            foreach (Room room in rooms)
            {
                sb.AppendLine(room.ToCsv());
            }

            return Encoding.ASCII.GetBytes(sb.ToString());
        }
    }
}