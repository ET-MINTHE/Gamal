#pragma checksum "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Booklet\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "32e36a37937ff2320de6c3ddebe36fa25672cb3a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Booklet_Index), @"mvc.1.0.view", @"/Views/Booklet/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"32e36a37937ff2320de6c3ddebe36fa25672cb3a", @"/Views/Booklet/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"00b07e519be85c819db8ca31c5e161827274582b", @"/Views/_ViewImports.cshtml")]
    public class Views_Booklet_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Gamal.ViewModel.BookletViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("a-booklet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "CourseDescription", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Booklet\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Student.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("UserFirstName", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 8 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Booklet\Index.cshtml"
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
#line 12 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Booklet\Index.cshtml"
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
                WriteLiteral("\r\n    <span style=\"font-size:22pt; text-align:justify\">Zone réservée de l\'étudiant </span><span style=\"font-size:20pt;\">");
#nullable restore
#line 29 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Booklet\Index.cshtml"
                                                                                                                   Write(ViewBag.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 29 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Booklet\Index.cshtml"
                                                                                                                                         Write(ViewBag.LastName);

#line default
#line hidden
#nullable disable
                WriteLiteral("-[MAT. ");
#nullable restore
#line 29 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Booklet\Index.cshtml"
                                                                                                                                                                  Write(ViewBag.SerialNumber);

#line default
#line hidden
#nullable disable
                WriteLiteral("]</span>\r\n    <br />\r\n");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("middlePanelBody", async() => {
                WriteLiteral(@"
    <div style=""text-align:justify"">
        <span style=""font-size:12pt;"">
            Vous trouverez ci-dessous des informations générales sur la situation universitaire et le livret.
            Cette page affiche des informations relatives aux activités pédagogiques du cahier de l'élève. Pour les activités pédagogiques non encore réussies et suivies, le lien est actif sur l'icône de la rubrique «Appels» qui permet d'accéder à la liste des appels définie par le secrétariat pédagogique.

            Pour remplir le questionnaire d'évaluation de l'enseignement, suivez le lien Services universitaires dans le menu latéral. La compilation n'est possible que pour les étudiants inscrits aux formations diplômantes participant à l'expérimentation, pour les autres veuillez remplir le questionnaire papier fourni par l'enseignant à la fin du cours.
        </span>
    </div>
    
    <br />
    <span style=""font-size:12pt; font-weight:bold"">Livret de:</span> <span style=""font-size:12pt; font-weight:bold; c");
                WriteLiteral("olor:red\"> ");
#nullable restore
#line 45 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Booklet\Index.cshtml"
                                                                                                                           Write(ViewBag.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 45 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Booklet\Index.cshtml"
                                                                                                                                              Write(ViewBag.LastName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" - [MAT. ");
#nullable restore
#line 45 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Booklet\Index.cshtml"
                                                                                                                                                                        Write(ViewBag.SerialNumber);

#line default
#line hidden
#nullable disable
                WriteLiteral("]</span>\r\n    <br />\r\n    <span style=\"font-size:12pt; font-weight:bold\">Moyenne Arithmétique: </span><span style=\"font-size:12pt; font-weight:bold; color:red\"> ");
#nullable restore
#line 47 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Booklet\Index.cshtml"
                                                                                                                                      Write(ViewBag.EverageMark);

#line default
#line hidden
#nullable disable
                WriteLiteral("/20</span>\r\n    <br />\r\n    <span style=\"font-size:12pt; font-weight:bold\">Moyenne Pondérée: </span><span style=\"font-size:12pt; font-weight:bold; color:red\"> ");
#nullable restore
#line 49 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Booklet\Index.cshtml"
                                                                                                                                  Write(ViewBag.WeightedEverageMark);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"/20 </span>
    <br />
    <div class=""border border-#6D7B8D"">
        <table class=""table"">
            <thead class=""thead-light"">
                <tr>
                    <th scope=""col""><span style=""font-size:9pt"">Activité Didactique</span></th>
                    <th scope=""col""><span style=""font-size:9pt"">Année</span></th>
                    <th scope=""col""><span style=""font-size:9pt"">Coefficient</span></th>
                    <th scope=""col""><span style=""font-size:9pt"">Etat</span></th>
                    <th scope=""col""><span style=""font-size: 9pt"">AA Freq.</span></th>
                    <th scope=""col""><span style=""font-size:9pt"">Note-Date Examen</span></th>
                </tr>
            </thead>
            <tbody>

");
#nullable restore
#line 65 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Booklet\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr style=\"line-height: 0.6;\">\r\n                        <th scope=\"row\">\r\n                            <span style=\"font-size:11pt; color:indianred\">\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "32e36a37937ff2320de6c3ddebe36fa25672cb3a11457", async() => {
                    WriteLiteral("\r\n                                    ");
#nullable restore
#line 72 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Booklet\Index.cshtml"
                               Write(item.Course.ToLower());

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-courseId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 70 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Booklet\Index.cshtml"
                                                            WriteLiteral(item.CourseCode);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["courseId"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-courseId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["courseId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 70 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Booklet\Index.cshtml"
                                                                                                      WriteLiteral(item.DepartmentCode);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["departmentCode"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-departmentCode", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["departmentCode"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            </span>\r\n                        </th>\r\n                        <td>1</td>\r\n                        <td>");
#nullable restore
#line 77 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Booklet\Index.cshtml"
                       Write(item.Weight);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        <td>\r\n");
#nullable restore
#line 79 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Booklet\Index.cshtml"
                             if (item.Status == true)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <figure class=\"circle-passed\"></figure>\r\n");
#nullable restore
#line 82 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Booklet\Index.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <figure class=\"circle-attended\"></figure>\r\n");
#nullable restore
#line 86 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Booklet\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </td>\r\n                        <td>\r\n");
#nullable restore
#line 89 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Booklet\Index.cshtml"
                             if (item.Status == true)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <span style=\"font-size:9pt\">");
#nullable restore
#line 91 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Booklet\Index.cshtml"
                                                       Write(item.Year);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n");
#nullable restore
#line 92 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Booklet\Index.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <span style=\"font-size: 9pt\">AAAA</span>\r\n");
#nullable restore
#line 96 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Booklet\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </td>\r\n                        <td>\r\n");
#nullable restore
#line 99 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Booklet\Index.cshtml"
                             if (item.Status == true)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <span style=\"font-size:9pt\">");
#nullable restore
#line 101 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Booklet\Index.cshtml"
                                                       Write(item.Mark);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n");
#nullable restore
#line 102 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Booklet\Index.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <span style=\"font-size: 9pt\">En Cours</span>\r\n");
#nullable restore
#line 106 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Booklet\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 109 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Booklet\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"            </tbody>
        </table>
    </div>

    <span style=""font-size:12pt"">Légende</span>
    <hr />
    <table>
        <tr>
            <td>
                <figure class=""circle-scheduled""></figure>
            </td>
            <td>
                <span style=""font-size:11pt""> Matrière Programmée</span>
            </td>
        </tr>
        <tr>
            <td>
                <figure class=""circle-passed""></figure>
            </td>
            <td>
                <span style=""font-size:11pt""> Matière Fréquentée</span>
            </td>
        </tr>
        <tr>
            <td>
                <figure class=""circle-attended""></figure>
            </td>
            <td>
                <span style=""font-size:11pt"">  Matière Passée</span>
            </td>
        </tr>
    </table>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Gamal.ViewModel.BookletViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591