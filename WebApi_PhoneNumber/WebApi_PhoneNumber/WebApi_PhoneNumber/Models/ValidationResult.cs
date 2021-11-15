using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_PhoneNumber.Models
{
    public class ValidationResult
    {
        public string PhoneNumber { get; set; }
        public bool Success { get; set; }
    }
}
