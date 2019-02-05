using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUVA.Domain
{
    public class Room
    {
        public Room()
        {
            Machines = new HashSet<int>();
        }

        // RoomNumber
        public string Id { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        // Link to the emergancy plan on the server.
        public string EmergencyPlan { get; set; }

        // Link to the list of first responders on the server.
        public string FirstResponders { get; set; }

        public HashSet<int> Machines { get; set; }

        //todo: Method that returns all pictogramms

        // Link
        public string GuestInfo { get; set; }

        public static Room GetFromCsv(string s)
        {
            Room room;

            try
            {
                room = new Room();

                room.Id = s.Split(';')[0];
                room.Description = s.Split(';')[1];
                room.Image = s.Split(';')[2];
                room.EmergencyPlan = s.Split(';')[3];
                room.FirstResponders = s.Split(';')[4];

                foreach(string machine in (s.Split(';')[5]).Split(','))
                {
                    room.Machines.Add(Convert.ToInt32(machine));
                }

                room.GuestInfo = s.Split(';')[6];
            }
            catch
            {
                room = null;
            }

            return room;
        }

        public static string GetCsvHeader()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Id");
            sb.Append(";");
            sb.Append("Description");
            sb.Append(";");
            sb.Append("Image");
            sb.Append(";");
            sb.Append("EmergencyPlan");
            sb.Append(";");
            sb.Append("FirstResponders");
            sb.Append(";");
            sb.Append("Machines");
            sb.Append(";");
            sb.Append("GuestInfo");

            return sb.ToString();
        }

        public string ToCsv()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(this.Id);
            sb.Append(";");
            sb.Append(this.Description);
            sb.Append(";");
            sb.Append(this.Image);
            sb.Append(";");
            sb.Append(this.EmergencyPlan);
            sb.Append(";");
            sb.Append(this.FirstResponders);
            sb.Append(";");

            for(int i = 0; i < this.Machines.Count; i++)
            {
                sb.Append(this.Machines.ElementAt(i).ToString());
                if(i != this.Machines.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append(";");
            sb.Append(this.GuestInfo);

            return sb.ToString();
        }
    }
}
