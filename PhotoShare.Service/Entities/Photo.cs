using System.Collections.Generic;

namespace PhotoShare.Service.Entities
{
    public class Photo : Entity
    {
        public Photo(int userId, byte[] image)
        {
            UserId = userId;
            Image = image;
        }
        public Photo()
        {}

        public int UserId { get; private set; }
        public List<Comment> Comments { get; set; } 
        public byte[] Image { get; private set; }
        public string Description { get; set; }
    }
}
