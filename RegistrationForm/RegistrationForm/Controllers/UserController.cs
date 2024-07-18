using Microsoft.AspNetCore.Mvc;
using RegistrationForm.BLL;
using RegistrationForm.BLL.Services;
using RegistrationForm.PL.Contexts;

namespace RegistrationForm.PL.Controllers
{
    [ApiController]//помечаем что это контроллер
    [Route("api/v1/[controller]")]//
    public class UserController : Controller
    {
        static Guid firstUserGuid = new Guid("7247d7c7-e367-459d-9269-eb1f2f1985ae");
        
        private static List<User> users = new List<User>(new[] {
            new User() { Id = firstUserGuid, Name = "Jack",Email = "Jack@mail.ru", Password = "J1"},
            new User() { Id = Guid.NewGuid(),Name = "Jane",Email = "Jane@mail.ru", Password = "J2"},
            new User() { Id = Guid.NewGuid(),Name = "Andy",Email = "Andy@mail.ru", Password = "A1"},
        });
        //private readonly ApplicationContext _context;
        private readonly IUserService _userService;//dependency injection takes place, singletone scope and smth else(уровни изолированности, но не совсем)
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
         public ActionResult<User> GetUser([FromRoute(Name = "id")] Guid Id)//Полинин Вариант
        //public IActionResult GetUser(Guid Id)//скорее всего, нужно сделать метод асинхронным
        {
            // var user = /*await*/ _context.Users.FindAsync();

            //var user = users.SingleOrDefault(u => u.Id == Id);
            //if (user == null)
            //{
            //     return  NotFound();
            //}
            //return  Ok(user);
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
