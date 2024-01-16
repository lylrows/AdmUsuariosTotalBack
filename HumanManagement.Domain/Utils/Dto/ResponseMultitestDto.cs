using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Utils.Dto
{
    public class ResponseMultitestDto
    {
        public List<FactorDto> DtoResponse { get; set; }
    }

    public class FactorDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Score { get; set; }
    }
}
