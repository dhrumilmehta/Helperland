using Helperland.Data;
using Helperland.Models;
using Helperland.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Helperland.Controllers
{
    public class UserManage : Controller
    {
        private readonly HelperlandContext _helperlandContext;
        public UserManage(HelperlandContext helperlandContext)
        {
            _helperlandContext = helperlandContext;
        }
        public IActionResult Signup()
        {
            User user = new User();
            return View(user);
        }

        [HttpPost]
        public IActionResult Signup(User user)
        {
            if (ModelState.IsValid)
            {
                if (_helperlandContext.Users.Where(x => x.Email == user.Email).Count() == 0 && _helperlandContext.Users.Where(x => x.Mobile == user.Mobile).Count() == 0)
                {
                    user.UserTypeId = 1;
                    user.CreatedDate = DateTime.Now;
                    user.ModifiedDate = DateTime.Now;
                    user.IsRegisteredUser = true;
                    user.ModifiedBy = 123;
                    user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

                    _helperlandContext.Users.Add(user);
                    _helperlandContext.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.signmessage = "User already exist. Try again";
                }
            }
            return View();

        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login user)
        {

            string password = _helperlandContext.Users.FirstOrDefault(x => x.Email == user.Email).Password;
            bool pass = BCrypt.Net.BCrypt.Verify(user.Password, password);

            if (_helperlandContext.Users.Where(x => x.Email == user.Email && pass).Count() > 0)
            {
                var U = _helperlandContext.Users.FirstOrDefault(x => x.Email == user.Email);
                Console.WriteLine("1");

                if (user.Remember == true)
                {
                    CookieOptions cookieRemember = new CookieOptions
                    {
                        Expires = DateTime.Now.AddSeconds(604800)
                    };
                    Response.Cookies.Append("userId", Convert.ToString(U.UserId), cookieRemember);
                }

                HttpContext.Session.SetInt32("userId", U.UserId);
                TempData["UserName"] = U.FirstName;


                if (U.UserTypeId == 1)
                {

                    return RedirectToAction("Customer", "UserPage");
                }
                else if (U.UserTypeId == 2)
                {

                    return RedirectToAction("Provider", "UserPage");
                }
                else
                {
                    return View();
                }

            }

            else
            {
                TempData["LoginWarn"] = "Check Credentials Again";
                return RedirectToAction("Index", "Home");
            }




        }




        public IActionResult BecomePro()
        {
            User signup = new User();
            return View(signup);
        }

        [HttpPost]
        public IActionResult BecomePro(User signup)
        {
            if (ModelState.IsValid)
            {

                if (_helperlandContext.Users.Where(x => x.Email == signup.Email).Count() == 0 && _helperlandContext.Users.Where(x => x.Mobile == signup.Mobile).Count() == 0)
                {
                    signup.UserTypeId = 2;
                    signup.CreatedDate = DateTime.Now;
                    signup.ModifiedDate = DateTime.Now;
                    signup.IsRegisteredUser = true;
                    signup.ModifiedBy = 123;
                    signup.Password = BCrypt.Net.BCrypt.HashPassword(signup.Password);

                    _helperlandContext.Users.Add(signup);
                    _helperlandContext.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.promessage = "User already exists";
                    return View();
                }
            }
            else
            {
                return View();
            }

        }


        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(ForgetPassword fgpass)
        {
            var userrecord = _helperlandContext.Users.Where(x => x.Email == fgpass.Email).FirstOrDefault();
            if (userrecord != null)
            {
                User Id = _helperlandContext.Users.FirstOrDefault(x => x.Email == fgpass.Email);

                string to = fgpass.Email;
                string subject = "Reset password";
                string body = "<p>Reset your password by click below link " +
                    "<a href='" + Url.Action("ResetPassword", "UserManage", new { userid = Id.UserId }, "http") + "'>Reset Password</a></p>";
                MailMessage msg = new MailMessage();
                msg.To.Add(to);
                msg.Subject = subject;
                msg.Body = body;
                msg.From = new MailAddress("dhrumilhelperlandtrail@gmail.com");
                msg.IsBodyHtml = true;
                SmtpClient setup = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    UseDefaultCredentials = true,
                    EnableSsl = true,
                    Credentials = new System.Net.NetworkCredential("dhrumilhelperlandtrail@gmail.com", "Helperland@123")
                };
                setup.Send(msg);

                TempData["TempPass"] = "To Reset Password check Email.";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["failpass"] = "Invalid EMail";
                return RedirectToAction("Index", "Home");
            }
        }





        public IActionResult ResetPassword(int userID)
        {
            TempData["id"] = userID;
            return PartialView();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ResetPassword(ResetPass user)
        {
            if (ModelState.IsValid)
            {
                user.newPassword = BCrypt.Net.BCrypt.HashPassword(user.newPassword);
                var newuser = new User() { UserId = user.userID, Password = user.newPassword, ModifiedDate = DateTime.Now };
                _helperlandContext.Users.Attach(newuser);
                _helperlandContext.Entry(newuser).Property(x => x.Password).IsModified = true;
                _helperlandContext.SaveChanges();

                TempData["resetpass"] = "Password reset successfully";
                return RedirectToAction("Index", "Home");
            }

            return View();
        }



        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            Response.Cookies.Delete("userid");

            return RedirectToAction("Index", "Home");
        }

    }
}