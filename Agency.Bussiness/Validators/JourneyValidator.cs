using Agency.Entities.Models.Request;
using FluentValidation;


namespace Agency.Bussiness.Validators
{
    public class JourneyValidator:AbstractValidator<RequestJourney>
    {
        public JourneyValidator()
        {
            RuleFor(x => x.DepartureStation)
                .NotNull().WithMessage("Field DepartureStation cannot be null")
                .NotEmpty().WithMessage("Fiel DepartureStation cannot be empty")
                .Length(3, 3).WithMessage("Fiel DepartureStation must have exactly 3 characters")
                .Matches("^[A-Z]*$").WithMessage("Field Departure can only contain letters");

            RuleFor(x => x.ArrivalStation)
                .NotNull().WithMessage("Field ArrivalStation cannot be null")
                .NotEmpty().WithMessage("Fiel ArrivalStation cannot be empty")
                .Length(3, 3).WithMessage("Fiel ArrivalStation must have exactly 3 characters")
                .Matches("^[A-Z]*$").WithMessage("Field ArrivalStation can only contain letters");
        }
    }
}
