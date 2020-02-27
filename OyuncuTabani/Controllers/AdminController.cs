using OyuncuTabani.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OyuncuTabani.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        private OyuncuTabaniEntities db = new OyuncuTabaniEntities();
        public ActionResult AdminPanelIndex()
        {
            return View(db.Futbolcu.ToList());
        }
    }
}