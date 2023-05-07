using FluentValidation;

namespace Application.Roles.Commands.DeleteRoleFromEmployee;

public class DeleteRoleFromEmployeeCommandValidator : AbstractValidator<DeleteRoleFromEmployeeCommand>
{
    public DeleteRoleFromEmployeeCommandValidator()
    {
        RuleFor(i => i.EmployeeId).NotEqual(Guid.Empty);
        RuleFor(i => i.RoleId).NotEmpty();
    }
}