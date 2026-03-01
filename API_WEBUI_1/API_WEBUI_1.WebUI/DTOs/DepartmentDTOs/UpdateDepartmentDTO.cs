using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_WEBUI_1.WebUI.DTOs.DepartmentDTOs
{
    public class UpdateDepartmentDTO
    {
        public int DepartmentId { get; set; }
        // Unique identifier for the customer

        public string Name { get; set; }
        // Name of the department

        public string PhoneNumber { get; set; }
        // Contact phone number of the department
    }
}
