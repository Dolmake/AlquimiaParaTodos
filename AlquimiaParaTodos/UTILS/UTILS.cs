using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace System.Web.Mvc.Html
{
    public static class EXTENSIONS
    {
        public static MvcHtmlString DisplayShortNameFor(this HtmlHelper html, string value, int maxlenght)
        {
            string add = "";
            if (value.Length > maxlenght)
            {
                add = "...";
            }
            return new MvcHtmlString(value.Substring(0, maxlenght) + add);
        }
    }
}