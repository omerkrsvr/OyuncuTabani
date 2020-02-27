using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OyuncuTabani.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult LogInIndex()
        {
            return View();
        }
    }
}