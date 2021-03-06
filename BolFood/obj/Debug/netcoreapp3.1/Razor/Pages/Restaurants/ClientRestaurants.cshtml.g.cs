#pragma checksum "C:\Users\Humza\source\repos\FoodApp\BolFood\Pages\Restaurants\ClientRestaurants.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "580696f6273642af335cfbad8c205758352cc69b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(BolFood.Pages.Restaurants.Pages_Restaurants_ClientRestaurants), @"mvc.1.0.razor-page", @"/Pages/Restaurants/ClientRestaurants.cshtml")]
namespace BolFood.Pages.Restaurants
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
#line 1 "C:\Users\Humza\source\repos\FoodApp\BolFood\Pages\_ViewImports.cshtml"
using BolFood;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"580696f6273642af335cfbad8c205758352cc69b", @"/Pages/Restaurants/ClientRestaurants.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"adb1b26e5c6661601891906f7a405657a4091446", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Restaurants_ClientRestaurants : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Humza\source\repos\FoodApp\BolFood\Pages\Restaurants\ClientRestaurants.cshtml"
  
    ViewData["Title"] = "ClientRestaurants";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>ClientRestaurants</h1>\r\n<table id=\"restaurants\" class=\"table\">\r\n</table>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"

    <link rel=""stylesheet"" type=""text/css"" href=""https://cdn.datatables.net/v/bs4/dt-1.10.21/datatables.min.css"" />
    <script type=""text/javascript"" src=""https://cdn.datatables.net/v/bs4/dt-1.10.21/datatables.min.js""></script>

    <script>
        $(function () {
            var cuisines = [""None"",""Mexican"",""Italian"",""Inidan"",""Pakistani""]
            $.ajax(""/api/restaurants/"", { method: ""get"" })
                .then(function (response) {
                    console.log(response);
                    $(""#restaurants"").DataTable({
                        data: response,
                        columns: [
                            { ""data"": ""name"" },
                            { ""data"": ""location"" },
                            {
                                ""data"": ""cuisine"", ""render"": function (data) {
                                    return cuisines[data];
                                }
                            }
                        ]
                    });
  ");
                WriteLiteral("              });\r\n        });\r\n\r\n    </script>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BolFood.ClientRestaurantsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BolFood.ClientRestaurantsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BolFood.ClientRestaurantsModel>)PageContext?.ViewData;
        public BolFood.ClientRestaurantsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
