#pragma checksum "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Secretary\Home.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9860891b6f46579d209891f153fbcf9b196816eb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Secretary_Home), @"mvc.1.0.view", @"/Views/Secretary/Home.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9860891b6f46579d209891f153fbcf9b196816eb", @"/Views/Secretary/Home.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"53a3cbe1952b84b6404f0a9759f671554cf5a320", @"/Views/_ViewImports.cshtml")]
    public class Views_Secretary_Home : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Secretary\Home.cshtml"
  
    ViewData["Title"] = "Home";
    Layout = "~/Views/Shared/_Secretary.cshtml";

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
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("middlePanelBody", async() => {
                WriteLiteral(@"
    <div class=""card"" style=""width:100%;"">
        <div class=""card-body"">
            <span style=""font-size:15pt; font-family:'Times New Roman'"">INSCRIPTIONS ET REINSCRIPTIONS ANNÉE ACADÉMIQUE 2019/2020</span>
        </div>
    </div>
    <br />
    <div>
        <div class=""card"" style=""width:49%; float:left"">
            <div class=""card-body"">
                <span style=""font-size:15pt; font-weight:bold; font-family:'Times New Roman'"">Procédure en ligne</span>
                <p style=""text-align:justify"">
                    La procédure en ligne est ouverte pour demander une évaluation des diplômes de master de deuxième niveau. Pour savoir comment et les délais, consultez les appels <a class=""a-secretary"" href=""https://www.gamal.gn/admission.html"">
                        <span style=""font-weight:bold; color:red;"">(https://www.gamal.gn/admission-Lau2V.html)</span>
                    </a> Des appels à l'accès à des formations diplômantes en nombre limité sont publiés. Pour plus d'infor");
                WriteLiteral(@"mations, consultez la page dédiée <span style=""font-weight:bold; color:red""><a class=""a-secretary"" href=""https: //www.unimore.it/bandi/StuLau.html"">(https: //www.unimore.it/bandi/StuLau.html)</a></span>.
                    Pour vous inscrire à un cursus en libre accès, consultez la page dédiée <span style=""font-weight:bold; color:red""><a class=""a-secretary"" href=""https://www.gamal.gn/admission/immaiscLLMCUAL.html"">(https://www.gamal.fr/admission/immaiscLLMCUAL.html)</a> </span> .
                </p>
            </div>
        </div>
        <div class=""card"" style=""width:49%; float:right"">
            <div class=""card-body"">
                <span style=""font-size:15pt; font-weight:bold; font-family:'Times New Roman'"">Demande de bourse</span>
                <p style=""text-align:justify"">
                    Pour vous inscrire, vous devez payer le premier versement de bourses universitaires. L'étudiant recevra une confirmation de l'inscription par SMS et e-mail à l'adresse e-mail personnelle définie");
                WriteLiteral(@" et le compte e-mail Unimore auquel les communications institutionnelles seront envoyées sera activé. Après cinq jours à compter de la réception de la communication, l'étudiant doit se rendre en personne au bureau de l'administration des étudiants pour récupérer la carte d'étudiant
                    Pour plus d'informations, écrivez à <span style=""font-weight:bold; color:red"">informastudenti ");
#nullable restore
#line 48 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Secretary\Home.cshtml"
                                                                                                             Write(Html.Raw("@"));

#line default
#line hidden
#nullable disable
                WriteLiteral("unimore.it.</span>\r\n                </p>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            }
            );
            WriteLiteral("\r\n\r\n");
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
