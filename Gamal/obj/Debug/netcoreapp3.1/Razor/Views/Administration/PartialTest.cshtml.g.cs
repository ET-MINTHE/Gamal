#pragma checksum "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\PartialTest.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3d7681cc2b766a7d17f47d07601739f96afa8a87"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Administration_PartialTest), @"mvc.1.0.view", @"/Views/Administration/PartialTest.cshtml")]
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
#line 1 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\_ViewImports.cshtml"
using Gamal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\_ViewImports.cshtml"
using Gamal.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3d7681cc2b766a7d17f47d07601739f96afa8a87", @"/Views/Administration/PartialTest.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"00b07e519be85c819db8ca31c5e161827274582b", @"/Views/_ViewImports.cshtml")]
    public class Views_Administration_PartialTest : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\PartialTest.cshtml"
  
    ViewData["Title"] = "PartialTest";
    Layout = "~/Views/Shared/_Student.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            DefineSection("UserFirstName", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 9 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\PartialTest.cshtml"
Write(ViewBag.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("UserLastName", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 13 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\PartialTest.cshtml"
Write(ViewBag.LastName);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("container", async() => {
                WriteLiteral("\r\n\r\n");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("leftPanelHeader", async() => {
                WriteLiteral("\r\n\r\n");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("leftPanelBody", async() => {
                WriteLiteral("\r\n\r\n");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("middlePanelHeader", async() => {
                WriteLiteral("\r\n    <span style=\"font-size:22pt;\">Zone réservée de l\'étudiant </span><span style=\"font-size:20pt;\">");
#nullable restore
#line 30 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\PartialTest.cshtml"
                                                                                                Write(ViewBag.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 30 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\PartialTest.cshtml"
                                                                                                                      Write(ViewBag.LastName);

#line default
#line hidden
#nullable disable
                WriteLiteral("-[MAT. ");
#nullable restore
#line 30 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\PartialTest.cshtml"
                                                                                                                                               Write(ViewBag.SerialNumber);

#line default
#line hidden
#nullable disable
                WriteLiteral("]</span>\r\n    <br />\r\n");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("middlePanelBody", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 36 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\PartialTest.cshtml"
     if (!String.IsNullOrEmpty(@ViewBag.Message))
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <h6 style=\"text-align:center; color:green\">\r\n            ");
#nullable restore
#line 39 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\PartialTest.cshtml"
       Write(ViewBag.Message);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </h6>\r\n");
#nullable restore
#line 41 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\PartialTest.cshtml"
    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    <span style=\"font-size:18pt; text-align:center\"> Epreuves partielles</span>\r\n    <br />\r\n    <span style=\"font-size:25pt; text-align:center; font-weight:bold\"> Page en construction</span>\r\n");
            }
            );
            WriteLiteral("\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
