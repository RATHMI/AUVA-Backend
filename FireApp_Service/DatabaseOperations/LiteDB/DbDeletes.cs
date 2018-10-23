using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AUVA.Domain;

namespace AUVA.Service.DatabaseOperations.LiteDB
{
    /// <summary>
    /// This class is for deleting objects from the LiteDB.
    /// </summary>
    public static class LiteDbDeletes
    {        
        /// <summary>
        /// Deletes a User from the LiteDB.
        /// </summary>
        /// <param name="userName">The Username of the User you want to delete.</param>
        /// <returns>Returns true if a User was deleted.</returns>
        public static bool DeleteUser(string userName)
        {
            try
            {
                if (userName != null)
                {
                    using (var db = AppData.UserDB())
                    {
                        var table = db.UserTable();
                        if (table.Delete(x => x.Id == userName) > 0)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool DeleteMachine(int machineId)
        {
            try
            {
                using (var db = AppData.MachineDB())
                {
                    var table = db.MachineTable();
                    if (table.Delete(x => x.Id == machineId) > 0)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool DeleteMachineType(int machineTypeId)
        {
            try
            {
                using (var db = AppData.MachineTypeDB())
                {
                    var table = db.MachineTypeTable();
                    if (table.Delete(x => x.Id == machineTypeId) > 0)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool DeleteRoom(string roomId)
        {
            try
            {
                if (roomId != null)
                {
                    using (var db = AppData.RoomDB())
                    {
                        var table = db.RoomTable();
                        if (table.Delete(x => x.Id == roomId) > 0)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool DeleteSecurityClothes(int scId)
        {
            try
            {
                using (var db = AppData.SecurityClothesDB())
                {
                    var table = db.SecurityClothesTable();
                    if (table.Delete(x => x.Id == scId) > 0)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool DeleteWarning(int warningId)
        {
            try
            {
                using (var db = AppData.WarningDB())
                {
                    var table = db.WarningTable();
                    if (table.Delete(x => x.Id == warningId) > 0)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}