using FluentValidation.AspNetCore;
using HumanManagement.Application.Home.IServices;
using HumanManagement.Application.Home.Services;
using HumanManagement.Application.Contact.IServices;
using HumanManagement.Application.Contact.Services;
using HumanManagement.Application.MasterTable.Services;
using HumanManagement.Application.MasterTable.IServices;
using HumanManagement.Application.Filters;
using HumanManagement.Application.Helpers;
using HumanManagement.Domain.Areas.Models;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Cargo.Models;
using HumanManagement.Domain.Home.Models;
using HumanManagement.Domain.Contact.Models;
using HumanManagement.Domain.MasterTable.Models;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Empresa.Contracts;
using HumanManagement.Domain.Models;
using HumanManagement.Domain.Organigram.Contracts;
using HumanManagement.Domain.Security.Contracts;
using HumanManagement.Domain.Security.Entities;
using HumanManagement.MsSql.Connections;
using HumanManagement.MsSql.Context;
using HumanManagement.MsSql.Repository;
using HumanManagement.Security.Encryption;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using HumanManagement.MsSql.Repository.Security;
using HumanManagement.Domain.Security.Models;
using HumanManagement.Domain.Areas.Contracts;
using HumanManagement.Domain.Cargo.Contracts;
using HumanManagement.Domain.Employee.Contracts;
using HumanManagement.Application.ImportEmployeeService;
using HumanManagement.Domain.Employee.Models;
using HumanManagement.Domain.General.Contracts;
using HumanManagement.MsSql.Repository.General;
using HumanManagement.Security;
using HumanManagement.Domain.Person.Contracts;
using HumanManagement.Domain.Utils.Constracts;
using HumanManagement.Domain.Contact.Contracts;
using HumanManagement.Domain.Mail.Contracts;
using HumanManagement.Mail.Repository;
using HumanManagement.Domain.Home.Contracts;
using HumanManagement.MsSql.Repository.Home;
using HumanManagement.Domain.Person.Models;
using HumanManagement.MsSql.Repository.Person;
using HumanManagement.Domain.Security.Services;
using HumanManagement.ExactusImport.FromFile;
using HumanManagement.Domain.Recognition.Contracts;
using HumanManagement.MsSql.Repository.RecognitionRepository;
using HumanManagement.MsSql.Repository.Notification;
using HumanManagement.Domain.Notification.Contracts;
using HumanManagement.Domain.Recognition.Models;
using HumanManagement.Domain.Notification.Model;
using HumanManagement.Domain.MasterTable.Contracts;
using HumanManagementApi.FIlters;
using Microsoft.AspNetCore.Http;
using HumanManagement.ReadHtml.HtmlMinifiers;
using HumanManagement.Domain.Recruitment.Contracts;
using HumanManagement.MsSql.Repository.Recruitment;
using HumanManagement.Domain.Job.Models;
using HumanManagement.Domain.Campaign.Contracts;
using HumanManagement.Domain.Campaign.Models;
using HumanManagement.Domain.Proficiency.Models;
using HumanManagement.Domain.Mof.Contracts;
using HumanManagement.Domain.Job.Contracts;
using HumanManagement.Application.Utils.IService;
using HumanManagement.Application.Utils.Service;
using HumanManagement.MsSql.Repository.Job;
using HumanManagement.Domain.Postulant.Area.Contracts;
using HumanManagement.Domain.Evaluation.Contracts;
using HumanManagement.MsSql.Repository.PostJobOffer;
using HumanManagement.Domain.Evaluation.Models;
using HumanManagement.Domain.EvaluationPostulant.Models;
using EvaluationModel = HumanManagement.Domain.EvaluationPostulant.Models.Evaluation;
using Evaluation = HumanManagement.Domain.Evaluation.Models.Evaluation;
using HumanManagement.Domain.Postulant.WorkExperience.Contracts;
using HumanManagement.Domain.Postulant.Education.Contracts;
using HumanManagement.Domain.Postulant.Skills.Contracts;
using HumanManagement.MsSql.Repository.Postulant.WorkExperience;
using HumanManagement.MsSql.Repository.Postulant.Education;
using HumanManagement.MsSql.Repository.Postulant.Skills;
using HumanManagement.MsSql.Repository.Postulant.Language;
using HumanManagement.Domain.Postulant.Languages.Contracts;
using HumanManagement.Domain.Postulant.SalaryPreference.Models;
using HumanManagement.Domain.Postulant.JobObjective.Models;
using HumanManagement.Domain.EvaluationPostulant.Contracts;
using HumanManagement.MsSql.Repository.EvaluationPostulant;
using HumanManagement.Domain.Postulant.Person.Models;
using HumanManagement.Domain.InformationPostulant.Models;
using HumanManagement.Domain.InformationPostulant.Contracts;
using HumanManagement.MsSql.Repository.InformationPostulant;
using HumanManagement.Domain.SalaryBand.Contracts;
using HumanManagement.Domain.RecruitmentArea.Models;
using HumanManagement.Domain.SalaryBand.Models;
using HumanManagement.Domain.EvaluationPostulantInternal.Models;
using HumanManagement.Domain.EvaluationPostulantInternal.Contracts;
using HumanManagement.MsSql.Repository.EvaluationPostulantInternal;
using HumanManagement.Domain.Empresa.Models;
using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.MsSql.Repository.StaffRequest;
using HumanManagement.Domain.StaffRequest.Models;
using HumanManagement.Domain.StaffRequest.Options;
using HumanManagement.Domain.Postulant.Models;
using HumanManagement.Domain.Postulant.WorkExperience.Models;
using HumanManagement.Domain.Postulant.Education.Models;
using HumanManagement.Domain.Postulant.Languages.Models;
using WSHumanManagement.Application.ServerUs.Asistencia.IServices;
using WSHumanManagement.Application.ServerUs.Asistencia.Services;
using HumanManagement.Domain.WindowsService.ServerUs.Contracts;
using HumanManagement.MsSqlServerUs.Repository;
using HumanManagement.Domain.Contracts.ServerUs;
using HumanManagement.MsSqlServerUs.Connections;
using HumanManagement.Domain.HMExactus.Models;
using HumanManagement.Domain.WindowsService.Exactus.Contracts;
using HumanManagement.MsSqlExactus.Repository;
using HumanManagement.MsSqlExactus.Connections;
using HumanManagement.Domain.Proficiency.Contracts;
using HumanManagement.Pdf;
using HumanManagement.Domain.NineBox.Models;
using HumanManagement.Domain.NineBox.Contracts;
using HumanManagement.Domain.Postulant.Disability.Models;

