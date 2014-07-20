using System;
using System.Collections.Generic;

namespace PhotoShare.Service.Entities
{
    public class Photo : Entity
    {
        public Photo(int userId, byte[] image)
        {
            UserId = userId;
            Image = image;
            DateTime = DateTime.Now;
        }

        public Photo()
        {
            DateTime = DateTime.Now;
        }

        public int UserId { get; private set; }
        public List<Comment> Comments { get; set; } 
        public byte[] Image { get; private set; }
        public string Description { get; set; }
        public DateTime DateTime { get; private set; }
    }
}
