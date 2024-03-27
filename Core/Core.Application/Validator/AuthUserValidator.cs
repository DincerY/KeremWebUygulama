using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.ViewModel;
using FluentValidation;

namespace Core.Application.Validator;

public class AuthUserValidator : AbstractValidator<VM_AuthUser>
{
    public AuthUserValidator()
    {
        RuleFor(u => u.Email).EmailAddress().NotEmpty();
        RuleFor(u => u.Password).NotEmpty().MaximumLength(20);
    }
}