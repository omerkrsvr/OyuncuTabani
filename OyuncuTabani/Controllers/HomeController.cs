using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OyuncuTabani.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OyuncuAra()
        {
            return View();
        }
        public ActionResult Iletisim()
        {
            return View();
        }


    }
}