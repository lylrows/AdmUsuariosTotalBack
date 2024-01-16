using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.InformationPostulant.Dto;
using HumanManagement.Domain.InformationPostulant.Models;
using HumanManagement.Domain.Postulant.Person.Models;
using HumanManagement.Domain.Utils.Constracts;
using HumanManagement.Domain.Utils.Dto;
using MediatR;
using Microsoft.Extensions.Options;
using System;

using System.IO;

using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.InformationPostulant.Command
{
    public class SaveInformationPostulantCommand: IRequest<Result>
    {
        public InformationPostulantAllDto dtos { get; set; }
    }

    public class SaveInformationPostulantCommandHandle : IRequestHandler<SaveInformationPostulantCommand, Result>
    {
        private readonly IBaseRepository<InformationWorkModel> baseRepositoryWork;
        private readonly IBaseRepository<InformationLangModel> baseRepositoryLang;
        private readonly IBaseRepository<InformationFamilyModel> baseRepositoryFamily;
        private readonly IBaseRepository<InformationEducationModel> baseRepositoryEdu;

        private readonly IBaseRepository<InformationAditionalModel> baseRepositoryAdicional;
        
        private readonly IBaseRepository<PersonModelPostulant> baseRepositoryPerson;
        private readonly IBaseRepository<InformationExtraModel> baseRepositoryExtra;
        private readonly IMapper mapper;
        private readonly AppSettings _appSettings;
        private readonly IUtilRepository _utilRepository;
        public SaveInformationPostulantCommandHandle(IBaseRepository<InformationWorkModel> baseRepositoryWork,
                                                     IBaseRepository<InformationLangModel> baseRepositoryLang,
                                                     IBaseRepository<InformationFamilyModel> baseRepositoryFamily,
                                                     IBaseRepository<InformationEducationModel> baseRepositoryEdu,

                                                     IBaseRepository<InformationAditionalModel> baseRepositoryAdicional,
                                                     
                                                     
                                                     IBaseRepository<PersonModelPostulant> baseRepositoryPerson,
                                                     IBaseRepository<InformationExtraModel> baseRepositoryExtra,
                                                     IMapper mapper,
                                                     IOptions<AppSettings> appSettings,
                                                     IUtilRepository utilRepository)
        {
            this.baseRepositoryWork = baseRepositoryWork;
            this.baseRepositoryLang = baseRepositoryLang;
            this.baseRepositoryFamily = baseRepositoryFamily;
            this.baseRepositoryEdu = baseRepositoryEdu;
            this.baseRepositoryAdicional = baseRepositoryAdicional;
            
            this.baseRepositoryPerson = baseRepositoryPerson;
            this.baseRepositoryExtra = baseRepositoryExtra;
            this.mapper = mapper;
            _appSettings = appSettings.Value;
            this._utilRepository = utilRepository;
        }
        public async Task<Result> Handle(SaveInformationPostulantCommand request, CancellationToken cancellationToken)
        {          

            foreach (var item in request.dtos.InformationWorkDtos)
            {
                var entity = mapper.Map<InformationWorkModel>(item);
                entity.IdEvaluation = request.dtos.IdEvaluation;
                await baseRepositoryWork.Update(entity);
            }

            //family
            foreach(var item in request.dtos.InformationFamilyDtos)
            {
                var entity = mapper.Map<InformationFamilyModel>(item);
                entity.IdEvaluation = request.dtos.IdEvaluation;
                await baseRepositoryFamily.UpdatePartial(entity, x => x.IdEvaluation);
            }
            //studies
            foreach (var item in request.dtos.InformationEducationDtos)
            {
                var entity = mapper.Map<InformationEducationModel>(item);
                entity.IdEvaluation = request.dtos.IdEvaluation;
                await baseRepositoryEdu.UpdatePartial(entity, x => x.IdEvaluation);
            }

            foreach (var item in request.dtos.InformationLangDtos)
            {
                var entity = mapper.Map<InformationLangModel>(item);
                
                if (entity.Id == 0)
                {
                    entity.Active = true;
                    await baseRepositoryLang.Add(entity);
                }
                else
                {
                    await baseRepositoryLang.UpdatePartial(entity, x => x.IdLanguage,
                                                                     x => x.IdOralLevel,
                                                                     x => x.IdWrittenLevel);
                }

            }

            var model = mapper.Map<InformationAditionalModel>(request.dtos.InformationAditionalDtos);
            model.IdEvaluation = request.dtos.IdEvaluation;
            if(model.Id!=0)
                await baseRepositoryAdicional.Update(model);
            else {
                model.Active = true;
                await baseRepositoryAdicional.Add(model);
            }

            var modelperson = mapper.Map<PersonModelPostulant>(request.dtos.InformationPerson);
      
            await baseRepositoryPerson.UpdatePartial(modelperson, x => x.FirstName,
                                                                       x =>x.SecondName,
                                                                       x => x.LastName,
                                                                       x => x.MotherLastName,
                                                                       x => x.Address,
                                                                       x => x.CellPhone,
                                                                       x => x.BirthDate,
                                                                       x => x.IdCivilStatus,
                                                                       x => x.DocumentNumber,
                                                                       x => x.IdNationality,
                                                                       x => x.AnotherPhone);

            var modelextra = mapper.Map<InformationExtraModel>(request.dtos.InformationExtraDto);
            modelextra.IdEvaluation = request.dtos.IdEvaluation;
            var date = new DateTime();
            if (modelextra.IncomeCountryDate == date) modelextra.IncomeCountryDate = null;
            if (modelextra.Id == 0) await baseRepositoryExtra.Add(modelextra);
            else {
                
                await baseRepositoryExtra.Update(modelextra);
            }

            
            foreach (var item_file in request.dtos.listaDocumentos)
            {
                var _nombreFileAleatorio = string.Empty;
                var pathComplete = string.Empty;
                if (!String.IsNullOrEmpty(item_file.archivo_base64))
                {
                    string _base64 = Functions.CleanBase64File(item_file.archivo_base64);
                    var _file = Convert.FromBase64String(_base64);
                    _nombreFileAleatorio = string.Format("{0}.{1}", Guid.NewGuid(), item_file.extension); ;
                    pathComplete = string.Format("{0}{1}", _appSettings.PathDocumentosPostulant, _nombreFileAleatorio);
                    File.WriteAllBytes(pathComplete, _file);
                }
                else pathComplete = item_file.ruta_archivo;

                var _document = new InformationFilesDto()
                {
                    nidinformationfile = item_file.nidinformationfile,
                    nidinformationextra = modelextra.Id,
                    nidreferences = request.dtos.InformationAditionalDtos.IdPostulant,
                    snamefile = item_file.filename,
                    skeyfile = _nombreFileAleatorio,
                    ntypefile = 3,
                    bactive = true,
                    path_complete = pathComplete,
                    stypeFile = item_file.tipo_archivo
                };
                var _result = await _utilRepository.SaveInformationFiles(_document);

            }

            
            foreach (var _document in request.dtos.listaDocumentosAdicionales)
            {
                if (!String.IsNullOrEmpty(_document.FileBase64))
                {
                    string _base64 = Functions.CleanBase64File(_document.FileBase64);
                    var _file = Convert.FromBase64String(_base64);
                    var _nombreFileAleatorio = string.Format("{0}.{1}", Guid.NewGuid(), Path.GetExtension(_document.NombreFile)); ;
                    var pathComplete = string.Format("{0}{1}", _appSettings.PathDocumentosPostulant, _nombreFileAleatorio);
                    File.WriteAllBytes(pathComplete, _file);
                    _document.PathFile = pathComplete;
                }
                _document.IdPostulant = request.dtos.InformationAditionalDtos.IdPostulant;
                var _result = await _utilRepository.SaveDocumentAditional(_document);

            }
            return new Result
            {
                Data = true,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
