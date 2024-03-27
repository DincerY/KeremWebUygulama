using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.ViewModel;
using FluentValidation;

namespace Core.Application.Validator;

public class UpdateUserValidator : AbstractValidator<VM_UpdateUser>
{
    public UpdateUserValidator()
    {
        RuleFor(u => u.Id).NotEmpty();
        RuleFor(u => u.Password).NotEmpty().MaximumLength(20);

    }
}