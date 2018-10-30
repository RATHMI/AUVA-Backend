using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AUVA.Domain;

namespace AUVA.Service.DatabaseOperations.LiteDB
{
    /// <summary>
    /// This class is for upserting objects into the LiteDB.
    /// </summary>
    public static class LiteDbUpserts
    {
        /// <summary>
        /// Upserts a User into the LiteDB.
        /// </summary>
        /// <param name="user">The User you want to upsert.</param>
        /// <returns>Returns true if the User was upserted.</returns>
        public static bool UpsertUser(User user)
        {
            if (user != null)
            {
                using (var db = AppData.UserDB())
                {
                    var table = db.UserTable();
                    table.Upsert(user);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool UpsertMachine(Machine machine)
        {
            if (machine != null)
            {
                using (var db = AppData.MachineDB())
                {
                    var table = db.MachineTable();
                    table.Upsert(machine);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool UpsertMachineType(MachineType machinetype)
        {
            if (machinetype != null)
            {
                using (var db = AppData.MachineTypeDB())
                {
                    var table = db.MachineTypeTable();
                    table.Upsert(machinetype);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool UpsertRoom(Room room)
        {
            if (room != null)
            {
                using (var db = AppData.RoomDB())
                {
                    var table = db.RoomTable();
                    table.Upsert(room);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool UpsertSecurityClothes(SecurityClothes sc)
        {
            if (sc != null)
            {
                using (var db = AppData.SecurityClothesDB())
                {
                    var table = db.SecurityClothesTable();
                    table.Upsert(sc);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool UpsertWarnings(Warning warning)
        {
            if (warning != null)
            {
                using (var db = AppData.WarningDB())
                {
                    var table = db.WarningTable();
                    table.Upsert(warning);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}