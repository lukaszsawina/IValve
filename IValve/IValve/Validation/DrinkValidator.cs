using DataAccessLibrary.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IValve.Validation
{

    public class DrinkValidator : AbstractValidator<DrinkModel>
    {
        public DrinkValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(3, 50).WithMessage("Name is empty");
            RuleFor(x => x.Amount).NotEmpty().GreaterThan(0).WithMessage("Amount less then 0");
        }
    }

}
