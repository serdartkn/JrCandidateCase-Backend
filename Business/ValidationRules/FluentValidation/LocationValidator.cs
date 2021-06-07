using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class LocationValidator : AbstractValidator<Location>
    {
        public LocationValidator() 
        {
            RuleFor(l => l.City).MinimumLength(2);
            RuleFor(l => l.Country).MinimumLength(2);
            RuleFor(l => l.PostCode).MinimumLength(2);
            RuleFor(l => l.State).MinimumLength(2);
            RuleFor(l => l.StreetId).NotNull();
        }
    }
}