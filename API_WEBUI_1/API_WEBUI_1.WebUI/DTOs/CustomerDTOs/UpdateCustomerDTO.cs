using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_WEBUI_1.WebUI.DTOs.CustomerDTOs
{
    public class UpdateCustomerDTO
    {
        public int CustomerId { get; set; }
        // Unique identifier for the customer
        public string FirstName { get; set; }
        // Customer's first name

        public string LastName { get; set; }
        // Customer's last name

        public string Address { get; set; }
        // Customer's residential address

        [RegularExpression(@"^\d{11}$", ErrorMessage = "The phone number must be exactly 11 digits.")]
        public string PhoneNumber { get; set; }
        // Customer's contact phone number

        public DateTime RegistrationDate { get; set; }
        // Date when the customer was registered
    }
}
