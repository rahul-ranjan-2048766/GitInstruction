#pragma checksum "C:\Users\2048766\source\repos\UseCase\Web UI (Report) Application\Web UI (Report) Application\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6d6df06d9d6f35ad2b78aa244a02b914d2075b84"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\2048766\source\repos\UseCase\Web UI (Report) Application\Web UI (Report) Application\Views\_ViewImports.cshtml"
using Web_UI__Report__Application;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\2048766\source\repos\UseCase\Web UI (Report) Application\Web UI (Report) Application\Views\_ViewImports.cshtml"
using Web_UI__Report__Application.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d6df06d9d6f35ad2b78aa244a02b914d2075b84", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bfc6ccbc130b0de7fec6a393543e9cd01d364cb", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Web_UI__Report__Application.Models.Bill>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<table class=\"table table-hover\">\r\n    <tr>\r\n        <th>Id</th>\r\n        <th>CreditCardNumber</th>\r\n        <th>CreditCardType</th>\r\n        <th>Amount</th>\r\n        <th>TransactionDate</th>\r\n        <th>TransactionId</th>\r\n    </tr>\r\n");
#nullable restore
#line 12 "C:\Users\2048766\source\repos\UseCase\Web UI (Report) Application\Web UI (Report) Application\Views\Home\Index.cshtml"
     foreach(var d in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <th>");
#nullable restore
#line 15 "C:\Users\2048766\source\repos\UseCase\Web UI (Report) Application\Web UI (Report) Application\Views\Home\Index.cshtml"
           Write(d.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 16 "C:\Users\2048766\source\repos\UseCase\Web UI (Report) Application\Web UI (Report) Application\Views\Home\Index.cshtml"
           Write(d.CreditCardNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 17 "C:\Users\2048766\source\repos\UseCase\Web UI (Report) Application\Web UI (Report) Application\Views\Home\Index.cshtml"
           Write(d.CreditCardType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 18 "C:\Users\2048766\source\repos\UseCase\Web UI (Report) Application\Web UI (Report) Application\Views\Home\Index.cshtml"
           Write(d.TransactionAmount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 19 "C:\Users\2048766\source\repos\UseCase\Web UI (Report) Application\Web UI (Report) Application\Views\Home\Index.cshtml"
           Write(d.TransactionDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 20 "C:\Users\2048766\source\repos\UseCase\Web UI (Report) Application\Web UI (Report) Application\Views\Home\Index.cshtml"
           Write(d.TransactionId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n        </tr>\r\n");
#nullable restore
#line 22 "C:\Users\2048766\source\repos\UseCase\Web UI (Report) Application\Web UI (Report) Application\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Web_UI__Report__Application.Models.Bill>> Html { get; private set; }
    }
}
#pragma warning restore 1591