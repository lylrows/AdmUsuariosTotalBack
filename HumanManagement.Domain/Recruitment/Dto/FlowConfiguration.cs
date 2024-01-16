using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Applicants.Dto
{
    public class FlowConfiguration
    {
        public int nid_flowconfiguration { get; set; }

        public int nid_originposition { get; set; }

        public int nid_destinationposition { get; set; }

        public int nid_nivel { get; set; }
    }
}
