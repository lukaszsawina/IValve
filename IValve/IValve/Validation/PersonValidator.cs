using FluentValidation;
using IValve.Models;
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
            RuleFor(x => x.Firstname).NotEmpty().Length(3, 50);
            RuleFor(x => x.Lastname).NotEmpty().Length(3, 50);
            RuleFor(x => x.BirthDate).NotEmpty().LessThan(DateTime.Now);
        }
    }
}
