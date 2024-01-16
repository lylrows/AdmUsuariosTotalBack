using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Recruitment.Commands
{
    public class AddBumeranCommand : IRequest<Result>
    {
        
        public class AddBumeranCommandHandler : IRequestHandler<AddBumeranCommand, Result>
        {
            
            public AddBumeranCommandHandler()
            {
            
            }

            
            public async Task<Result> Handle(AddBumeranCommand request, CancellationToken cancellationToken)
            {
            
             
                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    MessageError = new List<string>() { "Se guardó la banda de manera correcta." }
                };
            }
        }
    }
}
