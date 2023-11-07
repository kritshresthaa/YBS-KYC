using Client.Data;
using Client.Models.KYC;
using Client.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class SectionBController : Controller
    {
        private readonly KycDbContext kycDbContext_;
        private int userId_;


        public SectionBController(KycDbContext kycDbContext)
        {
            this.kycDbContext_ =  kycDbContext;
        }
        [HttpGet]
        public IActionResult SectionB(int userId)
        {
            userId_ = userId;
           ViewBag.getId = userId;
            return View();
        }
        [HttpPost]
        public IActionResult SectionB(AddUserFamilyDetailsRequest addUserFamilyDetailsRequest)
        {
/*            int userID = addUserFamilyDetailsRequest.userid;*/
            var familyDetail = new FamilyDetail
            {
                userid = addUserFamilyDetailsRequest.userid,
                MotherName = addUserFamilyDetailsRequest.MotherName,
                SonName = addUserFamilyDetailsRequest.SonName,
                DaughterName = addUserFamilyDetailsRequest.DaughterName,
                DaughterInLaw = addUserFamilyDetailsRequest.DaughterInLaw,
                FatherInLaw = addUserFamilyDetailsRequest.FatherInLaw,
                PanNumber = addUserFamilyDetailsRequest.PanNumber,
                SourceOfIncome = addUserFamilyDetailsRequest.SourceOfIncome,
               
            };

            kycDbContext_.FamilyDetails.Add(familyDetail);
            kycDbContext_.SaveChanges();
            ModelState.Clear();

            return RedirectToAction("SectionC", "SectionC", new {userId = familyDetail.userid });
        }
    }
}
