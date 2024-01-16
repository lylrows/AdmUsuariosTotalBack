using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Recognition.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Recognition.Commands.Create
{
    public class CreateRecognitionCommand : IRequest<Result>
    {
        
        public CreateRecognitionDto newRecognition { get; set; }
    }

    public class CreateRecognitionCommandHandler : IRequestHandler<CreateRecognitionCommand, Result>
    {
        private readonly IBaseRepository<Domain.Recognition.Models.Recognition> baseRepository;
        
        private readonly IUnitOfWork unitOfWork;

        public CreateRecognitionCommandHandler(IBaseRepository<Domain.Recognition.Models.Recognition> baseRepository,                        
                                    IUnitOfWork unitOfWork)
        {
            this.baseRepository = baseRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateRecognitionCommand request, CancellationToken cancellationToken)
        {
            Domain.Recognition.Models.Recognition recognition = new Domain.Recognition.Models.Recognition();


            recognition.nid_person = request.newRecognition.nid_person;
            recognition.nid_state = 45;
            recognition.nid_recognizer = request.newRecognition.nid_user;
            recognition.stitle = request.newRecognition.stitle;
            recognition.sdescription = request.newRecognition.sdescription;
            recognition.sicon = request.newRecognition.sicon;
            recognition.Active = true;
            recognition.DateRegister = DateTime.Now;
            recognition.IdUserRegister = request.newRecognition.nid_user;
            recognition.DateUpdate = DateTime.Now;
            recognition.IdUserUpdate = request.newRecognition.nid_user;

            await baseRepository.Add(recognition);
            await unitOfWork.Commit();
            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                MessageError = new List<string>() { "Se guardó el reconocimiento de manera correcta" }

            };

        }
    }
}
