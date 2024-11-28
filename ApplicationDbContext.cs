using Ebook8.Models;
using Microsoft.EntityFrameworkCore;

namespace Ebook8
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Register> RegisterNewUsertb { get; set; }  // Represents the Users table in the database
    }
}
