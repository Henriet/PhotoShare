using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoShare.Models
{
    public class Photo
    {
        public Photo(Guid userId, byte[] image)
        {
            UserId = userId;
            Image = image;
        }
        public Guid UserId { get; private set; }
        public List<Comment> Comments { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public int PhotoId { get; set; }
        public DateTime DateTime { get; set; }
    }
}