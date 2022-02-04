/*using Helperland.Models;
using Helperland.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Helperland.Controllers
{
    public class DbController : Controller
    {
        private readonly HelperlandContext _db;

        public DbController(HelperlandContext db)
        {
            _db = db;
        }

        [ValidateAntiForgeryToken]
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


                    return RedirectToAction("Index", "Public");


                }
                else
                {
                    ViewBag.message = "User already exist.";
                    return RedirectToAction("Index", "Public");


                }
            }
            return View();

        }
    }
}
*/