using API_WEBUI_1.WebUI.DTOs.DepartmentDTOs;
using FluentValidation;

namespace API_WEBUI_1.WebUI.Validators
{
    public class DepartmentValidator: AbstractValidator<CreateDepartmentDTO>
    {
        public DepartmentValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Department name must not be empty");
            RuleFor(x=>x.PhoneNumber).NotEmpty().WithMessage("Department name must not be empty");
        }
    }
}
