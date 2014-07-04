using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoShare.Service
{
    public class Administrator : AuthorizedUser
    {
        public Administrator(string name, string surname, string email, string password)
            : base(name, surname, email, password)
        {
            confirmPassword = true;
        }
    }
}
