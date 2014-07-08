using System.Collections.Generic;
using PhotoShare.Service.Entities;

namespace PhotoShare.Service
{
    public class Photo : Entity
    {
        public Photo(int userId, byte[] image)
        {
            UserId = userId;
            Image = image;
        }
        public int UserId { get; private set; }
        public List<Comment> Comments { get; set; } 
        public byte[] Image { get; private set; }
        public string Description { get; set; }
    }
}
