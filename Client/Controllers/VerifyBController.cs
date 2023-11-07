using Client.Data;
using Client.Models.KYC;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class VerifyBController : Controller
    {
        private readonly KycDbContext kycDbContext_;

        public VerifyBController(KycDbContext kycDbContext)
        {
            this.kycDbContext_ = kycDbContext;
        }

        public IActionResult VerifyB(int userId)
        {

            FamilyDetail? familyDetailFromDB = kycDbContext_.FamilyDetails.Find(userId);



            if (familyDetailFromDB == null)
            {
                return NotFound();
            }
            return View(familyDetailFromDB);
         
        }
        [HttpPost]
        public IActionResult VerifyB(FamilyDetail familyDetail)
        {     
            kycDbContext_.FamilyDetails.Update(familyDetail);
            kycDbContext_.SaveChanges();
            TempData["success"] = "Details Saved Successfully";
            return RedirectToAction("Index","Home");
         
         
        }
                
    }
}
