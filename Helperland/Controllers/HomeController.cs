using Helperland.Data;
using Helperland.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Help.Controllers
{
    public class HomeController : Controller
    {
        private readonly HelperlandContext _helpContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, HelperlandContext helpContext)
        {
            _logger = logger;
            _helpContext = helpContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Prices()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ContactU contactUs = new ContactU();
            return View(contactUs);

        }


        public IActionResult Faq()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult BecomePro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactU contactUs)
        {
            contactUs.IsDeleted = false;
            _helpContext.ContactUs.Add(contactUs);
            _helpContext.SaveChanges();
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
