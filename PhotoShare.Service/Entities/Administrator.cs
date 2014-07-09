namespace PhotoShare.Service.Entities
{
    public class Administrator : AuthorizedUser
    {
        public Administrator(string name, string surname, string email, string password)
            : base(name, surname, email, password)
        {
            ConfirmPassword = true;
        }
    }
}
