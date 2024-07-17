using Microsoft.EntityFrameworkCore;
using RegistrationForm.BLL;
namespace RegistrationForm.PL.Contexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public ApplicationContext()=>Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=RegistrationForm.db");
        }
    }
}
