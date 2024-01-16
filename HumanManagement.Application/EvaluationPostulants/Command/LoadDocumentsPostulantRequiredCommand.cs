using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.EvaluationPostulant.Dto;
using HumanManagement.Domain.EvaluationPostulant.Models;
using HumanManagement.Domain.Postulant.Person.Contracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.EvaluationPostulants.Command
{
    public class LoadDocumentsPostulantRequiredCommand: IRequest<Result>
    {
        public IFormFile formFile { get; set; }
        public EvaluationPostulantDocumentsDto dto { get; set; }
    }

    public class LoadDocumentsPostulantRequiredCommandHandler : IRequestHandler<LoadDocumentsPostulantRequiredCommand, Result>
    {
        private readonly IBaseRepository<EvaluationPostulantDocuments> baseRepository;
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;
        private readonly AppSettings _appSettings;

        public LoadDocumentsPostulantRequiredCommandHandler(IBaseRepository<EvaluationPostulantDocuments> baseRepository,
                                                            IPersonRepository personRepository,
                                                            IOptions<AppSettings> appSettings,
                                                            IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.personRepository = personRepository;
            this.mapper = mapper;
            this._appSettings = appSettings.Value;
        }
        public async Task<Result> Handle(LoadDocumentsPostulantRequiredCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<EvaluationPostulantDocuments>(request.dto);
            var person = await personRepository.GetPerson(request.dto.IdPostulant);

            var folder = _appSettings.PathSaveFile;
            var filenamefolder = folder + "FilesDocumentsPostulant\\Documents_" + string.Format(person.FirstName, "_", person.LastName) + "\\";
            var filename = request.formFile.FileName;
            var folderFile = filenamefolder + request.formFile.FileName;

            switch (request.dto.NombreDocumento)
            {
                case "antecedentes":
                    entity.FolderAntecedentes = folderFile;
                    break;
                case "certificado":
                    entity.FolderCertificado = folderFile;
                    break;
                default:
                    break;
            }

            if (!Directory.Exists(filenamefolder))
            {
                Directory.CreateDirectory(filenamefolder);
            }

            using (var stream = new FileStream(folderFile, FileMode.Create))
            {
                request.formFile.CopyTo(stream);
            }

            if (entity.Id == null)
            {
                await baseRepository.Add(entity);
            } else
            {
                if (request.dto.NombreDocumento == "antecedentes")
                {
                    await baseRepository.UpdatePartial(entity, x => x.FolderAntecedentes);
                } else
                {
                    await baseRepository.UpdatePartial(entity, x => x.FolderCertificado);
                }
            }


            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = entity
            };

        }
    }
}
