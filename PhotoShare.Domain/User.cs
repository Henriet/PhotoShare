﻿using System;
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
        public byte[] Avatar { get; set; }
        

        public User(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Photos = new List<Photo>();
            Friends = new List<User>();
        }

        public User()
        {
            Photos = new List<Photo>();
            Friends = new List<User>();
        }

        
    }
}
