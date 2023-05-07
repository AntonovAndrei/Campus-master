using FluentValidation;

namespace Application.Roles.Commands.AddRoleToEmployee;

public class AddRoleToEmployeeCommandValidator : AbstractValidator<AddRoleToEmployeeCommand>
{
    public AddRoleToEmployeeCommandValidator()
    {
        RuleFor(i => i.EmployeeId).NotEqual(Guid.Empty);
        RuleFor(i => i.RoleId).NotEmpty();
    }
}