using System.IO;

namespace HumanManagement.CrossCutting.Utils
{
    public class LeerHtml
    {
        public static string LeerTemplateHTML(string url)
        {
            using (StreamReader lector = new StreamReader(url, System.Text.Encoding.UTF8))
            {
                return lector.ReadToEnd();
            }
        }
    }
}
