using FluentValidation;

namespace Application.Photos.Queries.Detail;

public class DetailPhotoQueryValidator : AbstractValidator<DetailPhotoQuery>
{
    public DetailPhotoQueryValidator()
    {
        RuleFor(i => i.Id).NotEqual(Guid.Empty);
    }
}