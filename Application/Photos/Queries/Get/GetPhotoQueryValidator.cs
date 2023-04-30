using FluentValidation;

namespace Application.Photos.Queries.Get;

public class GetPhotoQueryValidator : AbstractValidator<GetPhotoQuery>
{
    public GetPhotoQueryValidator()
    {
        RuleFor(i => i.Id).NotEqual(Guid.Empty);
    }
}