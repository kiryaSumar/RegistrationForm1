using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationForm.BLL.Services
{
    internal class UserValidator: AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).Length(1, 20);
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).EmailAddress();

        }
    }
}
