using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Employee.Dto
{
    public class ReplaceEntity
    {
        public string stag { get; set; }
        public string sreplacetext { get; set; }
    }

    public class ResponseEnty
    {
        public int StateCode { get; set; }
        public List<string> MessageError { get; set; }
        public Object Data { get; set; }
        public ResponseEnty()
        {
            MessageError = new List<string>();
        }
    }
}
