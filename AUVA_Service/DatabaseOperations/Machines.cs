using AUVA.Domain;
using System;
using System.Collections.Generic;

namespace AUVA.Service.DatabaseOperations
{
    public static class Machines
    {
        public static bool Upsert(Machine machine)
        {
            try
            {
                return LiteDB.LiteDbUpserts.UpsertMachine(machine);
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
            return LiteDB.LiteDbDeletes.DeleteMachine(machineId);
        }

        /// <summary>
        /// Returns the machine with a matching machineId.
        /// </summary>
        /// <param name="machineId">The machineId of the Machine you are looking for.</param>
        /// <returns>Returns a machine with a matching machineId.</returns>
        public static Machine GetById(int machineId)
        {
            return LiteDB.LiteDbQueries.QueryMachine(machineId);
        }

        public static IEnumerable<Machine> GetAll()
        {
            return LiteDB.LiteDbQueries.QueryMachines();
        }

        public static List<string> GetPictograms(int machineId)
        {
            List<string> pictograms;
            Machine m = GetById(machineId);

            try
            {
                pictograms = new List<string>();

                Warning w;
                foreach (int id in m.Warnings)
                {
                    w = DatabaseOperations.Warnings.GetById(id);
                    if(w.Image != String.Empty)
                    {
                        pictograms.Add(w.Image);
                    }
                }

                AUVA.Domain.SecurityClothes s;
                foreach (int id in m.SecurityClothes)
                {
                    s = DatabaseOperations.SecurityClothes.GetById(id);
                    if (s.Image != String.Empty)
                    {
                        pictograms.Add(s.Image);
                    }
                }
            }
            catch
            {
                pictograms = null;
            }

            return pictograms;
        }
    }
}