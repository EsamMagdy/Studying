using FluentValidation;

namespace MediatRAndCQRS.Features.Students;

public class CreateStudentValidator : AbstractValidator<CreateStudent.Command>
{
    public CreateStudentValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100);

        RuleFor(x => x.Age)
            .InclusiveBetween(5, 120).WithMessage("Age must be between 5 and 120.");
    }
}
