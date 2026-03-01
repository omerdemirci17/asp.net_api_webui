using FluentValidation;
using API_WEBUI_1.WebUI.DTOs.CustomerDTOs;

namespace API_WEBUI_1.WebUI.Validators
{
    public class CustomerValidator : AbstractValidator<CreateCustomerDTO>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Please enter your first name");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Please enter your Last name");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Please enter your phone number");
        }
    }
}
