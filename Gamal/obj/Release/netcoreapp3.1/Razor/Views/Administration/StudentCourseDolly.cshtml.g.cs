#pragma checksum "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentCourseDolly.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c019a565efe7fb302f8907f32eb9be675442efb7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Administration_StudentCourseDolly), @"mvc.1.0.view", @"/Views/Administration/StudentCourseDolly.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c019a565efe7fb302f8907f32eb9be675442efb7", @"/Views/Administration/StudentCourseDolly.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"00b07e519be85c819db8ca31c5e161827274582b", @"/Views/_ViewImports.cshtml")]
    public class Views_Administration_StudentCourseDolly : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Gamal.Models.Domain.Dolly>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentCourseDolly.cshtml"
  
    ViewData["Title"] = "StudentCourseDolly";
    Layout = "~/Views/Shared/_Student.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("UserFirstName", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 8 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentCourseDolly.cshtml"
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
#line 12 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentCourseDolly.cshtml"
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
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("middlePanelBody", async() => {
                WriteLiteral(@"
    <span style=""font-size:15pt;"">Le matériel didactique et pédagogique : soutien à l’appropriation ou déterminant de l’intervention éducative </span>
    <br />
    <span style=""font-size:15pt;"">Vous trouverez ci-dessous le matériel didactiques relatifs aux différentes matières</span> <span style=""color:red; font-weight:bold"">");
#nullable restore
#line 35 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentCourseDolly.cshtml"
                                                                                                                                                                  Write(ViewBag.Course);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n    <br />\r\n    <br />\r\n");
#nullable restore
#line 38 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentCourseDolly.cshtml"
     if (Model.Count == 0)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <span style=\"font-size:15pt; color:red; font-weight:bold\">Aucun matériel didactique n\'est disponible pour le moment</span>\r\n");
#nullable restore
#line 41 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentCourseDolly.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <table class=\"table table-bordered\" style=\"text-align:center\">\r\n            <tbody>\r\n");
#nullable restore
#line 46 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentCourseDolly.cshtml"
                 foreach (var dolly in Model)
                {
                    var path = "/dolly/" + @dolly.FilePath;
                    

#line default
#line hidden
#nullable disable
                WriteLiteral("<tr class=\"td1\">\r\n                        <th scope=\"col\" style=\"color:red\">\r\n                            <span style=\"font-size:13pt; color:indianred\">\r\n                                <a class=\"a-booklet\"");
                BeginWriteAttribute("href", " href=", 1425, "", 1436, 1);
#nullable restore
#line 52 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentCourseDolly.cshtml"
WriteAttributeValue("", 1431, path, 1431, 5, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 52 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentCourseDolly.cshtml"
                                                           Write(dolly.FileName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a>\r\n                            </span>\r\n                        </th>\r\n                    </tr>\r\n");
#nullable restore
#line 56 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentCourseDolly.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </tbody>\r\n        </table>\r\n");
#nullable restore
#line 59 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentCourseDolly.cshtml"
    }

#line default
#line hidden
#nullable disable
            }
            );
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Gamal.Models.Domain.Dolly>> Html { get; private set; }
    }
}
#pragma warning restore 1591
