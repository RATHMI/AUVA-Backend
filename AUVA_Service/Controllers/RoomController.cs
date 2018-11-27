using AUVA.Domain;
using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AUVA.Service.Controllers {
    [RoutePrefix("rooms")]
    public class RoomController : ApiController
    {
        /// <summary>
        /// Inserts a Machine into the database or updates it if it already exists.
        /// Allows unregistered Users to create a new User.
        /// Allows registered Users to share an authorized object with another User.
        /// </summary>
        /// <param name="u">The User you want to upsert.</param>
        /// <returns>Returns true if the User was inserted.</returns>
        [HttpPost, HttpPut, Route("")]
        public bool UpsertRoom([FromBody] Room r)
        {
            try
            {
                if (r == null)
                {
                    throw new ArgumentNullException();
                }

                User user;
                AUVA.Service.Authentication.Token.CheckAccess(Request.Headers, out user);
                if (user != null)
                {
                    return DatabaseOperations.Rooms.Upsert(r);
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            catch (Exception)
            {
                return false;
            }    

        }

        /// <summary>
        /// Checks if the token of the request is valid.
        /// </summary>
        /// <returns>Returns the machine if the token is valid.</returns>
        [HttpGet, Route("{id}")]
        public Room GetRoom(string id)
        {
            try
            {
                User user;
                AUVA.Service.Authentication.Token.CheckAccess(Request.Headers, out user);
                if (user != null)
                {
                    return DatabaseOperations.Rooms.GetById(id); 
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Returns all the machines from the database.
        /// </summary>
        /// <returns>every machine object from the LiteDB.</returns>
        [HttpGet, Route("")]
        public IEnumerable<Room> GetRooms()
        {
            try
            {
                User user;
                AUVA.Service.Authentication.Token.CheckAccess(Request.Headers, out user);
                if (user != null)
                {
                    return DatabaseOperations.Rooms.GetAll();
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            catch (Exception)
            {
                return null;
            }
           
        }

        /// <summary>
        /// Deletes the Machine from the databases.
        /// </summary>
        /// <param name="machineId">Id of the Machine you want to delete.</param>
        /// <returns>Returns true if Machine was deleted.</returns>
        [HttpDelete, Route("{roomId}")]
        public bool DeleteRoom(string roomId)
        {
            try
            {
                User user;
                AUVA.Service.Authentication.Token.CheckAccess(Request.Headers, out user);
                if (user != null)
                {
                    return DatabaseOperations.Rooms.Delete(roomId);
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }             
       
    }
}
