using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebApi_PhoneNumber.Models;

namespace WebApi_PhoneNumber.BusinessLogic
{
    public class PhoneNumberValidator
    {
        private InputCountryCodeValidator _codeValidator;
        private string _clearRegex = @"[^\d]";
        private string _errorMessageForPrefixCode = "Input incorrect country code.";
        private string _errorMessageForPhone = "Input incorrect phone number.";
        private int _validLengthOfPhone;

        public PhoneNumberValidator(InputCountryCodeValidator codeValidator, int validPhoneLength = 8)
        {
            _codeValidator = codeValidator;
            _validLengthOfPhone = validPhoneLength;
        }

        public string GetOnlyDigitsOfPhoneNumber(string inputPhoneNumber)
        {
           string onlyDigitsOfPhone = Regex.Replace(inputPhoneNumber, _clearRegex, string.Empty);

            return onlyDigitsOfPhone;
        }

        // length of international phone number equals without code 7 - 11
        public bool IsValidPhoneNumberLength(string digitsOfPhoneNumber)
        {
            return digitsOfPhoneNumber.Length == _validLengthOfPhone;
        }

        public string GetCountryCodeIfExist(string phone, out bool isSetDefaultCode)
        {
            isSetDefaultCode = false;
            List<string> availableCountryCodes = _codeValidator.GetCountryCodes();
            List<string> selectedCode = availableCountryCodes
                .Where(x => phone.StartsWith(x))
                .Select(x => x).ToList();

            if (!selectedCode.Any())
            {
                if (phone.StartsWith("0"))
                {
                    selectedCode.Add(_codeValidator.PrefixCode);
                    isSetDefaultCode = true;
                }
            }

            return selectedCode?.FirstOrDefault();
        }

        public string Format(string selectedCode, string phoneWithoutCode)
        {
            return $"+{selectedCode}{phoneWithoutCode}";
        }

        public ValidationResult GetValidationResultOfPhoneNumber(string inputPhoneNumber)
        {
            ValidationResult validationResult = new ValidationResult();
            bool isSetDefaultCode; // if 0, defaultCode ("41") is set. differences between length of these codes

            string phoneNumberWithoutExtraSymbols = GetOnlyDigitsOfPhoneNumber(inputPhoneNumber);

            string selectedCode = GetCountryCodeIfExist(phoneNumberWithoutExtraSymbols, out isSetDefaultCode);

            bool isValidInputPhoneNumber;
            string validatedPhoneNumberWithoutCode;
            if (!string.IsNullOrEmpty(selectedCode))
            {
                validatedPhoneNumberWithoutCode = phoneNumberWithoutExtraSymbols
                    .Remove(
                        0,
                        isSetDefaultCode ? 1 : selectedCode.Length
                    );
                isValidInputPhoneNumber = IsValidPhoneNumberLength(validatedPhoneNumberWithoutCode);
            }
            else
            {
                throw new Exception(_errorMessageForPrefixCode);
            }

            validationResult.Success = isValidInputPhoneNumber;

            if (isValidInputPhoneNumber)
            {
                validationResult.PhoneNumber = Format(selectedCode, validatedPhoneNumberWithoutCode);
            }
            else
            {
                throw new Exception(_errorMessageForPhone);
            }

            return validationResult;
        }
    }
}
