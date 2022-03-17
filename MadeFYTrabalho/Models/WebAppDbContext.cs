using Microsoft.EntityFrameworkCore;

namespace MadeFYTrabalho.Models
{
    public class WebAppDbContext : DbContext
    {
        public WebAppDbContext(DbContextOptions<WebAppDbContext> options) : base(options)
        {
        }
        public DbSet<Frase> Frases { get; set; }
    }
}