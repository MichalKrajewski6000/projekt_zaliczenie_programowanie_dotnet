using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projekt_Blog.Models;

namespace Projekt_Blog.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorise(user user)
        {
                using (SoulsborneBlogContext db = new SoulsborneBlogContext())
                {
                    var userDetail = db.users.Where(x => x.nick == user.nick && x.haslo == user.haslo).FirstOrDefault();
                    if(userDetail==null)
                    {
                        return View("Index", user);
                    }
                    else
                    {
                        Session["user_id"] = userDetail.user_id.ToString();
                        Session["nick"] = userDetail.nick;
                        Session["role_id"] = userDetail.role_id.ToString();

                        return RedirectToAction("Index", "Home");
                    }
                    

                }            
        }

        public ActionResult AccountInfo()
        {
            return RedirectToAction("Details", "User", new { id = Session["user_id"] });
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}