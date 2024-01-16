using HumanManagement.Application.Helpers;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;

using HumanManagement.Domain.Contracts;

using HumanManagement.Domain.Mail.Contracts;
using HumanManagement.Domain.Mail.Dto;
using HumanManagement.Domain.Notification.Contracts;
using HumanManagement.Domain.Notification.Dto;
using HumanManagement.Domain.Notification.QueryFilter;

using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;

using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Notification.Commands.Create
{

    public class CreateSendNotificationSolicitudApprovedCommand : IRequest<Result> 
    {
        
        public NotificationDto Notification { get; set; }
    }

    public class CreateSendNotificationSolicitudApprovedCommandHandler : IRequestHandler<CreateSendNotificationSolicitudApprovedCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<Domain.Notification.Model.NotificationModel> _baseNotification;
        private readonly AppSettings _appSettings;
        private readonly INotificationRepository _notification;
        private readonly SessionManager _sessionManager;
        private readonly IMailRepository mailRepository;

        public CreateSendNotificationSolicitudApprovedCommandHandler(
                                    IBaseRepository<Domain.Notification.Model.NotificationModel> baseNotification,
                                    IOptions<AppSettings> appSettings,
                                    IUnitOfWork unitOfWork,
                                    INotificationRepository notification,
                                    IMailRepository mailRepository,
                                    SessionManager sessionManager
            )
        {
            this._baseNotification = baseNotification;
            _appSettings = appSettings.Value;
            this._unitOfWork = unitOfWork;
            this._notification = notification;
            this._sessionManager = sessionManager;
            this.mailRepository = mailRepository;
        }

        public async Task<Result> Handle(CreateSendNotificationSolicitudApprovedCommand request, CancellationToken cancellationToken)
        {
            SolicitudApprovedQueryFilter objFilter = new SolicitudApprovedQueryFilter();

            objFilter.IdUser = request.Notification.IdUser;
            objFilter.IsOption = request.Notification.IsOption;
            objFilter.IdRequest = request.Notification.Id;

            
            var result = await _notification.GetSendNotificationSolicitudApproved(objFilter);

            string fmt = File.ReadAllText(_appSettings.TemplateSendNotificationSolicitudApproved);
            fmt = fmt.Replace("[vacant_name]", request.Notification.Subject);
            fmt = fmt.Replace("[URL_RECRUITMENT_DETAIL]", _appSettings.UrlRecruitmentDetail + "/" +Convert.ToString( request.Notification.Id));

            var _listEmails = new List<String>();
            var _mailRequest = new MailRequestDto();

            switch (request.Notification.IsOption)
            {
                case 0: 
                    foreach (var item in result)
                    {
                        Domain.Notification.Model.NotificationModel newNotification = new Domain.Notification.Model.NotificationModel();

                        
                        newNotification.IdArea = item.nid_area;
                        newNotification.IdPerson = item.nid_person;  
                        newNotification.IdReceptor = item.nid_receptor;
                        newNotification.Subject = "Solicitud Pendiente Por Aprobar " + request.Notification.Subject;
                        newNotification.Body = fmt;
                        newNotification.SendDate = DateTime.Now;
                        newNotification.Active = true;
                        newNotification.Important = false;
                        newNotification.Favorite = false;

                        await _baseNotification.Add(newNotification);

                        if(IsValidEmail(item.email_receptor))
                        {
                            _listEmails.Add(item.email_receptor);
                        }
                    }

                    if (_listEmails.Count > 0)
                    {
                        _mailRequest = new MailRequestDto
                        {
                            Message = new MessageDto
                            {
                                Body = new BodyDto
                                {
                                    Format = EnumBodyMail.Html,
                                    Value = fmt
                                },
                                Subject = "Solicitud Pendiente Por Aprobar " + request.Notification.Subject
                            },
                            From = _appSettings.FromMailNotification,
                            FromName = _appSettings.FromNameNotification,
                            Cc = null
                        };

                        foreach (var _email in _listEmails)
                        {
                            _mailRequest.To.Add(_email);
                        }

                        bool respuestamail = await SendMailNotification(_mailRequest);
                    }
                    
                    break;
                case 1: 

                    foreach (var item in result)
                    {
                        Domain.Notification.Model.NotificationModel newNotification = new Domain.Notification.Model.NotificationModel();

   
                        newNotification.IdArea = item.nid_area;
                        newNotification.IdPerson = _sessionManager.User.IdPerson; 
                        newNotification.IdReceptor = item.nid_receptor;
                        newNotification.Subject = "Solicitud Pendiente Por Aprobar "+request.Notification.Subject;
                        newNotification.Body = fmt;
                        newNotification.SendDate = DateTime.Now;
                        newNotification.Active = true;
                        newNotification.Important = false;
                        newNotification.Favorite = false;

                        await _baseNotification.Add(newNotification);

                        if (IsValidEmail(item.email_receptor))
                        {
                            _listEmails.Add(item.email_receptor);
                        }
                    }

                    if (_listEmails.Count > 0)
                    {
                        _mailRequest = new MailRequestDto
                        {
                            Message = new MessageDto
                            {
                                Body = new BodyDto
                                {
                                    Format = EnumBodyMail.Html,
                                    Value = fmt
                                },
                                Subject = "Solicitud Pendiente Por Aprobar " + request.Notification.Subject
                            },
                            From = _appSettings.FromMailNotification,
                            FromName = _appSettings.FromNameNotification,
                            Cc = null
                        };

                        foreach (var _email in _listEmails)
                        {
                            _mailRequest.To.Add(_email);
                        }

                        bool respuestamail1 = await SendMailNotification(_mailRequest);
                    }

                    break;
                case 2: 
                    fmt = string.Empty;
                    fmt = File.ReadAllText(_appSettings.TemplateSendNotificationSolicitudApprovedFinal);
                    fmt = fmt.Replace("[vacant_name]", request.Notification.Subject);
                    fmt = fmt.Replace("[URL_RECRUITMENT_DETAIL]", _appSettings.UrlRecruitmentDetail + "/" + Convert.ToString(request.Notification.Id));

                    foreach (var item in result)
                    {
                        Domain.Notification.Model.NotificationModel newNotification = new Domain.Notification.Model.NotificationModel();

                      
                        newNotification.IdArea = item.nid_area;
                        newNotification.IdPerson = _sessionManager.User.IdPerson;
                        newNotification.IdReceptor = item.nid_receptor;
                        newNotification.Subject = "Solicitud Aprobada " + request.Notification.Subject;
                        newNotification.Body = fmt;
                        newNotification.SendDate = DateTime.Now;
                        newNotification.Active = true;
                        newNotification.Important = false;
                        newNotification.Favorite = false;
                        newNotification.IsApprovedRRHH = request.Notification.IsApprovedRRHH;

                        await _baseNotification.Add(newNotification);

                        if (IsValidEmail(item.email_receptor))
                        {
                            _listEmails.Add(item.email_receptor);
                        }
                    }

                    if (_listEmails.Count > 0)
                    {
                        _mailRequest = new MailRequestDto
                        {
                            Message = new MessageDto
                            {
                                Body = new BodyDto
                                {
                                    Format = EnumBodyMail.Html,
                                    Value = fmt
                                },
                                Subject = "Solicitud Aprobada " + request.Notification.Subject
                            },
                            From = _appSettings.FromMailNotification,
                            FromName = _appSettings.FromNameNotification,
                            Cc = null
                        };

                        foreach (var _email in _listEmails)
                        {
                            _mailRequest.To.Add(_email);
                        }

                        bool respuestamail2 = await SendMailNotification(_mailRequest);
                    }

                    break;
                default:
                    
                    break;
            }

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                MessageError = new List<string>() { "Se guardó la evaluación de manera correcta." }

            };
        }

        bool IsValidEmail(string email)
        {
            if (String.IsNullOrEmpty(email)) return false;
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; 
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> SendMailNotification(MailRequestDto mailRequestDto)
        {
            return await mailRepository.SendMail(mailRequestDto);
        }
    }
}
