using DataAccessLibrary.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IValve.Validation
{
    public class JobValidator : AbstractValidator<JobModel>
    {
        public JobValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(3, 50).WithMessage("First name is empty");
            RuleFor(x => x.Type).NotNull().WithMessage("Type is not selected");
            RuleFor(x => x.Deadline).NotEmpty().GreaterThan(DateTime.Now).WithMessage("Date is in past");
            RuleFor(x => x.Persons.Count).GreaterThan(0).WithMessage("No person selected");

        }
    }
}
