using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUVA.Domain
{
    public class Machine
    {
        public Machine()
        {
            MachineAdministrators = new HashSet<int>();
            Warnings = new HashSet<int>();
            SecurityClothes = new HashSet<int>();
            Files = new HashSet<string>();
            Defective = false;
        }

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
        public HashSet<string> Files { get; set; }

        // Link to the image on the server.
        public string Picture { get; set; }

        // Machine has a defect.
        public bool Defective { get; set; }

        // Defects that the machine has.
        public string Defects { get; set; }

        //TODO: create a list: when and what were previous defects

        // id of a user
        public int LastMaintainedBy { get; set; }


        public static string GetCsvHeader()
        {
            return "Id;Name;Type;Description;MachineAdministrators;Warnings;SecurityClothes;OperationManual;EmergencyPlan;Files;Picture;Defective;Defects;LastMaintainedBy";
        }

        public static Machine GetFromCsv(string csv)
        {
            Machine m;

            try
            {
                m = new Machine();
                m.Id = Convert.ToInt32(csv.Split(';')[0]);
                m.Name = csv.Split(';')[1];
                m.Type = Convert.ToInt32(csv.Split(';')[2]);
                m.Description = csv.Split(';')[3];

                foreach (string s in csv.Split(';')[4].Split(',')) {
                    m.MachineAdministrators.Add(Convert.ToInt32(s));
                }

                foreach (string s in csv.Split(';')[5].Split(',')) {
                    m.Warnings.Add(Convert.ToInt32(s));
                }

                foreach (string s in csv.Split(';')[6].Split(','))
                {
                    m.SecurityClothes.Add(Convert.ToInt32(s));
                }

                m.OperationManual = csv.Split(';')[7];
                m.EmergencyPlan = csv.Split(';')[8];

                foreach (string s in csv.Split(';')[9].Split(','))
                {
                    m.Files.Add(s);
                }

                m.Picture = csv.Split(';')[10];
                m.Defective = Convert.ToBoolean(csv.Split(';')[11]);
                m.Defects = csv.Split(';')[12];
                m.LastMaintainedBy = Convert.ToInt32(csv.Split(';')[13]);
            }
            catch
            {
                m = null;
            }


            return m;
        }

        public string ToCsv()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(this.Id);
            sb.Append(";");

            sb.Append(this.Name);
            sb.Append(";");

            sb.Append(this.Type);
            sb.Append(";");

            sb.Append(this.Description);
            sb.Append(";");


            for (int i = 0; i < this.MachineAdministrators.Count; i++)
            {
                sb.Append(this.MachineAdministrators.ElementAt(i).ToString());
                if (i != this.MachineAdministrators.Count - 1)
                {
                    sb.Append(",");
                }
            }
            sb.Append(";");

            for (int i = 0; i < this.Warnings.Count; i++)
            {
                sb.Append(this.Warnings.ElementAt(i).ToString());
                if (i != this.Warnings.Count - 1)
                {
                    sb.Append(",");
                }
            }
            sb.Append(";");

            for (int i = 0; i < this.SecurityClothes.Count; i++)
            {
                sb.Append(this.SecurityClothes.ElementAt(i).ToString());
                if (i != this.SecurityClothes.Count - 1)
                {
                    sb.Append(",");
                }
            }
            sb.Append(";");

            sb.Append(this.OperationManual);
            sb.Append(";");

            sb.Append(this.EmergencyPlan);
            sb.Append(";");

            for (int i = 0; i < this.Files.Count; i++)
            {
                sb.Append(this.Files.ElementAt(i).ToString());
                if (i != this.Files.Count - 1)
                {
                    sb.Append(",");
                }
            }
            sb.Append(";");

            sb.Append(this.Picture);
            sb.Append(";");

            sb.Append(this.Defective);
            sb.Append(";");

            sb.Append(this.Defects);
            sb.Append(";");

            sb.Append(this.LastMaintainedBy);


            return sb.ToString();
        }
    }
}
