using System;

namespace PhotoShare.Domain
{
    public class Comment : Entity
    {
        public Comment(string text, Guid commentOwnerId, Guid photoId)
        {
            CommentText = text;
            CommentOwnerId = commentOwnerId;
            Date = DateTime.Now;
            PhotoId = photoId;
        }

        public Comment()
        {}
        public string CommentText { get; set; }
        public Guid CommentOwnerId { get; private set; }
        public DateTime Date { get; private set; }
        public Guid PhotoId { get; private set; }
    }
}

