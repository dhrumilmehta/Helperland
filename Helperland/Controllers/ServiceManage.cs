using Helperland.Data;
using Helperland.Models;
using Helperland.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Controllers
{
    public class ServiceManage : Controller
    {
        private readonly HelperlandContext _helperlandContext;
        public ServiceManage(HelperlandContext helperlandContext)
        {
            _helperlandContext = helperlandContext;
        }

        public IActionResult BookService()
        {
            if (HttpContext.Session.GetInt32("userId") != null)
            {
                var id = HttpContext.Session.GetInt32("userId");
                User user = _helperlandContext.Users.Find(id);
                ViewBag.Name = user.FirstName;
                ViewBag.UserType = user.UserTypeId;
                if (user.UserTypeId == 1)
                {
                    return PartialView();
                }
            }
            else if (Request.Cookies["userId"] != null)
            {
                var user = _helperlandContext.Users.FirstOrDefault(x => x.UserId == Convert.ToInt32(Request.Cookies["userId"]));
                ViewBag.Name = user.FirstName;
                ViewBag.UserType = user.UserTypeId;
                if (user.UserTypeId == 1)
                {
                    return PartialView();
                }
            }
            TempData["LoginNeed"] = "Please Try Logging In";
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public IActionResult ValidPostalCode(Setupservice obj)
        {
            if (ModelState.IsValid) { 
            var list = _helperlandContext.Users.Where(x => (x.ZipCode == obj.ZipCode) && (x.UserTypeId == 2)).ToList();

            if (list.Count() > 0)
            {
                return Ok(Json("true"));
            }
            else {
                TempData["wrongZipCode"] = "service provider is not avilable in this area.";
                return Ok(Json("false"));
            }
            }

            else
            {
                return Ok(Json("Invalid")); 
            }
        }


        [HttpPost]
        public ActionResult ScheduleService(ScheduleService schedule)
        {

            if (ModelState.IsValid)
            {
                return Ok(Json("true"));
            }
            else
            {
                return Ok(Json("false"));
            }
        }




        [HttpGet]
        public IActionResult DetailsService(Setupservice obj)
        {

            int Id = 0;

            List<Address> Addresses = new List<Address>();
            if (HttpContext.Session.GetInt32("userId") != null)
            {
                Id = (int)HttpContext.Session.GetInt32("userId");
            }
            else if (Request.Cookies["userId"] != null)
            {
                Id = int.Parse(Request.Cookies["userId"]);

            }


            string postalcode = obj.ZipCode;
           // Console.WriteLine(obj.ZipCode);
            var table = _helperlandContext.UserAddresses.Where(x => x.UserId == Id && x.PostalCode == postalcode).ToList();
           // Console.WriteLine(table.ToString());

            foreach (var add in table)
            {
                //Console.WriteLine("1");
                Address useradd = new Address
                {
                    AddressId = add.AddressId,
                    AddressLine1 = add.AddressLine1,
                    AddressLine2 = add.AddressLine2,
                    City = add.City,
                    PostalCode = add.PostalCode,
                    Mobile = add.Mobile,
                    isDefault = add.IsDefault
                };

                Addresses.Add(useradd);
            }
            //Console.WriteLine("2");

            return new JsonResult(Addresses);
        }




        [HttpPost]
        public ActionResult AddNewAddress(UserAddress useradd)
        {
            //Console.WriteLine("Inside Addnew address 1");
            int Id = 0;


            if (HttpContext.Session.GetInt32("userId") != null)
            {
                Id = (int)HttpContext.Session.GetInt32("userId");
            }
            else if (Request.Cookies["userId"] != null)
            {
                Id = int.Parse(Request.Cookies["userId"]);

            }
            /* Console.WriteLine("Inside Addnew address 2");
             Console.WriteLine(Id);*/
            
            useradd.UserId = Id;
            useradd.IsDefault = false;
            useradd.IsDeleted = false;
            User user = _helperlandContext.Users.Where(x => x.UserId == Id).FirstOrDefault();
            useradd.Email = user.Email;
            var result = _helperlandContext.UserAddresses.Add(useradd);
            //Console.WriteLine("Inside Addnew address 3");
            _helperlandContext.SaveChanges();

            //Console.WriteLine("Inside Addnew address 4");
            if (result != null)
            {
                return Ok(Json("true"));
            }
            
            return Ok(Json("false"));
            
           
        }





        [HttpPost]
        public ActionResult CompleteBooking(CompleteBooking complete)
        {
            int Id = 0;


            if (HttpContext.Session.GetInt32("userId") != null)
            {
                Id = (int)HttpContext.Session.GetInt32("userId");
            }
            else if (Request.Cookies["userId"] != null)
            {
                Id = int.Parse(Request.Cookies["userId"]);

            }


            ServiceRequest add = new ServiceRequest
            {
                UserId = Id,
                ServiceId = Id,
                ServiceStartDate = complete.ServiceStartDate,
                ServiceHours = (double)complete.ServiceHours,
                ZipCode = complete.PostalCode,
                ServiceHourlyRate = 25,
                ExtraHours = complete.ExtraHours,
                SubTotal = (decimal)complete.SubTotal,
                TotalCost = (decimal)complete.TotalCost,
                Comments = complete.Comments,
                PaymentDue = false,
                PaymentDone = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                HasIssue = false,
                Status = 1,
                HasPets = complete.HasPets
            };
            //Console.Write(complete.HasPets);

            var result = _helperlandContext.ServiceRequests.Add(add);
            _helperlandContext.SaveChanges();

            UserAddress useraddr = _helperlandContext.UserAddresses.Where(x => x.AddressId == complete.AddressId).FirstOrDefault();

            ServiceRequestAddress srAddr = new ServiceRequestAddress
            {
                AddressLine1 = useraddr.AddressLine1,
                AddressLine2 = useraddr.AddressLine2,
                City = useraddr.City,
                Email = useraddr.Email,
                Mobile = useraddr.Mobile,
                PostalCode = useraddr.PostalCode,
                ServiceRequestId = result.Entity.ServiceRequestId,
                State = useraddr.State
            };

            var srAddrResult = _helperlandContext.ServiceRequestAddresses.Add(srAddr);
            _helperlandContext.SaveChanges();

            if (complete.Cabinet == true)
            {
                ServiceRequestExtra srExtra = new ServiceRequestExtra
                {
                    ServiceRequestId = result.Entity.ServiceRequestId,
                    ServiceExtraId = 1
                };
                _helperlandContext.ServiceRequestExtras.Add(srExtra);
                _helperlandContext.SaveChanges();
            }
            if (complete.Fridge == true)
            {
                ServiceRequestExtra srExtra = new ServiceRequestExtra
                {
                    ServiceRequestId = result.Entity.ServiceRequestId,
                    ServiceExtraId = 2
                };
                _helperlandContext.ServiceRequestExtras.Add(srExtra);
                _helperlandContext.SaveChanges();
            }
            if (complete.Oven == true)
            {
                ServiceRequestExtra srExtra = new ServiceRequestExtra
                {
                    ServiceRequestId = result.Entity.ServiceRequestId,
                    ServiceExtraId = 3
                };
                _helperlandContext.ServiceRequestExtras.Add(srExtra);
                _helperlandContext.SaveChanges();
            }
            if (complete.Laundry == true)
            {
                ServiceRequestExtra srExtra = new ServiceRequestExtra
                {
                    ServiceRequestId = result.Entity.ServiceRequestId,
                    ServiceExtraId = 4
                };
                _helperlandContext.ServiceRequestExtras.Add(srExtra);
                _helperlandContext.SaveChanges();
            }
            if (complete.Window == true)
            {
                ServiceRequestExtra srExtra = new ServiceRequestExtra
                {
                    ServiceRequestId = result.Entity.ServiceRequestId,
                    ServiceExtraId = 5
                };
                _helperlandContext.ServiceRequestExtras.Add(srExtra);
                _helperlandContext.SaveChanges();
            }



            if (result != null && srAddrResult != null)
            {
                return Ok(Json(result.Entity.ServiceRequestId));
            }

            return Ok(Json("false"));
        }

    } 
}
