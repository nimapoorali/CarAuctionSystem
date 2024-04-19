using CarAuction.Resources;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAuction.Application.Features.Bids.Queries.Validators
{
    public class CalculateBidQueryValidator : AbstractValidator<CalculateBidQuery>
    {
        public CalculateBidQueryValidator()
        {
            RuleFor(t => t.CarType)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage(string.Format(Messages.RequiredField, "{PropertyName}"))
                .NotEmpty();

            RuleFor(t => t.CarPrice)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage(string.Format(Messages.RequiredField, "{PropertyName}"));

            //CarPrice must be maximum 9 digits with 2 decimals 
            RuleFor(x => x.CarPrice)
                .PrecisionScale(9, 2, false)
                .WithMessage(Messages.InvalidCarPriceFormat);

        }
    }
}