namespace HumanManagementApi.RegisterIoC
{
    public class Register
    {
        public static void Services(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICryptography, Cryptography>();
            services.AddTransient<ITokenGenerator, TokenGenerator>();
            services.AddTransient<ITokenUserService, TokenUserService>();
            services.AddTransient<ITokenUserRepository, TokenUserRepository>();
            services.AddTransient<IImporterFromExcel, ImporterFromExcel>();
            services.AddTransient<IPasswordGenerator, PasswordGenerator>();
            services.AddTransient<IImportEmployeeService, ImportEmployeeService>();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<ISliderService, SliderService>();
            services.AddTransient<IDocumentService, DocumentService>();
            services.AddTransient<IOrganizationService, OrganizationService>();
            services.AddTransient<IMasterTableService, MasterTableService>();
            services.AddTransient<IHtmlReader, HtmlReader>();
            services.AddTransient<IFileDownloadService, FileDownloadService>();
            services.AddTransient<IConvertWordToPdf, PdfConverter>();
            services.AddTransient<ITextReplacement, TextReplacement>();

            services.AddScoped<IBaseRepository<EvaluationModel>, BaseRepository<EvaluationModel>>();
            services.AddScoped<IBaseRepository<EvaluationPostulant>, BaseRepository<EvaluationPostulant>>();
            services.AddScoped<IBaseRepository<Job>, BaseRepository<Job>>();
            services.AddScoped<IBaseRepository<JobIdiom>, BaseRepository<JobIdiom>>();
            services.AddScoped<IBaseRepository<NotificationModel>,BaseRepository<NotificationModel>>();
            services.AddScoped<IBaseRepository<NotificationFavorite>, BaseRepository<NotificationFavorite>>();
            services.AddScoped<IBaseRepository<NotificationViewed>, BaseRepository<NotificationViewed>>();

            
            services.AddScoped<IBaseRepository<Recognition>, BaseRepository<Recognition>>();
            services.AddScoped<IBaseRepository<Areas>,BaseRepository<Areas>>();
            services.AddScoped<IBaseRepository<Contact>, BaseRepository<Contact>>();
            services.AddScoped<IBaseRepository<Cargo>, BaseRepository<Cargo>>();
            services.AddScoped<IBaseRepository<NineBox>, BaseRepository<NineBox>>();
            services.AddScoped<IBaseRepository<Slider>, BaseRepository<Slider>>();
            services.AddScoped<IBaseRepository<Organization>, BaseRepository<Organization>>();
            services.AddScoped<IBaseRepository<Document>, BaseRepository<Document>>();
            services.AddScoped<IBaseRepository<MasterTable>, BaseRepository<MasterTable>>();
            services.AddScoped<IBaseRepository<Recognition>, BaseRepository<Recognition>>();
            services.AddScoped<IBaseRepository<Campaign>, BaseRepository<Campaign>>();
            services.AddScoped<IBaseRepository<Proficiency>, BaseRepository<Proficiency>>();
            services.AddScoped<IBaseRepository<CampaignEmployee>, BaseRepository<CampaignEmployee>>();
            services.AddScoped<IBaseRepository<ProficiencyCharge>, BaseRepository<ProficiencyCharge>>();
            services.AddScoped<IBaseRepository<EvaluationDetail>, BaseRepository<EvaluationDetail>>();
            services.AddScoped<IBaseRepository<Evaluation>, BaseRepository<Evaluation>>();
            services.AddScoped<IBaseRepository<EvaluationProficiency>, BaseRepository<EvaluationProficiency>>();
            services.AddScoped<IBaseRepository<EvaluationRatingPostulant>, BaseRepository<EvaluationRatingPostulant>>();
            services.AddScoped<IBaseRepository<PersonModelPostulant>, BaseRepository<PersonModelPostulant>>();
            services.AddScoped<IBaseRepository<SalaryBand>, BaseRepository<SalaryBand>>();
            services.AddScoped<IBaseRepository<EconomicCondition>, BaseRepository<EconomicCondition>>();



            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAreaRepository, AreaRepository>();
            services.AddScoped<ICargoRepository, CargoRepository>();
            services.AddScoped<INineBoxRepository, NineBoxRepository>();
            services.AddScoped<ISliderRepository, SliderRepository>();
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IOrganigramRepository, OrganigramRepository>();
            services.AddScoped<IMasterTableRepository, MasterTableRepository>();
            services.AddScoped<IRequestRepository,RequestRepository>();
            services.AddScoped<IRquestRepository, RquestRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILoginAttemptService, LoginAttemptService>();
            services.AddScoped<ILoginAttemptRepository, LoginAttemptRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IMailRepository, MailRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IRecognitionRepository, RecognitionRepository>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<HumanManagement.Domain.Evaluation.Contracts.IEvaluationRepository, HumanManagement.MsSql.Repository.EvaluationRepository>();
            services.AddScoped<IEvaluationProficiencyRepository, EvaluationProficiencyRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IJobKeyWordRepository, JobKeyWordRepository>();
            services.AddScoped<IBaseRepository<User>,BaseRepository<User>>();
            services.AddScoped<IBaseRepository<LoginAttempt>,BaseRepository<LoginAttempt>>();
            services.AddScoped<IBaseRepository<TokenUser>,BaseRepository<TokenUser>>();
            services.AddScoped<IBaseRepository<LoginAttempt>,BaseRepository<LoginAttempt>>();
            services.AddScoped<IProfileResourceRepository, ProfileResourceRepository>();
            services.AddScoped<IProfileUserRepository, ProfileUserRepository>();
            services.AddScoped<IUtilRepository, UtilRepository>();
            services.AddScoped<IBaseRepository<HumanManagement.Domain.Security.Models.Profile>, BaseRepository<HumanManagement.Domain.Security.Models.Profile>>();
            services.AddScoped<IBaseRepository<Resource>, BaseRepository<Resource>>();
            services.AddScoped<IBaseRepository<ProfileResource>, BaseRepository<ProfileResource>>();
            services.AddScoped<IBaseRepository<ProfileUser>, BaseRepository<ProfileUser>>();
            services.AddScoped<IBaseRepository<PersonModel>, BaseRepository<PersonModel>>();
            services.AddScoped<IBaseRepository<Phone>, BaseRepository<Phone>>();
            services.AddScoped<IPhoneRepository, PhoneRepository>();
            services.AddScoped<IBaseRepository<EmployeeModel>, BaseRepository<EmployeeModel>>();
            services.AddScoped<IBaseRepository<EmployeeFile>, BaseRepository<EmployeeFile>>();
            services.AddScoped<IBankRepository, BankRepository>();
            services.AddScoped<IMofRepository, MofRepository>();
            services.AddScoped<IWorkExperienceRepository, WorkExperienceRepository>();
            services.AddScoped<IEducationPostulantRepository, EducationPostulantRepository>();
            services.AddScoped<ISkillsPostulantRepository, SkillsPostulantRepository>();
            services.AddScoped<ILanguagesPostulantRepository, LanguageRepository>();
            services.AddScoped<IBaseRepository<SalaryPreferenceModel>, BaseRepository<SalaryPreferenceModel>>();
            services.AddScoped<IBaseRepository<JobObjectiveModel>, BaseRepository<JobObjectiveModel>>();
            services.AddScoped<IBaseRepository<NotesEvaluation>, BaseRepository<NotesEvaluation>>();
            services.AddScoped<IBaseRepository<EvaluationPostulantDocuments>, BaseRepository<EvaluationPostulantDocuments>>();
            services.AddScoped<IEvaluationRatingRepository, EvaluationRatingPostulantRepository>();
            services.AddScoped<IBaseRepository<InformationWorkModel>, BaseRepository<InformationWorkModel>>();
            services.AddScoped<IBaseRepository<InformationComputerSkillsModel>, BaseRepository<InformationComputerSkillsModel>>();
            services.AddScoped<IBaseRepository<InformationFamilyModel>, BaseRepository<InformationFamilyModel>>();
            services.AddScoped<IBaseRepository<InformationAditionalModel>, BaseRepository<InformationAditionalModel>>();
            services.AddScoped<IBaseRepository<InformationEducationModel>, BaseRepository<InformationEducationModel>>();
            services.AddScoped<IBaseRepository<InformationLangModel>, BaseRepository<InformationLangModel>>();
            services.AddScoped<IBaseRepository<InformationExtraModel>, BaseRepository<InformationExtraModel>>();
            services.AddScoped<IBaseRepository<JobPostulant>, BaseRepository<JobPostulant>>();
            services.AddScoped<IBaseRepository<JobOffersInternal>, BaseRepository<JobOffersInternal>>();
            services.AddScoped<IBaseRepository<RecruitmentArea>, BaseRepository<RecruitmentArea>>();
            services.AddScoped<IInformationFamilyRepository, InformationFamilyRepository>();
            services.AddScoped<IInformationEducationRepository, InformationEducationRepository>();
            services.AddScoped<ISalaryBandRepository, SalaryBandRepository>();
            services.AddScoped<IRequestMedicalRepository, RequestMedicalRepository>();
            services.AddScoped<IJobInternalRepository, JobInternalRepository>();
            services.AddScoped<IBaseRepository<JobOffersInternalPostulant>, BaseRepository<JobOffersInternalPostulant>>();
            services.AddScoped<IBaseRepository<JobOffersInternalCurriculum>, BaseRepository<JobOffersInternalCurriculum>>();

            services.AddScoped<IBudgetRepository, BudgetRepository>();
            services.AddScoped<IBaseRepository<AreaGroup>, BaseRepository<AreaGroup>>();
            services.AddScoped<IBaseRepository<EvaluationVacantInternal>, BaseRepository<EvaluationVacantInternal>>();
            services.AddScoped<IBaseRepository<EvaluationPostulantsInternal>, BaseRepository<EvaluationPostulantsInternal>>();
            services.AddScoped<IEvaluationInternalRepository, EvaluationInternalRepository>();
            services.AddScoped<IEvaluationPostulantsInternalRepository, EvaluationPostulantsInternalRepository>();
            services.AddScoped<IBaseRepository<Address>, BaseRepository<Address>>();
            services.AddScoped<IBaseRepository<EvaluationPostulantInfoCurriculum>, BaseRepository<EvaluationPostulantInfoCurriculum>>();
            services.AddScoped<IBaseRepository<EvaluationPostulantPosition>, BaseRepository<EvaluationPostulantPosition>>();
            services.AddScoped<IEvaluationPostulantInfoCurriculumRepository, EvaluationPostulantInfoCurriculumRepository>();
            services.AddScoped<IBaseRepository<NotesEvaluationInternal>, BaseRepository<NotesEvaluationInternal>>();
            services.AddScoped<IBaseRepository<EvaluationProficiencyIntern>, BaseRepository<EvaluationProficiencyIntern>>();
            services.AddScoped<IBaseRepository<EvaluationFortalezasIntern>, BaseRepository<EvaluationFortalezasIntern>>();
            services.AddScoped<IEvaluationFortalezasInternRepository, EvaluationFortalezasInternRepository>();
            services.AddScoped<IEvaluationProficiencyInternRepository, EvaluationProficiencyInternRepository>();
            services.AddScoped<IBaseRepository<EvaluationPostulantInternalLogros>, BaseRepository<EvaluationPostulantInternalLogros>>();
            services.AddScoped<IBaseRepository<Empresa>, BaseRepository<Empresa>>();
            services.AddScoped<IBudgetRepository, BudgetRepository>();
            services.AddScoped<IBaseRepository<AreaGroup>, BaseRepository<AreaGroup>>();
            services.AddScoped<IEconomicConditionRepository, EconomicConditionRepository>();
            services.AddScoped<HumanManagement.Domain.EvaluationPostulant.Contracts.IEvaluationRepository, HumanManagement.MsSql.Repository.EvaluationPostulant.EvaluationRepository>();
            services.AddScoped<IEvaluationPostulantRepository, EvaluationPostulantRepository>();
            services.AddScoped<ICampaignRepository, CampaignRepository>();
            services.AddScoped<IProficiencyRepository, ProficiencyRepository>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IJobIdiomRepository, JobIdiomRepository>();
            services.AddScoped<HumanManagement.Domain.Postulant.Person.Contracts.IPersonRepository, HumanManagement.MsSql.Repository.Postulant.Person.PersonRepository>();
            services.AddScoped<IJobKeyWordRepository, JobKeyWordRepository>();
            services.AddScoped<HumanManagement.Domain.Postulant.Person.Contracts.IPersonSkillRepository, HumanManagement.MsSql.Repository.Postulant.Person.PersonSkillRepository>();
            services.AddScoped<IRecruitmentAreaRepository, RecruitmentAreaRepository>();
            
            services.AddScoped<IBaseRepository<JobKeyWords>, BaseRepository<JobKeyWords>>();
            services.AddScoped<ITypeStaffRequestApproverRepository, TypeStaffRequestApproverRepository>();
            services.AddScoped<ITypeStaffRequestRepository, TypeStaffRequestRepository>();
            services.AddScoped<IBaseRepository<TypeStaffRequest>, BaseRepository<TypeStaffRequest>>();
            services.AddScoped<IBaseRepository<TypeStaffRequestApprover>, BaseRepository<TypeStaffRequestApprover>>();
            services.AddScoped<IBaseRepository<StaffRequestModel>, BaseRepository<StaffRequestModel>>();
            services.AddScoped<IBaseRepository<StaffRequestVacation>, BaseRepository<StaffRequestVacation>>();
            services.AddScoped<IStaffRequestRepository, StaffRequestRepository>();
            services.AddScoped<IBaseRepository<StaffRequestApprover>, BaseRepository<StaffRequestApprover>>();
            services.AddScoped<IStaffRequestApproverRepository, StaffRequestApproverRepository>();
            services.AddScoped<IStaffRequestVacationRepository, StaffRequestVacationRepository>();
            services.AddScoped<IBaseRepository<StaffRequestAdvancement>, BaseRepository<StaffRequestAdvancement>>();
            services.AddScoped<IStaffRequestPermitRepository, StaffRequestPermitRepository>();
            services.AddScoped<IBaseRepository<StaffRequestPermit>, BaseRepository<StaffRequestPermit>>();
            services.AddScoped<IBaseRepository<StaffRequestAbsence>, BaseRepository<StaffRequestAbsence>>();
            services.AddScoped<IBaseRepository<StaffRequestJustificationTardiness>, BaseRepository<StaffRequestJustificationTardiness>>();
            services.AddScoped<IStaffRequestAbsenceRepository, StaffRequestAbsenceRepository>();
            services.AddScoped<IStaffRequestJustificationTardinessRepository, StaffRequestJustificationTardinessRepository>();
            services.AddScoped<ITypeAbsenceRepository, TypeAbsenceRepository>();
            services.AddScoped<IPermitTypeRepository, PermitTypeRepository>();
            services.AddScoped<ITypeLoanRepository, TypeLoanRepository>();
            services.AddScoped<IStaffRequestLoanRepository, StaffRequestLoanRepository>();
            services.AddScoped<IStaffRequestAccountChangeCtsRepository, StaffRequestAccountChangeCtsRepository>();
            services.AddScoped<IBaseRepository<StaffRequestLoan>, BaseRepository<StaffRequestLoan>>();
            services.AddScoped<IBaseRepository<StaffRequestAccountChangeCts>, BaseRepository<StaffRequestAccountChangeCts>>();
            services.AddScoped<IBankingEntityChangeCtsRepository, BankingEntityChangeCtsRepository>();
            services.AddScoped<IBaseRepository<EvaluationExternTest>, BaseRepository <EvaluationExternTest>>();
            services.AddScoped<IHoliDayRepository, HoliDayRepository>();
            services.AddScoped<IBaseRepository<UserPostulant>, BaseRepository<UserPostulant>>();
            services.AddScoped<IJobPostulantRepository, JobPostulantRepository>();
            services.AddScoped<IBaseRepository<WorkExperienceModel>, BaseRepository<WorkExperienceModel>>();
            services.AddScoped<IBaseRepository<EducationPostulant>, BaseRepository<EducationPostulant>>();
            services.AddScoped<IBaseRepository<LanguagePostulant>, BaseRepository<LanguagePostulant>>();
            services.AddScoped<IBaseRepository<SalaryPreferenceModel>, BaseRepository<SalaryPreferenceModel>>();
            services.AddScoped<IBaseRepository<EvaluationMultitestExtern>, BaseRepository<EvaluationMultitestExtern>>();
            services.AddScoped<IBaseRepository<EvaluationMultitestIntern>, BaseRepository<EvaluationMultitestIntern>>();
            services.AddScoped<IEvaluationMultitestRepository, EvaluationMultitestRepository>();
            services.AddScoped<IEvaluationInternMultitestRepository, EvaluationInternMultitestRepository>();
            services.AddScoped<IInformationWorkRepository, InformationWorkRepository>();
            services.AddScoped<IBaseRepository<DisabilityModel>, BaseRepository<DisabilityModel>>();

            services.AddScoped<IServerUsAsistenciaService, ServerUsAsistenciaService>();
            services.AddScoped<ISUMovAsistenciaCabRepository, SUMovAsistenciaCabRepository>();
            services.AddScoped<ISUMovAsistenciaDetRepository, SUMovAsistenciaDetRepository>();


            services.AddScoped<IBaseRepository<HMExactusAfp>, BaseRepository<HMExactusAfp>>();
            services.AddScoped<IBaseRepository<HMExactusFinancialEntity>, BaseRepository<HMExactusFinancialEntity>>();
            services.AddScoped<IBaseRepository<HMExactusLocation>, BaseRepository<HMExactusLocation>>();
            services.AddScoped<IBaseRepository<HMExactusPayroll>, BaseRepository<HMExactusPayroll>>();
            services.AddScoped<IBaseRepository<HMExactusActionType>, BaseRepository<HMExactusActionType>>();
            services.AddScoped<IBaseRepository<HMExactusAbsenceType>, BaseRepository<HMExactusAbsenceType>>();
            services.AddScoped<IBaseRepository<HMExactusFamilyType>, BaseRepository<HMExactusFamilyType>>();

            
            services.AddScoped<IBaseRepository<TypeAbsence>, BaseRepository<TypeAbsence>>();


            services.AddScoped<IExactusEmpleadoRepository, ExactusEmpleadoRepository>();
            services.AddScoped<IExactusMedicalRequestRepository, ExactusMedicalRequestRepository>();
            

            services.AddScoped<IBaseRepository<HumanManagement.Domain.StaffRequest.Models.PermitType>, BaseRepository<HumanManagement.Domain.StaffRequest.Models.PermitType>>();

            services.AddScoped<IJobPregradoRepository, JobPregradoRepository>();
            services.AddScoped<IJobPostgradoRepository, JobPostgradoRepository>();
            services.AddScoped<IJobPregradoInternaRepository, JobPregradoInternaRepository>();
            services.AddScoped<IJobPostgradoInternaRepository, JobPostgradoInternaRepository>();
            services.AddScoped<IInformationPostulantRepository, InformationPostulantRepository>();

            services.AddAutoMapper(typeof(Register));
            services.AddAutoMapper(c => c.AddProfile<AutoMapping>(), typeof(Register));
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            services.AddMvc(options =>
            {
                options.Filters.Add<ValidationFilterAsync>();
            }).AddFluentValidation(option =>
            {
                option.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });

            services.AddMvcCore(options =>
            {
                options.Filters.Add<ValidationFilterAsync>();
            }).AddFluentValidation(option =>
            {
                option.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });

            services.AddMvcCore(option =>
            {
                option.Filters.Add(typeof(CustomAuthorization));
            });
        }

