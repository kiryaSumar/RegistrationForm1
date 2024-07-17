using Microsoft.AspNetCore.Mvc;
using RegistrationForm.BLL;
using RegistrationForm.BLL.Services;

namespace RegistrationForm.PL.Controllers
{
    [ApiController]//помечаем что это контроллер
    [Route("api/v1/[controller]")]//
    public class UserController : Controller
    {
        private readonly IUserService _userService;//dependency injection takes place, singletone scope and smth else(уровни изолированности, но не совсем)
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser([FromRoute(Name = "id")] Guid Id)
        {
            //var user = await _userService.Users.FindAsync();
            return Ok(new User());
        }

        [HttpPost]//ActionResult - read about
        public ActionResult<User> CreateUser([FromBody] User user)
        {

            var saveUser = _userService.CreateUser(user);
            return Ok(saveUser);
        }

    }
}
