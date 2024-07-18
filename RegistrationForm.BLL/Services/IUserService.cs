namespace RegistrationForm.BLL.Services
{
    public interface IUserService
    {// task - read about
        //Task<User> GetUserByEmail(string email);
        Task<User> CreateUser(User user);
    }
}

