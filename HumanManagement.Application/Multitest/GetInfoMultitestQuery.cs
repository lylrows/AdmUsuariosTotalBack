using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Utils.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Multitest
{
    public class GetInfoMultitestQuery: IRequest<Result>
    {
        public MultitestDto dto { get; set; }
        public String _urlMultitest { get; set; }

        public class GetJsonHandle : IRequestHandler<GetInfoMultitestQuery, Result>
        {
            public async Task<Result> Handle(GetInfoMultitestQuery request, CancellationToken cancellationToken)
            {
                string oResult = string.Empty;
                
                string apiurl = String.Format(request._urlMultitest, request.dto.ruc, request.dto.processId, request.dto.dni);
                try
                {
                    HttpWebRequest requestapi;
                    HttpWebResponse response;
                    requestapi = WebRequest.Create(apiurl) as HttpWebRequest;


                    byte[] data = UTF8Encoding.UTF8.GetBytes("");

                    requestapi.Method = "GET";

                    requestapi.ContentType = "application/json";
                    requestapi.ContentLength = data.Length;


                    try
                    {
     
                        response = requestapi.GetResponse() as HttpWebResponse;
                        using (Stream dataStream = response.GetResponseStream())
                        {
                            StreamReader reader = new StreamReader(dataStream);
                            string responsejson =  await reader.ReadToEndAsync();
     
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


                return new Result
                {
                    Data = oResult,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
        }
    }
}
