using AUVA.Domain;
using System;
using System.Collections.Generic;

namespace FireApp.Service.DatabaseOperations
{
    public static class Machines
    {
        public static bool Upsert(Machine machine)
        {
            try
            {
                return AUVA.Service.DatabaseOperations.LiteDB.LiteDbUpserts.UpsertMachine(machine);
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
        public static bool Delete(int machineId)
        {
            return AUVA.Service.DatabaseOperations.LiteDB.LiteDbDeletes.DeleteMachine(machineId);
        }

        /// <summary>
        /// Returns the machine with a matching machineId.
        /// </summary>
        /// <param name="machineId">The machineId of the Machine you are looking for.</param>
        /// <returns>Returns a machine with a matching machineId.</returns>
        public static Machine GetById(int machineId)
        {
            return AUVA.Service.DatabaseOperations.LiteDB.LiteDbQueries.QueryMachine(machineId);
        }

        public static IEnumerable<Machine> GetAll()
        {
            return AUVA.Service.DatabaseOperations.LiteDB.LiteDbQueries.QueryMachines();
        }
    }
}