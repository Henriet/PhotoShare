using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoShare.Models
{
    public class Comment
    {
        public Comment(string text, int ownerCommentId)
        {
            CommentText = text;
            CommentOwnerId = ownerCommentId;
            Date = DateTime.Now;
        }
        public string CommentText { get; set; }
        public int CommentOwnerId { get; private set; }
        public DateTime Date { get; private set; }
    }
}