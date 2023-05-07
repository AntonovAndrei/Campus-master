using FluentValidation;

namespace Application.Roles.Commands.AddRoleToResident;

public class AddRoleToResidentCommandValidator : AbstractValidator<AddRoleToResidentCommand>
{
    public AddRoleToResidentCommandValidator()
    {
        RuleFor(i => i.ResidentId).NotEqual(Guid.Empty);
        RuleFor(i => i.RoleId).NotEmpty();
    }
}