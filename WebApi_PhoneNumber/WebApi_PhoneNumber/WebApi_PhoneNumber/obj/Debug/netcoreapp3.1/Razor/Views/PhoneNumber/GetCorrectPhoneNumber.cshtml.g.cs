#pragma checksum "D:\Applications\WebApi_PhoneNumber_Part2\WebApi_PhoneNumber\WebApi_PhoneNumber\WebApi_PhoneNumber\Views\PhoneNumber\GetCorrectPhoneNumber.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "648ba64499d952a1b237f155759942bea241c96f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PhoneNumber_GetCorrectPhoneNumber), @"mvc.1.0.view", @"/Views/PhoneNumber/GetCorrectPhoneNumber.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Applications\WebApi_PhoneNumber_Part2\WebApi_PhoneNumber\WebApi_PhoneNumber\WebApi_PhoneNumber\Views\_ViewImports.cshtml"
using WebApi_PhoneNumber;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Applications\WebApi_PhoneNumber_Part2\WebApi_PhoneNumber\WebApi_PhoneNumber\WebApi_PhoneNumber\Views\_ViewImports.cshtml"
using WebApi_PhoneNumber.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"648ba64499d952a1b237f155759942bea241c96f", @"/Views/PhoneNumber/GetCorrectPhoneNumber.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"718a3d062255fa226fa19ed72f3f3bf0570c9738", @"/Views/_ViewImports.cshtml")]
    public class Views_PhoneNumber_GetCorrectPhoneNumber : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApi_PhoneNumber.Models.PhoneNumberModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"col-md-5\">\r\n    <input type=\"text\" id=\"resultOfPhoneNumber\"");
            BeginWriteAttribute("value", " value=\"", 124, "\"", 149, 1);
#nullable restore
#line 4 "D:\Applications\WebApi_PhoneNumber_Part2\WebApi_PhoneNumber\WebApi_PhoneNumber\WebApi_PhoneNumber\Views\PhoneNumber\GetCorrectPhoneNumber.cshtml"
WriteAttributeValue("", 132, Model.ResultInfo, 132, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" size=\"30\"/>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApi_PhoneNumber.Models.PhoneNumberModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
