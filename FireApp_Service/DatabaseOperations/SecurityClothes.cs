using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AUVA.Domain;

namespace AUVA.Service.DatabaseOperations
{
    public static class SecurityClothes
    {
        public static bool Upsert(AUVA.Domain.SecurityClothes sc)
        {
            try
            {
                return LiteDB.LiteDbUpserts.UpsertSecurityClothes(sc);
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
        public static bool Delete(int scId)
        {
            return LiteDB.LiteDbDeletes.DeleteSecurityClothes(scId);
        }

        /// <summary>
        /// Returns the machine with a matching machineId.
        /// </summary>
        /// <param name="machineId">The machineId of the Machine you are looking for.</param>
        /// <returns>Returns a machine with a matching machineId.</returns>
        public static AUVA.Domain.SecurityClothes GetById(int scId)
        {
            return LiteDB.LiteDbQueries.QuerySecurityClothes(scId);
        }

        public static IEnumerable<AUVA.Domain.SecurityClothes> GetAll()
        {
            return LiteDB.LiteDbQueries.QueryAllSecurityClothes();
        }
    }
}