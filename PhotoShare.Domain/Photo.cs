using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PhotoShare.Domain;

namespace PhotoShare.Domain
{
    public class Photo : Entity
    {
        public Photo(Guid userId, byte[] image)
        {
            UserId = userId;
            Image = image;
            DateTime = DateTime.Now;
            Description = " ";
        }

        public Photo()
        {}


        public Guid UserId { get; private set; }
        public virtual User User { get; set; }

        public virtual List<Comment> Comments { get; set; } 
        public byte[] Image { get; set; }
        [StringLength(255, ErrorMessage = "First name cannot be longer than 255 characters.")]
        public string Description { get; set; }
        public DateTime DateTime { get; private set; }
    }
}
