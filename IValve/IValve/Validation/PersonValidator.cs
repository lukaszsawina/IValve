using DataAccessLibrary.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IValve.Validation
{
    public class PersonValidator : AbstractValidator<PersonModel>
    {
        public PersonValidator()
        {
            RuleFor(x => x.Firstname).NotEmpty().Length(3, 50).WithMessage("First name is empty");
            RuleFor(x => x.Lastname).NotEmpty().Length(3, 50).WithMessage("Last name is empty");
            RuleFor(x => x.BirthDate).NotEmpty().LessThan(DateTime.Now).WithMessage("Date is in future");
        }
    }
}
