using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Security.Contracts;
using HumanManagement.Domain.Security.Dto;
using HumanManagement.Domain.Security.QueryFilter;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Security.Queries
{
    public class GetListUsersPaginationQuery : IRequest<Result>
    {
        public UserQueryFilter UserQueryFilter { get; set; }
        public class GetListUsersPaginationQueryHandler : IRequestHandler<GetListUsersPaginationQuery, Result>
        {
            private readonly IUserRepository userRepository;
            public GetListUsersPaginationQueryHandler(IUserRepository userRepository)
            {
                this.userRepository = userRepository;
            }
            public async Task<Result> Handle(GetListUsersPaginationQuery query, CancellationToken cancellationToken)
            {
                var listUser = await userRepository.GetListUsersPagination(query.UserQueryFilter);

               /* foreach (var item in listUser.list)
                {
                    item.Photo = GetAvatar(item.Photo);
                }*/

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = listUser
                };
            }

            public string GetAvatar(string url)
            {
                var base64ImageRepresentation = "";
                if (url != "" && url != null)
                {
                    var fileAvatar = url;
                    if (File.Exists(fileAvatar))
                    {
                        var imageArray = File.ReadAllBytes(fileAvatar);
                        base64ImageRepresentation = $"data:image/jpeg;base64,{Convert.ToBase64String(imageArray)}";
                    }
                }

                return base64ImageRepresentation;
            }
        }
    }
}
