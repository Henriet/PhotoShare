using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PhotoShare.Domain;
using PhotoShare.LogicService;
using WebMatrix.WebData;

namespace PhotoShare.Controllers
{
    public class AdministratorController : Controller
    {
        readonly UserBl _userBl = new UserBl();
        readonly CommentBl _commentBl = new CommentBl();
        readonly PhotoBl _photoBl = new PhotoBl();
        
        // GET: /Administrator/

        public ActionResult Index()
        {
            //if (!User.IsInRole("admin"))
            //    return RedirectToAction("NoAccess");

            return View();
        }

        public ActionResult Users()
        {
            if (!User.IsInRole("admin"))
                return RedirectToAction("NoAccess");
            var users = _userBl.GetAllUsers();
            return View(users);
        }

        public ActionResult DeleteUser(Guid id)
        {
            var user = _userBl.GetUserById(id);
            Membership.Provider.DeleteUser(user.Name, true);
            _userBl.DeleteUser(id);
            return RedirectToAction("Users");
        }

        public ActionResult Comments()
        {
            if (!User.IsInRole("admin"))
                return RedirectToAction("NoAccess");

            var comments = _commentBl.GetAllComments();
            comments.Sort();
            return View(comments);
        }

        public ActionResult DeleteComment(Guid id)
        {
            _commentBl.DeleteComment(id);
            return RedirectToAction("Comments");
        }

        public ActionResult EditComment(Guid id)
        {
            var comment = _commentBl.GetCommentById(id);
            return View(comment);
        }

        [HttpPost]
        public ActionResult EditComment(Comment comment)
        {
            var editComment = _commentBl.GetCommentById(comment.Id);
            editComment.CommentText = comment.CommentText;
            _commentBl.UpdateComment(editComment);
            return RedirectToAction("Comments");
        }

        public ActionResult Posts()
        {
            if (!User.IsInRole("admin"))
                return RedirectToAction("NoAccess");

            return View();
        }

        public ActionResult StaticPages()
        {
            if (!User.IsInRole("admin"))
                return RedirectToAction("NoAccess");

            return View();
        }

        public ActionResult NoAccess()
        {
            return View();
        }

    }
}
