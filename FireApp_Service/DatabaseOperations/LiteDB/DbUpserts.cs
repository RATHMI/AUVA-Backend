using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FireApp.Domain;

namespace FireApp.Service.DatabaseOperations.LiteDB
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
    }
}