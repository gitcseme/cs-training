#pragma checksum "C:\Users\shuvo\source\repos\ASP.netCore.Web.App.Tutorial\IntroductionToNetCore\Views\Administration\ListRoles.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ea4acd6ec565054ddb540298dac12d78027a25ec"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Administration_ListRoles), @"mvc.1.0.view", @"/Views/Administration/ListRoles.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Administration/ListRoles.cshtml", typeof(AspNetCore.Views_Administration_ListRoles))]
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
#line 1 "C:\Users\shuvo\source\repos\ASP.netCore.Web.App.Tutorial\IntroductionToNetCore\Views\_ViewImports.cshtml"
using IntroductionToNetCore.ViewModels;

#line default
#line hidden
#line 2 "C:\Users\shuvo\source\repos\ASP.netCore.Web.App.Tutorial\IntroductionToNetCore\Views\_ViewImports.cshtml"
using IntroductionToNetCore.Models;

#line default
#line hidden
#line 3 "C:\Users\shuvo\source\repos\ASP.netCore.Web.App.Tutorial\IntroductionToNetCore\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea4acd6ec565054ddb540298dac12d78027a25ec", @"/Views/Administration/ListRoles.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"adfdae37fdb0d7706aabdf748ffef3a4186c4403", @"/Views/_ViewImports.cshtml")]
    public class Views_Administration_ListRoles : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<IdentityRole>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary mb-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:auto"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateRole", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Administration", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditRole", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteRole", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/CustomJavaScript.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(34, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\shuvo\source\repos\ASP.netCore.Web.App.Tutorial\IntroductionToNetCore\Views\Administration\ListRoles.cshtml"
  
    ViewBag.Title = "All Roles";

#line default
#line hidden
            BeginContext(77, 24, true);
            WriteLiteral("\r\n<h1>All Roles</h1>\r\n\r\n");
            EndContext();
