using System;
using System.Collections.Generic;

namespace HumanManagement.Application.Response
{
    public class Result
    {
        public int StateCode { get; set; }
        public List<string> MessageError { get; set; }
        public Object Data { get; set; }
        public Object DataDetail { get; set; }
        public int LastId { get; set; }
        public Result()
        {
            MessageError = new List<string>();
        }
    }

    
}
