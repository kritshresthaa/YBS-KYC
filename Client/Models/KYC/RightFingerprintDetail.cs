using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Client.Models.KYC
{
    public class RightFingerprintDetail
    {
        [Key]
        public int Id { get; set; }
        public byte[] F2 { get; set; }

        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual UserDetail UserDetail { get; set; }
    }
}
