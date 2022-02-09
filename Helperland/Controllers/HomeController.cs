using Helperland.Models;
using Helperland.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Controllers
{
    public class HomeController : Controller
    {

        private readonly HelperlandContext _db = new HelperlandContext();

       /* public HomeController(HelperlandContext db)
        {
            _db = db;
        }*/

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult faq()
        {
            return View();
        }

        public IActionResult prices()
        {
            return View();
        }

        public IActionResult about()
        {
            return View();
        }
        public IActionResult contact()
        {
            ContactUs contactU = new ContactUs();
            return View(contactU);
        }

        public IActionResult become_Helper()
        {
            User user = new User();
            return View(user);
        }

        public IActionResult SignupPage()
        {
            User user = new User();
            return View(user);
        }

        //[ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult SignupPage(User user)
        {

            if (ModelState.IsValid)
            {
                if ((_db.Users.Where(x => x.Email == user.Email).Count() == 0 && _db.Users.Where(x => x.Mobile == user.Mobile).Count() == 0))
                {

                    user.CreatedDate = DateTime.Now;
                    user.ModifiedDate = DateTime.Now;
                    user.IsRegisteredUser = true;
                    user.ModifiedBy = 123;
                    user.UserTypeId = 1;

                    _db.Users.Add(user);
                    _db.SaveChanges();


                    return RedirectToAction("Index");


                }
                else
                {
                    ViewBag.message = "User already exist.";
                    return RedirectToAction("Index");


                }
            }
            return View();

        }
        [HttpPost]
        public IActionResult Become_Helper(User user)
        {

            if (ModelState.IsValid)
            {
                if ((_db.Users.Where(x => x.Email == user.Email).Count() == 0 && _db.Users.Where(x => x.Mobile == user.Mobile).Count() == 0))
                {

                    user.CreatedDate = DateTime.Now;
                    user.ModifiedDate = DateTime.Now;
                    user.IsRegisteredUser = true;
                    user.ModifiedBy = 123;
                    user.UserTypeId = 2;

                    _db.Users.Add(user);
                    _db.SaveChanges();


                    return RedirectToAction("Index");


                }
                else
                {
                    ViewBag.message = "User already exist.";
                    return RedirectToAction("Index");


                }
            }
            return View();

        }

        [HttpPost]
        public IActionResult Login(User user)
        {

            if (ModelState.IsValid)
            {
                if ((_db.Users.Where(x => x.Email == user.Email).Count() == 0 && _db.Users.Where(x => x.Password == user.Password).Count() == 0))
                {
                    ViewBag.message = "User invalid";
                    return RedirectToAction("Index");


                }
                else
                {
                    ViewBag.message = "login successful";
                    return RedirectToAction("contact");


                }
            }
            return View();

        }
        [HttpPost]
        public IActionResult Contact(ContactUs contactU)
        {

            if (ModelState.IsValid)
            {
                contactU.IsDeleted = false;
                _db.ContactUs.Add(contactU);
                _db.SaveChanges();
                return RedirectToAction("contact");
            }
            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
