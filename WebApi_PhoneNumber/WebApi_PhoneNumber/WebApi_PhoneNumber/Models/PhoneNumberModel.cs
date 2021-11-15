using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_PhoneNumber.Models
{
    public class PhoneNumberModel
    {
        [StringLength(20)]
        public string InputCountryCodes { get; set; }

        [Required(ErrorMessage = "Please enter your phone number", AllowEmptyStrings = false)]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Please, input although 5 numbers")]
        public string InputPhoneNumber { get; set; }
        public string ResultInfo { get; set; }
    }
}
