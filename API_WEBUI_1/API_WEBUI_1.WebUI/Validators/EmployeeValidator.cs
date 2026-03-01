using FluentValidation;
using API_WEBUI_1.WebUI.DTOs.EmployeeDTOs;

namespace API_WEBUI_1.WebUI.Validators
{
    public class EmployeeValidator :AbstractValidator<CreateEmployeeDTO>
    {
        public EmployeeValidator()
        {
            RuleFor(x=>x.FirstName).NotEmpty().WithMessage("First name must not be empty");
            RuleFor(x=>x.LastName).NotEmpty().WithMessage("Last name must not be empty");
            RuleFor(x=>x.Email).NotEmpty().WithMessage("Email must not be empty");
            RuleFor(x=>x.Email).EmailAddress().WithMessage("Must be in email format.");
            RuleFor(x=>x.PhoneNumber).NotEmpty().WithMessage("Phone number must not be empty");
            RuleFor(x=>x.Address).NotEmpty().WithMessage("Address must not be empty");

        }
    }
}
