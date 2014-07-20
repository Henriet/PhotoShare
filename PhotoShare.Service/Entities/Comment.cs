using System;
using System.ComponentModel.DataAnnotations;

namespace PhotoShare.Service.Entities
{
    public class Comment : Entity
    {
        public Comment(string text, AuthorizedUser ownerComment, Photo photo)
        {
            CommentText = text;
            CommentOwner = ownerComment;
            Date = DateTime.Now;
            Photo = photo;
        }

        public Comment()
        {}
        public string CommentText { get; set; }
        public AuthorizedUser CommentOwner { get; private set; }
        public DateTime Date { get; private set; }
        public Photo Photo { get; private set; }

        //todo photoid
    }
}
