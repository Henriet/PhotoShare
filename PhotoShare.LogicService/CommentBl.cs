using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoShare.Domain;
using PhotoShare.Service.Repository;

namespace PhotoShare.LogicService
{
    public class CommentBl : ICommentBl
    {
        private readonly Repository<Comment> _commentRepository;

        public CommentBl()
        {
            _commentRepository = new Repository<Comment>();
        }

        public Comment AddComment(Comment comment)
        {
            try
            {
                return _commentRepository.Insert(comment);
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to add comment");
            }
        }

        public bool DeleteComment(Guid id)
        {
            try
            {
                return _commentRepository.Delete(id);
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to delete comment");
            }
        }

        public Comment GetCommentById(Guid id)
        {
            try
            {
                return _commentRepository.Get(id);
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to get comment by id");
            }
        }

        public bool UpdateComment(Comment comment)
        {
            try
            {
                return _commentRepository.Update(comment);
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to update comment");
            }
        }

        public List<Comment> GetAllComments()
        {
            try
            {
                return _commentRepository.All();
            }
            catch (Exception)
            {
                throw new Exception("Error in BL while attempts to get all comments");
            }
        }
    }
}
