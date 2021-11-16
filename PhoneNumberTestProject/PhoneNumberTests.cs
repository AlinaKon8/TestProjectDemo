using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WebApi_PhoneNumber.BusinessLogic;
using WebApi_PhoneNumber.Models;
using Xunit;

namespace PhoneNumberTestProject
{
    [TestClass]
    public class PhoneNumberTests
    {
        [TestMethod]
        [DataRow("(0)79 / 257-31-15", "0792573115")]
        [DataRow("+*54(32/89)097", "543289097")]
        [DataRow("(0)79 / 257-31kkkk15", "0792573115")]
        public void GetOnlyDigitsOfPhoneNumber(string inputData, string expectedResult)
        {
            PhoneNumberValidator testPhoneObj = new PhoneNumberValidator(null);
            string phoneNumber = inputData;

            string clearPhoneNumber = testPhoneObj.GetOnlyDigitsOfPhoneNumber(phoneNumber);

            Assert.AreEqual(expectedResult, clearPhoneNumber);
        }

        [TestMethod]
        [DataRow("782579115", true)]
        [DataRow("414 11", false)]
        public void IsValidPhoneNumberLength(string inputData, bool expectedResult)
        {
            PhoneNumberValidator testPhoneObj = new PhoneNumberValidator(null, 9);
            string phoneNumber = inputData;

            bool isValidPhone = testPhoneObj.IsValidPhoneNumberLength(phoneNumber);

            Assert.AreEqual(expectedResult, isValidPhone);
        }

        [TestMethod]
        [DataRow("07(9) 257 311", "", "+4179257311")]
        [DataRow("37(9) 257 3118", "1 37 49", "+3792573118")]
        public void GetPositiveValidationResultOfPhoneNumber(string inputData, string codes, string expectedResult)
        {
            string prefixCode = "41";
            InputCountryCodeValidator codeValidator = new InputCountryCodeValidator(prefixCode, codes);
            PhoneNumberValidator phoneValidator = new PhoneNumberValidator(codeValidator, 8);
            string phoneNumber = inputData;

            ValidationResult correctPhoneNumber = phoneValidator.GetValidationResultOfPhoneNumber(phoneNumber);

            Assert.IsTrue(correctPhoneNumber.Success);
            Assert.AreEqual(expectedResult, correctPhoneNumber.PhoneNumber);
        }

        [TestMethod]
        [DataRow("37(9) 257 3118kki ", "1 49", "Input incorrect country code.")]
        [DataRow("49(9) 257 311", "1 49", "Input incorrect phone number.")]
        public void GetNegativeValidationResultOfPhoneNumber(string inputPhone, string codes, string expectedErrorMessage)
        {
            string prefixCode = "41";
            InputCountryCodeValidator codeValidator = new InputCountryCodeValidator(prefixCode, codes);
            PhoneNumberValidator phoneValidator = new PhoneNumberValidator(codeValidator, 10);
            string phoneNumber = inputPhone;

            var exception = Record.Exception(() => phoneValidator.GetValidationResultOfPhoneNumber(phoneNumber));

            Assert.AreEqual(exception.Message, expectedErrorMessage);
        }
    }
}
