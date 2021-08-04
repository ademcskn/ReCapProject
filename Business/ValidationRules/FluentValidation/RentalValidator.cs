using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FleuntValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.ReturnDate).Must(ReturnDateNull).WithMessage(Messages.VecihleError);
        }

        private bool ReturnDateNull(DateTime? arg)
        {
            return arg == null ? true : false;
        }
    }
}
