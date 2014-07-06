namespace PhotoShare.Service
{
    public class AuthorizedUser : Guest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool ConfirmPassword { get; set; }
        

        public AuthorizedUser(string name, string surname, string email, string password)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            ConfirmPassword = false;
        }
    }
}
