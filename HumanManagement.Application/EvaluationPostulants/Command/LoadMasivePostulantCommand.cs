using AutoMapper;
using ExcelDataReader;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Job.Contracts;
using HumanManagement.Domain.Job.Models;
using HumanManagement.Domain.Postulant.Education.Models;
using HumanManagement.Domain.Postulant.Languages.Models;
using HumanManagement.Domain.Postulant.Models;
using HumanManagement.Domain.Postulant.Person.Dto;
using HumanManagement.Domain.Postulant.Person.Models;
using HumanManagement.Domain.Postulant.SalaryPreference.Models;
using HumanManagement.Domain.Postulant.WorkExperience.Dto;
using HumanManagement.Domain.Postulant.WorkExperience.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MastertableModel = HumanManagement.Domain.MasterTable.Models.MasterTable;

namespace HumanManagement.Application.EvaluationPostulants.Command
{
    public class LoadMasivePostulantCommand: IRequest<Result>
    {
        public IFormFile formFile;
        public bool IsBumeran { get; set; }
        public int Job { get; set; }
    }

    public class LoadMasivePostulantCommandHandle : IRequestHandler<LoadMasivePostulantCommand, Result>  
    {
        private readonly IBaseRepository<UserPostulant> userBaseRepository;
        private readonly IBaseRepository<PersonModelPostulant> personBaseRepository;
        private readonly IBaseRepository<JobPostulant> jobPostulantRepository;
        private readonly IJobPostulantRepository jobRepository;
        private readonly IBaseRepository<MastertableModel> masterTableRepository;
        private readonly IBaseRepository<WorkExperienceModel> workExpBaseRepository;
        private readonly IBaseRepository<LanguagePostulant> langPostulantBaseRepository;
        private readonly IBaseRepository<EducationPostulant> educationPostulantBaseRepository;
        private readonly IBaseRepository<SalaryPreferenceModel> SalaryPreferenceBaseRepository;
        private readonly IMapper mapper;
        private readonly AppSettings _appSettings;
        public LoadMasivePostulantCommandHandle(IBaseRepository<UserPostulant> userBaseRepository, 
                                                IBaseRepository<PersonModelPostulant> personBaseRepository,
                                                IOptions<AppSettings> appSettings,
                                                IBaseRepository<JobPostulant> jobPostulantRepository,
                                                IJobPostulantRepository jobRepository,
                                                IBaseRepository<MastertableModel> masterTableRepository,
                                                IBaseRepository<WorkExperienceModel> workExpBaseRepository,
                                                IBaseRepository<LanguagePostulant> langPostulantBaseRepository,
                                                IBaseRepository<EducationPostulant> educationPostulantBaseRepository,
                                                IBaseRepository<SalaryPreferenceModel> SalaryPreferenceBaseRepository,
                                                 IMapper mapper)
        {
            this.userBaseRepository = userBaseRepository;
            this.personBaseRepository = personBaseRepository;
            this.jobPostulantRepository = jobPostulantRepository;
            this.jobRepository = jobRepository;
            this.masterTableRepository = masterTableRepository;
            this.workExpBaseRepository = workExpBaseRepository;
            this.langPostulantBaseRepository = langPostulantBaseRepository;
            this.educationPostulantBaseRepository = educationPostulantBaseRepository;
            this.SalaryPreferenceBaseRepository = SalaryPreferenceBaseRepository;
            this._appSettings = appSettings.Value;
            this.mapper = mapper;
        }
        public async Task<Result> Handle(LoadMasivePostulantCommand request, CancellationToken cancellationToken)
        {

            List<PersonDto> persons = new List<PersonDto>();
            if (request.formFile != null)
            {
                var path = _appSettings.PathSaveFile + "LoadMasivePostulant";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var filename = request.formFile.FileName;
                var pathFile = Path.Combine(path, filename);

                if (File.Exists(pathFile))
                {
                    File.Delete(pathFile);
                }

                using (var stream = new FileStream(pathFile, FileMode.Create))
                {
                  await request.formFile.CopyToAsync(stream);
                }


                if (request.IsBumeran == true)
                {
                    using (var stream = File.Open(pathFile, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            do
                            {
                                var i = 0;
                                while (reader.Read())
                                {
                                    i++;
                                    var listworks = new List<LoadedWorkExperienceDto>();
                                    var listStudy = new List<LoadedStudyDto>();
                                    var listLang = new List<LangDto>();
                                    if (i == 1) continue;

                                    if (i == 25)
                                    {
                                        var dos = 2;
                                    }

                                    if (!string.IsNullOrEmpty(reader.GetString(15)))
                                    {
                                        DateTime? dateend = null;
                                        bool? present = null;
                                        if (!string.IsNullOrEmpty(reader.GetString(17)))
                                        {
                                            dateend = DateTime.Parse(reader.GetString(17));
                                            present = false;
                                        }
                                        else
                                        {
                                            present = true;
                                        }


                                        var works1 = new LoadedWorkExperienceDto
                                        {
                                            Position = reader.GetString(15),
                                            DateStart = DateTime.Parse(reader.GetString(16)),
                                            DateFinish = dateend,
                                            Company = reader.GetString(18),
                                            Country = reader.GetString(19),
                                            Area = reader.GetString(20),
                                            SubArea = reader.GetString(21),
                                            Industria = reader.GetString(22),
                                            Descripcion = reader.GetString(23),
                                            Present = present
                                        };
                                        listworks.Add(works1);
                                    }

                                    if (!string.IsNullOrEmpty(reader.GetString(25)))
                                    {
                                        DateTime? dateend = null;
                                        bool? present = null;
                                        if (!string.IsNullOrEmpty(reader.GetString(27)))
                                        {
                                            dateend = DateTime.Parse(reader.GetString(27));
                                            present = false;
                                        }
                                        else
                                        {
                                            present = true;
                                        }

                                        var works2 = new LoadedWorkExperienceDto
                                        {
                                            Position = reader.GetString(25),
                                            DateStart = DateTime.Parse(reader.GetString(26)),
                                            DateFinish = dateend,
                                            Company = reader.GetString(28),
                                            Country = reader.GetString(29),
                                            Area = reader.GetString(30),
                                            SubArea = reader.GetString(31),
                                            Industria = reader.GetString(32),
                                            Descripcion = reader.GetString(33),
                                            Present = present
                                        };
                                        listworks.Add(works2);
                                    }

                                    if (!string.IsNullOrEmpty(reader.GetString(35)))
                                    {
                                        DateTime? dateend = null;
                                        bool? present = null;
                                        if (!string.IsNullOrEmpty(reader.GetString(37)))
                                        {
                                            dateend = DateTime.Parse(reader.GetString(37));
                                            present = false;
                                        } else
                                        {
                                            present = true;
                                        }

                                        var works3 = new LoadedWorkExperienceDto
                                        {
                                            Position = reader.GetString(35),
                                            DateStart = DateTime.Parse(reader.GetString(36)),
                                            DateFinish = dateend,
                                            Company = reader.GetString(38),
                                            Country = reader.GetString(39),
                                            Area = reader.GetString(40),
                                            SubArea = reader.GetString(41),
                                            Industria = reader.GetString(42),
                                            Descripcion = reader.GetString(43),
                                            Present = present
                                        };
                                        listworks.Add(works3);
                                    }

                                    if (!string.IsNullOrEmpty(reader.GetString(55)))
                                    {
                                        DateTime? dateend = null;
                                        bool? present = null;
                                        if (!string.IsNullOrEmpty(reader.GetString(59)))
                                        {
                                            dateend = DateTime.Parse(reader.GetString(59));
                                            present = false;
                                        }
                                        else
                                        {
                                            present = true;
                                        }

                                        var study1 = new LoadedStudyDto
                                        {
                                            Institution = reader.GetString(55),
                                            Titulo = reader.GetString(56),
                                            State = reader.GetString(57),
                                            DateStart = DateTime.Parse(reader.GetString(58)),
                                            DateFinish = dateend,
                                            Country = reader.GetString(60),
                                            Level = reader.GetString(61),
                                            Carreer = reader.GetString(62),
                                            Present = present
                                        };

                                        listStudy.Add(study1);
                                    }

                                    if (!string.IsNullOrEmpty(reader.GetString(63)))
                                    {
                                        DateTime? dateend = null;
                                        bool? present = null;
                                        if (!string.IsNullOrEmpty(reader.GetString(67)))
                                        {
                                            dateend = DateTime.Parse(reader.GetString(67));
                                            present = false;
                                        }
                                        else
                                        {
                                            present = true;
                                        }


                                        var study2 = new LoadedStudyDto
                                        {
                                            Institution = reader.GetString(63),
                                            Titulo = reader.GetString(64),
                                            State = reader.GetString(65),
                                            DateStart = DateTime.Parse(reader.GetString(66)),
                                            DateFinish = dateend,
                                            Country = reader.GetString(68),
                                            Level = reader.GetString(69),
                                            Carreer = reader.GetString(70),
                                            Present = present
                                        };

                                        listStudy.Add(study2);
                                    }

                                    if (!string.IsNullOrEmpty(reader.GetString(87)))
                                    {

                                        var langfield = reader.GetString(87);
                                        var langarr = langfield.Split("/");

                                        for (int j = 0; j < langarr.Length; j++)
                                        {
                                            var lang = langarr[j];
                                            var info = lang.Split("-");
                                            var infolang = new LangDto
                                            {
                                                Lang = info[0],
                                                Level = info[1]
                                            };

                                            listLang.Add(infolang);
                                        }
                                    }

                                    DateTime? applicant = null;
                                    if (string.IsNullOrEmpty(reader.GetString(89)))
                                    {
                                        applicant = null;
                                    } else
                                    {
                                        applicant = DateTime.Parse(reader.GetString(89));
                                    }
                                    var dto = new PersonDto
                                    {
                                        FirstName = reader.GetString(0),
                                        LastName = reader.GetString(1),
                                        BirthDate = reader.GetString(3),
                                        Nationality = reader.GetString(4),
                                        IdSex = reader.GetString(5) == "masculino" ? 12 : 13,
                                        IdCivilStatus = reader.GetString(6) == "Soltero/a" ? 17 : 18,
                                        IdNationality = 13,
                                        DateApplicant = applicant,
                                        Address = reader.GetString(9),
                                        CellPhone = reader.GetString(10),
                                        AnotherPhone = reader.GetString(11),
                                        Email = reader.GetString(12),
                                        IdTypeDocument = reader.GetString(13) == "Documento" ? 1 : 0,
                                        DocumentNumber = reader.GetString(14),
                                        IdActive = 20,
                                        WorkExperience = listworks,
                                        SalaryPreference = reader.GetString(88),
                                        StudyDto = listStudy,
                                        LangDto = listLang

                                    };
                                    persons.Add(dto);   
                                }
                            } while (reader.NextResult());
                        }
                    }
                } else
                {
                    using (var stream = File.Open(pathFile, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            do
                            {
                                var i = 0;                          
                                while (reader.Read())
                                {
                                    i++;
                                    var listworks = new List<LoadedWorkExperienceDto>();
                                    var listStudy = new List<LoadedStudyDto>();
                                    var listLang = new List<LangDto>();
                                    if (i == 1 || i == 2) continue;

                                    var workfield = reader.GetString(26);
                                    var workarr = workfield.Split("---------");
                                    for (int l = 0; l < workarr.Length; l++)
                                    {
                                        var job = workarr[l].Trim();
                                        var info1 = job.Split("\n");
                                        string descripcion = "";
                                        if (info1.Length == 2)
                                        {
                                            descripcion = "";
                                        } else
                                        {
                                            descripcion = info1[2];
                                        }
                                            var info2 = info1[1].Split("\n");
                                        var infojob = info1[0].Split(",");
                                        var arrfechas = info1[1].Split("-");
                                        var act = arrfechas[1] == "Actualmente" ? true : false;
                                        var datefin = new DateTime();
                                        if (act)
                                        {
                                            datefin = DateTime.Now;
                                        } else
                                        {
                                            datefin = DateTime.Parse(arrfechas[1]);
                                        }
                                        var work = new LoadedWorkExperienceDto
                                        {
                                            Company = infojob[1],
                                            Position = infojob[0].Trim(),
                                            DateStart = DateTime.Parse(arrfechas[0]),
                                            DateFinish = datefin,
                                            Descripcion = descripcion,
                                            Present = act,
                                            Country = "Perú"
                                            
                                        };
                                        listworks.Add(work);
                                    }

                                    var studyfield = reader.GetString(27);
                                    var studyarr = studyfield.Split("---------");
                                    for (int j = 0; j < studyarr.Length; j++)
                                    {
                                        var studyinfo = studyarr[j].Trim().Split("\n");
                                        var info1 = studyinfo[0].Split(",");
                                        var line1 = info1[0].Split("-");
                                        string level = "";
                                        string carreer = "";
                                        string institucion = "";
                                        if (line1.Length == 1)
                                        {
                                            level = line1[0];
                                            carreer = info1[1];
                                            institucion = "";
                                        } else
                                        {
                                            level = line1[0].Trim();
                                            carreer = line1[1].Trim();
                                            institucion = info1[1].Trim();
                                        }
                                        var arrfechas = studyinfo[1].Split("-");
                                        var arrState = studyinfo[2].Split(":");
                                        var state = arrState[1].Trim() == "Culminado" ? "Terminado" : arrState[1];
                                        var act = arrfechas[1].Trim() == "Actualmente" ? true : false;
                                        var datefin = new DateTime();
                                        if (act)
                                        {
                                            datefin = DateTime.Now;
                                        }
                                        else
                                        {
                                            datefin = DateTime.Parse(arrfechas[1]);
                                        }
                                        var study = new LoadedStudyDto
                                        {
                                            Level = level,
                                            Carreer = carreer,
                                            Institution = institucion,
                                            DateStart = DateTime.Parse(arrfechas[0]),
                                            DateFinish = datefin,
                                            Present = act,
                                            State = state.Trim(),
                                            Country = "Perú"
                                        };

                                        listStudy.Add(study);
                                    }

                                    var langfield = reader.GetString(28);
                                    var langarr = langfield.Split(",");
                                    for (int j = 0; j < langarr.Length ; j++)
                                    {
                                        var dtoLang = new LangDto
                                        {
                                            Lang = langarr[j] == "Español (Nativo)" ? "Español" : langarr[j],
                                            Level = "Básico"
                                        };

                                        listLang.Add(dtoLang);
                                    }

                                    var dto = new PersonDto
                                    {
                                        FirstName = reader.GetString(0),
                                        LastName = reader.GetString(1),
                                        IdTypeDocument = reader.GetString(2) == "D.N.I." ? 1 : 0,
                                        DocumentNumber = reader.GetString(3),
                                        DateApplicant = DateTime.Parse(reader.GetString(5)),
                                        BirthDate = reader.GetString(7),
                                        Address = reader.GetString(9),
                                        Nationality = reader.GetString(14),
                                        CellPhone = reader.GetString(16),
                                        Email = reader.GetString(17),
                                        IdSex = reader.GetString(18) == "Hombre" ? 12 : 13,
                                        IdCivilStatus = reader.GetString(19) == "Soltero(a)" ? 17 : 18,
                                        IdNationality = 13,
                                        IdActive = 20,
                                        SalaryPreference = reader.GetString(25),
                                        LangDto = listLang,
                                        WorkExperience = listworks,
                                        StudyDto = listStudy
                                    };
                                    persons.Add(dto);
                                }
                            } while (reader.NextResult());
                        }
                    }
                }
            }



            var listErrores = new List<string>();
            foreach (var item in persons)
            {
                var entity = mapper.Map<PersonModelPostulant>(item);
                var exist = await personBaseRepository.Exist(x => x.Email == item.Email);
                if (exist)
                {
                    listErrores.Add($"Este correo {item.Email} ya se encuentra registrado");
                } else
                {
                    await personBaseRepository.Add(entity);
                    var user = new UserPostulant
                    {
                        IdPerson = entity.Id,
                        Password = "123",
                        Blocked = false,
                        ActiveAccount = false,
                        UserName = entity.FirstName
                    };

                    await userBaseRepository.Add(user);

                    foreach (var ele in item.WorkExperience)
                    {
                        var monthini = ele.DateStart.Value.ToString("MMMM");
                        var yearini = ele.DateStart.Value.Year;
                        string monthfin = "";
                        string? yearfin = "";
                        if (ele.DateFinish != null)
                        {
                             monthfin = ele.DateFinish.Value.ToString("MMMM");
                             yearfin = ele.DateFinish.Value.Year.ToString();
                        } else
                        {
                            monthfin = "";
                            yearfin = "";
                        }
                        var country = await masterTableRepository.FindPredicate(x => x.DescriptionValue.Contains(ele.Country.Trim()));
                        var dto = new WorkExperienceModel
                        {
                            MonthStart = monthini,
                            MonthEnd = monthfin,
                            YearEnd = yearfin,
                            YearStart = yearini.ToString(),
                            DescriptionResponsabilities = ele.Descripcion,
                            IdPerson = entity.Id,
                            Company = ele.Company,
                            Stand = ele.Position,
                            IdCountry = country?.Id,
                            Active = true,
                            Present = ele.Present
                        };
                        await workExpBaseRepository.Add(dto);
                    }

                    foreach (var eleStudy in item.StudyDto)
                    {
                        var monthini = eleStudy.DateStart.Value.ToString("MMMM");
                        var yearini = eleStudy.DateStart.Value.Year;

                        string monthfin = "";
                        string? yearfin = "";
                        if (eleStudy.DateFinish != null)
                        {
                            monthfin = eleStudy.DateFinish.Value.ToString("MMMM");
                            yearfin = eleStudy.DateFinish.Value.Year.ToString();
                        }
                        else
                        {
                            monthfin = "";
                            yearfin = "";
                        }

                        var country = await masterTableRepository.FindPredicate(x => x.DescriptionValue.Contains(eleStudy.Country.Trim()));
                        var institute = await masterTableRepository.FindPredicate(x => x.DescriptionValue.Contains(eleStudy.Institution.Trim()));

                        var dto = new EducationPostulant
                        {
                            Carreer = eleStudy.Carreer,
                            MonthStart = monthini,
                            MonthEnd = monthfin,
                            YearEnd = yearfin.ToString(),
                            YearStart = yearini.ToString(),
                            IdInstitution = institute?.Id,
                            IdPerson = entity.Id,
                            IdCountry = country?.Id,
                            Active = true,
                            Present = eleStudy.Present
                        };


                        await educationPostulantBaseRepository.Add(dto);
                    }

                    foreach (var eleLang in item.LangDto)
                    {
                        var lang = await masterTableRepository.FindPredicate(x => x.DescriptionValue.Trim().Contains(eleLang.Lang.Trim()));
                        var level = await masterTableRepository.FindPredicate(x => x.DescriptionValue.Trim().Contains(eleLang.Level.Trim()));
                        var dto = new LanguagePostulant
                        {
                            IdLanguagePostulant = lang?.Id,
                            IdOralLeven = level?.Id,
                            IdWrittenLeven = level?.Id,
                            IdPerson = entity.Id,
                            Active = true
                        };

                        await langPostulantBaseRepository.Add(dto);
                    }

                    if (item.SalaryPreference != null || item.SalaryPreference != "")
                    {
                        var dto = new SalaryPreferenceModel
                        {
                            IdPerson = entity.Id,
                            Monto = item.SalaryPreference,
                            Active = true
                        };
                        await SalaryPreferenceBaseRepository.Add(dto);
                    }

                    var postulant = new JobPostulant
                    {
                        Id_Job = request.Job,
                        Id_Postulant = user.Id,
                        ApplicationSource = request.IsBumeran ? 985 : 986,
                        DateApplicant = item.DateApplicant
                    };

                    await jobPostulantRepository.Add(postulant);


                }
            }

            var postulantes = await jobRepository.GetPostulantLoad(request.Job);

            return new Result
            {
                Data = postulantes,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                MessageError = listErrores
            }; 
        }
    }
}
