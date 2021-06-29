namespace BxlForm.DemoSecurity.Mvc.Models.Client.Data
{
    public class User
    {
        public int Id { get; private set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Passwd { get; private set; }
        public bool IsAdmin { get; private set; }
        public string Token { get; private set; }

        public User(string lastName, string firstName, string email, string passwd)
        {
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            Passwd = passwd;
        }

        internal User(int id, string lastName, string firstName, string email, bool isAdmin, string token)
            : this(lastName, firstName, email, null)
        {
            Id = id;
            IsAdmin = isAdmin;
            Token = token;
        }
    }
}
