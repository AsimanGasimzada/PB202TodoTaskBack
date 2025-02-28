using FluentValidation;

namespace Todo_PB202.Validators.TodoValidators;

public class TodoCreateDtoValidator : AbstractValidator<TodoCreateDto>
{
    public TodoCreateDtoValidator()
    {
        RuleFor(x => x.Title).NotNull().NotEmpty().MaximumLength(10);
    }
}
