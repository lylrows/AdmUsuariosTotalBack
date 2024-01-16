using AutoMapper;
using FluentValidation;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Contracts;

using HumanManagement.Domain.Mail.Contracts;
using HumanManagement.Domain.Mail.Dto;
using HumanManagement.Domain.Postulant.Models;
using HumanManagement.Domain.Postulant.Person.Contracts;
using HumanManagement.Domain.Postulant.Person.Models;
using HumanManagement.Domain.Postulant.Security.Contracts;
using HumanManagement.Domain.Postulant.Security.Dto;
using HumanManagement.Domain.Postulant.Security.Entities;
using HumanManagement.Domain.Postulant.Security.Events;
using HumanManagement.Domain.Postulant.Security.Models;
using Microsoft.Extensions.Options;
using SitePostulant.Application.Response;
using SitePostulant.Application.Security.IServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

using System.Threading.Tasks;

namespace SitePostulant.Application.Security.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IBaseRepository<UserPostulant> baseUserRepository;
        private readonly IBaseRepository<ProfileUserPostulant> baseProfileUserRepository;
        private readonly IBaseRepository<PersonModelPostulant> personRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICryptography cryptography;
        private readonly AppSettings _appSettings;
        private readonly IMailRepository _mailRepository;
        private readonly IHtmlReader htmlReader;
        public UserService(IBaseRepository<UserPostulant> baseUserRepository,
                                        IBaseRepository<PersonModelPostulant> personRepository,
                                        IBaseRepository<ProfileUserPostulant> baseProfileUserRepository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork,
                                        ICryptography cryptography,
                                        IUserRepository _userRepository,
                                        IPersonRepository _personRepository,
                                        IOptions<AppSettings> appSettings,
                                        IMailRepository _mailRepository,
                                        IHtmlReader htmlReader)
        {
            this.baseUserRepository = baseUserRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.cryptography = cryptography;
            this.personRepository = personRepository;
            this.baseProfileUserRepository = baseProfileUserRepository;
            this._userRepository = _userRepository;
            this._personRepository = _personRepository;
            this._appSettings = appSettings.Value;
            this._mailRepository = _mailRepository;
            this.htmlReader = htmlReader;
        }

        public async Task<Result> ActiveAccount(int id)
        {
            var result = await _userRepository.ActiveAccount(id);
            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }

        public async Task<Result> ChangePassword(ResetPasswordDto resetPasswordDto)
        {
            Result result = new Result();
            resetPasswordDto.SetPassword(cryptography);
            var user = mapper.Map<UserPostulant>(resetPasswordDto);


            var usermodel = await baseUserRepository.Find(resetPasswordDto.Id);
            usermodel.Password = resetPasswordDto.Password;
            usermodel.DateUpdate = DateTime.Now;
            usermodel.ChangedPassword = true;


            await baseUserRepository.UpdatePartial(usermodel, x => x.Password,
                                                      x => x.DateUpdate,
                                                      x => x.ChangedPassword
                                                      );

            await unitOfWork.Commit();

            result.StateCode = Constants.StateCodeResult.STATE_CODE_OK;
            result.MessageError = new List<string>(){
                    "Se cambió la contraseña de manera correcta."
                };

            return result;
        }

        public async Task<Result> ChangePasswordConfiguration(ChangePasswordDto dto)
        {
            dto.SetPassword(cryptography);
            var exist = await baseUserRepository.Exist(x => x.Password == dto.PasswordActual);
            if (!exist)
            {
                throw new ValidationException("La contraseña actual es incorrecta, ingrese nuevamente");
            }

            var res = await _userRepository.ChangePassword(dto);
            return new Result
            {
                Data = res,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }

        public async Task<Result> CreateUser(UserDto userDto)
        {
            var exist = await personRepository.Exist(x => x.Email == userDto.Email);
            if (exist == true)
                throw new ValidationException("Ya existe una cuenta con el mismo correo");
            userDto.SetEncryptPassword(cryptography);
            var user = mapper.Map<UserPostulant>(userDto);
            var person = mapper.Map<PersonModelPostulant>(userDto);
            person.DateRegister = DateTime.Now;
            person.DateUpdate = DateTime.Now;
            person.DocumentNumber = "";
            person.IdSex = 12;
            person.IdActive = 24;

            await personRepository.Add(person);

            user.IdPerson = person.Id;
            user.UserName = person.GetUserName();
            await baseUserRepository.Add(user);
            var profileUser = mapper.Map<ProfileUserPostulant>(userDto);
            profileUser.IdProfile = 1;
            profileUser.IdUser = user.Id;
            await baseProfileUserRepository.Add(profileUser);
            await unitOfWork.Commit();

            UserMailDto userMailDto = new UserMailDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = userDto.PasswordWithoutEncryption,
                FullName = $"{person.FirstName} {person.SecondName} {person.LastName} {person.MotherLastName}",
                Email = person.Email
            };
            var userRegistered = new UserRegistered(userMailDto);

            MailSenderUser mailSenderUser = new MailSenderUser(htmlReader, userRegistered.UserMail, _appSettings.ActivateAccountTemplateHtml, _appSettings.HomeUrl);
            await _mailRepository.SendMail(mailSenderUser.GetMail());
            userDto.Id = user.Id;
            userDto.IdPerson = person.Id;
            return new Result
            {
                Data = userDto,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }

        public async Task<Result> DeleteUser(DeleteUserDto dto)
        {
            dto.SetPassword(cryptography);
            var exist = await baseUserRepository.Exist(x => x.Password == dto.PasswordActual);
            if (!exist)
            {
                throw new ValidationException("La contraseña actual es incorrecta, ingrese nuevamente");
            }

            var res = await _userRepository.DeleteUser(dto);
            return new Result
            {
                Data = res,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }

        public async Task<Result> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {
            Result result = new Result();


            var validateuser = await _userRepository.GetByEmail(forgotPasswordDto.Email);

            if (validateuser == null)
            {
                result.StateCode = Constants.StateCodeResult.ERROR_EXCEPTION;
                result.MessageError = new List<string>(){
                    "No existe un usuario registrado con este correo."
                };
                return result;
            }
            forgotPasswordDto.Id = validateuser.Id;


            var usermodel = await baseUserRepository.Find(forgotPasswordDto.Id);
            if (usermodel == null)
            {
                result.StateCode = Constants.StateCodeResult.ERROR_EXCEPTION;
                result.MessageError = new List<string>(){
                    "El usuario no existe"
                };
                return result;
            }


            var personmodel = await _personRepository.GetPerson(usermodel.IdPerson);

            if (personmodel == null)
            {
                result.StateCode = Constants.StateCodeResult.ERROR_EXCEPTION;
                result.MessageError = new List<string>(){
                    "La Persona no existe"
                };
                return result;
            }

            
            Byte[] bytes;
            String bytesBase64Url; 



            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {

                bytes = new Byte[12]; 
                rng.GetBytes(bytes);

                
                bytesBase64Url = Convert.ToBase64String(bytes).Replace('+', '-').Replace('/', '_');
            }

            usermodel.PasswordResetCode = bytes;
            usermodel.PasswordResetStart = DateTime.Now;



            await baseUserRepository.UpdatePartial(usermodel, x => x.PasswordResetCode,
                                                     x => x.PasswordResetStart
                                                     );
            await unitOfWork.Commit();


            
            


            string fmt = File.ReadAllText(_appSettings.PasswordRecoveryTemplateHtml);

            fmt = fmt.Replace("[URLPASSWORD]", _appSettings.PasswordRecoveryUrl + "?user=" + usermodel.Id + "&tokenresetpassword=" + bytesBase64Url);

            MailRequestDto reqMail = new MailRequestDto();



            bool respuestamail = await SendMailPasswordCode(personmodel.Email, fmt);

            if (!respuestamail)
            {
                result.StateCode = Constants.StateCodeResult.ERROR_EXCEPTION;
                result.MessageError = new List<string>(){
                    "Ocurrió un error al enviar el correo."
                };
                return result;
            }

            
            result.StateCode = Constants.StateCodeResult.STATE_CODE_OK;
            result.MessageError = new List<string>(){
                    "Se envió un correo con las instrucciones."
                };

            return result;
        }

        public async Task<Result> SendMailActivation(string email)
        {

            var person = await personRepository.FindPredicate(x => x.Email == email);
            var user = await baseUserRepository.FindPredicate(x => x.IdPerson == person.Id);

            UserMailDto userMailDto = new UserMailDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = null,
                FullName = $"{person.FirstName} {person.SecondName} {person.LastName} {person.MotherLastName}",
                Email = person.Email
            };
            var userRegistered = new UserRegistered(userMailDto);

            MailSenderUser mailSenderUser = new MailSenderUser(htmlReader, userRegistered.UserMail, _appSettings.ActivateAccountTemplateHtml, _appSettings.HomeUrl);
            bool success = await _mailRepository.SendMail(mailSenderUser.GetMail());
            return new Result
            {
                Data = success,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };

        }

        public async Task<Result> SendEmailPostulantConfirmation(string email,string job)
        {

            var person = await personRepository.FindPredicate(x => x.Email == email);
            var user = await baseUserRepository.FindPredicate(x => x.IdPerson == person.Id);

            UserMailDto userMailDto = new UserMailDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = null,
                FullName = $"{person.FirstName} {person.SecondName} {person.LastName} {person.MotherLastName}",
                Email = person.Email
            };
            var userRegistered = new UserRegistered(userMailDto);

            
            MailSenderUser mailSenderUser = new MailSenderUser(htmlReader, userRegistered.UserMail, _appSettings.ConfirmationPostulant, _appSettings.HomeUrl);
            bool success = await _mailRepository.SendMail(mailSenderUser.GetMailPostulantConfirmation(job));
            return new Result
            {
                Data = success,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };

        }


        public async Task<Result> ValidResetPasswordCode(int IdUser, byte[] providedCode)
        {
            Result result = new Result();
            TimeSpan _passwordResetExpiry = TimeSpan.FromMinutes(_appSettings.PasswordResetExpiry);
            var userDto = await _userRepository.GetById(IdUser);


            if (userDto == null)
            {
                result.StateCode = Constants.StateCodeResult.ERROR_EXCEPTION;
                result.MessageError = new List<string>(){
                    "El usuario no existe"};
                return result;
            }

            if (userDto.PasswordResetStart == null || userDto.PasswordResetCode == null)
            {
                result.StateCode = Constants.StateCodeResult.ERROR_EXCEPTION;
                result.MessageError = new List<string>(){
                    "No hay restablecimiento de contraseña pendiente."};
                return result;
            }

            Byte[] expectedCode = userDto.PasswordResetCode;
            DateTime? start = userDto.PasswordResetStart;

            if (!Enumerable.SequenceEqual(providedCode, expectedCode))
            {
                result.StateCode = Constants.StateCodeResult.ERROR_EXCEPTION;
                result.MessageError = new List<string>(){
                    "Código incorrecto."};
                return result;
            }
            DateTime dDateExpiry = userDto.PasswordResetStart.Value.AddMinutes(_appSettings.PasswordResetExpiry);
            if (DateTime.Now > dDateExpiry)
            {
                result.StateCode = Constants.StateCodeResult.ERROR_EXCEPTION;
                result.MessageError = new List<string>(){
                    "El enlace a vencido. Solicite nuevamente."};
                return result;
            }


            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = userDto
            };
        }

        private async Task<bool> SendMailPasswordCode(string mailuser, string bodyhtml)
        {
            MailRequestDto newMailRequest = new MailRequestDto();
            newMailRequest.From = _appSettings.FromMailNotification;
            newMailRequest.FromName = _appSettings.FromNameNotification;
            newMailRequest.To = new List<string>();
            newMailRequest.To.Add(mailuser);

            newMailRequest.Message = new MessageDto();

            newMailRequest.Message.Subject = "Restablecer Contraseña";

            newMailRequest.Message.Body = new BodyDto() { Format = EnumBodyMail.Html, Value = bodyhtml };

            var bmail = await _mailRepository.SendMail(newMailRequest);
            return bmail;

        }
    }
}
