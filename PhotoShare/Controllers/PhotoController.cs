using System;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Mvc;
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
        public ActionResult Index()
        {
            var model = new PhotoModel { UrlPhotoPath = "photoUrl", Description = "photoDescription" };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, string photoUrl)
        {
            if (!ModelState.IsValid || (file == null && photoUrl.IsNullOrWhiteSpace())) return RedirectToAction("Index", "Home");
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
            
            var user = _userBl.GetCurrentUser();
            var photo = new Photo(user.Id, imageData);
            _photoBl.CreatePhoto(photo);


            //after successfully uploading redirect the user
            return RedirectToAction("Index", "Home");
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
        public ActionResult PhotoShare()
        {

            return View();
        }

    }
}
