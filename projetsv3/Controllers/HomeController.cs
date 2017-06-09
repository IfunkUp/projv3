using projetsv3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetsv3.Controllers
{
   

    public class HomeController : Controller
    {
        
        PersoonServices ps = new PersoonServices();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string login, string password)
        {
           
            if (ps.CheckLogin(login,password))
            {
                Session["persoon"]=ps.GetPersoon(login);
                View("Index");
            }
            return View();
        }
    }
}