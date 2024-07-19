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
                    new User { Id =new Guid("65a6e05f-9777-4145-956e-cc25698d4c4d"), Name = "Tom", Email = "Tom@mail.ru", Password ="Password1" },
                    new User { Id = Guid.NewGuid(), Name = "Alice", Email = "Alice@mail.ru", Password = "Password2" },
                    new User { Id = Guid.NewGuid(), Name = "Bob", Email = "Bob@mail.ru", Password = "Password1" }
            );
        }
    }
}
