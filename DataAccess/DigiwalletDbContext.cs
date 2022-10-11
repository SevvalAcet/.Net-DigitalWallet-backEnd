using Digiwallet.Entities;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Digiwallet.DataAccess
{
    public class DigiwalletDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-AKE6CH7; Database=Digiwallet;Trusted_Connection=True;");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<LastTransaction> LastTransactions { get; set; }
    }
}
