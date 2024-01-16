using System.IO;
using System.Net;
using System.Text;

namespace HumanManagement.WebServices.Repository
{

    public static class ApiFormRepository<TRequest, TResponse>
       where TRequest : class
       where TResponse : class, new()
    {
        public static string ExecuteForm(string requestparam, string apiUrl)
        {
            
            string oResult = string.Empty;

            try
            {
                HttpWebRequest request;
                HttpWebResponse response;
                request = WebRequest.Create(apiUrl) as HttpWebRequest;


                

                byte[] data = UTF8Encoding.UTF8.GetBytes(requestparam);

                request.Method = "POST";
                request.ContentLength = data.Length;

                request.ContentType = "application/x-www-form-urlencoded";


                try
                {
                    using (Stream dataStream = request.GetRequestStream())
                    {
                        dataStream.Write(data, 0, data.Length);
                        dataStream.Close();
                    }
                    response = request.GetResponse() as HttpWebResponse;
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(dataStream);
                        string responsejson = reader.ReadToEnd();
                        
                        oResult = responsejson;

                    }
                }
                catch (WebException e)
                {
                    try
                    {
                        var responseCatch2 = e.Response as HttpWebResponse;
                        StreamReader streamReader = new StreamReader(responseCatch2.GetResponseStream(), Encoding.UTF7);
                        var d = streamReader.ReadToEnd();
                    }
                    catch (WebException) { }
                }
            }
            catch (WebException e)
            {
                try
                {
                    var responseCatch2 = e.Response as HttpWebResponse;
                    StreamReader streamReader = new StreamReader(responseCatch2.GetResponseStream(), Encoding.UTF7);
                    var d = streamReader.ReadToEnd();

                }

                catch (WebException) { }
            }



            return oResult;
        }


    }


}
