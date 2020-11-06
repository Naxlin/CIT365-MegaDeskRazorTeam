using Microsoft.EntityFrameworkCore;

namespace MegaDeskRazor.Data
{
    public class MegaDeskContext : DbContext
    {
        public MegaDeskContext(
            DbContextOptions<MegaDeskContext> options)
            : base(options)
        {
        }

        public DbSet<MegaDeskRazor.Models.Desk> Desk { get; set; }

        public DbSet<MegaDeskRazor.Models.DeskQuote> DeskQuote { get; set; }

        public DbSet<MegaDeskRazor.Models.Delivery> Delivery { get; set; }

        public DbSet<MegaDeskRazor.Models.DesktopMaterial> DesktopMaterial { get; set; }
    }
}