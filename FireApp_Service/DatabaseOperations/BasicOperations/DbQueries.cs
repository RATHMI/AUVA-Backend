using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FireApp.Domain;

namespace FireApp.Service.DatabaseOperations
{
    /// <summary>
    /// This class is for querying objects from the database.
    /// </summary>
    public static class DbQueries
    {
        /// <summary>
        /// Queries a User from the database.
        /// </summary>
        /// <returns>Returns a User with a matching id.</returns>
        public static User QueryUser(string id)
        {
            return LiteDB.LiteDbQueries.QueryUser(id);
        }
    }
}