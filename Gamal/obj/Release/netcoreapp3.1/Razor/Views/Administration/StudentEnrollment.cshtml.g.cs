#pragma checksum "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentEnrollment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "afee5044250afc0c0994a7ffb4a54186dd848b37"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Administration_StudentEnrollment), @"mvc.1.0.view", @"/Views/Administration/StudentEnrollment.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"afee5044250afc0c0994a7ffb4a54186dd848b37", @"/Views/Administration/StudentEnrollment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"00b07e519be85c819db8ca31c5e161827274582b", @"/Views/_ViewImports.cshtml")]
    public class Views_Administration_StudentEnrollment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Gamal.ViewModel.StudentEnrollmentViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/active-icon.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("25px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("25px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("a-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Administration", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "StudentEnrollment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentEnrollment.cshtml"
  
    ViewData["Title"] = "StudentEnrollment";
    Layout = "~/Views/Shared/_Student.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("UserFirstName", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 8 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentEnrollment.cshtml"
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
#line 12 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentEnrollment.cshtml"
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
                WriteLiteral("\r\n");
#nullable restore
#line 33 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentEnrollment.cshtml"
     if (!String.IsNullOrEmpty(@ViewBag.Message))
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <h6 style=\"text-align:center; color:green\">\r\n            ");
#nullable restore
#line 36 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentEnrollment.cshtml"
       Write(ViewBag.Message);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </h6>\r\n");
#nullable restore
#line 38 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentEnrollment.cshtml"
    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
    <span style=""font-size:12pt; text-align:center"">Situation des Inscriptions</span>
    <br />
    <span style=""font-size:12pt; text-align:center; font-weight:bold"">Vous trouverez ci-dessous des informations générales sur la situation universitaire et sur les inscriptions effectuées au fil des ans.</span>
    <br />
    <fieldset class=""border p-3"">
        <legend class=""w-auto"" style=""font-size:12pt; font-weight:bold; border-bottom: 3px solid red"">Détail d'inscription ");
#nullable restore
#line 45 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentEnrollment.cshtml"
                                                                                                                      Write(Model.AccademicYear);

#line default
#line hidden
#nullable disable
                WriteLiteral("</legend>\r\n        <table class=\"table\">\r\n            <tbody>\r\n                <tr class=\"td1\">\r\n                    <th scope=\"col\"><span style=\"color:#150517\">Année Académique</span></th>\r\n                    <td scope=\"col\">");
#nullable restore
#line 50 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentEnrollment.cshtml"
                               Write(Model.AccademicYear);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                </tr>\r\n                <tr class=\"td1\">\r\n                    <th><span style=\"color:#150517\">Date d\'inscription</span></th>\r\n                    <td>");
#nullable restore
#line 54 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentEnrollment.cshtml"
                   Write(Model.EnrollmentYear);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                </tr>\r\n                <tr class=\"td1\">\r\n                    <th><span style=\"color:#150517\">Département</span></th>\r\n                    <td>");
#nullable restore
#line 58 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentEnrollment.cshtml"
                   Write(Model.Department);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                </tr>\r\n                <tr class=\"td1\">\r\n                    <th><span style=\"color:#150517\">Année en cours</span></th>\r\n                    <td>");
#nullable restore
#line 62 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentEnrollment.cshtml"
                   Write(Model.Year);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                </tr>\r\n                <tr class=\"td1\">\r\n                    <th><span style=\"color:#250517\">Type d\'inscription</span></th>\r\n                    <td>\r\n");
#nullable restore
#line 67 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentEnrollment.cshtml"
                         if (Model.PartTime)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <span>SI</span>\r\n");
#nullable restore
#line 70 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentEnrollment.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <span>NO</span>\r\n");
#nullable restore
#line 74 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentEnrollment.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </td>\r\n                </tr>\r\n                <tr class=\"td1\">\r\n                    <th><span style=\"color:#250517\">Etat</span></th>\r\n                    <td>\r\n");
#nullable restore
#line 80 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentEnrollment.cshtml"
                         if (Model.State)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "afee5044250afc0c0994a7ffb4a54186dd848b3712205", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            <span>ACTIF</span>\r\n");
#nullable restore
#line 84 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentEnrollment.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <span>NON ACTIF</span>\r\n");
#nullable restore
#line 88 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentEnrollment.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                    </td>
                </tr>
            </tbody>
        </table>
    </fieldset>
    <br />
    <br />
    <fieldset class=""border p-3"" style=""border:3px solid red"">
        <legend class=""w-auto"" style=""font-size:10pt; font-weight:bold;"">Liste des inscriptions</legend>
        <table class=""table"">
            <thead class=""thead-light"">
                <tr class=""td1"">
                    <th scope=""col""><span style=""color:#150517"">Année Académique</span></th>
                    <th><span style=""color:#150517"">Date d'inscription</span></th>
                    <th><span style=""color:#150517"">Département</span></th>
                    <th><span style=""color:#250517"">Type d'inscription</span></th>
                    <th><span style=""color:#150517"">Année en cours</span></th>
                    <th><span style=""color:#250517"">Etat</span></th>
                </tr>
            </thead>
            <tbody>
                <tr class=""td1"">
                    <td scop");
                WriteLiteral("e=\"col\">\r\n                        <span style=\"font-size:11pt; color:indianred\">\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "afee5044250afc0c0994a7ffb4a54186dd848b3715299", async() => {
                    WriteLiteral("\r\n                                ");
#nullable restore
#line 115 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentEnrollment.cshtml"
                           Write(Model.AccademicYear);

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        </span>\r\n                    </td>\r\n                    <td>");
#nullable restore
#line 119 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentEnrollment.cshtml"
                   Write(Model.EnrollmentYear);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 120 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentEnrollment.cshtml"
                   Write(Model.Department);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 121 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentEnrollment.cshtml"
                   Write(Model.Year);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>\r\n");
#nullable restore
#line 123 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentEnrollment.cshtml"
                         if (Model.PartTime)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <span>SI</span>\r\n");
#nullable restore
#line 126 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentEnrollment.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <span>NO</span>\r\n");
#nullable restore
#line 130 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentEnrollment.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 133 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentEnrollment.cshtml"
                         if (Model.State)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "afee5044250afc0c0994a7ffb4a54186dd848b3719347", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            <span>ACTIF</span>\r\n");
#nullable restore
#line 137 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentEnrollment.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <span>\r\n                                NON ACTIF\r\n                            </span>\r\n");
#nullable restore
#line 143 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Administration\StudentEnrollment.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </td>\r\n                </tr>\r\n            </tbody>\r\n        </table>\r\n    </fieldset>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Gamal.ViewModel.StudentEnrollmentViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591