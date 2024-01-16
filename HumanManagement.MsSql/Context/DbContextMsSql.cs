using HumanManagement.Domain.Areas.Models;
using HumanManagement.Domain.Cargo.Models;
using HumanManagement.Domain.Contact.Models;
using HumanManagement.Domain.Empresa.Models;
using HumanManagement.Domain.Models;
using HumanManagement.Domain.Home.Models;
using HumanManagement.Domain.MasterTable.Models;
using Microsoft.EntityFrameworkCore;
using HumanManagement.Domain.Security.Models;
using HumanManagement.Domain.Employee.Models;
using HumanManagement.Domain.General.Models;
using HumanManagement.Domain.Person.Models;
using HumanManagement.Domain.Notification.Model;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using HumanManagement.Domain.BaseModel;
using System;
using HumanManagement.Domain.Recognition.Models;
using HumanManagement.Application.Helpers;
using HumanManagement.Domain.Postulant.Models;
using HumanManagement.Domain.Postulant.Security.Models;
using HumanManagement.Domain.Postulant.Person.Models;
using HumanManagement.Domain.Job.Models;
using HumanManagement.Domain.RecruitmentArea.Models;
using HumanManagement.Domain.Postulant.Education.Models;
using HumanManagement.Domain.Postulant.Languages.Models;
using HumanManagement.Domain.Postulant.Skills.Models;
using HumanManagement.Domain.Postulant.WorkExperience.Models;
using HumanManagement.Domain.Country.Models;
using HumanManagement.Domain.Postulant.SalaryPreference.Models;
using HumanManagement.Domain.Postulant.JobObjective.Models;
using HumanManagement.Domain.Postulant.Disability.Models;
using HumanManagement.Domain.Campaign.Models;
using HumanManagement.Domain.Proficiency.Models;
using HumanManagement.Domain.EvaluationPostulant.Models;
using HumanManagement.Domain.Evaluation.Models;
using HumanManagement.Domain.InformationPostulant.Models;
using HumanManagement.Domain.SalaryBand.Models;
using HumanManagement.Domain.EvaluationPostulantInternal.Models;
using HumanManagement.Domain.StaffRequest.Models;
using HumanManagement.Domain.HMExactus.Models;
using HumanManagement.Domain.NineBox.Models;
using HumanManagement.Domain.Request.Models;
using HumanManagement.Domain.CategoryEmployment.Models;

