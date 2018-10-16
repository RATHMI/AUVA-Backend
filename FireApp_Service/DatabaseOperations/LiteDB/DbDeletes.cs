using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FireApp.Domain;

namespace FireApp.Service.DatabaseOperations.LiteDB
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

    }
}