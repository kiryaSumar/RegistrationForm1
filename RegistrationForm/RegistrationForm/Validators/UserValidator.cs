using FluentValidation;
using global::RegistrationForm.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationForm.PL.Validators
{
    

   
        public class UserValidator : AbstractValidator<User>
        {
        
            public UserValidator()
            {
            RuleFor(x => x.Id)
           .NotNull().WithMessage("Id must not be null");
            RuleFor(x => x.Name)
            .Length(1, 20).WithMessage("Name Length must be between 1 and 20 symbols");
            RuleFor(x => x.Email)
            .EmailAddress().WithMessage("Invalid Email adress");
            RuleFor(x => x.Password)
            .Length(8, 25).WithMessage("Password Length must be between 8 and 20 symbols");
            RuleFor(x=>x.Password).NotEqual(x=>x.Password.ToLower())
                .WithMessage("Password must contain at least 1 upper case symbol")
                .Matches(@"(\d)").WithMessage("Password must contain at least 1 digit");

             }
        }
}

