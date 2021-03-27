using System;
using System.Drawing;

namespace Coursework_Game
{
    [Serializable]
    public class User
    {
        private string username, forename, surname;
        private byte[] passwordHash;
        private Image avatar;

        public override string ToString()
        {
            return $"User({username})";
        }

        public string Username { get => username; set => username = value; }
        public string Forename { get => forename; set => forename = value; }
        public string Surname { get => surname; set => surname = value; }
        public byte[] PasswordHash { get => passwordHash; set => passwordHash = value; }
        public Image Avatar { get => avatar; set => avatar = value; }
    }
}