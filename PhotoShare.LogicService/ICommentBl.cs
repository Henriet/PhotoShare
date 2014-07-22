using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoShare.Domain;

namespace PhotoShare.LogicService
{
    interface ICommentBl
    {
        Comment AddComment(Comment comment);
        bool DeleteComment(Guid id);
        Comment GetCommentById(Guid id);
        bool UpdateComment(Comment comment);
        List<Comment> GetAllComments();
    }
}
