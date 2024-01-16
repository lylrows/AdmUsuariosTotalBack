using HumanManagement.Domain.StaffRequest.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.StaffRequest.Models
{
    public class RequestStatusChecker
    {
        private int totalApprovalLevels;
        private int currentLevel;
        public int State { get; private set; }
        public RequestStatusChecker(int totalApprovalLevels,
                                    int currentLevel)
        {
            this.totalApprovalLevels = totalApprovalLevels;
            this.currentLevel = currentLevel;
        }

        public void SetStateApproved()
        {
            if (currentLevel < totalApprovalLevels)
            {
                State = (int)StaffRequestState.IN_PROCESS;
            }
            if (currentLevel == totalApprovalLevels)
            {
                State = (int)StaffRequestState.APPROVED;
            }   
        }
        public void SetStateRejected()
        {
            State = (int)StaffRequestState.REJECTED;

        }
    }
}
