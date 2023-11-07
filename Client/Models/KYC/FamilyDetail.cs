using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Client.Models.KYC
{
    public class FamilyDetail
    {
        [Key]
        public int Id { get; set; } // Primary key (or you can use another identifier)
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