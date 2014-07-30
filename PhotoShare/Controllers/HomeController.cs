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
        readonly UserBl _userBl = new UserBl();
    

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
    }
}