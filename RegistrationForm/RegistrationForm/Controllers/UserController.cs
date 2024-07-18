using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RegistrationForm.BLL;
using RegistrationForm.BLL.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace RegistrationForm.PL.Controllers
{
    [ApiController]//помечаем что это контроллер
    [Route("api/v1/[controller]")]//
    public class UserController : Controller
    {
        private UserValidator _validator = new UserValidator;/////////////
        private readonly IUserService _userService;//dependency injection takes place, singletone scope and smth else(уровни изолированности, но не совсем)
        public UserController(IValidator<User> validator, IUserService userService)
        {
            _validator = validator;
            _userService = userService;

        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser([FromRoute(Name = "id")] Guid Id)
        {
            //var user = await _userService.Users.FindAsync();
            return Ok(new User());
        }

        [HttpPost]//ActionResult - read about
        public  ActionResult<User> CreateUser([FromBody] User user)
        {

            var saveUser = _userService.CreateUser(user);
            ValidationResult result = _validator.Validate(user);
            //string numbers = "0123456789";
            //bool containsNumber = false;

            //if (string.IsNullOrEmpty(user.Name))
            //{
            //    return BadRequest();
            //}
            //if (string.IsNullOrEmpty(user.Email))
            //{
            //    return BadRequest();
            //}

            //string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            //Match isMatch = Regex.Match(user.Email, pattern, RegexOptions.IgnoreCase);

            //if (!isMatch.Success)//email check
            //{
            //    return BadRequest();
            //}
            //if (string.IsNullOrEmpty(user.Password))
            //{
            //    return BadRequest();
            //}
            //if (user.Password.Length < 8)
            //{
            //    return BadRequest();
            //}
            //if (user.Password.ToLower() == user.Password)
            //{
            //    return BadRequest();
            //}
            //foreach (var n in numbers)
            //{
            //    if (user.Password.Contains(n))
            //    { 
            //        containsNumber = true;
            //        break;
            //    }
            //}
            //if (!containsNumber)
            //{
            //    return BadRequest();
            //}

            return Ok(saveUser);
            
        }

    }
}