using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSHumanManagement.Application.Response
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
