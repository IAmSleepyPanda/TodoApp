using FluentValidation;
using Todo.Core.Commands;

namespace Todo.Core.Validations
{
    public class CreateTodoItemCommandValidator : AbstractValidator<CreateTodoItemCommand>
    {
        public CreateTodoItemCommandValidator()
        {
            RuleFor(x => x.TaskName).NotNull()
                .NotEmpty()
                .WithMessage("Название задачи не может быть пустым");

            RuleFor(x => x.Commentary)
                .Matches(@"\d")
                .WithMessage("Коментарий должен содержать цифры");
        }
    }
}