#line 9 "C:\Users\shuvo\source\repos\ASP.netCore.Web.App.Tutorial\IntroductionToNetCore\Views\Administration\ListRoles.cshtml"
 if (Model.Any())
{

#line default
#line hidden
            BeginContext(123, 4, true);
            WriteLiteral("    ");
            EndContext();
            BeginContext(127, 123, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ea4acd6ec565054ddb540298dac12d78027a25ec7575", async() => {
                BeginContext(234, 12, true);
                WriteLiteral("Add new role");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(250, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 12 "C:\Users\shuvo\source\repos\ASP.netCore.Web.App.Tutorial\IntroductionToNetCore\Views\Administration\ListRoles.cshtml"

    foreach (var role in Model)
    {

#line default
#line hidden
            BeginContext(294, 97, true);
            WriteLiteral("        <div class=\"card mb-3\">\r\n            <div class=\"card-header\">\r\n                Role Id: ");
            EndContext();
            BeginContext(392, 7, false);
#line 17 "C:\Users\shuvo\source\repos\ASP.netCore.Web.App.Tutorial\IntroductionToNetCore\Views\Administration\ListRoles.cshtml"
                    Write(role.Id);

#line default
#line hidden
            EndContext();
            BeginContext(399, 98, true);
            WriteLiteral("\r\n            </div>\r\n            <div class=\"card-body\">\r\n                <h5 class=\"card-title\">");
            EndContext();
            BeginContext(498, 9, false);
#line 20 "C:\Users\shuvo\source\repos\ASP.netCore.Web.App.Tutorial\IntroductionToNetCore\Views\Administration\ListRoles.cshtml"
                                  Write(role.Name);

#line default
#line hidden
            EndContext();
            BeginContext(507, 82, true);
            WriteLiteral("</h5>\r\n            </div>\r\n            <div class=\"card-footer\">\r\n                ");
            EndContext();
            BeginContext(589, 849, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ea4acd6ec565054ddb540298dac12d78027a25ec10677", async() => {
                BeginContext(657, 22, true);
                WriteLiteral("\r\n                    ");
                EndContext();
                BeginContext(679, 113, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ea4acd6ec565054ddb540298dac12d78027a25ec11081", async() => {
                    BeginContext(784, 4, true);
                    WriteLiteral("Edit");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 24 "C:\Users\shuvo\source\repos\ASP.netCore.Web.App.Tutorial\IntroductionToNetCore\Views\Administration\ListRoles.cshtml"
                                                                                                       WriteLiteral(role.Id);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(792, 29, true);
                WriteLiteral("\r\n\r\n                    <span");
                EndContext();
                BeginWriteAttribute("id", " id=\"", 821, "\"", 852, 2);
                WriteAttributeValue("", 826, "confirmDeleteSpan_", 826, 18, true);
#line 26 "C:\Users\shuvo\source\repos\ASP.netCore.Web.App.Tutorial\IntroductionToNetCore\Views\Administration\ListRoles.cshtml"
WriteAttributeValue("", 844, role.Id, 844, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(853, 228, true);
                WriteLiteral(" style=\"display:none\">\r\n                        <span>Are you sure to delete?</span>\r\n                        <button type=\"submit\" class=\"btn btn-danger\">Yes</button>\r\n                        <a href=\"#\" class=\"btn btn-primary\"");
                EndContext();
                BeginWriteAttribute("onclick", "\r\n                           onclick=\"", 1081, "\"", 1151, 4);
                WriteAttributeValue("", 1119, "confirmDelete(\'", 1119, 15, true);
#line 30 "C:\Users\shuvo\source\repos\ASP.netCore.Web.App.Tutorial\IntroductionToNetCore\Views\Administration\ListRoles.cshtml"
WriteAttributeValue("", 1134, role.Id, 1134, 8, false);

#line default
#line hidden
                WriteAttributeValue("", 1142, "\',", 1142, 2, true);
                WriteAttributeValue(" ", 1144, "false)", 1145, 7, true);
                EndWriteAttribute();
                BeginContext(1152, 65, true);
                WriteLiteral(">No</a>\r\n                    </span>\r\n\r\n                    <span");
                EndContext();
                BeginWriteAttribute("id", " id=\"", 1217, "\"", 1241, 2);
                WriteAttributeValue("", 1222, "deleteSpan_", 1222, 11, true);
#line 33 "C:\Users\shuvo\source\repos\ASP.netCore.Web.App.Tutorial\IntroductionToNetCore\Views\Administration\ListRoles.cshtml"
WriteAttributeValue("", 1233, role.Id, 1233, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1242, 61, true);
                WriteLiteral(">\r\n                        <a href=\"#\" class=\"btn btn-danger\"");
                EndContext();
                BeginWriteAttribute("onclick", "\r\n                           onclick=\"", 1303, "\"", 1372, 4);
                WriteAttributeValue("", 1341, "confirmDelete(\'", 1341, 15, true);
#line 35 "C:\Users\shuvo\source\repos\ASP.netCore.Web.App.Tutorial\IntroductionToNetCore\Views\Administration\ListRoles.cshtml"
WriteAttributeValue("", 1356, role.Id, 1356, 8, false);

#line default
#line hidden
                WriteAttributeValue("", 1364, "\',", 1364, 2, true);
                WriteAttributeValue(" ", 1366, "true)", 1367, 6, true);
                EndWriteAttribute();
                BeginContext(1373, 58, true);
                WriteLiteral(">Delete</a>\r\n                    </span>\r\n                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 23 "C:\Users\shuvo\source\repos\ASP.netCore.Web.App.Tutorial\IntroductionToNetCore\Views\Administration\ListRoles.cshtml"
                                                WriteLiteral(role.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1438, 38, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 40 "C:\Users\shuvo\source\repos\ASP.netCore.Web.App.Tutorial\IntroductionToNetCore\Views\Administration\ListRoles.cshtml"
    }
}
else
{

#line default
#line hidden
            BeginContext(1495, 265, true);
            WriteLiteral(@"    <div class=""card"">
        <div class=""card-header"">
            No roles created yet
        </div>
        <div class=""card-body"">
            <h5 class=""card-title"">
                Use the button below to create a role
            </h5>
            ");
            EndContext();
            BeginContext(1760, 165, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ea4acd6ec565054ddb540298dac12d78027a25ec19924", async() => {
                BeginContext(1878, 43, true);
                WriteLiteral("\r\n                Create Role\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1925, 30, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 58 "C:\Users\shuvo\source\repos\ASP.netCore.Web.App.Tutorial\IntroductionToNetCore\Views\Administration\ListRoles.cshtml"
}

#line default
#line hidden
            BeginContext(1958, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1978, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(1984, 48, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ea4acd6ec565054ddb540298dac12d78027a25ec22190", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2032, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<IdentityRole>> Html { get; private set; }
    }
}
#pragma warning restore 1591