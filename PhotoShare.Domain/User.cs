using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoShare.Domain
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public virtual List<User> Friends { get; set; }
        
        public virtual List<Photo>Photos { get; set; } 
        public byte[] Avatar { get; set; }
        

        public User(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }

        public User()
        {
        }

        
    }
}
