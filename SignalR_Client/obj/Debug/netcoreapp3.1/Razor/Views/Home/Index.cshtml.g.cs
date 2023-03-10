#pragma checksum "C:\Users\Merve\Desktop\AKBANK EĞİTİM SERÜVENİM\Ders Projeler\SignalRProject_API_Client\SignalR_Client\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3b193f4f284fe91032cc73abb16c23bd7ca2532f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\Merve\Desktop\AKBANK EĞİTİM SERÜVENİM\Ders Projeler\SignalRProject_API_Client\SignalR_Client\Views\_ViewImports.cshtml"
using SignalR_Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Merve\Desktop\AKBANK EĞİTİM SERÜVENİM\Ders Projeler\SignalRProject_API_Client\SignalR_Client\Views\_ViewImports.cshtml"
using SignalR_Client.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b193f4f284fe91032cc73abb16c23bd7ca2532f", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b87941c303b21a43455ab6517f9ce9b0fcbe5c6c", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/microsoft/signalr/dist/browser/signalr.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Merve\Desktop\AKBANK EĞİTİM SERÜVENİM\Ders Projeler\SignalRProject_API_Client\SignalR_Client\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3b193f4f284fe91032cc73abb16c23bd7ca2532f3922", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

    <script type=""text/javascript"">

        $(document).ready(() => {

            var connection = new signalR.HubConnectionBuilder()
                .withUrl(""https://localhost:44316/MyHub"")
                .withAutomaticReconnect([1000, 2000, 3000, 10000])
                .build();

            function statusShow() {
                $(""#conStatus"").text(connection.connectionState);
            }

            statusShow();

            connection.start().then(() => {
                statusShow();
                $(""#loading"").hide();
                connection.invoke(""GetNames"");
            }).catch((err) => { console.log(err) });

            $(""#btnSave"").click(() => {
                connection.invoke(""SendName"", $(""#txtName"").val())
                    .catch((err) => { console.log(err) });
            })

            connection.on(""ReceiveName"", (name) => {
                //console.log(name);
                $(""#namesList"").append(`<li class=""list-group-item"">${name}");
                WriteLiteral(@"</li>`);
            })

            connection.onreconnecting(err => {
                $(""#loading"").show();
                statusShow();
                console.log(err);
            })

            connection.onreconnected(err => {
                $(""#loading"").hide();
                statusShow();
                console.log(err);
            })

            connection.on(""ReceiveClientCount"", (ClientCount) => {
                $(""#clientCount"").text(ClientCount);
            })

            connection.on(""Notify"", (countText) => {
                $(""#notify"").html(`<div class=""alert alert-success"">${countText}</div>`);
            })

            connection.on(""Error"", (errorText) => {
                alert(errorText);
            })

            //Yeni client için kendinden önce yapılan işlemlerin gösterilmesi
            connection.on(""ReceiveNames"", (Names) => {
                $(""#namesList"").empty();
                Names.forEach((item, index) => {
                   ");
                WriteLiteral(@" $(""#namesList"").append(`<li class=""list-group-item"">${item}</li>`);
                })
            })

            $(""#btnroomname"").click(() => {
                let name = $(""#txtName"").val();
                let roomname = $(""input[type=radio]:checked"").val();

                if (roomname == null) {
                    alert(""Lütfen şehir seçimi yapınız"");
                }
                else {
                    connection.invoke(""SendNameByGroup"", name, roomname).catch((err) => {
                        console.log(err);
                    })
                }
            })

            connection.on(""ReceiveMessageByGroup"", (name, roomId) => {
                let listName;
                if (roomId == 1) {
                    listName = ""MersinGroupList""
                }
                else {
                    listName = ""AdanaGroupList""
                }
                $(`#${listName}`).append(`<li class=""list-group-item"">${name}</li>`);
            })

       ");
                WriteLiteral(@"     $(""input[type=radio]"").change(() => {
                let value = $(`input[type=radio]:checked`).val();
                if (value == ""Mersin"") {
                    connection.invoke(""AddToGroup"", value);
                    connection.invoke(""RemoveFromGroup"", ""Adana"");
                }
                else {
                    connection.invoke(""AddToGroup"", value);
                    connection.invoke(""RemoveFromGroup"", ""Mersin"");
                }
            })
        })

    </script>
    ");
            }
            );
            WriteLiteral(@"<div class=""row"">
    <div class=""col-md-8 offset-2"">
        <input type=""text"" class=""form-control"" id=""txtName"" />
        <hr />
        <button class=""btn btn-warning"" id=""btnSave"">İsmi Kaydet</button>
        <button class=""btn btn-primary"" id=""btnroomname"">Odaya Kişi Ekle</button>
        <div class=""alert alert-info mt-2"">
            <div class=""float-left"">
                Bağlantı Durumu:<strong id=""conStatus""></strong>
                ,Client Sayısı:<strong id=""clientCount""></strong>
            </div>
            <div class=""float-right"">
                <div id=""loading"" class=""spinner-border"" role=""status"">
                    <span class=""visually-hidden""></span>
                </div>
            </div>
            <div class=""clearfix""></div>
        </div>
        <div id=""notify""></div>
    </div>
    <div class=""col-md-8 offset-2"">
        <ul class=""list-group"" id=""namesList""></ul>
    </div>
</div>
<div class=""row"">
    <div class=""col-md-8 offset-2"">
        <");
            WriteLiteral(@"div class=""form-check form-check-inline"">
            <input class=""form-check-input"" type=""radio"" name=""roomgroup"" value=""Mersin"" />
            <label class=""form-check-label"">Mersin Grubu</label>
        </div>
        <div class=""form-check form-check-inline"">
            <input class=""form-check-input"" type=""radio"" name=""roomgroup"" value=""Adana"" />
            <label class=""form-check-label"">Adana Grubu</label>
        </div>
    </div>
    <br />
    <br />
    <div class=""col-md-8 offset-2"">
        <div class=""row"">
            <div class=""col-md-4"">
                <h5>Mersin Grubu</h5>
                <ul class=""list-group"" id=""MersinGroupList""></ul>
            </div>
            <div class=""col-md-4 offset-2"">
                <h5>Adana Grubu</h5>
                <ul class=""list-group"" id=""AdanaGroupList""></ul>
            </div>
        </div>
    </div>
</div>
");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
