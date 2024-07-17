using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationForm.BLL.Services
{
    public interface IUserService
    {// task - read about
        //Task<User> GetUserByEmail(string email);
        Task<User> CreateUser(User user);

    }
}
