using Client.Models.KYC;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Client.Models.ViewModels
{
    public class AddUserFamilyDetailsRequest
    {
        [Required]
        public string MotherName { get; set; }
        public string? SonName { get; set; }
        public string? DaughterName { get; set; }
        public string? DaughterInLaw { get; set; }
        public string? FatherInLaw { get; set; }
        [Required]
        public int PanNumber { get; set; }
        [Required]
        public string SourceOfIncome { get; set; }


        public int userid { get; set; }
        [ForeignKey("userid")]
        public virtual UserDetail userDetail { get; set; }
    }
}
