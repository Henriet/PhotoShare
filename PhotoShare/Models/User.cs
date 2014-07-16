using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoShare.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool ConfirmPassword { get; set; }
        public List<User> Friends { get; set; } 
        public List<Photo>Photos { get; set; } 
        public Photo Avatar { get; set; }


        public User(string name, string surname, string email, string password)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            ConfirmPassword = false;
        }
    }
}