using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AUVA.Domain;
using MlkPwgen;
using System.Text.RegularExpressions;
using static AUVA.Domain.User;

namespace AUVA.Service.DatabaseOperations
{
    public static class Users
    {
        /// <summary>
        /// Inserts a User into the database or updates it if it already exists.
        /// </summary>
        /// <param name="user">The User you want to upsert.</param>
        /// <returns>Returns true if the User was inserted.</returns>
        public static bool Upsert(User user)
        {
            try
            {
                // Encrypt password.
                user.Password = Encryption.Encrypt.EncryptString(user.Password);

                // Save the User in the database.
                return LiteDB.LiteDbUpserts.UpsertUser(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Deletes a User from all databases.
        /// </summary>
        /// <param name="userName">The Id of the User you want to delete.</param>
        /// <returns>Returns true if the User was deleted.</returns>
        public static bool Delete(string userName)
        {
            return LiteDB.LiteDbDeletes.DeleteUser(userName);           
        }

        /// <summary>
        /// Returns the User with a matching Username.
        /// </summary>
        /// <param name="username">The Username of the User you are looking for.</param>
        /// <returns>Returns a User with a matching Username.</returns>
        public static User GetById(string userName)
        {
            return LiteDB.LiteDbQueries.QueryUser(userName);
        }
    
        public static IEnumerable<User> GetAll()
        {
            return LiteDB.LiteDbQueries.QueryUsers();
        }

        public static void DeleteGuests()
        {
            foreach (User u in GetAll())
            {
                if(u.Type == Usertype.guest)
                {
                    Delete(u.Id);
                }
            }
        }
    }
}