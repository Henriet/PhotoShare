using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoShare.Models
{
    public class Administrator : User
    {
        public Administrator(string name, string surname, string email, string password)
            : base(name, surname, email, password)
        {
            ConfirmPassword = true;
        }
    }
}