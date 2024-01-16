

namespace HumanManagement.CrossCutting.Utils
{
    public class AppSettings 
    {
        public string PathSaveFile { get; set; }
        public string UrlFile { get; set; }
        public string PathTempMailFiles { get; set; }
        public string MailServer { get; set; }
        public int MailPort { get; set; }
        public string MailUser { get; set; }
        public string MailPassword { get; set; }
        public int PasswordResetExpiry { get; set; }
        public string SiteGrupoFeSeguro { get; set; }
        public string FromMailNotification { get; set; }
        public string FromNameNotification { get; set; }
        public string PasswordRecoveryTemplateHtml { get; set; }
        public string PasswordRecoveryGrupoFeTemplateHtml { get; set; }
        public string TemplateCvHtml { get; set; }
        public string TemplateCvDocx { get; set; }
        public string TemplateCvPostulantDocx { get; set; }
        public string TemplateCvPostulantTemp { get; set; }
        public string PathSaveCv { get; set; }
        public string InviteEvaluationTemplateHtml { get; set; }
        public string EvalNotiForEvaluatorTemplateHtml { get; set; }
        public string EvalNotiForEvaluatedTemplateHtml { get; set; }
        public string EvalExternNotiForEvaluadorTemplateHtml { get; set; }
        public string EvalInternNotiForEvaluadorTemplateHtml { get; set; }
        public string NewVacantTemplateHtml { get; set; }
        public string InformeFinalTemplateExcel { get; set; }
        public string UrlJobOfferDetail { get; set; }
        public string UrlBumeran { get; set; }
        public string UrlEvaluationExtern { get; set; }
        public string UrlEvaluationIntern { get; set; }
        public string RegisterRequestTemplateHtml { get; set; }
        public string RegisterRequestDocumentHtml { get; set; }
        public string DownloadRequestDocumentHtml { get; set; }        
        public string AceptRequestTemplateHtml { get; set; }
        public string AceptRequestDocumentHTML { get; set; }
        public string RejectRequestTemplateHtml { get; set; }
        public string RejectRequestDocumentTemplateHtml { get; set; }
        public string UrlEvaluation { get; set; }
        public string UrlFichaDatosPostulante { get; set; }
        public string PostulantSelectedTemplateHtml { get; set; }
        public string PostulantSelectedExternaTemplateHtml { get; set; }
        public string PostulantNotSelectedTemplateHtml { get; set; }
        public string PostulantNotSelectedExternaTemplateHtml { get; set; }
        public string PostulantInternSelectedTemplateHtml { get; set; }
        public string ActivateAccountTemplateHtml { get; set; }
        public string ConfirmationPostulant { get; set; }
        public int IdPersonRRHH { get; set; }
        public string MailRRHH { get; set; }
        public string PasswordRecoveryUrl { get; set; }
        public string HomeUrl { get; set; }
        public string URL_PHOTO_USER_DEFAULT { get; set; }
        public string URL_PHOTO_COMPANY_DEFAULT { get; set; }
        public string Certificado { get; set; }
        public string PATHSAVE { get; set; }
        public string PATHDOWNLOAD { get; set; }
        public string RegisterRequestAdvacement { get; set; }
        public string FormatoFeSaludWord { get; set;}
        public string FormatoPacificoWord { get; set; }
        public string FormatoCambioEPS { get; set; }
        public string FormatoCambioCuentaSueldo { get; set; }
        public string FormatoCambioCTS { get; set; }
        public string URLEVALUACION { get; set; }
        public string StaffRequestNotificationTemplateHtml { get; set; }
        public string StaffRequestNotificationAcceptTemplateHtml { get; set; }
        public string StaffRequestNotificationRejectTemplateHtml { get; set; }
        public string AceptRequestAdvacement { get; set; }
        public string RejectRequestAdvacement { get; set; }
        public string RegisterRequestMedical { get; set; }
        public string RegisterRequestBurial { get; set; }
        public string MedicalObservado { get; set; }
        public string MedicalAccept { get; set; } 
        public string RejectMedical { get; set; }
        public string RegisterRequestSalary { get; set; }
        public string AcepteRequestSalary { get; set; }
        public string AcepteRequestSalaryAcept { get; set; }
        public string RejectRequestSalary { get; set; }
        public string AceptRequestBurial { get; set; }
        public string AceptRequestBurialFin { get; set; }
        public string RejectRequestBurial { get; set; }
        public string AcepteRequestMedico { get; set; }
        public string DeleteEmployeeByCampaign { get; set; }
        public string AcepteRequestTypeSure { get; set; }
        public string ApprovedRequestMedico { get; set; }
        public string RejectRequestMedical { get; set; }
        public string RegisterRequestSure { get; set; }
        public string RegisterRequestTypeSure { get; set; }
        public string AcepteRequestSure { get; set; }
        public string RejectRequestSure { get; set; }
        public string TemplateReporteEvaluationIntern { get; set; }
        public string TemplateReporteEvaluationExtern { get; set; }
        public string TemplateReporteEvaluationIntegralIntern { get; set; }
        public string TemplateReporteEvaluationIntegralExtern { get; set; }
        public string NotificationEvaluationMailTemplate { get; set; }
        public string UrlStaffRequest { get; set; }

        public string UrlApiDocRRHH { get; set; }
        public string ClientIdApiDocRRHH { get; set; }
        public string ClientSecretApiDocRRHH { get; set; }
        public string ApiMultitest { get; set; }

        public string TemplateSendNotificationSolicitudApproved { get; set; }
        public string TemplateSendNotificationSolicitudApprovedFinal { get; set; }
        public string UrlRecruitmentDetail { get; set; }

        public string PostulantSelectedPrestaFe { get; set; }
        public string PostulantSelectedGrupoFe { get; set; }
        public string PostulantSelectedFeSalud { get; set; }
        public string PostulantSelectedCampoFe { get; set; }
        public string TemplateExportDetailEvaluation { get; set; }
        public string PathSaveExportDetailEvaluationPDF { get; set; }
        public int DaysTimeLine { get; set; }
        public string PostulantSelectedExternaBackground { get; set; }
        public string PostulantSelectedExternaColorDiv { get; set; }
        public string PostulantSelectedExternaColorButton { get; set; }
        public string PostulantSelectedExternaUrlInduccion { get; set; }
        public string PostulantNotSelectedExternaBackground { get; set; }
        public string PostulantNotSelectedExternaColorButton { get; set; }
        public string PostulantNotSelectedExternaUrlPercepcion { get; set; }
        public string PathDocumentosPostulant { get; set; }
        
        public string PostulantSelectedInternaBackground { get; set; }
        public string PostulantSelectedInternaColorDiv { get; set; }
        public string PostulantSelectedInternaColorButton { get; set; }
        public string PostulantSelectedInternaTemplateHtml { get; set; }
        public string PostulantSelectedInternaUrlInduccion { get; set; }
        
        public string TemplateSendNotificationFichaPersonal { get; set; }
        public string UrlPostulantEvaluationInterna { get; set; }
        public string UrlPostulantEvaluationExterna { get; set; }
        public string UrlPostulantAdministration { get; set; }
    }
}
