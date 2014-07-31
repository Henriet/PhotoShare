using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PhotoShare.Domain;

namespace PhotoShare.Domain
{
    public class Photo : Entity, IComparable<Photo>
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


        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public virtual List<Comment> Comments { get; set; } 
        public byte[] Image { get; set; }
        [StringLength(255, ErrorMessage = "Description cannot be longer than 255 characters.")]
        public string Description { get; set; }
        public DateTime DateTime { get; set; }

        public int CompareTo(Photo photoToCompare)
        {
            if (DateTime > photoToCompare.DateTime)
                return -1;
            return DateTime < photoToCompare.DateTime ? 1 : 0;
        }
    }
}
