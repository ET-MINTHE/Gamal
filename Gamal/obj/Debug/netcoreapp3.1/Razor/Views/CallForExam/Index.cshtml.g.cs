#pragma checksum "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\CallForExam\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "db65e21f24d2ee87a54bd3e555736a72dc7d5a81"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CallForExam_Index), @"mvc.1.0.view", @"/Views/CallForExam/Index.cshtml")]
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
#nullable restore
#line 5 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db65e21f24d2ee87a54bd3e555736a72dc7d5a81", @"/Views/CallForExam/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"53a3cbe1952b84b6404f0a9759f671554cf5a320", @"/Views/_ViewImports.cshtml")]
    public class Views_CallForExam_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\CallForExam\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Student.cshtml";

#line default
#line hidden
#nullable disable
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
#line 21 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\CallForExam\Index.cshtml"
                                                                                                Write(ViewBag.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 21 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\CallForExam\Index.cshtml"
                                                                                                                      Write(ViewBag.LastName);

#line default
#line hidden
#nullable disable
                WriteLiteral("-[MAT. ");
#nullable restore
#line 21 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\CallForExam\Index.cshtml"
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
#line 27 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\CallForExam\Index.cshtml"
     if (!String.IsNullOrEmpty(@ViewBag.Message))
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <h6 style=\"text-align:center; color:green\">\r\n            ");
#nullable restore
#line 30 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\CallForExam\Index.cshtml"
       Write(ViewBag.Message);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </h6>\r\n");
#nullable restore
#line 32 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\CallForExam\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
    <span style=""font-size:12pt;"">
        Vous trouverez ci-dessous des informations générales sur la situation universitaire et sur les inscriptions effectuées au fil des ans.
    </span>
    <br />
    <fieldset class=""border p-3"" style=""border:3px solid red"">
        <legend class=""w-auto"" style=""font-size:14pt; font-weight:bold; border-bottom: 5px solid red"">Informations sur l'étudiant</legend>
        <table class=""table"">
            <tbody>
                <tr class=""td1"">
                    <td scope=""col""><span style=""color:#150517"">Type de Course</span></td>
                    <td scope=""col"">Model.CourseType</td>
                </tr>
                <tr class=""td1"">
                    <td><span style=""color:#150517"">Profile de l'Etudiant</span></td>
                    <td>Model.StudentProfile</td>
                </tr>
                <tr class=""td1"">
                    <td><span style=""color:#150517"">Année en Cours</span></td>
                    <td>
                  ");
                WriteLiteral(@"      Model.CurrentYear
                    </td>
                </tr>
                <tr class=""td1"">
                    <td><span style=""color:#150517"">Date d'Immatriculation</span></td>
                    <td>
                        Model.EnrollmentYear
                    </td>
                </tr>
                <tr class=""td1"">
                    <td><span style=""color:#250517"">Département</span></td>
                    <td>Model.Course</td>
                </tr>
                <tr class=""td1"">
                    <td><span style=""color:#250517"">Part Time</span></td>
                    <td>Model.PartTime</td>
                </tr>
            </tbody>
        </table>
    </fieldset>
    <br />

    <span style=""font-size:13pt; font-weight:bold"">Situation des Inscriptions</span>
    <br />
    <table style=""border:1px solid black"" class=""table"">
        <thead class=""thead-light"">
            <tr>
                <th scope=""col""><span style=""font-size:9pt"">Année Acc");
                WriteLiteral(@"ademique</span></th>
                <th scope=""col""><span style=""font-size:9pt"">Département</span></th>
                <th scope=""col""><span style=""font-size:9pt"">Année</span></th>
                <th scope=""col""><span style=""font-size:9pt"">Date</span></th>
                <th scope=""col""><span style=""font-size:9pt"">Type</span></th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td scope=""row"">Model.AccademicYear</td>
                <td>Model.Course</td>
                <td>Model.CurrentYear</td>
                <td>Model.EnrollmentYear</td>
                <td>En cours</td>
            </tr>
        </tbody>
    </table>

");
            }
            );
            WriteLiteral("\r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor HttpContextAccessor { get; private set; }
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
