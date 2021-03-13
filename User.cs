namespace Coursework_Game
{
    public class User
    {
        private string username, forename, surname;
        private byte[] passwordHash;
        public User()
        {

        }

        public string Username { get => username; set => username = value; }
        public string Forename { get => forename; set => forename = value; }
        public string Surname { get => surname; set => surname = value; }
        public byte[] PasswordHash { get => passwordHash; set => passwordHash = value; }
    }
}