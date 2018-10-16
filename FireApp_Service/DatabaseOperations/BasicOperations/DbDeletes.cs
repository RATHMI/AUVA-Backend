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
        /// Deletes an active FireEvent from the database.
        /// </summary>
        /// <param name="fe">The FireEvent you want to delete.</param>
        /// <returns>Returns true if the FireEvent was deleted.</returns>
        public static bool DeleteUser(FireEvent fe)
        {
            try
            {
                // Delete active FireEvent from local database.
                LocalDatabase.DeleteActiveFireEvent(fe);

                // Delete active FireEvent from remote database.
                return DatabaseOperations.LiteDB.LiteDbDeletes.DeleteActiveFireEvent(fe);
            }
            catch (Exception)
            {
                return false;
            }        
        }

        

    }
}