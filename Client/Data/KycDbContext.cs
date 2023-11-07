using Client.Models.KYC;
using Microsoft.EntityFrameworkCore;

namespace Client.Data
{
    public class KycDbContext : DbContext
    {
        public KycDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<FamilyDetail> FamilyDetails { get; set; }
        public DbSet<LeftFingerprintDetail> LeftVerificationDetails { get; set; }
        public DbSet<RightFingerprintDetail> RightVerificationDetails { get; set; }



    }
}
