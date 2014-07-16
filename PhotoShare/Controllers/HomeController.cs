#region

using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotoShare.Models;
using PhotoShare.LogicService;

#endregion

namespace PhotoShare.Controllers
{
    public class HomeController : Controller
    {
        readonly PhotoShareBl _bl = new PhotoShareBl(); 

        public ActionResult Index()
        {
            
           return View();
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
            return View();
        }
       

        [Authorize]
        public ActionResult FileUpload()
        {
            var repositoryPhotos = _bl.GetAllPhotos();
            var photos = repositoryPhotos.Select(photo => new Photo(photo.UserId, photo.Image)).ToList();
            return View(photos);
        }

        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (!ModelState.IsValid || file == null) return RedirectToAction("Index", "Home");
            byte[] imageData;
            // считываем переданный файл в массив байтов
            using (var binaryReader = new BinaryReader(file.InputStream))
            {
                imageData = binaryReader.ReadBytes(file.ContentLength);
            }
            var userId = _bl.CreateAuthorizedUser("nam1", "surname123", "qwerty@mail", "147852");
            _bl.ConfirmPassword(userId);
            var photo = new Photo(userId, imageData);
            _bl.CreatePhoto(userId, photo.Image);

            //after successfully uploading redirect the user
        //return RedirectToAction("Return", "Index", "Home/Index");
        return RedirectToAction("Index", "Home");
        }
    }
}