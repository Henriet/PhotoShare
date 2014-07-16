using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoShare.Models
{
    public class Comment
    {
        public Comment(string text, User ownerComment)
        {
            CommentText = text;
            CommentOwner = ownerComment;
            Date = DateTime.Now;
        }
        public string CommentText { get; set; }
        public User CommentOwner { get; private set; }
        public DateTime Date { get; private set; }
    }
}