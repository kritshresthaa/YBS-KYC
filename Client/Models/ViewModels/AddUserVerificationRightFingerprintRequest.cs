using Client.Models.KYC;
using System.ComponentModel.DataAnnotations.Schema;

namespace Client.Models.ViewModels
{
    public class AddUserVerificationRightFingerprintRequest
    {
   
        public byte[] F2 { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual UserDetail UserDetail { get; set; }
    }
}
