#pragma checksum "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Secretary\Home.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "469423d31cf0e3a0139b4bd4b17ff2c4325b6c1a"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"469423d31cf0e3a0139b4bd4b17ff2c4325b6c1a", @"/Views/Secretary/Home.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"00b07e519be85c819db8ca31c5e161827274582b", @"/Views/_ViewImports.cshtml")]
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
            DefineSection("UserFirstName", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 8 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Secretary\Home.cshtml"
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
#line 12 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Secretary\Home.cshtml"
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
                WriteLiteral("\r\n    <span style=\"font-size:20pt;\">Zone réservée du secrétaire </span><span style=\"font-size:20pt;\">");
#nullable restore
#line 29 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Secretary\Home.cshtml"
                                                                                                Write(ViewBag.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 29 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Secretary\Home.cshtml"
                                                                                                                      Write(ViewBag.LastName);

#line default
#line hidden
#nullable disable
                WriteLiteral("-[MAT. ");
#nullable restore
#line 29 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Secretary\Home.cshtml"
                                                                                                                                               Write(ViewBag.SerialNumber);

#line default
#line hidden
#nullable disable
                WriteLiteral("]</span>\r\n    <br />\r\n");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("middlePanelBody", async() => {
                WriteLiteral("\r\n\r\n\r\n    <span style=\"font-size:20pt; color:red\">Direction du service pour les étudiants - Services Didactiques</span>\r\n    <br />\r\n");
#nullable restore
#line 39 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Secretary\Home.cshtml"
     if (!String.IsNullOrEmpty(@ViewBag.Error))
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <span style=\"color:red; font-weight:bold\">");
#nullable restore
#line 41 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Secretary\Home.cshtml"
                                             Write(ViewBag.Error);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n");
#nullable restore
#line 42 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Secretary\Home.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Secretary\Home.cshtml"
     if (!String.IsNullOrEmpty(@ViewBag.Message))
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <span style=\"color:green; font-weight:bold\">");
#nullable restore
#line 45 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Secretary\Home.cshtml"
                                               Write(ViewBag.Message);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n");
#nullable restore
#line 46 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Secretary\Home.cshtml"
    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"    <br />
    <span style=""color:black; font-size:20pt; border-bottom:5px solid red"">ESSE4</span>
    <br />
    <br />
    <span style=""font-size:20pt"">INSCRIPTIONS ET REINSCRIPTIONS ANNÉE ACADÉMIQUE 2019/2020</span>
    <br />
    <br />
    <p>
        La procédure en ligne est ouverte pour demander une évaluation des diplômes de master de deuxième niveau. Pour savoir comment et les délais, consultez les appels <a class=""a-secretary"" href=""https://www.gamal.gn/admission.html"">
            <span style=""font-weight:bold; color:red;"">(https://www.gamal.gn/admission-Lau2V.html)</span>
        </a> Des appels à l'accès à des formations diplômantes en nombre limité sont publiés. Pour plus d'informations, consultez la page dédiée <span style=""font-weight:bold; color:red""><a class=""a-secretary"" href=""https: //www.unimore.it/bandi/StuLau.html"">(https: //www.unimore.it/bandi/StuLau.html)</a></span>.
        Pour vous inscrire à un cursus en libre accès, consultez la page dédiée <span style=""font-weight:b");
                WriteLiteral(@"old; color:red""><a class=""a-secretary"" href=""https://www.gamal.gn/admission/immaiscLLMCUAL.html"">(https://www.gamal.fr/admission/immaiscLLMCUAL.html)</a> </span> .
    </p>
    <br />
    <p>
        Pour vous inscrire, vous devez payer le premier versement de bourses universitaires. L'étudiant recevra une confirmation de l'inscription par SMS et e-mail à l'adresse e-mail personnelle définie et le compte e-mail Unimore auquel les communications institutionnelles seront envoyées sera activé. Après cinq jours à compter de la réception de la communication, l'étudiant doit se rendre en personne au bureau de l'administration des étudiants pour récupérer la carte d'étudiant
        Pour plus d'informations, écrivez à <span style=""font-weight:bold; color:red"">informastudenti ");
#nullable restore
#line 63 "C:\Users\elhad\Desktop\Desktop\Gamal\Gamal\Views\Secretary\Home.cshtml"
                                                                                                 Write(Html.Raw("@"));

#line default
#line hidden
#nullable disable
                WriteLiteral("unimore.it</span>\r\n    </p>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
