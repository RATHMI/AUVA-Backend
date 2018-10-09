using FireApp.Domain;
using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FireApp.Service.Controllers {
    public class UserController : ApiController {

        [HttpPost, Route("user/upload")]
        public bool DetailsByCompanyId([FromBody] User fe) {
            using (var db = AppData.UserDB()) {
                var table = db.UserTable();
                return table.Upsert(fe);
            }
        }

        /*
        [HttpGet, Route("inserttest/{name}")]
        public bool DetailsByCompanyId(string name) {
            using (var db = AppData.FireEventDB()) {
                var table = db.FrieEventTable();
                return table.Upsert(new User {
                    At = DateTime.Now,
                    By = "asdasddas",
                    Name = name
                });
            }
        }
        */

        [HttpGet, Route("")]
        public IEnumerable<User> All() {
            using (var db = AppData.UserDB()) {
                var table = db.UserTable();
                return table.FindAll();
            }
        }

        [HttpGet, Route("{name}")]
        public IEnumerable<User> GetName(string name)
        {
            using (var db = AppData.FireEventDB())
            {
                var table = db.FrieEventTable();
                return table.Find(x => x.Name == name);             
            }
        }
    }
}
