using FluentValidation;
using HospitalManagement.Application.DTOs;
namespace HospitalManagement.Application.Validators
{
    public class CreatePatientDtoValidator : AbstractValidator<CreatePatientDto>
    {
        public CreatePatientDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required")
                .MaximumLength(100);

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Age)
                .InclusiveBetween(0, 120);

            RuleFor(x => x.Gender)
                .NotEmpty();
        }

    }
}
