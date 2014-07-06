using System;

namespace PhotoShare.Service
{
    public class Comment : Entity
    {
        public Comment(string text, AuthorizedUser ownerComment)
        {
            CommentText = text;
            CommentOwner = ownerComment;
            Date = DateTime.Now;
        }
        public string CommentText { get; private set; }
        public AuthorizedUser CommentOwner { get; private set; }
        public DateTime Date { get; private set; }
    }
}
