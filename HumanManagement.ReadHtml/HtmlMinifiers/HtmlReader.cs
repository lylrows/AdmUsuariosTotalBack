using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Contracts;
using ServiceStack.Html;

namespace HumanManagement.ReadHtml.HtmlMinifiers
{
    public class HtmlReader : IHtmlReader
    {
        public string ReadFromFile(string fullPath)
        {
            return Minifiers.Html.Compress(LeerHtml.LeerTemplateHTML(fullPath));
        }
    }
}
