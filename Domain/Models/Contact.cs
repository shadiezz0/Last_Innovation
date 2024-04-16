using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;


        // Arabic properties
        public string? AddressArabic { get; set; }
        public string? DescriptionArabic { get; set; }
        public string PhoneArabic { get; set; } = string.Empty;
    }
}
