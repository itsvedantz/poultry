using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using PoultryFormManagementSystem.Models;

namespace PoultryFormManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Registration()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(TblRegister r)
        {
            using(PoultryDataEntities db=new PoultryDataEntities())
            {
                if(ModelState.IsValid)
                {
                    db.TblRegisters.Add(r);
                    db.SaveChanges();
                    ViewBag.message("Registartion Sucessfuuly");
                    ModelState.Clear();
                }
            }
            return View(r);
        }
        [HttpPost]
        public ActionResult Login(TblRegister r1)
        {
            using (PoultryDataEntities db = new PoultryDataEntities())
            {
                if (ModelState.IsValid)
                {
                    var log = db.TblRegisters.Where(a => a.userName.Equals(r1.userName) && a.password.Equals(r1.password)).FirstOrDefault();
                    if(log != null)
                    {
                        return RedirectToAction("Contact");
                    }
                    ViewBag.message("Login Sucessfuuly");
                    ModelState.Clear();
                }
            }
            return View(r1);
        }
    }
}