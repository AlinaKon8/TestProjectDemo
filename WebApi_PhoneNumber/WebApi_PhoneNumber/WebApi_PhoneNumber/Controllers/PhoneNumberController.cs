using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_PhoneNumber.BusinessLogic;
using WebApi_PhoneNumber.Models;

namespace WebApi_PhoneNumber.Controllers
{
    public class PhoneNumberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetCorrectPhoneNumber(PhoneNumberModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var prefixCountry = "41"; // Switz
                    var phoneLength = 10;
                    var codeValidator = new InputCountryCodeValidator(prefixCountry, model.InputCountryCodes);
                    var phoneValidator = new PhoneNumberValidator(codeValidator, phoneLength);

                    var validationResult = phoneValidator.GetValidationResultOfPhoneNumber(model.InputPhoneNumber);

                    if (validationResult.Success)
                    {
                        model.ResultInfo = validationResult.PhoneNumber;
                    }
                }
                catch(Exception ex)
                {
                    model.ResultInfo = ex?.Message;
                }

                return View(model);
            }
            return RedirectToAction("Index");
        }
    }
}
