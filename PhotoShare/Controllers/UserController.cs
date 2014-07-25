using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotoShare.LogicService;

namespace PhotoShare.Controllers
{
    public class UserController : Controller
    {
        readonly UserBl _userBl = new UserBl();
        readonly CommentBl _commentBl = new CommentBl();
        readonly PhotoBl _photoBl = new PhotoBl();

        public ActionResult Search(string searchString)
        {
            if (String.IsNullOrEmpty(searchString)) return View();
            var searchResult =_userBl.SearchUser(searchString);
            return View(searchResult);
        }

        public ActionResult UserProfile(string userName)
        {
            var user = _userBl.GetCurrentUser();
            return View(user);
        }

    }
}
