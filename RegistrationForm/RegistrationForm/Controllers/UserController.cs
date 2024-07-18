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
    [ApiController]//note that it is a controller
    [Route("api/v1/[controller]")]//
    public class UserController : Controller
    {
        private readonly IUserService _userService;//dependency injection takes place, singletone scope and smth else(уровни изолированности, но не совсем)
        private readonly IValidator<User> _validator;// = new UserValidator();/////////////

        public UserController( IUserService userService, IValidator<User> validator)
        {
            
            _userService = userService;
            _validator = validator;

        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser([FromRoute(Name = "id")] Guid Id)
        {
            //var user = await _userService.Users.FindAsync();
            return Ok(new User());
        }

        [HttpPost]//ActionResult - read about
        public async Task<ActionResult<User>> CreateUser([FromBody] User user)
        {

            var saveUser = _userService.CreateUser(user);
            var result = _validator.Validate(user);//changed type from ValidationResult to var

            if (!result.IsValid)
            {
                return BadRequest(result.ToString("\n"));
            }

            return Ok(saveUser);
            
        }

    }
}