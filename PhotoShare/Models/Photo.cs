using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoShare.Models
{
    public class Photo
    {
        public Photo(int userId, byte[] image)
        {
            UserId = userId;
            Image = image;
        }
        public int UserId { get; private set; }
        public List<Comment> Comments { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int PhotoId { get; set; }
    }
}