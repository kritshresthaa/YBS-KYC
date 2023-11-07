using Client.Data;
using Microsoft.AspNetCore.Mvc;
using Grpc.Net.Client;
using GrpcClient.Fingerprint;
using Client.Models;
using Client.Models.ViewModels;
using Client.Models.KYC;

namespace Client.Controllers
{
    public class SectionCController : Controller
    {
        private readonly KycDbContext kycDbContext_;

        private bool isInitialized;
        Byte[] f1, f2;
        public SectionCController(KycDbContext kycDbContext)
        {
            this.kycDbContext_ = kycDbContext;
        }
        [HttpGet]
        public IActionResult SectionC(int userId)
        {
       
            ViewBag.getId = userId;
          
            return View();
        }
        [HttpGet]
        public JsonResult btn_InitSecugen()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7028");
            var secugenClient = new Fingerprint.FingerprintClient(channel);
            InitializeRequest initializeRequest = new InitializeRequest();
            var secugenResponse = secugenClient.InitializeDevice(initializeRequest);

            SecugenData secugenData; // Declare the variable

            if (secugenResponse.Success)
            {
                // The device was successfully initialized
                secugenData = new SecugenData
                {
                    result = "Connected"
                };
                Console.WriteLine("Device Successfully Connected");
            }
            else
            {
                secugenData = new SecugenData
                {
                    result = "Device not Connected"
                };
                Console.WriteLine("Device initialization failed: " + " " + secugenResponse.ErrorMessage);
            }

            return Json(secugenData);
        }



        [HttpPost] // Use [HttpPost] attribute for handling POST requests
        public JsonResult CaptureLeftFingerprint([FromBody] AddUserVerificationLeftFingerprintRequest addUserVerificationLeftFingerprintRequest)
        {
            // You can access the UserID directly from addUserVerificationFingerprintRequest
            int userId = addUserVerificationLeftFingerprintRequest.UserID;

            var channel = GrpcChannel.ForAddress("https://localhost:7028");
            var secugenClient = new Fingerprint.FingerprintClient(channel);
            CaptureRequest captureRequest = new CaptureRequest();
            var response = secugenClient.CaptureLeftFingerprint(captureRequest);
            secugenCapture secugenDataCapture;

            if (response.Success)
            {
                f1 = response.FingerprintData.ToByteArray();
                var userFingerprintData = new LeftFingerprintDetail
                {
                    F1 = f1,
                    UserID = userId, // Use the captured UserID
                };
                kycDbContext_.LeftVerificationDetails.Add(userFingerprintData);
                kycDbContext_.SaveChanges();
                secugenDataCapture = new secugenCapture
                {
                    result = "Captured",
                };
            }
            else
            {
                secugenDataCapture = new secugenCapture
                {
                    result = "Error",
                };
            }
            return Json(secugenDataCapture);
        }

        [HttpPost] // Use [HttpPost] attribute for handling POST requests

        public JsonResult CaptureRightFingerprint([FromBody] AddUserVerificationRightFingerprintRequest addUserVerificationRightFingerprintRequest)
        {
            // You can access the UserID directly from addUserVerificationFingerprintRequest
            int userId = addUserVerificationRightFingerprintRequest.UserID;

            var channel = GrpcChannel.ForAddress("https://localhost:7028");
            var secugenClient = new Fingerprint.FingerprintClient(channel);
            CaptureRequest captureRequest = new CaptureRequest();
            var response = secugenClient.CaptureRightFingerprint(captureRequest);
            secugenCapture secugenDataCapture;

            if (response.Success)
            {
                f2 = response.FingerprintData.ToByteArray();
                var userFingerprintData = new RightFingerprintDetail
                {
                    UserID = userId,
                    F2 = f2,
                };
                kycDbContext_.RightVerificationDetails.Add(userFingerprintData);
                kycDbContext_.SaveChanges();
                secugenDataCapture = new secugenCapture
                {
                    result = "Captured",
                };
            }
            else
            {
                secugenDataCapture = new secugenCapture
                {
                    result = "Error",
                };
            }
            return Json(secugenDataCapture);
        }
      
        public IActionResult SectionCNext(int userId)
        {
            TempData["success"] = "Please do verify the entered details";
            return RedirectToAction("VerifyA", "Verify", new {userId_=userId});
        }


    }
}


