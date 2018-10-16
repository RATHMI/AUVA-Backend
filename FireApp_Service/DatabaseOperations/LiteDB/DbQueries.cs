﻿using System;
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
        /// Queries all Users from the LiteDB.
        /// </summary>
        /// <returns>Returns a list with all Users from database.</returns>
        public static IEnumerable<User> QueryUsers()
        {
            using (var db = AppData.UserDB())
            {
                var table = db.UserTable();
                return table.FindAll();
            }
        }

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
    }
}