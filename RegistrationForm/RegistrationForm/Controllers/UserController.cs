using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RegistrationForm.BLL;
using RegistrationForm.BLL.Services;
using RegistrationForm.DAL;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace RegistrationForm.PL.Controllers
{
    [ApiController]//note that it is a controller
    [Route("api/v1/[controller]")]//
    public class UserController : Controller
    {
        private readonly IUserService _userService;//dependency injection takes place, singletone scope and smth else(уровни изолированности, но не совсем)
        private readonly IValidator<User> _validator;// = new UserValidator();/////////////

        private readonly ApplicationContext _context;//
        public UserController( IUserService userService, IValidator<User> validator, ApplicationContext context)
        {
            
            _userService = userService;
            _validator = validator;

            _context = context;

        }
       //почему FromRoute и FromBody
        [HttpGet("{id}")]
        public ActionResult<User> GetUser([FromRoute(Name = "id")] Guid Id)
        {
            var user = _context.Users.Find(Id);

            //выдает код 200, но не выводит нужного юзера
            //var user = _context.Users.FindAsync(Id);//Как понимает что поиск ведется по Id
            if (user == null)//
            { 
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]//ActionResult - read about
        public ActionResult<User> CreateUser([FromBody] User user)// или все-же Task
        {

            var saveUser = _userService.CreateUser(user);//почуму кидает ошибку и код 500 без Dependency injection
            var result = _validator.Validate(user);//changed type from ValidationResult to var

            if (!result.IsValid)
            {
                return BadRequest(result.ToString("\n"));
            }
            _context.Users.Add(user);//Почему добавляет user но не добавляет saveUser
            return Ok(saveUser);
            
        }

    }
}