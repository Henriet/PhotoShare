using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotoShare.Domain;
using PhotoShare.LogicService;
using User = PhotoShare.Models.User;

namespace PhotoShare.Controllers
{
    public class UserController : Controller
    {
        readonly UserBl _userBl = new UserBl();
        readonly CommentBl _commentBl = new CommentBl();
        readonly PhotoBl _photoBl = new PhotoBl();

        [Authorize]
        public ActionResult Search(string searchString)
        {
            if (String.IsNullOrEmpty(searchString)) return View();
            var searchResult =_userBl.SearchUser(searchString);
            return View(searchResult);
        }

        [Authorize]
        public ActionResult UserProfile(string userName)
        {
            var user = _userBl.SearchUser(userName).First();
            return View(user);
        }


        [Authorize]
        [HttpPost]
        public ActionResult UserProfile(Domain.User user)
        {
            return RedirectToAction("UserProfile","User", new{ userName = _userBl.GetUserById(user.Id).Name});
        }

    }
}
