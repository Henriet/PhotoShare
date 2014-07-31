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
            return View(photo);
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddPhotoStepTwo(Photo photo)
        {
            photo.UserId = _userBl.GetCurrentUser().Id;
            photo.DateTime = DateTime.Now;
            _photoBl.CreatePhoto(photo);
            return RedirectToAction("AddPhoto");

        }


        [Authorize]
        public ActionResult PhotoShare()
        {
            var user = _userBl.GetCurrentUser();
            var photos = user.Photos;
            if (!user.Friends.Any()) return View(photos);
            foreach (var friend in user.Friends.Where(friend => friend.Photos.Any()))
            {
                photos.AddRange(friend.Photos);
            }
            photos.Sort();
            return View(photos);
        }


        [Authorize]
        public ActionResult EditDescription(Photo photo)
        {
            if (!ModelState.IsValid) return RedirectToAction("UserProfile", "User", new { userName = _userBl.GetCurrentUser().Name });
            try
            {
                var _photo = _photoBl.GetPhotoById(photo.Id);
                // photo.Description = description;
                _photoBl.UpdatePhoto(photo);

                return RedirectToAction("UserProfile", "User", new { userName = _userBl.GetCurrentUser().Name });
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }

            // If we got this far, something failed, redisplay form
            return View(ModelState);
        }

        [Authorize]
        public ActionResult DeleteImage(Guid id)
        {
            _photoBl.DeletePhoto(id);
            return RedirectToAction("UserProfile", "User", new { userName = _userBl.GetCurrentUser().Name });
        }





    }
}
