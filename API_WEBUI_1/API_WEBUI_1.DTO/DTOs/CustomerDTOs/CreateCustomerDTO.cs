using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace API_WEBUI_1.DTO.DTOs.CustomerDTOs
{
    public class CreateCustomerDTO
    {
        public int CustomerId { get; set; }
        // Unique identifier for the customer

        public string ImageUrl { get; set; }

        public string FirstName { get; set; }
        // Customer's first name

        public string LastName { get; set; }
        // Customer's last name

        public string Address { get; set; }
        // Customer's residential address

        public string PhoneNumber { get; set; }
        // Customer's contact phone number

        public DateTime RegistrationDate { get; set; }
        // Date when the customer was registered
    }
}
