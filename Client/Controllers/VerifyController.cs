using Client.Data;
using Client.Models.KYC;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class VerifyController : Controller
    {
        private readonly KycDbContext kycDbContext_;

        public VerifyController(KycDbContext kycDbContext)
        {
            this.kycDbContext_ = kycDbContext;
        }

        public IActionResult VerifyA(int userId_)
        {

            UserDetail? userDetailFromDB = kycDbContext_.UserDetails.Find(userId_);



            if (userDetailFromDB == null)
            {
                return NotFound();
            }
            return View(userDetailFromDB);
        }

        [HttpPost]
        public IActionResult VerifyA(UserDetail userDetail)
        {
            if(ModelState.IsValid)
            {
                kycDbContext_.UserDetails.Update(userDetail);
                kycDbContext_.SaveChanges();
                TempData["success"] = "Details Saved Successfully";
                int userId_ = userDetail.Id;
                return RedirectToAction ("VerifyB","VerifyB", new {userId=userId_});
            }
           

            return View();
        }
   

    }
}
