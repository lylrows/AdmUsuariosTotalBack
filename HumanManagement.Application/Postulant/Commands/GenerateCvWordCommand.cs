using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Employee.Dto;
using HumanManagement.Domain.Job.Models;
using HumanManagement.Domain.Postulant.Education.Contracts;
using HumanManagement.Domain.Postulant.JobObjective.Contracts;
using HumanManagement.Domain.Postulant.JobObjective.Models;
using HumanManagement.Domain.Postulant.Languages.Contracts;
using HumanManagement.Domain.Postulant.Person.Contracts;
using HumanManagement.Domain.Postulant.SalaryPreference.Contracts;
using HumanManagement.Domain.Postulant.SalaryPreference.Models;
using HumanManagement.Domain.Postulant.Skills.Contracts;
using HumanManagement.Domain.Postulant.WorkExperience.Contracts;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using System.Text.RegularExpressions;

namespace HumanManagement.Application.Postulant.Commands
{
    public class GenerateCvWordCommand : IRequest<Result>
    {
        public int IdPostulant { get; set; }
        public int IdJob { get; set; }
        public int IdUser { get; set; }

    }

    public class GenerateCvWordCommandHandler : IRequestHandler<GenerateCvWordCommand, Result>
    {
        private readonly AppSettings _appSettings;
        private readonly IPersonRepository personRepository;
        private readonly ISkillsPostulantRepository skillsPostulantRepository;
        private readonly IWorkExperienceRepository workExperienceRepository;
        private readonly IBaseRepository<SalaryPreferenceModel> baseRepository;
        private readonly ILanguagesPostulantRepository languagesPostulantRepository;
        private readonly IEducationPostulantRepository educationPostulantRepository;
        private readonly IBaseRepository<JobObjectiveModel> objectivebaseRepository;
        private readonly IBaseRepository<JobPostulant> jobbaseRepository;
        public GenerateCvWordCommandHandler(IPersonRepository personRepository, 
                                        IOptions<AppSettings> appSettings,
                                        IWorkExperienceRepository workExperienceRepository,
                                        ISkillsPostulantRepository skillsPostulantRepository,
                                        IBaseRepository<SalaryPreferenceModel> baseRepository,
                                        ILanguagesPostulantRepository languagesPostulantRepository,
                                        IEducationPostulantRepository educationPostulantRepository,
                                        IBaseRepository<JobObjectiveModel> objectivebaseRepository,
                                        IBaseRepository<JobPostulant> jobbaseRepository)
        {
            this._appSettings = appSettings.Value;
            this.personRepository = personRepository;
            this.workExperienceRepository = workExperienceRepository;
            this.skillsPostulantRepository = skillsPostulantRepository;
            this.baseRepository = baseRepository;
            this.languagesPostulantRepository = languagesPostulantRepository;
            this.educationPostulantRepository = educationPostulantRepository;
            this.objectivebaseRepository = objectivebaseRepository;
            this.jobbaseRepository = jobbaseRepository;
        }
        public async Task<Result> Handle(GenerateCvWordCommand request, CancellationToken cancellationToken)
        { 
            var job = await jobbaseRepository.FindPredicate(x => x.Id_Postulant == request.IdUser && x.Id_Job == request.IdJob);
            job.IdState = 757;
            await jobbaseRepository.Update(job);

             
            var person = await personRepository.GetPerson(request.IdPostulant);
            var salaryPreference = await baseRepository.FindPredicate(x => x.IdPerson == request.IdPostulant);
            var skills = await skillsPostulantRepository.GetSkillsByPostulant(request.IdPostulant);
            var languages = await languagesPostulantRepository.GetLanguagePostulant(request.IdPostulant);
            var works = await workExperienceRepository.GetWorkExperience(request.IdPostulant);
            var education = await educationPostulantRepository.GetEducationByPostulant(request.IdPostulant);
            var objetive = await objectivebaseRepository.FindPredicate(x => x.IdPerson == request.IdPostulant);

            /*Generate Word Document*/
            string spathWord = string.Empty;
            string randomnameNew1 = string.Empty;
            string fullpath = string.Empty;
            byte[] _wordFinal = default;
            spathWord = _appSettings.TemplateCvPostulantDocx;


            if (!String.IsNullOrEmpty(spathWord))
            {
                randomnameNew1 = "CV_" + DateTime.Now.ToString("ddMMyyyy") + DateTime.Now.ToString("hhmmss");
                if (!Directory.Exists(_appSettings.TemplateCvPostulantTemp)) Directory.CreateDirectory(_appSettings.TemplateCvPostulantTemp);
                fullpath = string.Format("{0}\\{1}.docx", _appSettings.TemplateCvPostulantTemp, randomnameNew1);

                File.Copy(spathWord, fullpath);
                var _generateWord = new GenerateWord();
                var _resultGenerateWord = _generateWord.GenertaWordByPath(fullpath, works, education, skills, languages, person);

                if (_resultGenerateWord)
                {
                    var fileBytes = File.ReadAllBytes(fullpath);
                    File.Delete(fullpath);
                    return new Result
                    {
                        Data = fileBytes,
                        StateCode = Constants.StateCodeResult.STATE_CODE_OK
                    };
                }
            }
            _wordFinal = File.ReadAllBytes(fullpath);
            /*Generate Word Document*/

            return new Result
            {
                Data = null,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
