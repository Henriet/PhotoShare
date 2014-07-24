using System;
using System.Collections.Generic;

namespace PhotoShare.Domain
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public List<User> Friends { get; set; } 
        public List<Photo>Photos { get; set; } 
        public Photo Avatar { get; set; }
        

        public User(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
           // Id = id;
        }

        public User(){}

        
    }
}
