using AUVA.Domain;
using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

        [HttpGet, Route("pictograms/{id}")]
        public HashSet<string> GetPictograms(string id)
        {
            try
            {
                User user;
                AUVA.Service.Authentication.Token.CheckAccess(Request.Headers, out user);
                if (user != null)
                {
                    return DatabaseOperations.Rooms.GetPictograms(id);
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

        [HttpGet, Route("csv")]
        public HttpResponseMessage GetCsv()
        {
            HttpResponseMessage result;
            try
            {
                User user;
                Authentication.Token.CheckAccess(Request.Headers, out user);
                if (user != null)
                {
                    if (user.Type == Usertype.admin)
                    {
                        var stream = new MemoryStream();

                        // Get all rooms.
                        IEnumerable<Room> rooms = DatabaseOperations.Rooms.GetAll();

                        // Convert rooms into a CSV file.
                        byte[] file = FileOperations.RoomFiles.ExportToCSV(rooms);

                        // Write CSV file into the stream.
                        stream.Write(file, 0, file.Length);

                        // Set position of stream to 0 to avoid problems with the index.
                        stream.Position = 0;
                        result = new HttpResponseMessage(HttpStatusCode.OK);

                        // Add the CSV file to the content of the response.
                        result.Content = new ByteArrayContent(stream.ToArray());
                        result.Content.Headers.ContentDisposition =
                            new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                            {
                                FileName = "Users.csv"
                            };
                        result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/csv");
                    }
                    else
                    {
                        // User is not an admin.
                        result = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                        result.Content = null;
                    }
                }
                else
                {
                    // Notify user that the login was not successful.
                    result = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                    result.Content = null;
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return result;
            }
        }

        [HttpPost, Route("csv")] //todo: test
        public HttpResponseMessage UpsertCsv([FromBody] string csv)
        {
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            try
            {
                User user;
                Authentication.Token.CheckAccess(Request.Headers, out user);
                if (user != null)
                {
                    if (user.Type == Usertype.admin)
                    {
                        IEnumerable<Room> rooms;
                        List<byte> bytes = new List<byte>();

                        csv = csv.Trim('"');

                        // Get the rooms from the csv.
                        rooms = FileOperations.RoomFiles.GetFromCSV(csv);

                        // Upsert the Users into the database.
                        int upserted = 0;
                        foreach (Room r in rooms)
                        {
                            if (DatabaseOperations.Rooms.Upsert(r))
                            {
                                upserted++;
                            }
                        }

                        // Sets the content of the response to the number of upserted rooms.
                        result.Content = new ByteArrayContent(Encoding.ASCII.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(upserted)));
                    }
                    else
                    {
                        // The User is not an admin.
                        result = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                        result.Content = null;
                    }
                }
                else
                {
                    // Notify the User that the login was not successful.
                    result = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                    result.Content = null;
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return result;
            }
        }
    }
}
