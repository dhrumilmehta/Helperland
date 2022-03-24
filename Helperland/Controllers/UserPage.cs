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

                ViewBag.Name = user.FirstName;
            }
            else if (Request.Cookies["userId"] != null)
            {
                user = _helperlandContext.Users.FirstOrDefault(x => x.UserId == Convert.ToInt32(Request.Cookies["userId"]));
                userTypeId = user.UserTypeId;

                ViewBag.Name = user.FirstName;
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
                        dash.Status = (int)service.Status;
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




        [HttpPost]
        public IActionResult RescheduleService(CustomerDashboard reschedule)
        {
            ServiceRequest rescheduleService = _helperlandContext.ServiceRequests.FirstOrDefault(x => x.ServiceRequestId == reschedule.ServiceRequestId);

            Console.WriteLine(reschedule.ServiceRequestId);

            rescheduleService.ServiceStartDate = DateTime.Parse(reschedule.Date + " " + reschedule.StartTime);
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
        public IActionResult CancelService(ServiceRequest cancel)
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
        public JsonResult GetCustomerData()
        {
            int? Id = HttpContext.Session.GetInt32("userId");
            if (Id == null)
            {
                Id = Convert.ToInt32(Request.Cookies["userId"]);
            }

            User user = _helperlandContext.Users.FirstOrDefault(x => x.UserId == Id);
            return new JsonResult(user);

        }




        [HttpPost]
        public IActionResult UpdateCustomer(User user)
        {
            int? Id = HttpContext.Session.GetInt32("userId");
            if (Id == null)
            {
                Id = Convert.ToInt32(Request.Cookies["userId"]);
            }
            User u = _helperlandContext.Users.FirstOrDefault(x => x.UserId == Id);
            u.FirstName = user.FirstName;
            u.LastName = user.LastName;
            u.Mobile = user.Mobile;
            u.DateOfBirth = user.DateOfBirth;
            u.ModifiedDate = DateTime.Now;

            //ViewBag.Name = u.FirstName;

            var result = _helperlandContext.Users.Update(u);
            _helperlandContext.SaveChanges();
            if (result != null)
            {
                return Ok(Json("true"));
            }

            return Ok(Json("false"));
        }




        [HttpGet]
        public JsonResult GetUserAddress()
        {
            int? Id = HttpContext.Session.GetInt32("userId");
            if (Id == null)
            {
                Id = Convert.ToInt32(Request.Cookies["userId"]);
            }

            List<UserAddress> Addresses = _helperlandContext.UserAddresses.Where(x => x.UserId == Id && x.IsDeleted == false).ToList();
            return new JsonResult(Addresses);

        }




        [HttpPost]
        public IActionResult AddUserAddress(UserAddress addr)
        {
            int? Id = HttpContext.Session.GetInt32("userId");
            if (Id == null)
            {
                Id = Convert.ToInt32(Request.Cookies["userId"]);
            }
            addr.UserId = (int)Id;
            addr.IsDefault = false;
            addr.IsDeleted = false;

            var result = _helperlandContext.UserAddresses.Add(addr);
            _helperlandContext.SaveChanges();
            if (result != null)
            {
                return Ok(Json("true"));
            }
            else
            {
                return Ok(Json("false"));
            }

        }



        [HttpGet]
        public JsonResult EditAddressView(UserAddress addr)
        {
            int? Id = HttpContext.Session.GetInt32("userId");
            if (Id == null)
            {
                Id = Convert.ToInt32(Request.Cookies["userId"]);
            }
            UserAddress address = _helperlandContext.UserAddresses.FirstOrDefault(x => x.AddressId == addr.AddressId);
            return new JsonResult(address);


        }

        [HttpPost]
        public IActionResult EditUserAddress(UserAddress addr)
        {
            int? Id = HttpContext.Session.GetInt32("userId");
            if (Id == null)
            {
                Id = Convert.ToInt32(Request.Cookies["userId"]);
            }
            addr.UserId = (int)Id;
            var result = _helperlandContext.UserAddresses.Update(addr);
            _helperlandContext.SaveChanges();
            if (result != null)
            {
                return Ok(Json("true"));
            }
            else
            {
                return Ok(Json("false"));
            }
        }




        [HttpPost]
        public JsonResult DeleteUserAddress(UserAddress addr)
        {
            int? Id = HttpContext.Session.GetInt32("userId");
            if (Id == null)
            {
                Id = Convert.ToInt32(Request.Cookies["userId"]);
            }
            UserAddress userAddress = _helperlandContext.UserAddresses.FirstOrDefault(x => x.AddressId == addr.AddressId);

            userAddress.IsDeleted = true;
            var result = _helperlandContext.UserAddresses.Update(userAddress);
            _helperlandContext.SaveChanges();
            if (result != null)
            {
                return new JsonResult(true);
            }
            else
            {

                return new JsonResult(false);
            }
        }


        [HttpPost]
        public IActionResult ChangePassword(ChangePassword password)
        {
            int? Id = HttpContext.Session.GetInt32("userId");
            if (Id == null)
            {
                Id = Convert.ToInt32(Request.Cookies["userId"]);
            }
            User user = _helperlandContext.Users.FirstOrDefault(x => x.UserId == Id);


            if (BCrypt.Net.BCrypt.Verify(password.oldPassword, user.Password))
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(password.newPassword);
                user.ModifiedDate = DateTime.Now;
                _helperlandContext.Users.Update(user);
                _helperlandContext.SaveChanges();
                return Ok(Json("true"));
            }
            else
            {
                return Ok(Json("false"));
            }


        }





        [HttpGet]
        public JsonResult DashbordServiceDetails(CustomerDashboard ID)
        {

            CustomerDashboard Details = new CustomerDashboard();

            ServiceRequest sr = _helperlandContext.ServiceRequests.FirstOrDefault(x => x.ServiceRequestId == ID.ServiceRequestId);
            Details.ServiceRequestId = ID.ServiceRequestId;
            Details.Date = sr.ServiceStartDate.ToString("dd/MM/yyyy");
            Details.StartTime = sr.ServiceStartDate.ToString("HH:mm");
            Details.Duration = (decimal)(sr.ServiceHours + sr.ExtraHours);
            Details.EndTime = sr.ServiceStartDate.AddHours((double)sr.SubTotal).ToString("HH:mm");
            Details.TotalCost = sr.TotalCost;
            Details.Comments = sr.Comments;
            Details.Status = (int)sr.Status;

            Console.WriteLine("helo");
            Console.WriteLine(Details.Status);
            List<ServiceRequestExtra> SRExtra = _helperlandContext.ServiceRequestExtras.Where(x => x.ServiceRequestId == ID.ServiceRequestId).ToList();

            foreach (ServiceRequestExtra row in SRExtra)
            {
                if (row.ServiceExtraId == 1)
                {
                    Details.Cabinet = true;
                }
                else if (row.ServiceExtraId == 2)
                {
                    Details.Oven = true;
                }
                else if (row.ServiceExtraId == 3)
                {
                    Details.Window = true;
                }
                else if (row.ServiceExtraId == 4)
                {
                    Details.Fridge = true;
                }
                else
                {
                    Details.Laundry = true;
                }
            }

            ServiceRequestAddress Address = _helperlandContext.ServiceRequestAddresses.FirstOrDefault(x => x.ServiceRequestId == ID.ServiceRequestId);

            Details.Address = Address.AddressLine1 + ", " + Address.AddressLine2 + ", " + Address.City + " - " + Address.PostalCode;

            Details.PhoneNo = Address.Mobile;
            Details.Email = Address.Email;

            return new JsonResult(Details);
        }













        /************************  Provider  ************************/


        public IActionResult Provider()
        {
            int? Id = HttpContext.Session.GetInt32("userId");
            if (Id == null)
            {
                Id = Convert.ToInt32(Request.Cookies["userId"]);
            }

            if (Id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            User user = _helperlandContext.Users.FirstOrDefault(x => x.UserId == Id);
            int userTypeId = user.UserTypeId;
            if (userTypeId != 2)
            {
                return RedirectToAction("Index", "Home");

            }


            ViewBag.Name = user.FirstName;
            ViewBag.UserType = user.UserTypeId;


            List<NewServiceReq> dashboardTable = new List<NewServiceReq>();


            var ServiceRequest = _helperlandContext.ServiceRequests.Where(x => x.ZipCode == user.ZipCode && x.Status == 1).ToList();

            var BlockedCustomer = _helperlandContext.FavoriteAndBlockeds.Where(x => x.UserId == Id && x.IsBlocked == true).Select(x => x.TargetUserId).ToList();

            Console.WriteLine(BlockedCustomer.ToString());

            if (ServiceRequest.Any())
            {
                foreach (var req in ServiceRequest)
                {
                    if (!BlockedCustomer.Contains(req.UserId))
                    {
                        NewServiceReq temp = new NewServiceReq();


                        temp.ServiceRequestId = req.ServiceRequestId;
                        var StartDate = req.ServiceStartDate.ToString();
                        //temp.Date = StartDate.Substring(0, 10);

                        temp.Date = req.ServiceStartDate.ToString("dd/MM/yyyy");
                        temp.StartTime = req.ServiceStartDate.AddHours(0).ToString("HH:mm ");
                        var totaltime = (double)(req.ServiceHours + req.ExtraHours);
                        temp.EndTime = req.ServiceStartDate.AddHours(totaltime).ToString("HH:mm ");
                        temp.Status = (int)req.Status;
                        temp.TotalCost = req.TotalCost;
                        temp.HasPet = req.HasPets;
                        temp.Comments = req.Comments;


                        User customer = _helperlandContext.Users.FirstOrDefault(x => x.UserId == req.UserId);
                        temp.CustomerName = customer.FirstName + " " + customer.LastName;

                        ServiceRequestAddress Address = (ServiceRequestAddress)_helperlandContext.ServiceRequestAddresses.FirstOrDefault(x => x.ServiceRequestId == req.ServiceRequestId);

                        temp.Address = Address.AddressLine1 + ", " + Address.AddressLine2 + ", " + Address.City + " - " + Address.PostalCode;

                        List<ServiceRequestExtra> SRExtra = _helperlandContext.ServiceRequestExtras.Where(x => x.ServiceRequestId == req.ServiceRequestId).ToList();

                        foreach (ServiceRequestExtra row in SRExtra)
                        {
                            if (row.ServiceExtraId == 1)
                            {
                                temp.Cabinet = true;
                            }
                            else if (row.ServiceExtraId == 2)
                            {
                                temp.Oven = true;
                            }
                            else if (row.ServiceExtraId == 3)
                            {
                                temp.Window = true;
                            }
                            else if (row.ServiceExtraId == 4)
                            {
                                temp.Fridge = true;
                            }
                            else
                            {
                                temp.Laundry = true;
                            }
                        }



                        dashboardTable.Add(temp);





                    }
                }
            }

            return View(dashboardTable);
        }





        public JsonResult getServiceHistory()
        {
            int? Id = HttpContext.Session.GetInt32("userId");
            if (Id == null)
            {
                Id = Convert.ToInt32(Request.Cookies["userId"]);
            }

            User user = _helperlandContext.Users.FirstOrDefault(x => x.UserId == Id);

            List<NewServiceReq> ServiceHistoryTable = new List<NewServiceReq>();

            var ServiceRequest = _helperlandContext.ServiceRequests.Where(x => x.Status == 3 && x.ServiceProviderId == user.UserId).ToList();

            if (ServiceRequest.Any())
            {
                foreach (var req in ServiceRequest)
                {
                    NewServiceReq temp = new NewServiceReq();
                    temp.ServiceRequestId = req.ServiceRequestId;
                    var StartDate = req.ServiceStartDate.ToString();
                    temp.Date = req.ServiceStartDate.ToString("dd/MM/yyyy");
                    temp.StartTime = req.ServiceStartDate.AddHours(0).ToString("HH:mm ");
                    var totaltime = (double)(req.ServiceHours + req.ExtraHours);
                    temp.EndTime = req.ServiceStartDate.AddHours(totaltime).ToString("HH:mm ");
                    temp.Status = (int)req.Status;
                    //temp.TotalCost = req.TotalCost;
                    // temp.HasPet = req.HasPets;
                    //temp.Comments = req.Comments;
                    User customer = _helperlandContext.Users.FirstOrDefault(x => x.UserId == req.UserId);
                    temp.CustomerName = customer.FirstName + " " + customer.LastName;

                    ServiceRequestAddress Address = (ServiceRequestAddress)_helperlandContext.ServiceRequestAddresses.FirstOrDefault(x => x.ServiceRequestId == req.ServiceRequestId);

                    temp.Address = Address.AddressLine1 + ", " + Address.AddressLine2 + ", " + Address.City + " , " + Address.PostalCode;

                    ServiceHistoryTable.Add(temp);

                }

            }

            return new JsonResult(ServiceHistoryTable);

        }




        [HttpGet]
        public JsonResult GetProDetail()
        {

            int? Id = HttpContext.Session.GetInt32("userId");
            if (Id == null)
            {
                Id = Convert.ToInt32(Request.Cookies["userId"]);
            }

            User user = _helperlandContext.Users.FirstOrDefault(x => x.UserId == Id);
            return new JsonResult(user);
        }

        [HttpGet]
        public JsonResult GetProAddress()
        {

            int? Id = HttpContext.Session.GetInt32("userId");
            if (Id == null)
            {
                Id = Convert.ToInt32(Request.Cookies["userId"]);
            }

            UserAddress Addresses = _helperlandContext.UserAddresses.FirstOrDefault(x => x.UserId == Id);
            return new JsonResult(Addresses);

        }


        [HttpPost]
        public IActionResult UpdateProData(ProviderDetail sPSettings)
        {
            int? Id = HttpContext.Session.GetInt32("userId");
            if (Id == null)
            {
                Id = Convert.ToInt32(Request.Cookies["userId"]);
            }


            User sp = _helperlandContext.Users.FirstOrDefault(x => x.UserId == Id);
            sp.FirstName = sPSettings.user.FirstName;
            sp.LastName = sPSettings.user.LastName;
            sp.Mobile = sPSettings.user.Mobile;
            sp.DateOfBirth = sPSettings.user.DateOfBirth;
            sp.NationalityId = sPSettings.user.NationalityId;
            sp.Gender = sPSettings.user.Gender;
            sp.UserProfilePicture = sPSettings.user.UserProfilePicture;
            sp.ModifiedDate = DateTime.Now;
            sp.ModifiedBy = 123;


            var userresult = _helperlandContext.Users.Update(sp);

            _helperlandContext.SaveChanges();

            UserAddress userAddress1 = _helperlandContext.UserAddresses.FirstOrDefault(x => x.UserId == Id);

            if (userAddress1 == null)
            {

                sPSettings.address.UserId = (int)Id;
                UserAddress userAddress = sPSettings.address;
                var updateaddress = _helperlandContext.UserAddresses.Update(userAddress);

                _helperlandContext.SaveChanges();
            }
            else
            {
                userAddress1.AddressLine1 = sPSettings.address.AddressLine1;
                userAddress1.AddressLine2 = sPSettings.address.AddressLine2;
                userAddress1.City = sPSettings.address.City;
                userAddress1.State = sPSettings.address.State;
                userAddress1.PostalCode = sPSettings.address.PostalCode;
                userAddress1.Mobile = sPSettings.address.Mobile;
                var updateaddress = _helperlandContext.UserAddresses.Update(userAddress1);

                _helperlandContext.SaveChanges();

            }




            if (userresult != null)
            {
                return Ok(Json("true"));
            }

            return Ok(Json("false"));
        }


        [HttpPost]
        public IActionResult ProChangePassword(ChangePassword password)
        {
            int? Id = HttpContext.Session.GetInt32("userId");
            if (Id == null)
            {
                Id = Convert.ToInt32(Request.Cookies["userId"]);
            }
            User user = _helperlandContext.Users.FirstOrDefault(x => x.UserId == Id);


            if (BCrypt.Net.BCrypt.Verify(password.oldPassword, user.Password))
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(password.newPassword);
                user.ModifiedDate = DateTime.Now;
                _helperlandContext.Users.Update(user);
                _helperlandContext.SaveChanges();
                return Ok(Json("true"));
            }
            else
            {
                return Ok(Json("false"));
            }


        }





        public JsonResult getUpcomingService()
        {
            int? Id = HttpContext.Session.GetInt32("userId");
            if (Id == null)
            {
                Id = Convert.ToInt32(Request.Cookies["userId"]);
            }

            User user = _helperlandContext.Users.FirstOrDefault(x => x.UserId == Id);

            List<NewServiceReq> UpcomingTable = new List<NewServiceReq>();

            var ServiceRequest = _helperlandContext.ServiceRequests.Where(x => x.Status == 2 && x.ServiceProviderId == user.UserId).ToList();

            if (ServiceRequest.Any())
            {
                foreach (var req in ServiceRequest)
                {
                    NewServiceReq temp = new NewServiceReq();


                    temp.ServiceRequestId = req.ServiceRequestId;
                    var StartDate = req.ServiceStartDate.ToString();
                    temp.Date = req.ServiceStartDate.ToString("dd/MM/yyyy");
                    temp.StartTime = req.ServiceStartDate.AddHours(0).ToString("HH:mm ");
                    var totaltime = (double)(req.ServiceHours + req.ExtraHours);
                    temp.EndTime = req.ServiceStartDate.AddHours(totaltime).ToString("HH:mm ");
                    /* complete btn */
                    temp.Complete = req.ServiceStartDate.AddHours(totaltime) <= DateTime.Now;
                    temp.Status = (int)req.Status;
                    temp.TotalCost = req.TotalCost;
                    // temp.HasPet = req.HasPets;
                    //temp.Comments = req.Comments;
                    User customer = _helperlandContext.Users.FirstOrDefault(x => x.UserId == req.UserId);
                    temp.CustomerName = customer.FirstName + " " + customer.LastName;

                    ServiceRequestAddress Address = (ServiceRequestAddress)_helperlandContext.ServiceRequestAddresses.FirstOrDefault(x => x.ServiceRequestId == req.ServiceRequestId);

                    temp.Address = Address.AddressLine1 + ", " + Address.AddressLine2 + ", " + Address.City + " , " + Address.PostalCode;



                    UpcomingTable.Add(temp);






                }


            }


            return new JsonResult(UpcomingTable);

        }




        public JsonResult GetCustomer()
        {

            int? Id = HttpContext.Session.GetInt32("userId");
            if (Id == null)
            {
                Id = Convert.ToInt32(Request.Cookies["userId"]);
            }

            List<int> customerID = _helperlandContext.ServiceRequests.Where(x => x.ServiceProviderId == Id && x.Status != 1).Select(u => u.UserId).ToList();


            var CustomerSetId = new HashSet<int>(customerID);

            List<BlockCustomerData> blockData = new List<BlockCustomerData>();

            foreach (int temp in CustomerSetId)
            {
                User user = _helperlandContext.Users.FirstOrDefault(x => x.UserId == temp);
                FavoriteAndBlocked FB = _helperlandContext.FavoriteAndBlockeds.FirstOrDefault(x => x.UserId == Id && x.TargetUserId == temp);

                BlockCustomerData blockCustomerData = new BlockCustomerData
                {
                    user = user,
                    favoriteAndBlocked = FB
                };

                blockData.Add(blockCustomerData);



            }



            return Json(blockData);


        }



        public string cancelRequest(ServiceRequest request)
        {

            ServiceRequest requestObj = _helperlandContext.ServiceRequests.FirstOrDefault(x => x.ServiceRequestId == request.ServiceRequestId);

            requestObj.ServiceProviderId = null;
            requestObj.Status = 1;

            var result = _helperlandContext.ServiceRequests.Update(requestObj);
            _helperlandContext.SaveChanges();
            if (result != null)
            {
                return "Success";
            }
            else
            {
                return "error";
            }




        }



        public string BlockCustomer(BlockCust temp)
        {
            int? Id = HttpContext.Session.GetInt32("userId");
            if (Id == null)
            {
                Id = Convert.ToInt32(Request.Cookies["userId"]);
            }

            FavoriteAndBlocked obj = _helperlandContext.FavoriteAndBlockeds.FirstOrDefault(x => x.UserId == Id && x.TargetUserId == temp.Id);

            if (temp.Req == "B")
            {

                if (obj == null)
                {
                    obj = new FavoriteAndBlocked();
                    obj.UserId = (int)Id;
                    obj.TargetUserId = temp.Id;
                    obj.IsBlocked = true;

                }
                else
                {
                    obj.IsBlocked = true;
                }

            }
            else
            {
                obj.IsBlocked = false;

            }





            var result = _helperlandContext.FavoriteAndBlockeds.Update(obj);
            _helperlandContext.SaveChanges();
            if (result != null)
            {
                return "Suceess";
            }
            else
            {
                return "error";
            }


        }







        [HttpGet]
        public JsonResult getAllDetails(NewServiceReq ID)
        {

            NewServiceReq Details = new NewServiceReq();

            ServiceRequest sr = _helperlandContext.ServiceRequests.FirstOrDefault(x => x.ServiceRequestId == ID.ServiceRequestId);

            Details.ServiceRequestId = ID.ServiceRequestId;

            Details.Date = sr.ServiceStartDate.ToString("dd/MM/yyyy");

            Details.StartTime = sr.ServiceStartDate.ToString("HH:mm");

            Details.Duration = (decimal)(sr.ServiceHours + sr.ExtraHours);

            Details.EndTime = sr.ServiceStartDate.AddHours((double)Details.Duration).ToString("HH:mm");
            Details.TotalCost = sr.TotalCost;
            Details.Comments = sr.Comments;
            Details.Status = (int)sr.Status;
            Details.Complete = sr.ServiceStartDate.AddHours((double)Details.Duration) <= DateTime.Now;



            List<ServiceRequestExtra> SRExtra = _helperlandContext.ServiceRequestExtras.Where(x => x.ServiceRequestId == ID.ServiceRequestId).ToList();



            foreach (ServiceRequestExtra row in SRExtra)
            {
                if (row.ServiceExtraId == 1)
                {
                    Details.Cabinet = true;
                }
                else if (row.ServiceExtraId == 2)
                {
                    Details.Oven = true;
                }
                else if (row.ServiceExtraId == 3)
                {
                    Details.Window = true;
                }
                else if (row.ServiceExtraId == 4)
                {
                    Details.Fridge = true;
                }
                else
                {
                    Details.Laundry = true;
                }
            }

            ServiceRequestAddress Address = _helperlandContext.ServiceRequestAddresses.FirstOrDefault(x => x.ServiceRequestId == ID.ServiceRequestId);

            Details.Address = Address.AddressLine1 + ", " + Address.AddressLine2 + ", " + Address.City + " - " + Address.PostalCode;
            Details.ZipCode = Address.PostalCode;

            User customer = _helperlandContext.Users.FirstOrDefault(x => x.UserId == sr.UserId);

            Details.CustomerName = customer.FirstName + " " + customer.LastName;


            return new JsonResult(Details);
        }




        [HttpGet]
        public string acceptService(NewServiceReq ID)
        {
            int? spId = HttpContext.Session.GetInt32("userId");
            if (spId == null)
            {
                spId = Convert.ToInt32(Request.Cookies["userId"]);
            }

            ServiceRequest serviceRequest = _helperlandContext.ServiceRequests.FirstOrDefault(x => x.ServiceRequestId == ID.ServiceRequestId);
            if (serviceRequest != null && serviceRequest.Status != 1)
            {
                return new string("Service Req Not available");
            }

            int conflict = CheckConflict((int)serviceRequest.ServiceRequestId);

            if (conflict != -1)
            {

                return conflict.ToString();

            }



            serviceRequest.Status = 2;
            serviceRequest.ServiceProviderId = spId;
            serviceRequest.SpacceptedDate = DateTime.Now;
            var result = _helperlandContext.ServiceRequests.Update(serviceRequest);
            _helperlandContext.SaveChanges();
            if (result != null)
            {
                return "Suceess";
            }
            else
            {
                return "error";
            }

        }


        public string ConflictDetails(NewServiceReq ID)
        {
            Console.WriteLine(ID.ServiceRequestId);

            int conflict = CheckConflict(ID.ServiceRequestId);

            ServiceRequest sr = _helperlandContext.ServiceRequests.FirstOrDefault(x => x.ServiceRequestId == conflict);


            string conflictmsg = "This Request is conflicting with Service ID: " + sr.ServiceRequestId + " on :" + sr.ServiceStartDate;

            return conflictmsg;






        }

        public int CheckConflict(int SRID)
        {

            int? Id = HttpContext.Session.GetInt32("userId");
            if (Id == null)
            {
                Id = Convert.ToInt32(Request.Cookies["userId"]);
            }


            ServiceRequest request = _helperlandContext.ServiceRequests.FirstOrDefault(x => x.ServiceRequestId == SRID);

            String reqdate = request.ServiceStartDate.ToString("yyyy-MM-dd");

            String startDateStr = reqdate + " 00:00:00.000";
            String endDateStr = reqdate + " 23:59:59.999";


            DateTime startDate = DateTime.ParseExact(startDateStr, "yyyy-MM-dd HH:mm:ss.fff",
                                       System.Globalization.CultureInfo.InvariantCulture);

            DateTime endDate = DateTime.ParseExact(endDateStr, "yyyy-MM-dd HH:mm:ss.fff",
                                       System.Globalization.CultureInfo.InvariantCulture);

            List<ServiceRequest> list = _helperlandContext.ServiceRequests.Where(x => (x.ServiceProviderId == Id) && (x.Status == 2) && (x.ServiceStartDate > startDate && x.ServiceStartDate < endDate)).ToList();

            double mins = ((double)(request.ServiceHours + request.ExtraHours)) * 60;
            DateTime endTimeRequest = request.ServiceStartDate.AddMinutes(mins + 60);

            request.ServiceStartDate = request.ServiceStartDate.AddMinutes(-60);
            Console.WriteLine(endTimeRequest);
            Console.WriteLine(request.ServiceStartDate);
            foreach (ServiceRequest booked in list)
            {
                mins = ((double)(booked.ServiceHours + booked.ExtraHours)) * 60;
                DateTime endTimeBooked = booked.ServiceStartDate.AddMinutes(mins);

                if (request.ServiceStartDate < booked.ServiceStartDate)
                {
                    if (endTimeRequest <= booked.ServiceStartDate)
                    {
                        return -1;
                    }
                    else
                    {
                        return booked.ServiceRequestId;
                    }
                }
                else
                {
                    if (request.ServiceStartDate < endTimeBooked)
                    {
                        return booked.ServiceRequestId;
                    }
                }

            }

            return -1;

        }





        public string CompleteService(ServiceRequest request)
        {

            ServiceRequest requestObj = _helperlandContext.ServiceRequests.FirstOrDefault(x => x.ServiceRequestId == request.ServiceRequestId);

            requestObj.Status = 3;

            var result = _helperlandContext.ServiceRequests.Update(requestObj);
            _helperlandContext.SaveChanges();
            if (result != null)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }


    }

}