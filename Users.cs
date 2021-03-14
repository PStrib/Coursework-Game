using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Coursework_Game
{
    public class Users
    {

        private static Dictionary<string, User> users;
        public Users()
        {
            if (users == null)
            {
                users = new Dictionary<string, User>();
            }
        }

        public User GetUser(string username, string password)
        {
            User user;
            if (!users.TryGetValue(username, out user))
            {
                throw new Exception("User does not exist");
            }
            byte[] attemptPasswordHash = hash(password);
            if (!user.PasswordHash.SequenceEqual(attemptPasswordHash))
            {
                throw new Exception("Incorrect Password");
            }
            return user;

        }

        private static byte[] hash(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            HashAlgorithm sha = SHA256.Create();
            byte[] attemptPasswordHash = sha.ComputeHash(passwordBytes);
            return attemptPasswordHash;
        }

        public bool HasUser(string username)
        {
            return users.ContainsKey(username);            
        }


        public void AddUser(User user, string password)
        {
            user.PasswordHash = hash(password);
            if (HasUser(user.Username))
            {
                throw new Exception("Username already in use");
            }
            users.Add(user.Username, user);
        }
    }
}
