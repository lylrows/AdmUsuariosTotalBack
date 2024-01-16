using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Job.Contracts;
using HumanManagement.Domain.Person.Contracts;
using HumanManagement.Domain.Person.QueryFilter;
using HumanManagement.Domain.Postulant.Person.Dto;
using HumanManagement.Domain.Postulant.Person.Models;
using HumanManagement.Domain.Postulant.WorkExperience.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Postulant.Queries
{
    public class GetListPostulantsInternalPaginationQuery: IRequest<Result>
    {
        public PostulantQueryFilter queryFilter { get; set; }
        public class GetListPostulantsInternalPaginationQueryHandle : IRequestHandler<GetListPostulantsInternalPaginationQuery, Result>
        {
            private readonly IPersonRepository personRepository;
            private readonly IJobKeyWordRepository jobKeyWordRepository;
            private readonly IMapper mapper;

            public GetListPostulantsInternalPaginationQueryHandle(IPersonRepository personRepository,
                                                                  IMapper mapper,
                                                                  IJobKeyWordRepository jobKeyWordRepository)
            {
                this.personRepository = personRepository;
                this.mapper = mapper;
                this.jobKeyWordRepository = jobKeyWordRepository;
            }
            public async Task<Result> Handle(GetListPostulantsInternalPaginationQuery request, CancellationToken cancellationToken)
            {
                var listPostulant = await personRepository.GetListPostulant(request.queryFilter);

                if(listPostulant.list.Count > 0)
                {
                    var listJobKeyWords = await jobKeyWordRepository.GetKeyWordList(listPostulant.list.FirstOrDefault().IdJob);
                    var listPostulantSkills = await personRepository.GetListSkillInternal(listPostulant.list.FirstOrDefault().IdJob);
                    var listExperiences = await personRepository.GetWorkExperiencePostulantsInternal(listPostulant.list.FirstOrDefault().IdJob);
                    try
                    {
                        
                        #region "Mapear"
                        var _listPostulants = new List<HumanManagement.Domain.Postulant.Person.Dto.PostulantDto>();
                        foreach(var item in listPostulant.list)
                        {
                            var _obj = new HumanManagement.Domain.Postulant.Person.Dto.PostulantDto();
                            _obj.Id                    =    item.Id                       ;
                            _obj.IdPostulant           =    item.IdPostulant              ;
                            _obj.IdPerson              =    item.IdPerson                 ;
                            _obj.Email                 =    item.Email                    ;
                            _obj.FullName              =    item.FullName                 ;
                            _obj.DateRegister          =    item.DateRegister             ;
                            _obj.CellPhone             =    item.CellPhone                ;
                            _obj.CvName                =    item.CvName                   ;
                            _obj.CvGrupoFe             =    item.CvGrupoFe                ;
                            _obj.CvAttached            =    item.CvAttached               ;
                            _obj.State                 =    item.State                    ;
                            _obj.Skill                 =    item.Skill                    ;
                            _obj.TotalSkills           =    item.TotalSkills              ;
                            _obj.Position              =    item.Position                 ;
                            _obj.IdJob                 =    item.IdJob                    ;
                            _obj.Gender                =    item.Gender                   ;
                            _obj.DocumentNumber        =    item.DocumentNumber           ;
                            _obj.CivilStatus           =    item.CivilStatus              ;
                            _obj.LevelStudy            =    item.LevelStudy               ;
                            _obj.WorkExperience        =    item.WorkExperience           ;
                            _obj.IdPositionCurrently   =    item.IdPositionCurrently      ;
                            _obj.MinimunSalary         =    item.MinimunSalary            ;
                            _obj.MaximumSalary         =    item.MaximumSalary            ;
                            _obj.SalaryPreference      =    item.SalaryPreference         ;
                            _obj.Address               =    item.Address                  ;
                            _obj.Flag_coincide_grado   =    item.Flag_coincide_grado      ;
                            _obj.Scareer_position      =    item.Scareer_position         ;
                            _obj.Scareer_postulant     =    item.Scareer_postulant        ;
                            _obj.PorcentajeAsertividad =    item.PorcentajeAsertividad    ;
                            _obj.SalaryPostulant       =    item.SalaryPostulant          ;
                            _obj.AgePostulant          =    item.AgePostulant             ;
                            _obj.NidSex                =    item.NidSex                   ;
                            _obj.CurrentWorking        =    item.CurrentWorking           ;
                            _obj.Universities          =    item.Universities             ;
                            _obj.NivelesEstudio        =    item.NivelesEstudio           ;
                            _listPostulants.Add(_obj);
                        }

                        var _filter = new Domain.Postulant.Person.QueryFilter.PostulantQueryFilter();
                        _filter.Universidad      = request.queryFilter.Universidad    ;
                        _filter.EdadMinima       = request.queryFilter.EdadMinima     ;
                        _filter.EdadMaxima       = request.queryFilter.EdadMaxima     ;
                        _filter.Estudios         = request.queryFilter.Estudios       ;
                        _filter.Experiencia      = request.queryFilter.Experiencia    ;
                        _filter.SalarioMinimo    = request.queryFilter.SalarioMinimo  ;
                        _filter.SalarioMaximo    = request.queryFilter.SalarioMaximo  ;
                        _filter.Genero           = request.queryFilter.Genero         ;
                        _filter.IsWorking        = request.queryFilter.IsWorking      ;
                        _filter.KeyWords         = request.queryFilter.KeyWords       ;
                        _filter.LevelStudy       = request.queryFilter.LevelStudy     ;
                        #endregion


                        GenerateListPostulant generateListPostulant = new GenerateListPostulant(_listPostulants,
                                                                                                listJobKeyWords,
                                                                                                listPostulantSkills,
                                                                                                listExperiences,
                                                                                                _filter);
                        generateListPostulant.Generate();
                   
                        foreach(var _postulant in listPostulant.list)
                        {
                            var _object = (from lista in generateListPostulant.PostulantOrderList
                                           where lista.Id == _postulant.Id
                                           select lista).ToList().FirstOrDefault();
                            _postulant.PorcentajeAsertividad = _object.PorcentajeAsertividad;
                        }
                    }
                    catch (Exception ex)
                    {
                        var _error = ex;
                    }                    

                }

                return new Result
                {
                    Data = listPostulant,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
        }
    }
}
