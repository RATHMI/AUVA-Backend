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
    [RoutePrefix("users")]
    public class UserController : ApiController
    {
        /// <summary>
        /// Inserts a User into the database or updates it if it already exists.
        /// Allows unregistered Users to create a new User.
        /// Allows registered Users to share an authorized object with another User.
        /// </summary>
        /// <param name="u">The User you want to upsert.</param>
        /// <returns>Returns true if the User was inserted.</returns>
        [HttpPost, HttpPut]
        public bool UpsertUser([FromBody] User u)
        {
            try
            {
                if (u == null)
                {
                    throw new ArgumentNullException();
                }

                User user;
                Authentication.Token.CheckAccess(Request.Headers, out user);
                if (user != null && u.Id == user.Id)
                {
                    return DatabaseOperations.Users.Upsert(u);
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
        /// This method generates a new token and 
        /// saves it in the User object with the matching UserLogin. 
        /// </summary>
        /// <param name="login">The login data of a User.</param>
        /// <returns>Returns the token if the login worked or null if not.</returns>
        [HttpPost, Route("authenticate")]
        public string Authenticate([FromBody]UserLogin login)
        {
            try
            {
                return Authentication.Token.RefreshToken(login.Username, login.Password);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Checks if the token of the request is valid.
        /// </summary>
        /// <returns>Returns the user if the token is valid.</returns>
        [HttpGet, Route("self")]
        public User GetUser()
        {
            try
            {
                User user;
                Authentication.Token.CheckAccess(Request.Headers, out user);
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpGet, Route("{id}")]
        public User GetUser(string id)
        {
            try
            {
                User user;
                Authentication.Token.CheckAccess(Request.Headers, out user);
                
                if(user.Type == Usertype.teacher)
                {
                    return DatabaseOperations.Users.GetById(id);
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
        /// Deletes the User from the databases.
        /// </summary>
        /// <param name="userName">Id of the User you want to delete.</param>
        /// <returns>Returns true if User was deleted.</returns>
        [HttpDelete, Route("{username}")]
        public bool DeleteUser(string userName)
        {
            try
            {
                User user;
                Authentication.Token.CheckAccess(Request.Headers, out user);
                if (user != null && user.Id == userName)
                {
                    return DatabaseOperations.Users.Delete(userName);
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
