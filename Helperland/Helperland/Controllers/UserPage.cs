using Helperland.Data;
using Helperland.Models;
using Helperland.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Help.Controllers
{
    public class UserPage : Controller
    {

        private readonly HelperlandContext _helperlandContext;
        public UserPage(HelperlandContext helperlandContext)
        {
            _helperlandContext = helperlandContext;
        }

        /*************************  Customer  ****************************/


        public IActionResult Customer()
        {
            var userTypeId = 0;
            User user = null;

            if (HttpContext.Session.GetInt32("userId") != null)
            {
                var id = HttpContext.Session.GetInt32("userId");
                user = _helperlandContext.Users.Find(id);
                userTypeId = user.UserTypeId;
            }
            else if (Request.Cookies["userId"] != null)
            {
                user = _helperlandContext.Users.FirstOrDefault(x => x.UserId == Convert.ToInt32(Request.Cookies["userId"]));
                userTypeId = user.UserTypeId;
            }
            if (userTypeId == 1)
            {
                List<CustomerDashboard> dashboard = new List<CustomerDashboard>();



                //var ServiceTable = _helperlandContext.ServiceRequests.Where(x => (x.UserId == user.UserId) && (x.Status == 1 || x.Status == 2)).ToList();

                var ServiceTable = _helperlandContext.ServiceRequests.Where(x => x.UserId == user.UserId).ToList();

                //var ServiceTable = _helperlandContext.ServiceRequests.Where(x=>x.UserId==user.UserId ).ToList();
                if (ServiceTable.Any())  /*ServiceTable.Count()>0*/
                {
                    foreach (var service in ServiceTable)
                    {

                        CustomerDashboard dash = new CustomerDashboard();
                        dash.ServiceRequestId = service.ServiceRequestId;
                        var StartDate = service.ServiceStartDate.ToString();
                        //dash.Date = StartDate.Substring(0, 10);
                        //dash.StartTime = StartDate.Substring(11);
                        dash.Date = service.ServiceStartDate.ToString("dd/MM/yyyy");
                        dash.StartTime = service.ServiceStartDate.AddHours(0).ToString("HH:mm ");
                        var totaltime = (double)(service.ServiceHours + service.ExtraHours);
                        dash.EndTime = service.ServiceStartDate.AddHours(totaltime).ToString("HH:mm ");
                        //dash.Status = (int)service.Status;
                        dash.TotalCost = service.TotalCost;

                        if (service.ServiceProviderId != null)
                        {

                            User sp = _helperlandContext.Users.Where(x => x.UserId == service.ServiceProviderId).FirstOrDefault();

                            dash.ServiceProvider = sp.FirstName + " " + sp.LastName;

                            //decimal rating = _helperlandContext.Ratings.Where(x => x.RatingTo == service.ServiceProviderId).Average(x => x.Ratings);

                            //dash.SPRatings = rating;

                        }

                        dashboard.Add(dash);
                    }
                }

                return PartialView(dashboard);
            }
            return RedirectToAction("Index", "Home");
        }






        /**/
        [HttpPost]
        public IActionResult RescheduleServiceRequest(CustomerDashboard reschedule)
        {
            ServiceRequest rescheduleService = _helperlandContext.ServiceRequests.FirstOrDefault(x => x.ServiceRequestId == reschedule.ServiceRequestId);

            Console.WriteLine(reschedule.ServiceRequestId);

            string date = reschedule.Date + " " + reschedule.StartTime;

            rescheduleService.ServiceStartDate = DateTime.Parse(date);
            rescheduleService.ServiceRequestId = reschedule.ServiceRequestId;
            rescheduleService.ModifiedDate = DateTime.Now;

            var result = _helperlandContext.ServiceRequests.Update(rescheduleService);
            _helperlandContext.SaveChanges();

            if (result != null)
            {
                return Ok(Json("true"));
            }

            return Ok(Json("false"));
        }




        [HttpPost]
        public IActionResult CancelServiceRequest(ServiceRequest cancel)
        {



            Console.WriteLine(cancel.ServiceRequestId);
            ServiceRequest cancelService = _helperlandContext.ServiceRequests.FirstOrDefault(x => x.ServiceRequestId == cancel.ServiceRequestId);
            cancelService.Status = 4;
            if (cancel.Comments != null)
            {
                cancelService.Comments = cancel.Comments;
            }

            var result = _helperlandContext.ServiceRequests.Update(cancelService);
            _helperlandContext.SaveChanges();
            if (result != null)
            {
                return Ok(Json("true"));
            }

            return Ok(Json("false"));
        }




        [HttpGet]
        public JsonResult GetRating(CustomerDashboard ID)
        {
            ServiceRequest sr = _helperlandContext.ServiceRequests.FirstOrDefault(x => x.ServiceRequestId == ID.ServiceRequestId);

            if (_helperlandContext.Ratings.Where(x => x.RatingTo == sr.ServiceProviderId).Count() > 0)
            {
                decimal avgrating = _helperlandContext.Ratings.Where(x => x.RatingTo == sr.ServiceProviderId).Average(x => x.Ratings);



                CustomerDashboard customerDashboard = new CustomerDashboard();
                //customerDashboard.AverageRating = (float)decimal.Round(avgrating, 1, MidpointRounding.AwayFromZero);

                User sp = _helperlandContext.Users.Where(x => x.UserId == sr.ServiceProviderId).FirstOrDefault();
                //customerDashboard.UserProfilePicture = "/images/" + sp.UserProfilePicture;
                customerDashboard.ServiceProvider = sp.FirstName + " " + sp.LastName;

                return new JsonResult(customerDashboard);
            }
            return new JsonResult(null);
        }


        public IActionResult RateServiceProvider(Rating rating)
        {
            int? Id = -1;
            if (HttpContext.Session.GetInt32("userId") != null)
            {
                Id = HttpContext.Session.GetInt32("userId");
            }
            else if (Request.Cookies["userId"] != null)
            {

                Id = Convert.ToInt32(Request.Cookies["userId"]);
            }

            if (Id != null)
            {
                if (_helperlandContext.Ratings.Where(x => x.ServiceRequestId == rating.ServiceRequestId).Count() > 0)
                {
                    return Ok(Json("false"));
                }


                rating.RatingDate = DateTime.Now;
                ServiceRequest sr = _helperlandContext.ServiceRequests.FirstOrDefault(x => x.ServiceRequestId == rating.ServiceRequestId);
                rating.RatingTo = (int)sr.ServiceProviderId;
                rating.RatingFrom = (int)Id;
                Console.WriteLine(rating.Ratings);

                var result = _helperlandContext.Ratings.Add(rating);
                _helperlandContext.SaveChanges();

                if (result != null)
                {
                    return Ok(Json("true"));
                }
            }
            return Ok(Json("false"));
        }

        /************************  Provider  ************************/


        public IActionResult Provider()
        {
            if (HttpContext.Session.GetInt32("userId") != null)
            {
                var id = HttpContext.Session.GetInt32("userId");
                User user = _helperlandContext.Users.Find(id);
                ViewBag.Name = user.FirstName;
                ViewBag.UserType = user.UserTypeId;
                if (user.UserTypeId == 2)
                {
                    return PartialView();
                }
            }
            else if (Request.Cookies["userId"] != null)
            {
                var user = _helperlandContext.Users.FirstOrDefault(x => x.UserId == Convert.ToInt32(Request.Cookies["userId"]));
                ViewBag.Name = user.FirstName;
                ViewBag.UserType = user.UserTypeId;
                if (user.UserTypeId == 2)
                {
                    return PartialView();
                }
            }
            return RedirectToAction("Index", "Home");
        }

    }
}