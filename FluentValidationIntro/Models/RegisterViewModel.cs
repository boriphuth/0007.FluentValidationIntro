using System.ComponentModel.DataAnnotations;
using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Results;

namespace FluentValidationIntro.Models
{
    [Validator(typeof(RegisterViewModelValidator))]
    public class RegisterViewModel
    {
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }
    }

    public class RegisterViewModelValidator : AbstractValidator<RegisterViewModel>
    {
        public RegisterViewModelValidator()
        {
            RuleFor(m => m.Email)
                .NotEmpty().WithMessage("Dude, you need to give an email address")
                .EmailAddress().WithMessage("C'mon man, that is no email address");
            RuleFor(m => m.Password)
                .NotEmpty()
                .Length(6, 100);
            RuleFor(m => m.ConfirmPassword)
                .Equal(m => m.Password);

            Custom(m =>
                   {
                       if (m.Password == "password")
                           return new ValidationFailure("Password", "Using 'password' as a password is not too clever...");

                       return null;
                   });
        }
    }
}