using FluentValidation;

namespace Application.Roles.Commands.DeleteRoleFromResident;

public class DeleteRoleFromResidentCommandValidator : AbstractValidator<DeleteRoleFromResidentCommand>
{
    public DeleteRoleFromResidentCommandValidator()
    {
        RuleFor(i => i.ResidentId).NotEqual(Guid.Empty);
        RuleFor(i => i.RoleId).NotEmpty();
    }
}