using AUVA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AUVA.Service.DatabaseOperations
{
    public static class Warnings
    {
        public static bool Upsert(Warning warning)
        {
            try
            {
                return LiteDB.LiteDbUpserts.UpsertWarnings(warning);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Deletes a machine from all databases.
        /// </summary>
        /// <param name="machineId">The Id of the machine you want to delete.</param>
        /// <returns>Returns true if the machine was deleted.</returns>
        public static bool Delete(int warningId)
        {
            return LiteDB.LiteDbDeletes.DeleteWarning(warningId);
        }

        /// <summary>
        /// Returns the machine with a matching machineId.
        /// </summary>
        /// <param name="machineId">The machineId of the Machine you are looking for.</param>
        /// <returns>Returns a machine with a matching machineId.</returns>
        public static Warning GetById(int warningId)
        {
            return LiteDB.LiteDbQueries.QueryWarning(warningId);
        }

        public static IEnumerable<Warning> GetAll()
        {
            return LiteDB.LiteDbQueries.QueryWarnings();
        }
    }
}