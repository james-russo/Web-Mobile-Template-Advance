using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Models.Domain.UserModels;

namespace Demo.Validation
{
    public class UserProfileValidator : AbstractValidator<UserProfile>
    {
        public UserProfileValidator()
        {
            RuleFor(a => a.FirstName)
                .NotEmpty()
                .WithMessage("First Name required.");

            RuleFor(a => a.LastName)
                .NotEmpty()
                .WithMessage("Last name required.");
        }
    }
}
