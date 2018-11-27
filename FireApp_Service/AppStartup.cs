﻿using System;
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

            Machine m = new Machine();
            m.Id = 1;
            m.Name = "Testmaschine";

            Room room = new Room();
            room.Id = "4-57";
            room.Description = "testroom";
            room.Machines.Add(m.Id);
            

            DatabaseOperations.Users.Upsert(admin);
            DatabaseOperations.Machines.Upsert(m);
            DatabaseOperations.Rooms.Upsert(room);
        }
    }
}
