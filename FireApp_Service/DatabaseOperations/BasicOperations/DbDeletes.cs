using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FireApp.Domain;

namespace FireApp.Service.DatabaseOperations
{
    /// <summary>
    /// This class is for deleting objects from the database.
    /// </summary>
    public static class DbDeletes
    {
        /// <summary>
        /// Deletes a User from the database.
        /// </summary>
        /// <param name="id">The id of the User you want to delete.</param>
        /// <returns>Returns true if the User was deleted.</returns>
        public static bool DeleteUser(string id)
        {
            try
            {
                // Delete active FireEvent from remote database.
                return DatabaseOperations.LiteDB.LiteDbDeletes.DeleteUser(id);
            }
            catch (Exception)
            {
                return false;
            }        
        }
    }
}