#pragma checksum "C:\Users\Dhrumil Mehta\Desktop\ddm\ff\Helperland\Views\Admin\AdminDashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5311796f4577f399c41d1dc7d2fce0f555a2caa4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_AdminDashboard), @"mvc.1.0.view", @"/Views/Admin/AdminDashboard.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Dhrumil Mehta\Desktop\ddm\ff\Helperland\Views\_ViewImports.cshtml"
using Helperland;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Dhrumil Mehta\Desktop\ddm\ff\Helperland\Views\_ViewImports.cshtml"
using Helperland.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5311796f4577f399c41d1dc7d2fce0f555a2caa4", @"/Views/Admin/AdminDashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b5f94cf04a7ec23f27ac33992ef127038e0b3154", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_AdminDashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/service_request.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/Admin-datatable.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/admin.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Images/user.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Images/logout.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn rounded-pill book-btn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Logout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "UserManage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Dhrumil Mehta\Desktop\ddm\ff\Helperland\Views\Admin\AdminDashboard.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<!DOCTYPE html>\n<html lang=\"en\">\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5311796f4577f399c41d1dc7d2fce0f555a2caa47902", async() => {
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">

    <!-- Bootstrap CSS -->
    <link href=""https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css"" rel=""stylesheet""
          integrity=""sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC"" crossorigin=""anonymous"">
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "5311796f4577f399c41d1dc7d2fce0f555a2caa48593", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <link rel=""preconnect"" href=""https://fonts.googleapis.com"">
    <link rel=""preconnect"" href=""https://fonts.gstatic.com"" crossorigin>
    <link href=""https://fonts.googleapis.com/css2?family=Roboto&display=swap"" rel=""stylesheet"">

    <link rel=""stylesheet"" href=""https://code.jquery.com/ui/1.13.0/themes/base/jquery-ui.css"">
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "5311796f4577f399c41d1dc7d2fce0f555a2caa410202", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"

    <script src=""https://code.jquery.com/jquery-3.6.0.js"" defer></script>
    <script src=""https://code.jquery.com/ui/1.13.0/jquery-ui.js"" defer></script>
    <script src=""https://cdn.datatables.net/1.11.5/js/jquery.dataTables.min.js"" defer></script>

    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5311796f4577f399c41d1dc7d2fce0f555a2caa411639", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("defer", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n    <!--script src=\"~/js/paging.js\" defer></script-->\n\n\n\n    <title>Admin Page</title>\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5311796f4577f399c41d1dc7d2fce0f555a2caa413855", async() => {
                WriteLiteral(@"


    <!--Navigation Bar-->
    <nav class=""navbar  navbar-expand-lg"">
        <div class=""container-fluid navbar_div"">
            <a class=""navbar-brand"" href=""homepage.html"">
                helperland
            </a>

            <button class=""navbar-toggler navbar-dark"" type=""button"" data-bs-toggle=""collapse""
                    data-bs-target=""#navbarSupportedContent"" aria-controls=""navbarSupportedContent"" aria-expanded=""false""
                    aria-label=""Toggle navigation"" style=""font-size:20px;outline: none !important;box-shadow: none;"">
                <span class=""navbar-toggler-icon"">
                    <i class=""fas fa-bars""></i>
                </span>
            </button>

            <div class=""collapse navbar-collapse"" id=""navbarSupportedContent"">
                <ul class=""navbar-nav ms-auto mb-2 mb-lg-0 text-end"">

                    <li class=""nav-item nav-options user-btn"">
                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "5311796f4577f399c41d1dc7d2fce0f555a2caa415089", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("<span>\n                            ");
#nullable restore
#line 59 "C:\Users\Dhrumil Mehta\Desktop\ddm\ff\Helperland\Views\Admin\AdminDashboard.cshtml"
                       Write(ViewBag.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("&nbsp;");
#nullable restore
#line 59 "C:\Users\Dhrumil Mehta\Desktop\ddm\ff\Helperland\Views\Admin\AdminDashboard.cshtml"
                                          Write(ViewBag.Lname);

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                        </span>\n                    </li>\n                    <li class=\"nav-item nav-options logout-btn\">\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5311796f4577f399c41d1dc7d2fce0f555a2caa416964", async() => {
                    WriteLiteral("\n                            ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "5311796f4577f399c41d1dc7d2fce0f555a2caa417254", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\n                        ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_10.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_11.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                    </li>

                </ul>
            </div>
        </div>
    </nav>





    <section class=""main-section"">
        <div class=""side-nav"" id=""lnav-list"">
            <ul>
                <li><button class=""lnav-link"">Service Management</button></li>
                <li><button class=""lnav-link"">Role Management</button></li>
                <li>
                    <button class=""accordion-button collapsed"" data-bs-toggle=""collapse"" data-bs-target=""#collapseOne""
                            aria-expanded=""false"" aria-controls=""collapseOne"">
                        Coupon Code Management
                    </button>
                    <div id=""collapseOne"" class=""accordion-collapse collapse"">
                        <div class=""accordion-body"">
                            <button class=""lnav-link"">Coupon Codes</button>
                            <button class=""lnav-link"">Usage History</button>
                        </div>
                    </div>
                </li>
          ");
                WriteLiteral(@"      <li><button class=""lnav-link"">Escalation Management</button></li>
                <li>
                    <button class=""active lnav-link"" onclick=""NavBtnServReq()"" id=""ServiceReqBtn"">
                        Service Requests
                    </button>
                </li>
                <li><button class=""lnav-link"">Service Providers</button></li>
                <li><button class=""lnav-link"" onclick=""NavBtnUserMng()"" id=""UserMngBtn"">User Management</button></li>
                <li>
                    <button class=""accordion-button collapsed"" data-bs-toggle=""collapse"" data-bs-target=""#collapseTwo""
                            aria-expanded=""false"" aria-controls=""collapseTwo"">
                        Finance Module
                    </button>
                    <div id=""collapseTwo"" class=""accordion-collapse collapse"">
                        <div class=""accordion-body"">
                            <button class=""lnav-link"">All Transactions</button>
                            <button class=""");
                WriteLiteral(@"lnav-link"">Generate Payment</button>
                            <button class=""lnav-link"">Customer Invoices</button>
                        </div>
                    </div>
                </li>
                <li><button class=""lnav-link"">Zip Code Management</button></li>
                <li><button class=""lnav-link"">Rating Management</button></li>
                <li><button class=""lnav-link"">Inquiry Management</button></li>
                <li><button class=""lnav-link"">Newsletter Management</button></li>
                <li>
                    <button class=""accordion-button collapsed"" data-bs-toggle=""collapse"" data-bs-target=""#collapseThree""
                            aria-expanded=""false"" aria-controls=""collapseThree"">
                        Content Management
                    </button>
                    <div id=""collapseThree"" class=""accordion-collapse collapse"">
                        <div class=""accordion-body"">
                            <button class=""lnav-link"">Blog</button>
         ");
                WriteLiteral("                   <button class=\"lnav-link\">FAQs</button>\n                        </div>\n                    </div>\n                </li>\n            </ul>\n        </div>\n\n\n\n        ");
#nullable restore
#line 137 "C:\Users\Dhrumil Mehta\Desktop\ddm\ff\Helperland\Views\Admin\AdminDashboard.cshtml"
   Write(await Html.PartialAsync("ServiceRequestPage"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n\n        ");
#nullable restore
#line 139 "C:\Users\Dhrumil Mehta\Desktop\ddm\ff\Helperland\Views\Admin\AdminDashboard.cshtml"
   Write(await Html.PartialAsync("UserManagePage"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"


    </section>




    <section class=""modal-popup"">

        <!-- Button trigger modal -->
        <button type=""button"" class=""btn btn-primary d-none"" data-bs-toggle=""modal"" id=""ServiceEditBtn""
                data-bs-target=""#ServiceEditModal"">
            Service Edit modal
        </button>

        <!-- Modal -->
        <div class=""modal fade"" id=""ServiceEditModal"" tabindex=""-1"" aria-labelledby=""exampleModalLabel""
             aria-hidden=""true"">
            <div class=""modal-dialog modal-dialog-centered"" style=""max-width: 550px;"">
                <div class=""modal-content"">
                    <div class=""modal-header"">
                        <h5 class=""modal-title"" id=""exampleModalLabel"" style=""font-weight: 600;"">Edit Service Request</h5>
                        <button type=""button"" id=""ServiceEditModalClose"" class=""btn-close"" data-bs-dismiss=""modal""
                                aria-label=""Close""></button>
                    </div>
                    <div class=""modal-body"" style=""font-wei");
                WriteLiteral(@"ght:500"">
                        <!--div class=""alert alert-danger d-none mt-3 d-flex justify-content-center""
                             style=""max-width:800px"" id=""ServiceEditPopupAlert"" role=""alert"">
                        </div-->

                        <div class=""row"">
                            <div class=""col-md-6"">
                                <label for=""ServiceEditDate"" class=""form-label"">Date</label>
                                <input type=""date"" class=""form-control"" name=""date"" id=""ServiceEditDate""
                                       placeholder=""calender"">
                            </div>
                            <div class=""col-md-6"">
                                <label class=""form-label"" for=""ServiceEditTime"">Time</label>
                                <input type=""time"" id=""ServiceEditTime"" class=""form-control"">
                            </div>
                        </div>

                        <p class=""form-label mt-4"" style=""font-weight:700;margin-bottom: 20");
                WriteLiteral(@"px;""> Service Address</p>

                        <div class=""row mb-2"">
                            <div class=""col-md-6"">
                                <label for=""ServiceEditStreet"" class=""form-label"">Street Name</label>
                                <input type=""text"" class=""form-control"" name=""Street"" id=""ServiceEditStreet"">
                            </div>
                            <div class=""col-md-6"">
                                <label for=""ServiceEditHouse"" class=""form-label"">House No</label>
                                <input type=""text"" class=""form-control"" name=""House"" id=""ServiceEditHouse"">
                            </div>
                        </div>
                        <div class=""row"">
                            <div class=""col-md-6"">
                                <label for=""ServiceEditZipCode"" class=""form-label"">PostalCode</label>
                                <input type=""text"" class=""form-control"" name=""PostalCode"" id=""ServiceEditZipCode"">
                   ");
                WriteLiteral(@"         </div>
                            <div class=""col-md-6"">
                                <label for=""ServiceEditCity"" class=""form-label"">City</label>
                                <input type=""text"" class=""form-control"" name=""City"" id=""ServiceEditCity"" style=""cursor:not-allowed"">

                            </div>
                        </div>
                        <p class=""form-label mt-4"" style=""font-weight:700;margin-bottom: 20px;""> Invoice Address</p>

                        <div class=""row mb-2"">
                            <div class=""col-md-6"">
                                <label for=""ServiceEditInvoiceStreet"" class=""form-label"">Street Name</label>
                                <input type=""text"" class=""form-control"" name=""Street"" id=""ServiceEditInvoiceStreet"">
                            </div>
                            <div class=""col-md-6"">
                                <label for=""ServiceEditInvoiceHouse"" class=""form-label"">House No</label>
                               ");
                WriteLiteral(@" <input type=""text"" class=""form-control"" name=""House"" id=""ServiceEditInvoiceHouse"">
                            </div>
                        </div>
                        <div class=""row"">
                            <div class=""col-md-6"">
                                <label for=""ServiceEditInvoiceZipCode"" class=""form-label"">PostalCode</label>
                                <input type=""text"" class=""form-control"" name=""PostalCode""
                                       id=""ServiceEditInvoiceZipCode"">
                            </div>
                            <div class=""col-md-6"">
                                <label for=""ServiceEditInvoiceCity"" class=""form-label"">City</label>
                                <input type=""text"" class=""form-control"" name=""City"" id=""ServiceEditInvoiceCity"" style=""cursor:not-allowed"">

                            </div>
                        </div>
                        <div class=""row"">

                            <div class=""row mt-4"">
                        ");
                WriteLiteral(@"        <label for=""ServiceWhyEdit"" class=""form-label "">
                                    Why do you want to
                                    reSchedule Service req?
                                </label>
                                <textarea class=""form-control ms-2"" name=""City"" id=""ServiceWhyEdit""></textarea>
                            </div>
                            <div class=""row mt-4"">
                                <label for=""ServiceWhyCall"" class=""form-label"">
                                    Call Center EMP Notes
                                </label>
                                <textarea class=""form-control ms-2"" name=""City"" id=""ServiceWhyCall""
                                          placeholder=""Enter Notes""></textarea>
                            </div>
                            <div class=""row mt-4 mb-2"">
                                <button type=""button"" id=""ServEditUpdateBtn""
                                        class="" ms-2 btn btn-primary "">
              ");
                WriteLiteral(@"                      Update
                                </button>
                            </div>

                        </div>

                    </div>




                </div>
            </div>
        </div>

    </section>



    <script src=""https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js""
            integrity=""sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM""
            crossorigin=""anonymous"">

    </script>
    


");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n</html>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
