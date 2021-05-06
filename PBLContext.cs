using Microsoft.EntityFrameworkCore;

namespace PBL.Models
{
    public class PBLContext : DbContext
    {
        public PBLContext(DbContextOptions<PBLContext> options) : base(options)
        {



        }
        public DbSet<chocolate> chocolates { get; set; }
    }
}