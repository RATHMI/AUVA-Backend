using FireApp.Domain;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace FireApp.Service {
    public static class AppData {
        static AppData() {
            BsonMapper.Global.Entity<User>()
                .Id(x => x.Id, true);
        }

        #region UserDB
        public static LiteDatabase UserDB() {
            return new LiteDatabase(AppSettings.AuvaDBPath);
        }
        public static LiteCollection<User> UserTable(this LiteDatabase db) {
            return db.GetCollection<User>("user");
        }
        #endregion
    }
}