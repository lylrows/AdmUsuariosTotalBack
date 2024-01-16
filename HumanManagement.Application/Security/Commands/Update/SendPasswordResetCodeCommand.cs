using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Mail.Contracts;
using HumanManagement.Domain.Mail.Dto;
using HumanManagement.Domain.Models;
using HumanManagement.Domain.Person.Contracts;
using HumanManagement.Domain.Security.Contracts;
using HumanManagement.Domain.Security.Dto;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Security.Commands.Update
{


    public class SendPasswordResetCodeCommand : IRequest<Result>
    {
        public ForgotPasswordDto forgotPassword { get; set; }
    }

    public class SendPasswordResetCodeCommandHandler : IRequestHandler<SendPasswordResetCodeCommand, Result>
    {
        private readonly IBaseRepository<User> baseRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly AppSettings _appSettings;
        private readonly IMailRepository _mailRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPersonRepository _personRepository;


        public SendPasswordResetCodeCommandHandler(IBaseRepository<User> baseRepository,
                                            IMapper mapper,
                                            IUnitOfWork unitOfWork,
                                            ICryptography cryptography,
                                            IOptions<AppSettings> appSettings,
                                            IMailRepository mailRepository,
                                            IUserRepository userRepository,
                                            IPersonRepository personRepository
                                            )
        {
            this.baseRepository = baseRepository;
            
            this.unitOfWork = unitOfWork;
            
            _appSettings = appSettings.Value;
            this._mailRepository = mailRepository;
            this._userRepository = userRepository;
            this._personRepository = personRepository;
        }

        public async Task<Result> Handle(SendPasswordResetCodeCommand request, CancellationToken cancellationToken)
        {

            Result result = new Result();
            

            var validateuser =  await _userRepository.GetByEmail(request.forgotPassword.Email);

            if (validateuser == null)
            {
                result.StateCode = Constants.StateCodeResult.ERROR_EXCEPTION;
                result.MessageError = new List<string>(){
                    "No existe un usuario registrado con este correo."
                };
                return result;
            }
            request.forgotPassword.Id = validateuser.Id;


            var usermodel = await baseRepository. Find(request.forgotPassword.Id);
            if (usermodel == null)
            {
                result.StateCode = Constants.StateCodeResult.ERROR_EXCEPTION;
                result.MessageError = new List<string>(){
                    "El usuario no existe"
                };
                return result;
            }


            var personmodel = await _personRepository.GetPerson( usermodel.IdPerson);

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
            
            

            await baseRepository.UpdatePartial(usermodel, x => x.PasswordResetCode,
                                                     x => x.PasswordResetStart
                                                     );
            await unitOfWork.Commit();


            string fmt = File.ReadAllText(_appSettings.PasswordRecoveryGrupoFeTemplateHtml);

            fmt = fmt.Replace("[URLPASSWORD]", _appSettings.PasswordRecoveryUrl+ "?user=" + usermodel.Id  +"&tokenresetpassword=" + bytesBase64Url);
           
            MailRequestDto reqMail = new MailRequestDto();



             bool respuestamail = await SendMailPasswordCode(personmodel.semail, fmt);

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

        private async Task<bool> SendMailPasswordCode( string mailuser,string bodyhtml)
        {
            MailRequestDto newMailRequest = new MailRequestDto();
            newMailRequest.From = _appSettings.FromMailNotification;
            newMailRequest.FromName = _appSettings.FromNameNotification;
            newMailRequest.To = new List<string>();
            newMailRequest.To.Add(mailuser);

            newMailRequest.Message = new MessageDto();

            newMailRequest.Message.Subject = "Restablecer Contraseña";

            newMailRequest.Message.Body = new BodyDto() { Format  = EnumBodyMail.Html, Value = bodyhtml };

           var bmail = await  _mailRepository.SendMail(newMailRequest);
            return bmail;

        }
    }


}
