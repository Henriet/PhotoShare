namespace PhotoShare.Service.Entities
{
    public class Administrator : AuthorizedUser
    {
        public Administrator(string name, string surname, string email)
            : base(name, surname, email)
        {
            ConfirmPassword = true;
        }

        public Administrator()
        {}
    }
}
