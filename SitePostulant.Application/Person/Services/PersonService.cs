using AutoMapper;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Postulant.Person.Contracts;
using HumanManagement.Domain.Postulant.Person.Dto;
using HumanManagement.Domain.Postulant.Person.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SitePostulant.Application.Person.IServices;
using SitePostulant.Application.Response;
using System;

using System.IO;

using System.Threading.Tasks;

namespace SitePostulant.Application.Person.Services
{
    public class PersonService : IPersonService
    {
        private readonly IBaseRepository<PersonModelPostulant> basePersonRepository;
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;
        private readonly AppSettings _appSettings;
        private readonly ILogger<PersonService> _logger;
        public PersonService(IBaseRepository<PersonModelPostulant> basePersonRepository,
                             IPersonRepository personRepository,
                             IMapper mapper,
                             IOptions<AppSettings> appSettings,
                             ILogger<PersonService> logger)
        {
            this.basePersonRepository = basePersonRepository;
            this.personRepository = personRepository;
            this.mapper = mapper;
            this._appSettings = appSettings.Value;
            this._logger = logger;
        }

        public async Task<Result> DeleteCv(int IdPerson)
        {
            var res = await personRepository.DeleteCv(IdPerson);

            return new Result
            {
                Data = res,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }

        public async Task<Result> GetById(int id)
        {
            var person = await personRepository.GetPerson(id);
            _logger.LogInformation(string.Format("PERSON => ID: {0}, IMG: {1}", person.Id, person.Img));
            if (person.Img != null)
            {
                var file = person.Img;
                if (File.Exists(file))
                {
                    var buffer = File.ReadAllBytes(file);
                    person.Img = $"data:image/jpeg;base64,{Convert.ToBase64String(buffer)}";
                }
            }

            if (person.CvFolder != null)
            {
                var file = person.CvFolder;
                if (File.Exists(file))
                {
                    var buffer = File.ReadAllBytes(file);
                    person.CvFile = buffer;
                    person.ContentType = Path.GetExtension(person.CvName);
                }
            }



            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = person
            };
        }

        public async Task<Result> SaveCv(PersonCvDto dto, IFormFile formFile)
        {
            var folder = _appSettings.PathSaveFile;
            var filenamefolder = folder + "Curriculum\\";
            dto.Name = formFile.FileName;
            dto.Folder = filenamefolder + dto.Name;

            if (!Directory.Exists(filenamefolder))
            {
                Directory.CreateDirectory(filenamefolder);
            }

            using (var stream = new FileStream(dto.Folder, FileMode.Create))
            {
                formFile.CopyTo(stream);
            }


            var result = await personRepository.SaveCv(dto);
            var person = await personRepository.GetPerson(dto.IdPerson);

            if (person.CvFolder != null)
            {
                var file = person.CvFolder;
                if (File.Exists(file))
                {
                    var buffer = File.ReadAllBytes(file);
                    dto.Archivo = buffer;
                    dto.ContentType = Path.GetExtension(person.CvName);
                }
            }

            return new Result
            {
                Data = dto,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }

        public async Task<Result> SaveImg(PersonCvDto dto, IFormFile formFile)
        {
            try
            {
                var folder = _appSettings.PathSaveFile;
                var filenamefolder = folder + "Photo\\";
                var _nombreFileAleatorio = string.Format("{0}{1}", Guid.NewGuid(), Path.GetExtension(formFile.FileName));
                dto.Name = _nombreFileAleatorio;
                dto.Folder = filenamefolder + _nombreFileAleatorio;

                if (!Directory.Exists(filenamefolder))
                {
                    Directory.CreateDirectory(filenamefolder);
                }

                using (var stream = new FileStream(dto.Folder, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }


                var result = await personRepository.SaveImg(dto);
                var person = await personRepository.GetPerson(dto.IdPerson);

                if (person.Img != null)
                {
                    var file = person.Img;
                    if (File.Exists(file))
                    {
                        var buffer = File.ReadAllBytes(file);
                        dto.Img = $"data:image/jpeg;base64,{Convert.ToBase64String(buffer)}";
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("SaveImg ex message => {0}, stacktrace {1}", ex.Message, ex.StackTrace));
            }

            return new Result
            {
                Data = dto,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }

        public async Task<Result> UpdateContactInformation(PersonDto personDto)
        {
            var person = mapper.Map<PersonModelPostulant>(personDto);

            await basePersonRepository.UpdatePartial(person, x => x.CellPhone,
                                                            x => x.AnotherPhone,
                                                            x => x.IdDistrictLocation,
                                                            x => x.IdProvinceLocation,
                                                            x => x.IdDepartmentLocation,
                                                            x => x.Address,
                                                            x => x.Email,
                                                            x => x.UrlProfesional);

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }

        public async Task<Result> UpdatePersonalInformation(PersonDto personDto)
        {
            var birthDate = personDto.BirthDate;
            var date = new DateTime();
            var dat = personDto.BirthDate.Split('/');
            if (dat?.Length > 0)
            {
                date = new DateTime(Convert.ToInt32(dat[2]), Convert.ToInt32(dat[1]), Convert.ToInt32(dat[0]));
            }

            personDto.BirthDate = null;
            var person = mapper.Map<PersonModelPostulant>(personDto);
            

            person.BirthDate = date;

            await basePersonRepository.UpdatePartial(person, x => x.FirstName,
                                                            x => x.SecondName,
                                                            x => x.LastName,
                                                            x => x.MotherLastName,
                                                            x => x.BirthDate,
                                                            x => x.IdNationality,
                                                            x => x.IdCivilStatus,
                                                            x => x.IdTypeDocument,
                                                            x => x.DocumentNumber,
                                                            x => x.HaveDriverLicense,
                                                            x => x.LicenceDrive,
                                                            x => x.HaveOwnMobility,
                                                            x => x.IdSex);

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
