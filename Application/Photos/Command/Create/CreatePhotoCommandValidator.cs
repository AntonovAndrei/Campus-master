using FluentValidation;

namespace Application.Photos.Command.Create;

public class CreatePhotoCommandValidator : AbstractValidator<CreatePhotoCommand>
{
    public CreatePhotoCommandValidator()
    {
        RuleFor(f => f.File)
            .NotEmpty().WithMessage("File is required");
        RuleFor(n => n.File.FileName)
            .Must(str => str.EndsWith(".jpeg") || str.EndsWith(".jpg"))
            .WithMessage("Photo format must been .jpeg or .jpg");
    }
}