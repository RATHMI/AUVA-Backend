using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FireApp.Domain;

namespace FireApp.Service.DatabaseOperations.LiteDB
{
    /// <summary>
    /// This class is for querying objects from the LiteDB.
    /// </summary>
    public static class LiteDbQueries
    {      
        /// <summary>
        /// Queries the User from the LiteDB.
        /// </summary>
        /// <returns>Returns the User from the database.</returns>
        public static User QueryUser(string id)
        {
            using (var db = AppData.UserDB())
            {
                var table = db.UserTable();
                return table.FindById(id);
            }
        }

        /// <summary>
        /// Queries the Users from the LiteDB.
        /// </summary>
        /// <returns>Returns all Users from the database.</returns>
        public static IEnumerable<User> QueryUsers()
        {
            using (var db = AppData.UserDB())
            {
                var table = db.UserTable();
                return table.FindAll();
            }
        }

        /// <summary>
        /// Queries the Machine with the given id from the LiteDB
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns the machine from the database.</returns>
        public static Machine QueryMachine(int id)
        {
            using (var db = AppData.MachineDB())
            {
                var table = db.MachineTable();
                return table.FindById(id);
            }
        }
        
        /// <summary>
        /// Queries the Machines from the LiteDB
        /// </summary>
        /// <returns> Returns all Machines from the database.</returns>
        public static IEnumerable<Machine> QueryMachines()
        {
            using (var db = AppData.MachineDB())
            {
                var table = db.MachineTable();
                return table.FindAll();
            }
        }

        /// <summary>
        /// Queries the Room from the LiteDB.
        /// </summary>
        /// <returns>Returns the Room from the database.</returns>
        public static Room QueryRoom(string id)
        {
            using (var db = AppData.UserDB())
            {
                var table = db.RoomTable();
                return table.FindById(id);
            }
        }

        /// <summary>
        /// Queries the Rooms from the LiteDB
        /// </summary>
        /// <returns>Returns all Rooms from the database.</returns>
        public static IEnumerable<Room> QueryRooms()
        {
            using (var db = AppData.RoomDB())
            {
                var table = db.RoomTable();
                return table.FindAll();
            }
        }

        /// <summary>
        /// Queries one specific kind of security clothes from the LiteDB
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns the kind of security clothes from the database with the given id.</returns>
        public static SecurityClothes QuerySecurityClothes(int id)
        {
            using (var db = AppData.SecurityClothesDB())
            {
                var table = db.SecurityClothesTable();
                return table.FindById(id);
            }
        }

        /// <summary>
        /// Queries all the security clothes from the LiteDB
        /// </summary>
        /// <returns>returns all the security clothes from the database.</returns>
        public static IEnumerable<SecurityClothes> QueryAllSecurityClothes()
        {
            using (var db = AppData.SecurityClothesDB())
            {
                var table = db.SecurityClothesTable();
                return table.FindAll();
            }
        }

        /// <summary>
        /// Queries a warning from the LiteDB
        /// </summary>
        /// <param name="id"></param>
        /// <returns>returns the warning with the given id from the database.</returns>
        public static Warning QueryWarning(int id)
        {
            using (var db = AppData.WarningDB())
            {
                var table = db.WarningTable();
                return table.FindById(id);
            }
        }

        /// <summary>
        /// Queries all warnings from the LiteDB
        /// </summary>
        /// <returns>returns all warnings from the database.</returns>
        public static IEnumerable<Warning> QueryWarnings()
        {
            using (var db = AppData.WarningDB())
            {
                var table = db.WarningTable();
                return table.FindAll();
            }
        }

    }
}