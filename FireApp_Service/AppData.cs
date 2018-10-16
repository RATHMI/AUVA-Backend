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

            BsonMapper.Global.Entity<Machine>()
                .Id(x => x.Id, true);

            BsonMapper.Global.Entity<MachineType>()
                .Id(x => x.Id, true);

            BsonMapper.Global.Entity<Room>()
                .Id(x => x.Id, true);

            BsonMapper.Global.Entity<SecurityClothes>()
                .Id(x => x.Id, true);

            BsonMapper.Global.Entity<Warning>()
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

        #region MachineDB
        public static LiteDatabase MachineDB()
        {
            return new LiteDatabase(AppSettings.AuvaDBPath);
        }
        public static LiteCollection<Machine> MachineTable(this LiteDatabase db)
        {
            return db.GetCollection<Machine>("machine");
        }
        #endregion

        #region MachineTypeDB
        public static LiteDatabase MachineTypeDB()
        {
            return new LiteDatabase(AppSettings.AuvaDBPath);
        }
        public static LiteCollection<MachineType> MachineTypeTable(this LiteDatabase db)
        {
            return db.GetCollection<MachineType>("machineType");
        }
        #endregion

        #region RoomDB
        public static LiteDatabase RoomDB()
        {
            return new LiteDatabase(AppSettings.AuvaDBPath);
        }
        public static LiteCollection<Room> RoomTable(this LiteDatabase db)
        {
            return db.GetCollection<Room>("room");
        }
        #endregion

        #region SecurityClothesDB
        public static LiteDatabase SecurityClothesDB()
        {
            return new LiteDatabase(AppSettings.AuvaDBPath);
        }
        public static LiteCollection<SecurityClothes> SecurityClothesTable(this LiteDatabase db)
        {
            return db.GetCollection<SecurityClothes>("securityClothes");
        }
        #endregion

        #region WarningDB
        public static LiteDatabase WarningDB()
        {
            return new LiteDatabase(AppSettings.AuvaDBPath);
        }
        public static LiteCollection<Warning> WarningTable(this LiteDatabase db)
        {
            return db.GetCollection<Warning>("warning");
        }
        #endregion
    }
}