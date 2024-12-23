using FluentValidation;
using Tabu.DTOs.Words;
using Tabu.Enums;

namespace Tabu.Validators.Words
{
    public class WordCreateDtoValidator : AbstractValidator<WordCreateDto>
    {
        public WordCreateDtoValidator()
        {
            RuleFor(x => x.Text)
                .NotEmpty()
                .NotNull()
                .MaximumLength(32);

            RuleForEach(x => x.BannedWords)
                .NotNull()
                .Must(x => x.Count() == (int)GameLevel.Hard)
                .WithMessage((int)GameLevel.Hard + " ədəd unikal qadağan olunnmuş söz daxil etməlisiniz!");

            RuleForEach(x => x.BannedWords)
                .NotNull()
                .MaximumLength(32);
        }
    }
}
