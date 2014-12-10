using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace QverbITMS.Web.HtmlHelpers
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString UnorderedList(this HtmlHelper helper,
                                                    string id, List<SelectListItem> items, string classname = "",
                                                    IDictionary<string, object> htmlAttributes = null)
        {
            var attributes = new StringBuilder();
            if (htmlAttributes != null)
            {
                foreach (var htmlAttribute in htmlAttributes)
                {
                    attributes.Append(htmlAttribute);
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<ul id='{0}'," + attributes + ">", id);
            foreach (SelectListItem item in items)
                sb.AppendFormat("<li><a href='#' id='{0}' class='{1}'>{2}</a></li>", item.Value, classname, item.Text);
            sb.AppendLine("</ul>");

            return MvcHtmlString.Create(sb.ToString());
        }

        public static MvcHtmlString QEditorFor(this HtmlHelper helper,
                                                    string id, string placeholder,
                                                    IDictionary<string, object> htmlAttributes = null)
        {
            var attributes = new StringBuilder();
            if (htmlAttributes != null)
            {
                foreach (var htmlAttribute in htmlAttributes)
                {
                    attributes.Append(htmlAttribute);
                }
            }

            StringBuilder sb = new StringBuilder();
            
            sb.AppendFormat("<input type='text' class='form-control' id='{0}' placeholder='{1}'>", id, placeholder );

            return MvcHtmlString.Create(sb.ToString());
        }
    }
}