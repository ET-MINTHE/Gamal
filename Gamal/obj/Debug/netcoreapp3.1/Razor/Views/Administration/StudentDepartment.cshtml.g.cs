#pragma checksum "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentDepartment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eaf07fbc61e00ab283f0209410cca67d6b362b35"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Administration_StudentDepartment), @"mvc.1.0.view", @"/Views/Administration/StudentDepartment.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaf07fbc61e00ab283f0209410cca67d6b362b35", @"/Views/Administration/StudentDepartment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"00b07e519be85c819db8ca31c5e161827274582b", @"/Views/_ViewImports.cshtml")]
    public class Views_Administration_StudentDepartment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Gamal.ViewModel.StudentDepartmentViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentDepartment.cshtml"
  
    ViewData["Title"] = "StudentDepartment";
    Layout = "~/Views/Shared/_Student.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            DefineSection("UserFirstName", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 9 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentDepartment.cshtml"
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
#line 13 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentDepartment.cshtml"
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
#line 30 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentDepartment.cshtml"
                                                                                                Write(ViewBag.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 30 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentDepartment.cshtml"
                                                                                                                      Write(ViewBag.LastName);

#line default
#line hidden
#nullable disable
                WriteLiteral("-[MAT. ");
#nullable restore
#line 30 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentDepartment.cshtml"
                                                                                                                                               Write(ViewBag.SerialNumber);

#line default
#line hidden
#nullable disable
                WriteLiteral("]</span>\r\n    <br />\r\n    <br />\r\n");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("middlePanelBody", async() => {
                WriteLiteral(@"
    <span style=""font-size:12pt;"">
       Informations relatives à mon département
    </span>
    <br />
    <br />
    <fieldset class=""border p-3"" style=""border:3px solid red"">
        <legend class=""w-auto"" style=""font-size:18pt; font-weight:bold; border-bottom: 5px solid red"">");
#nullable restore
#line 43 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentDepartment.cshtml"
                                                                                                 Write(Model.Department);

#line default
#line hidden
#nullable disable
                WriteLiteral("</legend>\r\n        <table class=\"table\">\r\n            <tbody>\r\n                <tr class=\"td1\">\r\n                    <th scope=\"col\"><span style=\"color:#150517\">Départment</span></th>\r\n                    <td scope=\"col\">");
#nullable restore
#line 48 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentDepartment.cshtml"
                               Write(Model.Department);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                </tr>\r\n                <tr class=\"td1\">\r\n                    <th><span style=\"color:#150517\">Code du Département</span></th>\r\n                    <td>");
#nullable restore
#line 52 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentDepartment.cshtml"
                   Write(Model.DepartmentCode);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                </tr>\r\n                <tr class=\"td1\">\r\n                    <th><span style=\"color:#150517\">Faculté</span></th>\r\n                    <td>");
#nullable restore
#line 56 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentDepartment.cshtml"
                   Write(Model.Faculty);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                </tr>\r\n                <tr class=\"td1\">\r\n                    <th><span style=\"color:#150517\">Code Faculté</span></th>\r\n                    <td>");
#nullable restore
#line 60 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentDepartment.cshtml"
                   Write(Model.FacultyCode);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                </tr>\r\n                <tr class=\"td1\">\r\n                    <th><span style=\"color:#250517\">Année d\'Inscription</span></th>\r\n                    <td>");
#nullable restore
#line 64 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentDepartment.cshtml"
                   Write(Model.EnrollmentYeart);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                </tr>\r\n                <tr class=\"td1\">\r\n                    <th><span style=\"color:#250517\">Type de Cours</span></th>\r\n                    <td>");
#nullable restore
#line 68 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentDepartment.cshtml"
                   Write(Model.CourseType);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                </tr>\r\n                <tr class=\"td1\">\r\n                    <th><span style=\"color:#250517\">Crédit</span></th>\r\n                    <td>");
#nullable restore
#line 72 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentDepartment.cshtml"
                   Write(Model.Credit);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                </tr>\r\n            </tbody>\r\n        </table>\r\n    </fieldset>\r\n    <br />\r\n");
            }
            );
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Gamal.ViewModel.StudentDepartmentViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
