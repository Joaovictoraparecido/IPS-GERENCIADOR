using Microsoft.EntityFrameworkCore;

namespace ips.Models
{
    public class BancoDeDados1 : DbContext
    {
        public DbSet<EnderecoIP> EnderecoIPs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ips;Integrated Security=True");
        }

    }
}
