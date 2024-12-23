using FluentValidation;
using Tabu.DTOs.Languages;
using Tabu.DTOs.Words;

namespace Tabu.Validators.Words;

public class WordUpdateDtoValidator : AbstractValidator<WordUpdateDto>
{
    public WordUpdateDtoValidator()
    {
        RuleFor(x => x.Text)
                .NotEmpty()
                .NotNull()
                .MaximumLength(32);

        RuleForEach(x => x.BannedWords)
            .NotNull();

        RuleForEach(x => x.BannedWords)
            .NotNull()
            .MaximumLength(32);
    }
}
