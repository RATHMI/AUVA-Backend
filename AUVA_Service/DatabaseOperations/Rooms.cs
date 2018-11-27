using AUVA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AUVA.Service.DatabaseOperations
{
    public static class Rooms
    {
        public static bool Upsert(Room room)
        {
            try
            {
                return LiteDB.LiteDbUpserts.UpsertRoom(room);
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
        public static bool Delete(string roomId)
        {
            return LiteDB.LiteDbDeletes.DeleteRoom(roomId);
        }

        /// <summary>
        /// Returns the machine with a matching machineId.
        /// </summary>
        /// <param name="machineId">The machineId of the Machine you are looking for.</param>
        /// <returns>Returns a machine with a matching machineId.</returns>
        public static Room GetById(string roomId)
        {
            return LiteDB.LiteDbQueries.QueryRoom(roomId);
        }

        public static IEnumerable<Room> GetAll()
        {
            return LiteDB.LiteDbQueries.QueryRooms();
        }
    }
}