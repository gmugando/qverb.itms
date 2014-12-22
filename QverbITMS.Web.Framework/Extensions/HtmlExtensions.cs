using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace QverbITMS.Web.Framework.Extensions
{
    public static class HtmlExtensions
    {
        #region DropDownList Extensions

        private static readonly SelectListItem[] _singleEmptyItem = new[] { new SelectListItem { Text = "", Value = "" } };

        public static SelectList ToSelectList<TEnum>(this TEnum enumObj)
        {
            var values = (from TEnum e in Enum.GetValues(typeof(TEnum))
                          select new { ID = e, Name = e.ToString() }).ToList();

            return new SelectList(values, "Id", "Name", enumObj);
        }

        public static MvcHtmlString DropDownListForEnum<TModel, TEnum>(
                                this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression, object htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

            var items =
                values.Select(
                   value =>
                   new SelectListItem
                   {
                       Text = GetEnumDescription(value),
                       Value = value.ToString(),
                       Selected = value.Equals(metadata.Model)
                   });
            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            return htmlHelper.DropDownListFor(expression, items, attributes);
        }

        public static string GetEnumDescription<TEnum>(TEnum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }


        #endregion
    }
}
