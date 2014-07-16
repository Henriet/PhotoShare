using System;
using System.ComponentModel.DataAnnotations;

namespace PhotoShare.Service.Entities
{
    public class Comment : Entity
    {
        public Comment(string text, AuthorizedUser ownerComment)
        {
            CommentText = text;
            CommentOwner = ownerComment;
            Date = DateTime.Now;
        }

        public Comment()
        {}
        public string CommentText { get; set; }
        public AuthorizedUser CommentOwner { get; private set; }
        public DateTime Date { get; private set; }
    }
}
