using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Client.Models.KYC
{
    public class LeftFingerprintDetail
    {
        [Key]
        public  int Id { get; set; }
        public byte[] F1 { get; set; }

        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual UserDetail UserDetail { get; set; }

    }
}
