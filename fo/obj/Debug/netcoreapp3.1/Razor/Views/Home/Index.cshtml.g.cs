#pragma checksum "E:\Documents\m2\naina\galery-service-web-api-bo-fo-asp-net-mvc-and-asp-net-core\fo\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ec7828b3fae884601937f50025dba25d111be4a4"
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
#line 1 "E:\Documents\m2\naina\galery-service-web-api-bo-fo-asp-net-mvc-and-asp-net-core\fo\Views\_ViewImports.cshtml"
using fo;

#line default
#line hidden
#line 2 "E:\Documents\m2\naina\galery-service-web-api-bo-fo-asp-net-mvc-and-asp-net-core\fo\Views\_ViewImports.cshtml"
using fo.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec7828b3fae884601937f50025dba25d111be4a4", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"762ce31aee2654ea658350b8cfea0862b7befcca", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "E:\Documents\m2\naina\galery-service-web-api-bo-fo-asp-net-mvc-and-asp-net-core\fo\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            WriteLiteral(@"
<div class=""text-center"">
    <h1 class=""display-4"">Welcome</h1>
    <p>Search for your picture.</p>
    <div class=""input-group"">
        <input onkeyup=""search()"" type=""text"" class=""form-control"" placeholder=""name"" id=""NAME_PICTURE"">
        <input onkeyup=""search()"" type=""text"" class=""form-control"" placeholder=""category"" id=""NAME_CATEGORY_PICTURE"">
        <input onkeyup=""search()"" type=""number"" class=""form-control"" placeholder=""price min"" id=""MIN"">
        <input onkeyup=""search()"" type=""number"" class=""form-control"" placeholder=""price max"" id=""MAX"">
    </div>
    <br />
    <div class=""input-group"">
        <div class=""input-group-prepend"">
            <span class=""input-group-text""");
            BeginWriteAttribute("id", " id=\"", 755, "\"", 760, 0);
            EndWriteAttribute();
            WriteLiteral(@">Publish</span>
        </div>
        <input onchange=""search()"" type=""date"" class=""form-control"" id=""MINDATEPUB"">
        <input onchange=""search()"" type=""date"" class=""form-control"" id=""MAXDATEPUB"">
    </div>
    <br />
    <div class=""input-group"">
        <div class=""input-group-prepend"">
            <span class=""input-group-text""");
            BeginWriteAttribute("id", " id=\"", 1106, "\"", 1111, 0);
            EndWriteAttribute();
            WriteLiteral(@">Upload</span>
        </div>
        <input onchange=""search()"" type=""date"" class=""form-control"" id=""MINDATEUP"">
        <input onchange=""search()"" type=""date"" class=""form-control"" id=""MAXDATEUP"">
    </div>
    <br />
    <table class=""table"">
        <thead>
            <tr>
                <th scope=""col"">#</th>
                <th scope=""col"">Name</th>
                <th scope=""col"">Category</th>
                <th scope=""col"">Date Publish</th>
                <th scope=""col"">Date Uploaded</th>
                <th scope=""col"">Price</th>
                <th scope=""col"">Picture</th>

            </tr>
        </thead>
        <tbody id=""records_table"">
        </tbody>
    </table>
</div>
<script src=""https://code.jquery.com/jquery-3.3.1.min.js""></script>
<script type=""text/javascript"">
    function CategoryPicture(){
        $('#records_table').empty();
        $.ajax({
            type: ""GET"",
            // https://localhost:44321/Home/IndexRest
            url: """);
#line 55 "E:\Documents\m2\naina\galery-service-web-api-bo-fo-asp-net-mvc-and-asp-net-core\fo\Views\Home\Index.cshtml"
             Write(Url.Action("IndexRest"));

#line default
#line hidden
            WriteLiteral(@""",
            dataType: ""json"",
            success: function (msg) {
                $.each(msg, function (i, item) {
                    var $tr = $('<tr>').append(
                        $('<td>').text(item.iD_PICTURE),
                        $('<td>').text(item.namE_PICTURE),
                        $('<td>').text(item.namE_CATEGORY_PICTURE),
                        $('<td>').text(item.datE_PUBLISH_PICTURE),
                        $('<td>').text(item.datE_UPLOAD_PICTURE),
                        $('<td>').text(item.pricE_PICTURE),
                        $('<td>').append('<div class=""text-center""><img class=""img-thumbnail"" src=""https://localhost:44388/Content/Images/'+item.iD_PICTURE+'.jpg"" style=""width: 100px; height: 100px;""></div>')
                    ).appendTo('#records_table');
                });
            },
            error: function (req, status, error) {
                alert(msg);
            }
        });
    }
    CategoryPicture()
</script>
<script type=""text/j");
            WriteLiteral(@"avascript"">
    function search() {
        var MAXDATEPUB = $('#MAXDATEPUB').val();
        var MAXDATEUP = $('#MAXDATEUP').val();
        if ($('#MAXDATEPUB').val() == """") {
            MAXDATEPUB=""9999-12-03""
        }
        if ($('#MAXDATEUP').val() == """") {
            MAXDATEUP=""9999-12-03""
        }
        $('#records_table').empty();
        $.ajax({
            type: ""GET"",
            // https://localhost:44321/Home/IndexRest
            url: """);
#line 91 "E:\Documents\m2\naina\galery-service-web-api-bo-fo-asp-net-mvc-and-asp-net-core\fo\Views\Home\Index.cshtml"
             Write(Url.Action("SearchRest"));

#line default
#line hidden
            WriteLiteral(@"?NAME_PICTURE=""
                + $('#NAME_PICTURE').val()
                + ""&NAME_CATEGORY_PICTURE=""
                + $('#NAME_CATEGORY_PICTURE').val()
                + ""&MIN=""
                + $('#MIN').val()
                + ""&MAX=""
                + $('#MAX').val()
                + ""&MINDATEPUB=""
                + $('#MINDATEPUB').val()
                + ""&MAXDATEPUB=""
                + MAXDATEPUB
                + ""&MINDATEUP=""
                + $('#MINDATEUP').val()
                + ""&MAXDATEUP=""
                + MAXDATEUP,
            dataType: ""json"",
            complete: function (data, xhr, textStatus) {
                $.each(data.responseJSON, function (i, item) {
                    var $tr = $('<tr>').append(
                        $('<td>').text(item.iD_PICTURE),
                        $('<td>').text(item.namE_PICTURE),
                        $('<td>').text(item.namE_CATEGORY_PICTURE),
                        $('<td>').text(item.datE_PUBLISH_PICTURE),
       ");
            WriteLiteral(@"                 $('<td>').text(item.datE_UPLOAD_PICTURE),
                        $('<td>').text(item.pricE_PICTURE),
                        $('<td>').append('<div class=""text-center""><img class=""img-thumbnail"" src=""https://localhost:44388/Content/Images/'+item.iD_PICTURE+'.jpg"" style=""width: 100px; height: 100px;""></div>')
                    ).appendTo('#records_table');
                });
            }
        });
    }
</script>");
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