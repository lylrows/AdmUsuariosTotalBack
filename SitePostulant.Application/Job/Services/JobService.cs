using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Job.Contracts;
using HumanManagement.Domain.Job.Dto;
using HumanManagement.Domain.Job.Models;
using HumanManagement.Domain.Postulant.Education.Contracts;
using HumanManagement.Domain.Postulant.Person.Contracts;
using HumanManagement.Domain.Postulant.WorkExperience.Contracts;
using Microsoft.Extensions.Logging;
using SitePostulant.Application.Job.IServices;
using SitePostulant.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace SitePostulant.Application.Job.Services
{
   
    public class JobService : IJobService
    {
        
        private readonly IJobRepository _jobRepository;
        private readonly IJobPostulantRepository _jobPostulantRepository;

        private readonly IBaseRepository<JobPostulant> _baseRepositoryJobPostulant;

        private readonly IWorkExperienceRepository _workExperienceRepository;
        private readonly IEducationPostulantRepository _educationPostulantRepository;
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<JobService> _logger;
        private readonly IPersonRepository personRepository;

        public JobService(IJobRepository jobRepository, IJobPostulantRepository jobPostulantRepository, IBaseRepository<JobPostulant> baseRepositoryJobPostulant,
            IUnitOfWork unitOfWork, IWorkExperienceRepository workExperienceRepository, IEducationPostulantRepository educationPostulantRepository,
            ILogger<JobService> logger, IPersonRepository personRepository)
        {
            this._jobRepository = jobRepository;
            this._jobPostulantRepository = jobPostulantRepository;
            this._baseRepositoryJobPostulant = baseRepositoryJobPostulant;
            this._unitOfWork = unitOfWork;
            _workExperienceRepository = workExperienceRepository;
            _educationPostulantRepository = educationPostulantRepository;
            this._logger = logger;
            this.personRepository = personRepository;
        }


        public async Task<Result> GetById(int Id)
        {
            var oJob = await _jobRepository.GetById(Id);
            oJob.srelativetime = RelativeTime(oJob.dcreationdate);
            oJob.screationdate = oJob.dcreationdate.ToShortDateString();
            
            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = oJob
            };
        }
        public async Task<Result> IsJobPostulated(int nIdJob, int nIdPostulant)
        {
            bool result = false;
            var oJob = await _jobPostulantRepository.GetById(nIdJob,nIdPostulant);
            
            if (oJob != null)
            {
                result = true;
            }

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = new { 
                    IsPostulated = result,
                    DatePostulated=  oJob == null ? string.Empty :  oJob.DateRegister
                } 
            };
        }
        public async Task<Result> AddJobPostulant(int nIdJob, int nIdPostulant)
        {
            Result response = new Result();
            JobPostulant newjobPostulant = new JobPostulant();


            newjobPostulant.Id_Job = nIdJob;
            newjobPostulant.Id_Postulant = nIdPostulant;
            newjobPostulant.IdState = 758;

            newjobPostulant.Active = true;
            newjobPostulant.DateRegister = DateTime.Now;
            newjobPostulant.IdUserRegister = nIdPostulant;
            newjobPostulant.DateUpdate = DateTime.Now;
            newjobPostulant.IdUserUpdate = nIdPostulant;
            newjobPostulant.ApplicationSource = 984;
            newjobPostulant.DateApplicant = DateTime.Now;

            
            var person = await personRepository.GetPerson(nIdPostulant);
            bool _validatePerson = true;

            
            if (String.IsNullOrEmpty(person.FirstName)) _validatePerson = false;
            if (String.IsNullOrEmpty(person.LastName)) _validatePerson = false;
            if (String.IsNullOrEmpty(person.SecondlastName)) _validatePerson = false;
            if (person.IdNationality == 0) _validatePerson = false;
            if (person.IdCivilStatus == 0) _validatePerson = false;
            if (String.IsNullOrEmpty(person.Sex)) _validatePerson = false;
            if (String.IsNullOrEmpty(person.BirthDate)) _validatePerson = false;
            if (String.IsNullOrEmpty(person.DocumentNumber)) _validatePerson = false;
            if (String.IsNullOrEmpty(person.DocumentType)) _validatePerson = false;
            
            if (String.IsNullOrEmpty(person.CellPhone)) _validatePerson = false;
            if (person.IdDepartmentLocation == 0) _validatePerson = false;
            if (person.IdProvinceLocation == 0) _validatePerson = false;
            if (person.IdDistrictLocation == 0) _validatePerson = false;
            if (String.IsNullOrEmpty(person.Address)) _validatePerson = false;
            if (String.IsNullOrEmpty(person.Email)) _validatePerson = false;

            if (!_validatePerson)
            {
                response.StateCode = Constants.StateCodeResult.VALIDATION;
                response.MessageError.Add("Debe completar la información del Perfil");
                return response;
            }

            var experiences = await _workExperienceRepository.GetWorkExperience(nIdPostulant);
            var education = await _educationPostulantRepository.GetEducationByPostulant(nIdPostulant);
            _logger.LogInformation("nIdPostulant => {0}", nIdPostulant);
            _logger.LogInformation("experiences => {0}", experiences.Count());
            _logger.LogInformation("education => {0}", education.Count());
            if (experiences.Count > 0 && education.Count > 0)
            {
                await _baseRepositoryJobPostulant.Add(newjobPostulant);
                await _unitOfWork.Commit();
                response.StateCode = Constants.StateCodeResult.STATE_CODE_OK;
                response.MessageError = new List<string>() { "Se guardó la postulación de manera correcta" };
            }
            else
            {
                response.StateCode = Constants.StateCodeResult.VALIDATION;
                if(experiences.Count == 0 && education.Count == 0)
                {
                    response.MessageError.Add("Experiencia laboral incompleta, Educación academica incompleta");
                }
                else
                {
                    if (education.Count == 0)
                    {
                        response.MessageError.Add("Educación academica incompleta");
                    }
                    else if (experiences.Count == 0)
                    {
                        response.MessageError.Add("Experiencia laboral incompleta");
                    }
                }
            }
            return response;

           
        }

        public async Task<Result> GetRelatedJobs(int nIdJob)
        {
            var lstJobs = await _jobRepository.GetRelatedJobs(nIdJob);
            
            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = lstJobs
            };
        }
        public async Task<Result> GetOtherJobs()
        {
            var lstJobs = await _jobRepository.GetOtherJobs();

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = lstJobs
            };
        }
        public async Task<Result> GetAllJobs(JobFilterDto filter)
        {
            var lstJobs = await _jobRepository.GetAllJobs(filter);
            int ntotalrecords = lstJobs.Count();
            lstJobs = lstJobs.Skip((filter.CurrentPage - 1) * 5).Take(5).ToList();

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = new { 
                    lista = lstJobs,
                    totalrecords= ntotalrecords
                }
                
            };
        }


        private string RelativeTime(DateTime  date)
        {
            
            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;

            var ts = new TimeSpan(DateTime.UtcNow.Ticks - date.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 1 * MINUTE)
                return ts.Seconds == 1 ? "hace un segundo" : "Hace " +ts.Seconds + " segundos";

            if (delta < 2 * MINUTE)
                return "hace un minuto";

            if (delta < 45 * MINUTE)
                return "hace " + ts.Minutes + " minutos";

            if (delta < 90 * MINUTE)
                return "hace una hora";

            if (delta < 24 * HOUR)
                return  "hace " + ts.Hours + " horas";

            if (delta < 48 * HOUR)
                return "ayer";

            if (delta < 30 * DAY)
                return "hace " + ts.Days + " días";

            if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "hace un mes" : "hace " + months + " meses";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "hace un año" : "hace " + years + " años";
            }
        }


    }
}
