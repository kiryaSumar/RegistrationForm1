using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RegistrationForm.BLL;
namespace RegistrationForm.DAL
{
    public class ApplicationContext: DbContext
    {
        public DbSet<User> Users { get; set; }// =null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)//пробовать без
        {
            modelBuilder.Entity<User>().HasData(
                    new User { Id = Guid.NewGuid(), Name = "Tom", Email = "Tom@mail.ru", Password ="Password1" },
                    new User { Id = Guid.NewGuid(), Name = "Alice", Email = "Alice@mail.ru", Password = "Password2" },
                    new User { Id = Guid.NewGuid(), Name = "Bob", Email = "Bob@mail.ru", Password = "Password1" }
            );
        }
    }
}
