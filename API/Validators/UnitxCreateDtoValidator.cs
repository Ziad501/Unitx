using API.Models.Dto;
using FluentValidation;

namespace API.Validators
{
    public class UnitxCreateDtoValidator : AbstractValidator<UnitxDto>
    {
        public UnitxCreateDtoValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Details).NotEmpty().MaximumLength(500);
            RuleFor(x => x.Rate).NotEmpty();
            RuleFor(x => x.Area).GreaterThan(0);
            RuleFor(x => x.Ocupancy).GreaterThanOrEqualTo(0);
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Invalid Image URL");
            RuleFor(x => x.Amenity).NotEmpty();
        }
    }
}
