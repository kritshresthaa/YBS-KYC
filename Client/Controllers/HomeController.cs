using Client.Data;
using Client.Models;
using Client.Models.KYC;
using Client.Models.ViewModels;
using Grpc.Net.Client;
using GrpcClient.Fingerprint;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly KycDbContext kycDbContext_;
        private bool isInitialized;


        public HomeController(ILogger<HomeController> logger, KycDbContext kycDbContext)
        {
            this.kycDbContext_ = kycDbContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Index(AddUserDetailsRequest addUserDetailsRequest)
        {
            var userDetail = new UserDetail
            {
                AccountNumber = addUserDetailsRequest.AccountNumber,
                UserName = addUserDetailsRequest.UserName,
                UserNumber = addUserDetailsRequest.UserNumber,
                UserDob = addUserDetailsRequest.UserDob,
                District = addUserDetailsRequest.District,
                Municipality = addUserDetailsRequest.Municipality,
                Tole = addUserDetailsRequest.Tole,
                HouseNumber = addUserDetailsRequest.HouseNumber,
                WardNumber = addUserDetailsRequest.WardNumber,
                Education = addUserDetailsRequest.Education,
                FatherName = addUserDetailsRequest.FatherName,
                GrandFatherName = addUserDetailsRequest.GrandFatherName,
                Spouse = addUserDetailsRequest.Spouse,
                Occupation = addUserDetailsRequest.Occupation,
                Institution = addUserDetailsRequest.Institution,
                Designation = addUserDetailsRequest.Designation,
                AnnualTransaction = addUserDetailsRequest.AnnualTransaction,
                OtherBank =
                addUserDetailsRequest.OtherBank,
                CrimalAct = addUserDetailsRequest.CrimalAct,


            };
            kycDbContext_.UserDetails.Add(userDetail);
            kycDbContext_.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("SectionB", "SectionB", new { userId = userDetail.Id });
        }       


   
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}