        public static void DataBaseContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContextMsSql>(option => option.UseSqlServer(
                configuration.GetConnectionString("ConnectionStringSqlServer")));
            services.AddDbContext<HumanManagementDbContext>(options =>
                     options
                     .UseSqlServer(configuration.GetConnectionString("ConnectionStringSqlServer"))
            );
            services.AddScoped<IHumanManagementDbContext>(provider => provider.GetService<HumanManagementDbContext>());
            services.AddScoped<IHumanManagementWriteDbConnection, HumanManagementWriteDbConnection>();
            services.AddScoped<IHumanManagementReadDbConnection, HumanManagementReadDbConnection>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<SessionManager>();
            services.AddScoped<SitePostulant.Application.Helpers.SessionManager>();


            services.AddScoped<IServerUsReadDbConnection, ServerUsReadDbConnection>();
            services.AddScoped<IExactusReadDbConnection, ExactusReadDbConnection>();

        }

        public static void AddOptions(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TokenOption>(option =>
            {
                configuration.GetSection("TokenOption")
                .Bind(option);
            });
            services.Configure<JwtOptions>(option =>
            {
                configuration.GetSection("jwt")
                .Bind(option);
            });
            services.Configure<StaffRequestDocument>(option =>
            {
                configuration.GetSection("StaffRequestDocument")
                .Bind(option);
            });
        }
    }
}
