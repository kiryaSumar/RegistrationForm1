using Microsoft.EntityFrameworkCore;
using RegistrationForm.BLL;
namespace RegistrationForm.PL.Contexts
{
   
        public class UserContext : DbContext
        {
            public UserContext(DbContextOptions<UserContext> options)
                : base(options)
            {
            }

            public DbSet<User> TodoItems { get; set; } = null!;
        }
    
}
