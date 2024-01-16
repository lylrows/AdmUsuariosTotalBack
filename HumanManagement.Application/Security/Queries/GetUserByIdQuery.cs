using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Security.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Security.Queries
{
    public class GetUserByIdQuery : IRequest<Result>
    {
        public int IdUser { get; set; }
        public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Result>
        {
            private readonly IUserRepository userRepository;
            public GetUserByIdQueryHandler(IUserRepository userRepository)
            {
                this.userRepository = userRepository;
            }
            public async Task<Result> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
            {
                var userDto = await userRepository.GetById(request.IdUser);

                //if (!System.IO.File.Exists(userDto.PhotoUrl))
                //{
                //    userDto.PhotoUrl = "../../../../../assets/images/avatars/avatar.jpg";
                //}

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = userDto
                };
            }
        }
    }
}
