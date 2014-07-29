#region namespace

using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using PhotoShare.Domain;
using PhotoShare.LogicService;

#endregion

namespace PhotoShare.Controllers
{
    public class HomeController : Controller
    {
        //todo move controllers to separet
        //todo edit html files
        readonly UserBl _userBl = new UserBl();
        CommentBl _commentBl = new CommentBl();
        PhotoBl _photoBl = new PhotoBl();
    

        public ActionResult Index()
        {
            var users = _userBl.GetAllUsers();
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
           
            return View();
        }

        public ActionResult Photo()
        {
            var user = _userBl.GetCurrentUser();
            return View(user);
        }
       

        
        //public ActionResult FileUpload()
        //{
        //    //var repositoryPhotos = _bl.GetAllPhotos();
        //    //var photos = repositoryPhotos.Select(photo => new Photo(photo.UserId, photo.Image)).ToList();
        //    //return View(photos);
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Photo(HttpPostedFileBase file)
        //{
        //    if (!ModelState.IsValid || file == null) return RedirectToAction("Index", "Home");
        //    byte[] imageData;
        //    using (var binaryReader = new BinaryReader(file.InputStream))
        //    {
        //        imageData = binaryReader.ReadBytes(file.ContentLength);
        //    }
        //    var user = _bl.GetUserByName(System.Web.HttpContext.Current.User.Identity.Name);

        //    var photo = new Photo(user.Id, imageData);
        //    _bl.CreatePhoto(user.Id, photo.Image);

        //    //after successfully uploading redirect the user
        //    return RedirectToAction("Photo", "Home");
        //}
    }
}