namespace HumanManagement.MsSql.Context
{
    public class DbContextMsSql : DbContext
    {
        protected readonly SessionManager sessionManager;
        protected readonly SitePostulant.Application.Helpers.SessionManager sessionManagerPostulant;
        public DbSet<User> User { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Resource> Resource { get; set; }
        public DbSet<ProfileResource> ProfileResource { get; set; }
        public DbSet<ProfileUser> ProfileUser { get; set; }
        public DbSet<Areas> tb_area { get; set; }
        public DbSet<Request> tb_request { get; set; }
        public DbSet<Cargo> tb_charge { get; set; }
        public DbSet<NineBox> tb_config_level_ninebox { get; set; }
        public DbSet<Contact> tb_contact { get; set; }
        public DbSet<Empresa> tb_company { get; set; }
        public DbSet<Empresa> tb_category_employment { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<Organization> Organization { get; set; }
        public DbSet<MasterTable> MasterTable { get; set; }
        public DbSet<PersonModel> Person { get; set; }
        public DbSet<EmployeeModel> Employee { get; set; }
        public DbSet<EmployeeFile> EmployeeFile { get; set; }
        public DbSet<Bank> Bank { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<CoreParameter> CoreParameter { get; set; }
        public DbSet<Phone> Phone { get; set; }
        public DbSet<LoginAttempt> LoginAttempt { get; set; }
        public DbSet<TokenUser> TokenUser { get; set; }
        public DbSet<ProfileApiAccess> ProfileApiAccess { get; set; }
        public DbSet<ApiAccess> ApiAccess { get; set; }
        public DbSet<NotificationModel> Notification { get; set; }
        public DbSet<NotificationFavorite> tb_notification_favorite { get; set; }
        public DbSet<NotificationViewed> tb_notification_viewed { get; set; }
        public DbSet<Recognition> Recognition { get; set; }
        public DbSet<Campaign> tb_campaign { get; set; }
        public DbSet<CampaignEmployee> tb_campaign_employee { get; set; }
        public DbSet<Proficiency> tb_proficiency { get; set; }
        public DbSet<ProficiencyCharge> tb_proficiency_charge { get; set; }
        public DbSet<Domain.EvaluationPostulant.Models.Evaluation> tb_evaluation_flu { get; set; }
        public DbSet<EvaluationPostulant> tb_evaluation_postulants { get; set; }
        public DbSet<EvaluationDetail> tb_evaluation_detail { get; set; }
        public DbSet<Domain.Evaluation.Models.Evaluation> tb_evaluation { get; set; }
        public DbSet<NotesEvaluation> tb_notes_evaluation { get; set; }
        public DbSet<EvaluationProficiency> tb_evaluation_proficiency { get; set; }
        public DbSet<EvaluationRatingPostulant> tb_evaluation_rating { get; set; }
        public DbSet<EvaluationPostulantDocuments> tb_evaluation_documents { get; set; }
        public DbSet<InformationAditionalModel> tb_information_aditional { get; set; }
        public DbSet<InformationComputerSkillsModel> tb_information_skills_computer { get; set; }
        public DbSet<InformationLangModel> tb_information_lang { get; set; }
        public DbSet<InformationFamilyModel> tb_information_family { get; set; }
        public DbSet<InformationWorkModel> tb_information_work { get; set; }
        public DbSet<InformationEducationModel> tb_information_education { get; set; }
        public DbSet<InformationExtraModel> tb_information_extra { get; set; }
        public DbSet<GroupSalaryBand> tb_groupsalaryband { get; set; }
        public DbSet<SalaryBand> tb_salaryband { get; set; }
        public DbSet<SalaryConcept> tb_salaryconcept { get; set; }

        
        public DbSet<SalaryPayrollCab> tb_salarypayrollcab { get; set; }
        public DbSet<SalaryPayrollDet> tb_salarypayrolldet { get; set; }
        public DbSet<AreaGroup> tb_areagroup { get; set; }
        public DbSet<Budget> tb_budget { get; set; }
        public DbSet<JobOffersInternal> tb_job_offers { get; set; }
        public DbSet<JobOffersInternalPostulant> tb_job_offers_postulant { get; set; }
        public DbSet<JobOffersInternalCurriculum> tb_job_offers_postulant_curriculum { get; set; }
        public DbSet<EvaluationVacantInternal> tb_evaluation_vacant_internal { get; set; }
        public DbSet<EvaluationPostulantsInternal> tb_evaluation_postulants_internal { get; set; }
        public DbSet<EvaluationPostulantInfoCurriculum> tb_evaluation_postulant_info_curriculum { get; set; }
        public DbSet<EvaluationPostulantPosition> tb_evaluation_postulant_position { get; set; }
        public DbSet<NotesEvaluationInternal> tb_notes_evaluation_internal { get; set; }
        public DbSet<EvaluationProficiencyIntern> tb_evaluation_proficiency_intern { get; set; }
        public DbSet<EvaluationFortalezasIntern> tb_evaluation_fortalezas_intern { get; set; }
        public DbSet<EvaluationPostulantInternalLogros> tb_evaluation_postulant_logros { get; set; }
        public DbSet<EconomicCondition> tb_economiccondition { get; set; }
        public DbSet<TypeStaffRequest> tb_type_staff_request { get; set; }
        public DbSet<TypeStaffRequestApprover> tb_type_staff_request_approver { get; set; }
        public DbSet<StaffRequestApprover> tb_staff_request_approver { get; set; }
        public DbSet<StaffRequestModel> tb_staff_request { get; set; }
        public DbSet<StaffRequestVacation> tb_staff_request_vacation { get; set; }
        public DbSet<StaffRequestAdvancement> tb_staff_request_advancement { get; set; }
        public DbSet<PermitType> tb_permit_type { get; set; }
        public DbSet<StaffRequestPermit> tb_staff_request_permit { get; set; }
        public DbSet<StaffRequestAbsence> tb_staff_request_absence { get; set; }
        public DbSet<TypeAbsence> tb_type_absence { get; set; }
        public DbSet<StaffRequestJustificationTardiness> tb_staff_request_justification_tardiness { get; set; }
        public DbSet<StaffRequestLoan> tb_staff_request_loan { get; set; }
        public DbSet<TypeLoan> tb_type_loan { get; set; }
        public DbSet<StaffRequestAccountChangeCts> tb_staff_request_account_change_cts { get; set; }
        public DbSet<BankingEntityChangeCts> tb_banking_entity_change_cts { get; set; }
        public DbSet<EvaluationExternTest> tb_evaluation_extern_test { get; set; }
        public DbSet<HoliDayModel> tb_holiday { get; set; }
        public DbSet<EvaluationMultitestExtern> tb_evaluation_multitest_extern { get; set; }
        public DbSet<EvaluationMultitestIntern> tb_evaluation_multitest_intern { get; set; }
        public DbSet<HMExactusFinancialEntity> tb_financialentity { get; set; }
        
        #region postulant

        public DbSet<UserPostulant> UserPostulant { get; set; }

        public DbSet<ProfilePostulant> ProfilePostulant { get; set; }

        public DbSet<ProfileUserPostulant> ProfileUserPostulant { get; set; }

        public DbSet<TokenUserPostulant> TokenUserPostulant { get; set; }

        public DbSet<PersonModelPostulant> PersonPostulant { get; set; }

        public DbSet<Job> tb_Job { get; set; }

        public DbSet<JobIdiom> JobIdiom { get; set; }

        public DbSet<RecruitmentArea> tb_AreaRecruitment { get; set; }

        public DbSet<JobPostulant> tb_JobPostulant { get; set; }

        public DbSet<EducationPostulant> EducationPostulant { get; set; }

        public DbSet<LanguagePostulant> LanguagePostulant { get; set; }

        public DbSet<SkillsPostulant> SkillsPostulant { get; set; }

        public DbSet<WorkExperienceModel> WorkExperience { get; set; }

        public DbSet<Country> Country { get; set; }

        public DbSet<Skills> Skills { get; set; }

        public DbSet<SalaryPreferenceModel> SalaryPreference { get; set; }

        public DbSet<JobObjectiveModel> JobObjective { get; set; }

        public DbSet<DisabilityModel> Disability { get; set; }

        public DbSet<JobKeyWords> JobKeyWords { get; set; }

        public DbSet<JobPregrado> JobPregrado { get; set; }

        public DbSet<JobPostgrado> JobPostgrado { get; set; }
        public DbSet<JobPregradoInterna> JobPregradoInterna { get; set; }

        public DbSet<JobPostgradoInterna> JobPostgradoInterna { get; set; }


        #endregion

        public DbContextMsSql(DbContextOptions<DbContextMsSql> option,
                                SessionManager sessionManager, SitePostulant.Application.Helpers.SessionManager sessionManagerPostulant)
            : base(option)
        {
            this.sessionManager = sessionManager;
            this.sessionManagerPostulant = sessionManagerPostulant;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ParameterConfig(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
        private void ParameterConfig(ModelBuilder modelBuilder)
        {
            #region HumanManagement
            
            modelBuilder.Entity<SalaryPayrollCab>(e =>
            {
                e.ToTable("tb_payroll_cab", "salaryband")
                .HasKey(x => x.IdPayrollCab);
                e.Property(c => c.IdPayrollCab)
                 .ValueGeneratedOnAdd();

            });


            modelBuilder.Entity<SalaryPayrollDet>(e =>
            {
                e.ToTable("tb_payroll_det", "salaryband")
                .HasKey(x => x.IdPayrollDet);
                e.Property(c => c.IdPayrollDet)
                 .ValueGeneratedOnAdd();
                
            });



            modelBuilder.Entity<SalaryConcept>(e =>
            {
                e.ToTable("tb_concept", "salaryband")
                .HasKey(x => x.CodConcept);
                e.Property(c => c.CodConcept);
            });

            modelBuilder.Entity<EconomicCondition>(e =>
            {
                e.ToTable("tb_economic_conditions", "salaryband")
                .HasKey(x => x.IdEconomicCondition);
                e.Property(c => c.IdEconomicCondition)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AreaGroup>(e =>
            {
                e.ToTable("tb_areagroup", "salaryband")
                .HasKey(x => x.IdAreaGroup);
                e.Property(c => c.IdAreaGroup)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Budget>(e =>
            {
                e.ToTable("tb_budget", "salaryband")
                .HasKey(x => x.IdBudget);
                e.Property(c => c.IdBudget)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<SalaryBand>(e =>
            {
                e.ToTable("tb_band_box", "salaryband")
                .HasKey(x => x.IdBandBox);
                e.Property(c => c.IdBandBox)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<GroupSalaryBand>(e =>
            {
                e.ToTable("tb_group", "salaryband")
                .HasKey(x => x.IdGroup);
                e.Property(c => c.IdGroup)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Domain.Evaluation.Models.Evaluation>(e =>
            {
                e.ToTable("tb_evaluation", "campaign")
                .HasKey(x => x.IdEvaluation);
                e.Property(c => c.IdEvaluation)
                .ValueGeneratedOnAdd();
            });


            modelBuilder.Entity<EvaluationDetail>(e =>
            {
                e.ToTable("tb_evaluation_detail", "campaign")
                .HasKey(x => x.IdEvaluationDetail);
                e.Property(c => c.IdEvaluationDetail)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Proficiency>(e =>
            {
                e.ToTable("tb_proficiency", "campaign")
                .HasKey(x => x.IdProficiency);
                e.Property(c => c.IdProficiency)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Campaign>(e =>
            {
                e.ToTable("tb_campaign", "campaign")
                .HasKey(x => x.Id_Campaign);
                e.Property(c => c.Id_Campaign)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<CampaignEmployee>(e =>
            {
                e.ToTable("tb_campaign_employee", "campaign")
                .HasKey(x => new
                {
                    x.IdCampaign,
                    x.IdEmployee
                });
            });

            modelBuilder.Entity<ProficiencyCharge>(e =>
            {
                e.ToTable("tb_proficiency_charge", "campaign")
                .HasKey(x => new
                {
                    x.IdCampaign,
                    x.IdCharge,
                    x.IdProficiency
                });
            });

            modelBuilder.Entity<NotificationFavorite>(e =>
            {
                e.ToTable("tb_notification_favorite")
                .HasKey(x => new
                {
                    x.Id,
                    x.IdReceptor,
                });
            });

            modelBuilder.Entity<NotificationViewed>(e =>
            {
                e.ToTable("tb_notification_viewed")
                .HasKey(x => new
                {
                    x.Id,
                    x.IdReceptor,
                });
            });

            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("tb_user")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Resource>(e =>
            {
                e.ToTable("tb_resource")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Profile>(e =>
            {
                e.ToTable("tb_profile")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ProfileResource>(e =>
            {
                e.ToTable("tb_profile_resource")
                .HasKey(x => new
                {
                    x.IdProfile,
                    x.IdResource
                });
                e.HasOne(p => p.Profile)
                .WithMany()
                .HasForeignKey(f => f.IdProfile);
                e.HasOne(p => p.Resource)
                .WithMany()
                .HasForeignKey(f => f.IdResource);
            });

            modelBuilder.Entity<ProfileUser>(e =>
            {
                e.ToTable("tb_profile_user")
                .HasKey(x => new
                {
                    x.IdProfile,
                    x.IdUser
                });
                e.HasOne(p => p.Profile)
                .WithMany()
                .HasForeignKey(f => f.IdProfile);
                e.HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(f => f.IdUser);
            });

            modelBuilder.Entity<Areas>(e =>
            {
                e.ToTable("tb_area")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Cargo>(e =>
            {
                e.ToTable("tb_charge")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<NineBox>(e =>
            {
                e.ToTable("tb_config_level_ninebox")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Slider>(e =>
            {
                e.ToTable("tb_home_slider")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Document>(e =>
            {
                e.ToTable("tb_home_document")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Organization>(e =>
            {
                e.ToTable("tb_home_organization")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<MasterTable>(e =>
            {
                e.ToTable("tb_master_table")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Contact>(e =>
            {
                e.ToTable("tb_contact")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Empresa>(e =>
            {
                e.ToTable("tb_company")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<CategoryEmployment>(e =>
            {
                e.ToTable("tb_category_employment")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<PersonModel>(e =>
            {
                e.ToTable("tb_person")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<EmployeeModel>(e =>
            {
                e.ToTable("tb_employee")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();

                e.HasOne(p => p.Person)
                .WithMany()
                .HasForeignKey(f => f.IdPerson);
            });

            modelBuilder.Entity<EmployeeFile>(e =>
            {
                e.ToTable("tb_employee_file")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
                e.HasOne(p => p.Employee)
                .WithMany()
                .HasForeignKey(f => f.IdEmployee);
            });

            modelBuilder.Entity<Bank>(e =>
            {
                e.ToTable("tb_bank")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Address>(e =>
            {
                e.ToTable("tb_address")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Department>(e =>
            {
                e.ToTable("tb_department")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Province>(e =>
            {
                e.ToTable("tb_province")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<District>(e =>
            {
                e.ToTable("tb_district")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<CoreParameter>(e =>
            {
                e.ToTable("tb_coreparameter")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Phone>(e =>
            {
                e.ToTable("tb_phone")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
                e.HasOne(p => p.Person)
                .WithMany()
                .HasForeignKey(f => f.IdPerson);
            });

            modelBuilder.Entity<LoginAttempt>(e =>
            {
                e.ToTable("tb_login_attempt")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TokenUser>(e =>
            {
                e.ToTable("tb_token_user")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
                e.HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(f => f.IdUser);
            });

            modelBuilder.Entity<ApiAccess>(e =>
            {
                e.ToTable("tb_api_access")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ProfileApiAccess>(e =>
            {
                e.ToTable("tb_profile_api_access")
                .HasKey(x => new
                {
                    x.IdProfile,
                    x.IdApiAccess
                });
                e.HasOne(p => p.ApiAccess)
                .WithMany()
                .HasForeignKey(f => f.IdApiAccess);
                e.HasOne(p => p.Profile)
                .WithMany()
                .HasForeignKey(f => f.IdApiAccess);
            });
            modelBuilder.Entity<NotificationModel>(e =>
            {
                e.ToTable("tb_notification")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Recognition>(e =>
            {
                e.ToTable("tb_recognition")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Domain.EvaluationPostulant.Models.Evaluation>(e =>
            {
                e.ToTable("tb_evaluation")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<EvaluationPostulant>(e =>
            {
                e.ToTable("tb_evaluation_postulants")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<NotesEvaluation>(e =>
            {
                e.ToTable("tb_notes_evaluation_postulant")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<EvaluationProficiency>(e =>
            {
                e.ToTable("tb_evaluation_proficiency")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<EvaluationRatingPostulant>(e =>
            {
                e.ToTable("tb_evaluation_fortalezas_postulant")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<EvaluationPostulantDocuments>(e =>
            {
                e.ToTable("tb_evaluation_postulant_documents")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<InformationAditionalModel>(e =>
            {
                e.ToTable("tb_information_aditional_postulant")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<InformationComputerSkillsModel>(e =>
            {
                e.ToTable("tb_computer_skills_postulant")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<InformationLangModel>(e =>
            {
                e.ToTable("tb_languages_postulant")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<InformationWorkModel>(e =>
            {
                e.ToTable("tb_information_work_postulant")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<InformationEducationModel>(e =>
            {
                e.ToTable("tb_information_education_postulant")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<InformationFamilyModel>(e =>
            {
                e.ToTable("tb_information_family_postulant")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<InformationExtraModel>(e =>
            {
                e.ToTable("tb_information_extra_postulant")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<JobOffersInternal>(e =>
            {
                e.ToTable("tb_job_offers_internal")
                .HasKey(x => x.Id_Job);
                e.Property(c => c.Id_Job)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<JobOffersInternalPostulant>(e =>
            {
                e.ToTable("tb_job_offers_postulant")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<JobOffersInternalCurriculum>(e =>
            {
                e.ToTable("tb_job_curriculum_postulant")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<EvaluationPostulantsInternal>(e =>
            {
                e.ToTable("tb_evaluation_postulants_internal")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TypeStaffRequest>(e =>
            {
                e.ToTable("tb_type_staff_request")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<EvaluationVacantInternal>(e =>
            {
                e.ToTable("tb_evaluation_job_internal")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<EvaluationPostulantInfoCurriculum>(e =>
            {
                e.ToTable("tb_evaluation_postulant_info_curriculum")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<EvaluationPostulantPosition>(e =>
            {
                e.ToTable("tb_evaluation_postulant_actual_position")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TypeStaffRequestApprover>(e =>
            {
                e.ToTable("tb_type_staff_request_approver")
                .HasKey(x => new
                {
                    x.IdTypeStaffRequest,
                    x.IdApprover
                });
            });

            modelBuilder.Entity<StaffRequestModel>(e =>
            {
                e.ToTable("tb_staff_request")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<NotesEvaluationInternal>(e =>
            {
                e.ToTable("tb_notes_evaluation_postulant_internal")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<EvaluationProficiencyIntern>(e =>
            {
                e.ToTable("tb_evaluation_proficiency_intern")
                 .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<StaffRequestVacation>(e =>
            {
                e.ToTable("tb_staff_request_vacation")
                .HasKey(x => x.IdStaffRequest);
            });

            modelBuilder.Entity<StaffRequestApprover>(e =>
            {
                e.ToTable("tb_staff_request_approver")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<EvaluationFortalezasIntern>(e =>
            {
                e.ToTable("tb_evaluation_fortalezas_postulant_intern")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<EvaluationPostulantInternalLogros>(e =>
            {
                e.ToTable("tb_evaluation_postulant_internal_logros")
                 .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<StaffRequestAdvancement>(e =>
            {
                e.ToTable("tb_staff_request_advancement")
                .HasKey(x => new
                {
                    x.nid_advancement,
                    x.nid_request,
                    x.nid_collaborator,
                });

                e.Property(c => c.nid_advancement)
                .ValueGeneratedOnAdd();

                e.HasOne(r => r.Requests)
                   .WithMany()
                .HasForeignKey(f => f.nid_request);

                e.HasOne(co => co.Collaborators)
                   .WithMany()
                .HasForeignKey(q => q.nid_collaborator);

            });

            modelBuilder.Entity<StaffRequestPermit>(e =>
            {
                e.ToTable("tb_staff_request_permit")
                .HasKey(x => x.IdStaffRequest);
            });

            modelBuilder.Entity<PermitType>(e =>
            {
                e.ToTable("tb_permit_type")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<StaffRequestAbsence>(e =>
            {
                e.ToTable("tb_staff_request_absence")
                .HasKey(x => x.IdStaffRequest);
            });

            modelBuilder.Entity<TypeAbsence>(e =>
            {
                e.ToTable("tb_type_absence")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<StaffRequestJustificationTardiness>(e =>
            {
                e.ToTable("tb_staff_request_justification_tardiness")
                .HasKey(x => x.IdStaffRequest);
            });

            modelBuilder.Entity<StaffRequestLoan>(e => 
            {
                e.ToTable("tb_staff_request_loan")
                .HasKey(x => x.IdStaffRequest);
            });

            modelBuilder.Entity<TypeLoan>(e =>
            {
                e.ToTable("tb_type_loan")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<StaffRequestAccountChangeCts>(e =>
            {
                e.ToTable("tb_staff_request_account_change_cts")
                .HasKey(x => x.IdStaffRequest);
            });

            modelBuilder.Entity<HoliDayModel>(e =>
            {
                e.ToTable("tb_holiday")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<BankingEntityChangeCts>(e =>
            {
                e.ToTable("tb_banking_entity_change_cts")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<EvaluationExternTest>(e =>
            {
                e.ToTable("tb_evaluation_external_test")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<EvaluationMultitestExtern>(e =>
            {
                e.ToTable("tb_evaluation_extern_multitest")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<EvaluationMultitestIntern>(e =>
            {
                e.ToTable("tb_evaluation_intern_multitest")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });



            modelBuilder.Entity<HMExactusAfp>(e =>
            {
                e.ToTable("tb_afp", "exactus")
                .HasKey(x => x.Code);
                e.Property(c => c.Code);
            });

            modelBuilder.Entity<HMExactusFinancialEntity>(e =>
            {
                e.ToTable("tb_financialentity", "exactus")
                .HasKey(x => x.Code);
                e.Property(c => c.Code);
            });

            modelBuilder.Entity<HMExactusLocation>(e =>
            {
                e.ToTable("tb_location", "exactus")
                .HasKey(x => x.Code);
                e.Property(c => c.Code);
            });

            modelBuilder.Entity<HMExactusPayroll>(e =>
            {
                e.ToTable("tb_payroll", "exactus")
                .HasKey(x => x.Code);
                e.Property(c => c.Code);
            });


            modelBuilder.Entity<HMExactusAbsenceType>(e =>
            {
                e.ToTable("tb_absencetype", "exactus")
                .HasKey(x => x.Code);
                e.Property(c => c.Code);
            });

            modelBuilder.Entity<HMExactusActionType>(e =>
            {
                e.ToTable("tb_actiontype", "exactus")
                .HasKey(x => x.Code);
                e.Property(c => c.Code);
            });
            modelBuilder.Entity<HMExactusFamilyType>(e =>
            {
                e.ToTable("tb_familytype", "exactus")
                .HasKey(x => x.Code);
                e.Property(c => c.Code);
            });


            #endregion

            #region postulant
            modelBuilder.Entity<UserPostulant>(e =>
            {
                e.ToTable("tb_user", "recruitment")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ProfilePostulant>(e =>
            {
                e.ToTable("tb_profile", "recruitment")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Job>(e =>
            {
                e.ToTable("tb_job", "recruitment")
                .HasKey(x => x.Id_Job);
                e.Property(c => c.Id_Job)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<JobIdiom>(e =>
            {
                e.ToTable("tb_job_idiom", "recruitment")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
                e.HasOne(p => p.Job)
                .WithMany()
                .HasForeignKey(f => f.IdJob);
            });

            modelBuilder.Entity<JobPostulant>(e =>
            {
                e.ToTable("tb_jobpostulant", "recruitment")
                .HasKey(x => new
                {
                    x.Id_Job,
                    x.Id_Postulant
                });
            });

            modelBuilder.Entity<RecruitmentArea>(e =>
            {
                e.ToTable("tb_area", "recruitment")
                .HasKey(x => x.Id_Area);
                e.Property(c => c.Id_Area)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ProfileUserPostulant>(e =>
            {
                e.ToTable("tb_profile_user", "recruitment")
                .HasKey(x => new
                {
                    x.IdProfile,
                    x.IdUser
                });
                e.HasOne(p => p.Profile)
                .WithMany()
                .HasForeignKey(f => f.IdProfile);
                e.HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(f => f.IdUser);
            });

            modelBuilder.Entity<TokenUserPostulant>(e =>
            {
                e.ToTable("tb_token_user", "recruitment")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
                e.HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(f => f.IdUser);
            });

            modelBuilder.Entity<PersonModelPostulant>(e =>
            {
                e.ToTable("tb_person", "recruitment")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<EducationPostulant>(e =>
            {
                e.ToTable("tb_education_postulant", "recruitment")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<LanguagePostulant>(e =>
            {
                e.ToTable("tb_language_postulant", "recruitment")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<SkillsPostulant>(e =>
            {
                e.ToTable("tb_skills_postulant", "recruitment")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<WorkExperienceModel>(e =>
            {
                e.ToTable("tb_work_experience_postulant", "recruitment")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Country>(e =>
            {
                e.ToTable("tb_country", "recruitment")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Skills>(e =>
            {
                e.ToTable("tb_skills", "recruitment")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<JobObjectiveModel>(e =>
            {
                e.ToTable("tb_job_objective_postulant", "recruitment")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<SalaryPreferenceModel>(e =>
            {
                e.ToTable("tb_salary_preference_postulant", "recruitment")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<DisabilityModel>(e =>
            {
                e.ToTable("tb_disability_postulant", "recruitment")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<JobKeyWords>(e =>
            {
                e.ToTable("tb_job_keywords", "recruitment")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
                e.HasOne(p => p.Job)
                .WithMany()
                .HasForeignKey(f => f.IdJob);
            });

            modelBuilder.Entity<JobPregrado>(e =>
            {
                e.ToTable("tb_pregrado_jobs")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
                e.HasOne(p => p.Job)
                .WithMany()
                .HasForeignKey(f => f.idjobs);
            });

            modelBuilder.Entity<JobPostgrado>(e =>
            {
                e.ToTable("tb_postgrado_jobs")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
                e.HasOne(p => p.Job)
                .WithMany()
                .HasForeignKey(f => f.idjobs);
            });

            modelBuilder.Entity<JobPregradoInterna>(e =>
            {
                e.ToTable("tb_pregrado_interna_jobs")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
                e.HasOne(p => p.Job)
                .WithMany()
                .HasForeignKey(f => f.idjobs);
            });

            modelBuilder.Entity<JobPostgradoInterna>(e =>
            {
                e.ToTable("tb_postgrado_interna_jobs")
                .HasKey(x => x.Id);
                e.Property(c => c.Id)
                .ValueGeneratedOnAdd();
                e.HasOne(p => p.Job)
                .WithMany()
                .HasForeignKey(f => f.idjobs);
            });
            #endregion
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseModel && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));
            

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseModel)entityEntry.Entity).DateRegister = DateTime.Now;
                    if (sessionManager.User != null)
                    {
                        ((BaseModel)entityEntry.Entity).IdUserRegister = sessionManager.User == null ? 1 : sessionManager.User.IdUser;
                    }
                    else if (sessionManagerPostulant.User != null)
                    {
                        ((BaseModel)entityEntry.Entity).IdUserRegister = sessionManagerPostulant.User == null ? 1 : sessionManagerPostulant.User.IdUser;
                    }
                    else
                    {
                        ((BaseModel)entityEntry.Entity).IdUserRegister = 1;
                    }
                }
                else
                {
                    Entry((BaseModel)entityEntry.Entity).Property(p => p.DateRegister).IsModified = false;
                    Entry((BaseModel)entityEntry.Entity).Property(p => p.IdUserRegister).IsModified = false;
                }
                ((BaseModel)entityEntry.Entity).DateUpdate = DateTime.Now;
                if (sessionManager.User != null)
                {
                    ((BaseModel)entityEntry.Entity).IdUserUpdate = sessionManager.User == null ? 1 : sessionManager.User.IdUser;
                }
                else
                {
                    ((BaseModel)entityEntry.Entity).IdUserUpdate = sessionManagerPostulant.User == null ? 1 : sessionManagerPostulant.User.IdUser;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
