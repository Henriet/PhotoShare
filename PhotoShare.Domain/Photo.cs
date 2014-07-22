using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PhotoShare.Domain;

namespace PhotoShare.Domain
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
        [MaxLength(255)]
        public string Description { get; set; }
        public DateTime DateTime { get; private set; }
    }
}
