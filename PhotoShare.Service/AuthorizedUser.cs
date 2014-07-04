using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoShare.Service
{
    public class AuthorizedUser : Guest
    {
        protected string name { get; set; }
        protected string surname { get; set; }
        protected string email { get; set; }
        protected string password { get; set; }
        protected bool confirmPassword { get; set; }

        public AuthorizedUser(string name, string surname, string email, string password)
        {
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.password = password;
            confirmPassword = false;
        }
    }
}
