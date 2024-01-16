using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Mail.Dto
{
    public class OptionsDto
    {
        public bool OpenTracking { get; set; }
        public bool ClickTracking { get; set; }
        public bool TextHtmlTracking { get; set; }
        public bool AutoTextBody { get; set; }
    }
}
