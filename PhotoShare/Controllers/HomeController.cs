#region namespace

using System.Web.Mvc;
using PhotoShare.LogicService;

#endregion

namespace PhotoShare.Controllers
{
    public class HomeController : Controller
    {
        //todo move controllers to separet
        //todo edit html files

        private PhotoBl _photoBl;
        private CommentBl _commentBl;
        private readonly UserBl _userBl;


        public HomeController()
        {
            _photoBl = new PhotoBl();
            _userBl = new UserBl();
            _commentBl = new CommentBl();
        }


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

        //public ActionResult Photo()
        //{
        //   // var memberId = WebSecurity.GetUserId(System.Web.HttpContext.Current.User.Identity.Name);
        //    var authorizedUser = _bl.GetUserByName(System.Web.HttpContext.Current.User.Identity.Name);
        //    var user = new User(authorizedUser);

        //    return View(user);
        //}
       

        
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
        //    // считываем переданный файл в массив байтов//todo
        //    using (var binaryReader = new BinaryReader(file.InputStream))
        //    {
        //        imageData = binaryReader.ReadBytes(file.ContentLength);
        //    }
        //    var user = _bl.GetUserByName(System.Web.HttpContext.Current.User.Identity.Name);
            
        //    var photo = new Photo(user.Id, imageData);
        //    _bl.CreatePhoto(user.Id, photo.Image);

        //    //after successfully uploading redirect the user
        //return RedirectToAction("Photo", "Home");
        //}
    }
}