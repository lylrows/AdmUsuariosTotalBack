using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.EvaluationPostulant.Dto;
using HumanManagement.Domain.EvaluationPostulant.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.EvaluationPostulants.Command
{
    public class DeleleDocumentPostulantCommand: IRequest<Result>
    {
        public EvaluationPostulantDocumentsDto EvaluationPostulantDocumentsDto;
    }

    public class DeleleDocumentPostulantCommandHandle : IRequestHandler<DeleleDocumentPostulantCommand, Result>
    {
        private readonly IBaseRepository<EvaluationPostulantDocuments> baseRepository;
        private readonly IMapper mapper;
        public DeleleDocumentPostulantCommandHandle(IBaseRepository<EvaluationPostulantDocuments> baseRepository, IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<Result> Handle(DeleleDocumentPostulantCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<EvaluationPostulantDocuments>(request.EvaluationPostulantDocumentsDto);

            switch (request.EvaluationPostulantDocumentsDto.NombreDocumento)
            {
                case "antecedentes":
                    if (File.Exists(entity.FolderAntecedentes))
                    {
                        File.Delete(entity.FolderAntecedentes);
                        entity.FolderAntecedentes = null;
                    }

                    break;
                case "certificado":
                    if (File.Exists(entity.FolderCertificado))
                    {
                        File.Delete(entity.FolderCertificado);
                        entity.FolderCertificado = null;
                    }

                    break;
                default:
                    break;
            }


            await baseRepository.Update(entity);

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = entity
            };
        }
    }
}
