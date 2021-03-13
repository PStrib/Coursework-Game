namespace Coursework_Game
{
    public class User
    {
        private string username, forename, surname, password;
        public User()
        {

        }
        public User(string username, string forename, string surname, string password)
        {
            this.username = username;
            this.forename = forename;
            this.surname = surname;
            this.password = password;
        }

        public string Username { get => username; set => username = value; }
        public string Forename { get => forename; set => forename = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Password { get => password; set => password = value; }
    }
}