﻿using ASPProductTask2.Entities;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace ASPProductTask2.TagHelpers
{
    [HtmlTargetElement("product-list")]
    public class ProductListTagHelper : TagHelper
    {
        const string productList = "products";

        [HtmlAttributeName(productList)]
        public List<Product> Products { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "ul";
            output.Attributes.SetAttribute("style", "display:flex;flex-wrap:wrap;gap:15px;align-items:center;justify-content:center;list-style:none;padding:0;");
        }
    }
}
