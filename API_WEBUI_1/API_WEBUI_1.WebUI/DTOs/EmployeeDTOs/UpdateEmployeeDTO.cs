using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_WEBUI_1.WebUI.DTOs.SocialMediaDTOs;

namespace API_WEBUI_1.WebUI.DTOs.EmployeeDTOs
{
    public class UpdateEmployeeDTO
    {
        public int EmployeeId { get; set; }
        // Unique identifier for the employee
        public string ImageUrl { get; set; }

        public string FirstName { get; set; }
        // Employee's first name

        public string LastName { get; set; }
        // Employee's last name

        public string Email { get; set; }
        // Employee's email address

        [RegularExpression(@"^\d{11}$", ErrorMessage = "The phone number must be exactly 11 digits.")]
        public DateTime BirthDate { get; set; }
        // Employee's date of birth

        public string PhoneNumber { get; set; }
        // Employee's contact phone number

        public string Address { get; set; }
        // Employee's residential address

        public int DepartmentId { get; set; }
        // ID of the department the employee belongs to
        public List<ResultSocialMediaDTO> SocialMedia { get; set; } = new();

    }
}
