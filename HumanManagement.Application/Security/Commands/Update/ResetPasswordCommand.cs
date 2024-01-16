using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Models;
using HumanManagement.Domain.Security.Contracts;
using HumanManagement.Domain.Security.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Security.Commands.Update
{
    public class ResetPasswordCommand : IRequest<Result>
    {
        public ResetPasswordDto ResetPassword { get; set; }
    }

    public class ResetPasswordCommandHandler: IRequestHandler<ResetPasswordCommand, Result>
    {
        private readonly IBaseRepository<User> baseRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICryptography cryptography;
        public ResetPasswordCommandHandler(IBaseRepository<User> baseRepository,
                                            IMapper mapper,
                                            IUnitOfWork unitOfWork,
                                            ICryptography cryptography)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.cryptography = cryptography;
        }
        
        public async Task<Result> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            Result result = new Result();
            request.ResetPassword.SetPassword(cryptography);
            var user = mapper.Map<User>(request.ResetPassword);
          

            var usermodel = await baseRepository.Find(request.ResetPassword.Id);
            usermodel.Password = request.ResetPassword.Password;
            usermodel.DateUpdate = DateTime.Now;
            usermodel.ChangedPassword = true;


            await baseRepository.UpdatePartial(usermodel, x => x.Password,
                                                      x => x.DateUpdate,
                                                      x => x.ChangedPassword
                                                      );

            await unitOfWork.Commit();

            result.StateCode = Constants.StateCodeResult.STATE_CODE_OK;
            result.MessageError = new List<string>(){
                    "Se cambió la contraseña de manera correcta."
                };

            return result;
        }
    }

}
