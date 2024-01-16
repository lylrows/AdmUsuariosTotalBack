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

namespace HumanManagement.Application.EvaluationPostulants.Queries
{
    public class GetDocumentPostulantQuery: IRequest<Result>
    { 
        public int IdEvaluationPostulant { get; set; }

        public class GetDocumentPostulantQueryHandle : IRequestHandler<GetDocumentPostulantQuery, Result>
        {
            private readonly IBaseRepository<EvaluationPostulantDocuments> baseRepository;
            private readonly IMapper mapper;
            public GetDocumentPostulantQueryHandle(IBaseRepository<EvaluationPostulantDocuments> baseRepository, IMapper mapper)
            {
                this.baseRepository = baseRepository;
                this.mapper = mapper;
            }
            public async Task<Result> Handle(GetDocumentPostulantQuery request, CancellationToken cancellationToken)
            {
                var dto = new EvaluationPostulantDocumentsDto();
                var entity = await baseRepository.FindPredicate(x => x.IdEvaluationPostulant == request.IdEvaluationPostulant);
                if (entity != null)
                {
                    dto = mapper.Map<EvaluationPostulantDocumentsDto>(entity);

                    if (dto.FolderAntecedentes != null)
                    {
                        var file = dto.FolderAntecedentes;
                        var filename = Path.GetFileName(file);
                        if (File.Exists(file))
                        {
                            dto.FileAntecedentes = new FileDto();
                            var buffer = File.ReadAllBytes(file);
                            dto.FileAntecedentes.File = buffer;
                            dto.FileAntecedentes.ContentType = Path.GetExtension(filename);
                            dto.FileAntecedentes.NameFile = filename;
                        }
                    }

                    if (dto.FolderCertificado != null)
                    {
                        var file = dto.FolderCertificado;
                        var filename = Path.GetFileName(file);
                        if (File.Exists(file))
                        {
                            dto.FileCertificado = new FileDto();
                            var buffer = File.ReadAllBytes(file);
                            dto.FileCertificado.File = buffer;
                            dto.FileCertificado.ContentType = Path.GetExtension(filename);
                            dto.FileCertificado.NameFile = filename;
                        }
                    }
                }



                return new Result
                {
                    Data = dto,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
        }
    }
}
