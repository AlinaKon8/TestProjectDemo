using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_PhoneNumber.Models
{
    public class InputCountryCodeValidator
    {
        private string _inputCountryCodes { get; set; }
        public string PrefixCode {get;}

        public InputCountryCodeValidator(string countryPrefix, string selectedCodes)
        {
            PrefixCode = countryPrefix;
            _inputCountryCodes = selectedCodes;
        }

        public List<string> GetCountryCodes()
        {
            List<string> countryCodes;
            if (string.IsNullOrEmpty(_inputCountryCodes))
            {
                countryCodes = new List<string> { PrefixCode };
            }
            else
            {
                countryCodes = _inputCountryCodes.Split(new char[] { ' ' }).ToList<string>();
            }

            return countryCodes;
        }
    }
}
