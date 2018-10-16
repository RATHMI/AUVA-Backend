using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FireApp.Domain;

namespace FireApp.Service.DatabaseOperations
{
    /// <summary>
    /// This class is for upserting objects into the database.
    /// </summary>
    public static class DbUpserts
    {       
        /// <summary>
        /// Upserts a User into the database.
        /// </summary>
        /// <param name="user">The User you want to upsert.</param>
        /// <returns>Returns true if the User was upserted.</returns>
        public static bool UpsertUser(User user)
        {
            try
            {     
                // Insert into remote database.                
                return DatabaseOperations.LiteDB.LiteDbUpserts.UpsertUser(user);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}