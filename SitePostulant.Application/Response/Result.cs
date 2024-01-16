using System;
using System.Collections.Generic;

namespace SitePostulant.Application.Response
{
    public class Result
    {
        public int StateCode { get; set; }
        public List<string> MessageError { get; set; }
        public Object Data { get; set; }

        public Result()
        {
            MessageError = new List<string>();
        }
    }
}
