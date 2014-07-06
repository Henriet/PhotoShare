using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
