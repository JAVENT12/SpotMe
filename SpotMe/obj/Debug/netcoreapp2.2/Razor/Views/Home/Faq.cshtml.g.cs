#pragma checksum "C:\Users\Jason Ventura\source\repos\SpotMe\Views\Home\Faq.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c5057498902e2a5c81d26200c669930729858369"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Faq), @"mvc.1.0.view", @"/Views/Home/Faq.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Faq.cshtml", typeof(AspNetCore.Views_Home_Faq))]
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
#line 1 "C:\Users\Jason Ventura\source\repos\SpotMe\Views\_ViewImports.cshtml"
using Identity.Models;

#line default
#line hidden
#line 2 "C:\Users\Jason Ventura\source\repos\SpotMe\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c5057498902e2a5c81d26200c669930729858369", @"/Views/Home/Faq.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"077be99a267e43b31473dc51873a64c9309c5ed2", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Faq : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/HelpSheet.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\Jason Ventura\source\repos\SpotMe\Views\Home\Faq.cshtml"
  
    ViewData["Title"] = "FAQ";

#line default
#line hidden
            BeginContext(39, 4, true);
            WriteLiteral("<h1>");
            EndContext();
            BeginContext(44, 17, false);
#line 4 "C:\Users\Jason Ventura\source\repos\SpotMe\Views\Home\Faq.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(61, 9, true);
            WriteLiteral("</h1>\r\n\r\n");
            EndContext();
            BeginContext(70, 2231, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c5057498902e2a5c81d26200c6699307298583694467", async() => {
                BeginContext(76, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(82, 52, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c5057498902e2a5c81d26200c6699307298583694850", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(134, 2160, true);
                WriteLiteral(@"
    <section class=""cd-faq js-cd-faq container max-width-md margin-top-lg margin-bottom-lg"">
        <ul class=""cd-faq__categories"">
            <li><a class=""cd-faq__category cd-faq__category-selected truncate"" href=""#basics"">Basics</a></li>
            <!--<li><a class=""cd-faq__category truncate"" href=""#fitness"">Fitness</a></li>-->
            <!-- ... -->
        </ul> <!-- cd-faq__categories -->

        <div class=""cd-faq__items"">

            <ul id=""basics"" class=""cd-faq__group"">

                <li class=""cd-faq__title""><h2>Basics</h2></li>
                <li class=""cd-faq__item"">
                    <a class=""cd-faq__trigger"" href=""#0""><span>How do I change my password?</span></a>
                    <div class=""cd-faq__content"">
                        <div class=""text-component"">
                            <!-- content here -->
                        </div>
                    </div> <!-- cd-faq__content -->
                </li>

                <li class=""cd-faq__item"">");
                WriteLiteral(@"
                    <a class=""cd-faq__trigger"" href=""#0""><span>How do I sign up?</span></a>
                    <div class=""cd-faq__content"">
                        <div class=""text-component"">
                            <!-- content here -->
                        </div>
                    </div> <!-- cd-faq__content -->
                </li>

                <li class=""cd-faq__item"">
                    <a class=""cd-faq__trigger"" href=""#0""><span>Do I need a spotter?</span></a>
                    <div class=""cd-faq__content"">
                        <div class=""text-component"">
                            <p> </p>
                        </div>
                    </div> <!-- cd-faq__content -->
                </li>

            </ul> <!-- cd-faq__group -->




            <ul id=""fitness"" class=""cd-faq__group"">
            </ul> <!-- cd-faq__group -->
            <!-- ... -->
        </div> <!-- cd-faq__items -->

        <a href=""#0"" class=""cd-faq__close-panel text-replac");
                WriteLiteral("e\">Close</a>\r\n\r\n        <div class=\"cd-faq__overlay\" aria-hidden=\"true\"></div>\r\n    </section> <!-- cd-faq -->\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
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
