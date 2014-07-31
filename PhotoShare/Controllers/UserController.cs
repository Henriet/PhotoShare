using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using PhotoShare.Domain;
using PhotoShare.LogicService;

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
            var user = userName.IsNullOrWhiteSpace() ? _userBl.GetCurrentUser() : _userBl.SearchUser(userName).First();
            return View(user);
        }
        
        [Authorize]
        [HttpPost]
        public ActionResult UserProfile(User user, Photo currentPhoto)
        {
            return RedirectToAction("UserProfile","User", new{ userName = _userBl.GetUserById(user.Id).Name});
        }

        //[Authorize]
        //public ActionResult EditDescription(Guid id)
        //{
        //    var photo = _photoBl.GetPhotoById(id);
        //    return View(photo);
        //}

       
        [Authorize]
        public ActionResult AddFriend(Guid id)
        {
            var currentUser = _userBl.GetCurrentUser();
            var friend = _userBl.GetUserById(id);
            currentUser.Friends.Add(friend);
            _userBl.UpdateUser(currentUser);
            var user = _userBl.GetCurrentUser();
            return RedirectToAction("UserProfile", "User", new { userName = friend.Name });
        }

        [Authorize]
        public ActionResult DeleteFriend(Guid id)
        {
            var currentUser = _userBl.GetCurrentUser();
            var friend = _userBl.GetUserById(id);
            currentUser.Friends.Remove(friend);
            _userBl.UpdateUser(currentUser);

            return RedirectToAction("Friends", "User");
        }

        [Authorize]
        public ActionResult Friends()
        {
            var user = _userBl.GetCurrentUser();
            return View(user);
        }



    }
}
