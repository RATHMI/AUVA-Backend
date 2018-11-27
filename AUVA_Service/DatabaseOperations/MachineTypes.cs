using AUVA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AUVA.Service.DatabaseOperations
{
    public static class MachineTypes
    {
        public static bool Upsert(MachineType machinetype)
        {
            try
            {
                return LiteDB.LiteDbUpserts.UpsertMachineType(machinetype);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Deletes a machinetype from all databases.
        /// </summary>
        /// <param name="machineTypeId">The Id of the machinetype you want to delete.</param>
        /// <returns>Returns true if the machine was deleted.</returns>
        public static bool Delete(int machinetypeId)
        {
            return LiteDB.LiteDbDeletes.DeleteMachineType(machinetypeId);
        }

        /// <summary>
        /// Returns the machinetype with a matching machinetypeId.
        /// </summary>
        /// <param name="machinetypeId">The machinetypeId of the Machinetype you are looking for.</param>
        /// <returns>Returns a machinetype with a matching machineId.</returns>
        public static MachineType GetById(int machinetypeId)
        {
            return LiteDB.LiteDbQueries.QueryMachineType(machinetypeId);
        }

        public static IEnumerable<MachineType> GetAll()
        {
            return LiteDB.LiteDbQueries.QueryMachineTypes();
        }
    }
}