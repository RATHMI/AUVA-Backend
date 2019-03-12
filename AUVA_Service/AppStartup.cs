using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Net.Http.Formatting;
using Newtonsoft.Json.Serialization;
using System.Web;
using Microsoft.Owin.Cors;
using AUVA.Domain;

[assembly: OwinStartup(typeof(AUVA.Service.AppStartup))]
namespace AUVA.Service {
    public class AppStartup {
        public void Configuration(IAppBuilder app) {
            var config = new HttpConfiguration();

            app.UseCors(CorsOptions.AllowAll);

            // Web API configuration and services
            config.Formatters.Clear();
            var jsonFormatter = new JsonMediaTypeFormatter();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.Add(jsonFormatter);
            // Web API routes
            config.MapHttpAttributeRoutes();

            app.UseWebApi(config);

            User admin = new User();
            admin.Id = "admin";
            admin.Password = "admin";
            admin.Type = Usertype.admin;

            User phice = new User();
            phice.Id = "phice";
            phice.Password = "phice";
            phice.Type = Usertype.admin;

            User bauerbaerli = new User();
            bauerbaerli.Id = "bauerbaerli";
            bauerbaerli.Password = "bauerbaerli";
            bauerbaerli.Type = Usertype.admin;

            User turtlebear = new User();
            turtlebear.Id = "turtlebear";
            turtlebear.Password = "turtlebear";
            turtlebear.Type = Usertype.admin;
            

            DatabaseOperations.Users.Upsert(admin);
            DatabaseOperations.Users.Upsert(phice);
            DatabaseOperations.Users.Upsert(bauerbaerli);
            DatabaseOperations.Users.Upsert(turtlebear);

            DatabaseOperations.MachineTypes.Upsert(new MachineType(1, "Säulenbohrmaschine", ""));
            DatabaseOperations.MachineTypes.Upsert(new MachineType(2, "Tischbohrmaschine", ""));
            DatabaseOperations.MachineTypes.Upsert(new MachineType(3, "Schleifmaschine", ""));

            Room w13m = DatabaseOperations.Rooms.GetById("W13M");

            if(w13m != null)
            {
                // Machine 1
                Machine m1 = new Machine();
                m1.Id = 1;
                m1.Defective = false;
                m1.Defects = "";
                m1.Description = "Säulenbohrmaschine der Firma Alzmetall";
                m1.EmergencyPlan = "http://192.168.95.196:51337/Data/Rooms/emergency_plan.pdf";
                m1.LastMaintainedBy = 1;
                m1.MachineAdministrators = null;
                m1.Name = "Säulenbohrmaschine Alzmetall";
                m1.OperationManual = "";
                m1.Picture = "http://192.168.95.196:51337/Data/Machines/Raum_W13M/Saeulenbohrmaschine_Alzmetall.JPG";
                m1.SecurityClothes.Add(2);
                m1.SecurityClothes.Add(8);
                m1.SecurityClothes.Add(3);
                m1.SecurityClothes.Add(5);
                m1.Type = 1;
                m1.Warnings.Add(9);
                m1.Warnings.Add(10);

                DatabaseOperations.Machines.Upsert(m1);
                w13m.Machines.Add(m1.Id);
                DatabaseOperations.Rooms.Upsert(w13m);

                //Machine 2
                Machine m2 = new Machine();
                m2.Id = 2;
                m2.Defective = false;
                m2.Defects = "";
                m2.Description = "Säulenbohrmaschine \"Flott\" M3";
                m2.EmergencyPlan = "http://192.168.95.196:51337/Data/Rooms/emergency_plan.pdf";
                m2.LastMaintainedBy = 1;
                m2.MachineAdministrators = null;
                m2.Name = "Säulenbohrmaschine Flott M3";
                m2.OperationManual = "";
                m2.Picture = "http://192.168.95.196:51337/Data/Machines/Raum_W13M/Saeulenbohrmaschine_FlottM3.JPG";
                m2.SecurityClothes.Add(2);
                m2.SecurityClothes.Add(8);
                m2.SecurityClothes.Add(3);
                m2.SecurityClothes.Add(5);
                m2.Type = 1;
                m2.Warnings.Add(9);
                m2.Warnings.Add(10);

                DatabaseOperations.Machines.Upsert(m2);
                w13m.Machines.Add(m2.Id);
                DatabaseOperations.Rooms.Upsert(w13m);


                //Machine 3
                Machine m3 = new Machine();
                m3.Id = 3;
                m3.Defective = false;
                m3.Defects = "";
                m3.Description = "Säulenbohrmaschine Maxion";
                m3.EmergencyPlan = "http://192.168.95.196:51337/Data/Rooms/emergency_plan.pdf";
                m3.LastMaintainedBy = 1;
                m3.MachineAdministrators = null;
                m3.Name = "Säulenbohrmaschine Maxion";
                m3.OperationManual = "";
                m3.Picture = "http://192.168.95.196:51337/Data/Machines/Raum_W13M/Saeulenbohrmaschine_Maxion.JPG";
                m3.SecurityClothes.Add(2);
                m3.SecurityClothes.Add(8);
                m3.SecurityClothes.Add(3);
                m3.SecurityClothes.Add(5);
                m3.Type = 1;
                m3.Warnings.Add(9);
                m3.Warnings.Add(10);

                DatabaseOperations.Machines.Upsert(m3);
                w13m.Machines.Add(m3.Id);
                DatabaseOperations.Rooms.Upsert(w13m);


                //Machine 4
                Machine m4 = new Machine();
                m4.Id = 4;
                m4.Defective = false;
                m4.Defects = "";
                m4.Description = "Säulenbohrmaschine Unbekannter Hersteller";
                m4.EmergencyPlan = "http://192.168.95.196:51337/Data/Rooms/emergency_plan.pdf";
                m4.LastMaintainedBy = 1;
                m4.MachineAdministrators = null;
                m4.Name = "Säulenbohrmaschine Unbekannt";
                m4.OperationManual = "";
                m4.Picture = "http://192.168.95.196:51337/Data/Machines/Raum_W13M/Saeulenbohrmaschine2.JPG";
                m4.SecurityClothes.Add(2);
                m4.SecurityClothes.Add(8);
                m4.SecurityClothes.Add(3);
                m4.SecurityClothes.Add(5);
                m4.Type = 1;
                m4.Warnings.Add(9);
                m4.Warnings.Add(10);

                DatabaseOperations.Machines.Upsert(m4);
                w13m.Machines.Add(m4.Id);
                DatabaseOperations.Rooms.Upsert(w13m);



                //Machine 5
                Machine m5 = new Machine();
                m5.Id = 5;
                m5.Defective = false;
                m5.Defects = "";
                m5.Description = "Säulenbohrmaschine Unbekannter Hersteller";
                m5.EmergencyPlan = "http://192.168.95.196:51337/Data/Rooms/emergency_plan.pdf";
                m5.LastMaintainedBy = 1;
                m5.MachineAdministrators = null;
                m5.Name = "Säulenbohrmaschine Unbekannt";
                m5.OperationManual = "";
                m5.Picture = "http://192.168.95.196:51337/Data/Machines/Raum_W13M/Saeulenbohrmaschine.JPG";
                m5.SecurityClothes.Add(2);
                m5.SecurityClothes.Add(8);
                m5.SecurityClothes.Add(3);
                m5.SecurityClothes.Add(5);
                m5.Type = 1;
                m5.Warnings.Add(9);
                m5.Warnings.Add(10);

                DatabaseOperations.Machines.Upsert(m5);
                w13m.Machines.Add(m5.Id);
                DatabaseOperations.Rooms.Upsert(w13m);


                //Machine 6
                Machine m6 = new Machine();
                m6.Id = 6;
                m6.Defective = false;
                m6.Defects = "";
                m6.Description = "Schleifmaschine Reichmann&Sohn";
                m6.EmergencyPlan = "http://192.168.95.196:51337/Data/Rooms/emergency_plan.pdf";
                m6.LastMaintainedBy = 1;
                m6.MachineAdministrators = null;
                m6.Name = "Schleifmaschine Reichmann&Sohn";
                m6.OperationManual = "";
                m6.Picture = "http://192.168.95.196:51337/Data/Machines/Raum_W13M/Schleifmaschine_ReichmannUndSohn.JPG";
                m6.SecurityClothes.Add(2);
                m6.SecurityClothes.Add(8);
                m6.SecurityClothes.Add(3);
                m6.SecurityClothes.Add(5);
                m6.Type = 3;
                m6.Warnings.Add(9);
                m6.Warnings.Add(10);

                DatabaseOperations.Machines.Upsert(m6);
                w13m.Machines.Add(m6.Id);
                DatabaseOperations.Rooms.Upsert(w13m);



                //Machine 7
                Machine m7 = new Machine();
                m7.Id = 7;
                m7.Defective = false;
                m7.Defects = "";
                m7.Description = "Tischbohrmaschine 13Plus";
                m7.EmergencyPlan = "http://192.168.95.196:51337/Data/Rooms/emergency_plan.pdf";
                m7.LastMaintainedBy = 1;
                m7.MachineAdministrators = null;
                m7.Name = "Tischbohrmaschine 13Plus";
                m7.OperationManual = "";
                m7.Picture = "http://192.168.95.196:51337/Data/Machines/Raum_W13M/Tischbohrmaschine_13Plus.JPG";
                m7.SecurityClothes.Add(2);
                m7.SecurityClothes.Add(8);
                m7.SecurityClothes.Add(3);
                m7.SecurityClothes.Add(5);
                m7.Type = 2;
                m7.Warnings.Add(9);
                m7.Warnings.Add(10);

                DatabaseOperations.Machines.Upsert(m7);
                w13m.Machines.Add(m7.Id);
                DatabaseOperations.Rooms.Upsert(w13m);
            }

        }
    }
}
