using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Employee.Models;
using HumanManagement.Domain.EvaluationPostulant.Dto;
using HumanManagement.Domain.EvaluationPostulantInternal.Dto;
using HumanManagement.Domain.Job.Models;
using HumanManagement.Domain.Models;
using HumanManagement.Domain.Person.Contracts;
using HumanManagement.Domain.Person.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EvaluationPostulantsInternalModel = HumanManagement.Domain.EvaluationPostulantInternal.Models.EvaluationPostulantsInternal;
using MasterTableModel = HumanManagement.Domain.MasterTable.Models.MasterTable;
using CargoModel = HumanManagement.Domain.Cargo.Models.Cargo;
using AreaModel = HumanManagement.Domain.Areas.Models.Areas;
using EmpresaModel = HumanManagement.Domain.Empresa.Models.Empresa;
using HumanManagement.Domain.EvaluationPostulantInternal.Models;

namespace HumanManagement.Application.EvaluationPostulantsInternal.Queries
{
    public class GetInformationPostulantQuery: IRequest<Result>
    {
        public int IdEvaluationPostulant { get; set; }

        public class GetInformationPostulantQueryHandle : IRequestHandler<GetInformationPostulantQuery, Result>
        {
            private readonly IPersonRepository personRepository;

            private readonly IBaseRepository<EvaluationVacantInternal> evaluationbaseRepository;
            private readonly IBaseRepository<EvaluationPostulantsInternalModel> baseRepository;
            private readonly IBaseRepository<JobOffersInternalPostulant> jobPostulantBaseRepository;
            private readonly IBaseRepository<JobOffersInternalCurriculum> jobPostulantCurriculumBaseRepository;
            private readonly IBaseRepository<User> userBaseRepository;
            private readonly IBaseRepository<MasterTableModel> masterTableBaseRepository;
            private readonly IBaseRepository<Phone> phoneBaseRepository;
            private readonly IBaseRepository<Address> addressBaseRepository;
            private readonly IBaseRepository<EmployeeModel> employeeBaseRepository;
            private readonly IBaseRepository<CargoModel> cargoBaseRepository;
            private readonly IBaseRepository<AreaModel> areaBaseRepository;
            private readonly IBaseRepository<EmpresaModel> empresaBaseRepository;
            private readonly IMapper mapper;
            public GetInformationPostulantQueryHandle(IPersonRepository personRepository, 
                                                      IMapper mapper, 
                                                      IBaseRepository<EvaluationPostulantsInternalModel> baseRepository,
                                                      IBaseRepository<JobOffersInternalPostulant> jobPostulantBaseRepository,
                                                      IBaseRepository<JobOffersInternalCurriculum> jobPostulantCurriculumBaseRepository,
                                                      IBaseRepository<MasterTableModel> masterTableBaseRepository,
                                                      IBaseRepository<User> userBaseRepository,
                                                      IBaseRepository<Phone> phoneBaseRepository,
                                                      IBaseRepository<Address> addressBaseRepository,
                                                      IBaseRepository<EmployeeModel> employeeBaseRepository,
                                                      IBaseRepository<CargoModel> cargoBaseRepository,
                                                      IBaseRepository<AreaModel> areaBaseRepository,
                                                      IBaseRepository<EmpresaModel> empresaBaseRepository,
                                                      IBaseRepository<EvaluationVacantInternal> evaluationbaseRepository)
            {
                this.personRepository = personRepository;
                this.baseRepository = baseRepository;
                this.mapper = mapper;
                this.jobPostulantBaseRepository = jobPostulantBaseRepository;
                this.jobPostulantCurriculumBaseRepository = jobPostulantCurriculumBaseRepository;
                this.masterTableBaseRepository = masterTableBaseRepository;
                this.userBaseRepository = userBaseRepository;
                this.phoneBaseRepository = phoneBaseRepository;
                this.addressBaseRepository = addressBaseRepository;
                this.employeeBaseRepository = employeeBaseRepository;
                this.cargoBaseRepository = cargoBaseRepository;
                this.areaBaseRepository = areaBaseRepository;
                this.empresaBaseRepository = empresaBaseRepository;
                this.evaluationbaseRepository = evaluationbaseRepository;
            }
            public async Task<Result> Handle(GetInformationPostulantQuery request, CancellationToken cancellationToken)
            {
                var dto = new InfoPostulantDto();
                var evaluation = await baseRepository.FindPredicate(x => x.Id == request.IdEvaluationPostulant);
                dto.Approved = evaluation.Approved;
                dto.IdEvaluation = evaluation.IdEvaluation;
                var entityMastertable = await masterTableBaseRepository.FindPredicate(x => x.Id == evaluation.State);
                dto.StateEvaluation = entityMastertable.DescriptionValue;

                /* obtener proceso id*/
                var evaluationIntern = await evaluationbaseRepository.FindPredicate(x => x.Id == dto.IdEvaluation);
                dto.Process = evaluationIntern.Process;
                dto.PositionRequired = evaluationIntern.PositionRequired;

                var phone = await phoneBaseRepository.FindPredicate(x => x.IdPerson == evaluation.IdPostulant);
                var addres = await addressBaseRepository.FindPredicate(x => x.IdPerson == evaluation.IdPostulant);

                var user = await userBaseRepository.FindPredicate(x => x.IdPerson == evaluation.IdPostulant);
                var salary = await jobPostulantBaseRepository.FindPredicate(x => x.IdPostulant == user.Id);
                var curriculum = await jobPostulantCurriculumBaseRepository.FindPredicate(x => x.IdPostulant == user.Id);

                dto.SueldoPretendido = salary.SalaryPreference;

                dto.InformationPersonal = await personRepository.GetPerson(evaluation.IdPostulant);

                if (phone != null)
                {
                    dto.InformationPersonal.sphonenumber = phone.phone;
                }

                if (addres != null)
                {
                    dto.InformationPersonal.saddress = addres.AddressDescription;
                }


                if (dto.InformationPersonal.simg != null)
                {
                    var file = dto.InformationPersonal.simg;
                    if (file != null) {
                        if (file.Substring(0, 4).Equals("http"))
                        {
                            dto.InformationPersonal.simg = dto.InformationPersonal.simg;
                        }
                        else {
                            if (File.Exists(file))
                            {
                                var buffer = File.ReadAllBytes(file);
                                dto.InformationPersonal.simg = $"data:image/jpeg;base64,{Convert.ToBase64String(buffer)}";
                            }
                        }
                    }
                }
                
                if (curriculum != null)
                {
                    if (curriculum.SFolderCv != null)
                    {
                        var file = curriculum.SFolderCv;
                        if (File.Exists(file))
                        {
                            var buffer = File.ReadAllBytes(file);
                            dto.InformationPersonal.CvName = Path.GetFileName(file);
                            dto.InformationPersonal.CvFile = buffer;
                            dto.InformationPersonal.ContentType = Path.GetExtension(dto.InformationPersonal.CvName);
                        }
                    }
                }

                if (evaluation.FolderFileMultitest != null)
                {
                    var file = evaluation.FolderFileMultitest;
                    if (File.Exists(file))
                    {
                        dto.FileMultitest = new FileDto();
                        var buffer = File.ReadAllBytes(file);
                        dto.FileMultitest.File = buffer;
                        dto.FileMultitest.ContentType = Path.GetExtension(evaluation.FolderFileMultitest);
                        dto.FileMultitest.NameFile = Path.GetFileName(evaluation.FolderFileMultitest);
                    }
                }

                var employee = await employeeBaseRepository.FindPredicate(x => x.IdPerson == evaluation.IdPostulant);
                var cargo = await cargoBaseRepository.FindPredicate(x => x.Id == employee.IdPosition);
                var area = await areaBaseRepository.FindPredicate(x => x.Id == cargo.IdArea);
                var empresa = await empresaBaseRepository.FindPredicate(x => x.Id == employee.IdCompany);
                dto.ActualPosition = cargo.NameCargo;
                dto.ActualArea = area.NameArea;
                dto.Company = empresa.Descripcion;
                dto.DateRegister = (DateTime)employee.DateRegister;

                return new Result
                {
                    Data = dto,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
        }
    }
}
