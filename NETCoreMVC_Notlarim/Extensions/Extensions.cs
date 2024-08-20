using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NETCoreMVC_Notlarim.Extensions
{
    static public class Extensions
    {
        public static IHtmlContent CustomTextBox(this IHtmlHelper htmlHelper, string name, string value="", string placeholder = "")
        =>
            htmlHelper.TextBox(name, value, new
            {
                style = "background-color:green;color:white;font-size:11px;",
                @class = "form-input",
                a = "a",
                b = "b",
                placeholder = placeholder
            });
        
    }
}
