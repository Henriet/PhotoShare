#region namespace

using System.IO;
using System.Web;
using System.Web.Mvc;
using PhotoShare.Models;
using PhotoShare.LogicService;

#endregion

namespace PhotoShare.Controllers
{
    public class HomeController : Controller
    {
        //todo move controllers to separet
        //todo edit html files

        readonly PhotoShareBl _bl = new PhotoShareBl(); 

        public ActionResult Index()
        {
            var photos = _bl.GetAllPhotos();
            return View(photos);
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
           
            return View();
        }

        public ActionResult Photo()
        {
            var authorizedUser = _bl.GetUserByName(System.Web.HttpContext.Current.User.Identity.Name);
            var user = new User(authorizedUser);

            return View(user);
        }
       

        
        public ActionResult FileUpload()
        {
            //var repositoryPhotos = _bl.GetAllPhotos();
            //var photos = repositoryPhotos.Select(photo => new Photo(photo.UserId, photo.Image)).ToList();
            //return View(photos);
            return View();
        }

        [HttpPost]
        public ActionResult Photo(HttpPostedFileBase file)
        {
            if (!ModelState.IsValid || file == null) return RedirectToAction("Index", "Home");
            byte[] imageData;
            // считываем переданный файл в массив байтов//todo
            using (var binaryReader = new BinaryReader(file.InputStream))
            {
                imageData = binaryReader.ReadBytes(file.ContentLength);
            }
            var user = _bl.GetUserByName(System.Web.HttpContext.Current.User.Identity.Name);
            
            var photo = new Photo(user.Id, imageData);
            _bl.CreatePhoto(user.Id, photo.Image);

            //after successfully uploading redirect the user
        return RedirectToAction("Photo", "Home");
        }
    }
}