using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using PhotoShare.LogicService;
using PhotoShare.Models;
using Photo = PhotoShare.Domain.Photo;

namespace PhotoShare.Controllers
{
    public class PhotoController : Controller
    {
        readonly UserBl _userBl = new UserBl();
        readonly CommentBl _commentBl = new CommentBl();
        readonly PhotoBl _photoBl = new PhotoBl();

        //
        // GET: /Photo/
        [Authorize]
        public ActionResult AddPhoto()
        {
            var model = new PhotoModel { UrlPhotoPath = "photoUrl"};
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddPhoto(HttpPostedFileBase file, string photoUrl)
        {
            if (!ModelState.IsValid || (file == null && photoUrl.IsNullOrWhiteSpace())) return RedirectToAction("AddPhoto");
            var imageData = new byte[] {};

            if (file != null)
            {
                using (var binaryReader = new BinaryReader(file.InputStream))
                {
                    imageData = binaryReader.ReadBytes(file.ContentLength);
                }
            }
            else
            {
                Uri uriResult;
                var result = Uri.TryCreate(photoUrl, UriKind.Absolute, out uriResult) &&
                              uriResult.Scheme == Uri.UriSchemeHttp;
                if (result)
                {
                   imageData = DownloadImages(photoUrl);
                }
            }
            if (imageData == null) return RedirectToAction("AddPhotoStepTwo");
            if (!imageData.Any()) return RedirectToAction("AddPhotoStepTwo");
            var user = _userBl.GetCurrentUser();
            var photo = new Models.Photo(user.Id, imageData) {Description = "  "};

            TempData["uploadPhoto"] = photo;
            return RedirectToAction("AddPhotoStepTwo");
        }

        public byte[] DownloadImages(string urlImage)
        {
            var remoteImgPath = urlImage;

            try
            {
                var remoteImgPathUri = new Uri(remoteImgPath);
                var remoteImgPathWithoutQuery = remoteImgPathUri.GetLeftPart(UriPartial.Path);
                var fileExtension = Path.GetExtension(remoteImgPathWithoutQuery); // .jpg, .png
                if (fileExtension != ".jpg" && fileExtension != ".png" && fileExtension != ".gif" &&
                    fileExtension != ".bmp") return null;
                var webClient = new WebClient();
                var dataImage = webClient.DownloadData(urlImage);
                return dataImage;
            }
            catch (Exception )
            {
                return null;
            }
        }

        [Authorize]
        public ActionResult AddPhotoStepTwo()
        {
            var photo =(Models.Photo) TempData["uploadPhoto"];
            photo.Description = " ";
            TempData["photo"] = photo;
            return View(photo);
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddPhotoStepTwo(string description)
        {
           var newDescription = Request.Form[0];
           var photo = (Models.Photo) TempData["photo"];
           var uploadPhoto = new Photo(photo.UserId, photo.Image);
           if (!newDescription.IsNullOrWhiteSpace())
               uploadPhoto.Description = newDescription;
            _photoBl.CreatePhoto(uploadPhoto);

            return RedirectToAction("AddPhoto");

        }


        [Authorize]
        public ActionResult PhotoShare()
        {

            return View();
        }

    }
}
