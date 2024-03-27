using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.ViewModel;
using FluentValidation;

namespace Core.Application.Validator;

public class AddUserValidator : AbstractValidator<VM_AddUser>
{
    public AddUserValidator()
    {
        RuleFor(u => u.Email).EmailAddress().NotEmpty();
        RuleFor(u => u.Password).NotEmpty().MaximumLength(15);
        RuleFor(u => u.Name).NotEmpty().MaximumLength(20);
        RuleFor(u => u.Surname).NotEmpty().MaximumLength(20);
    }
}