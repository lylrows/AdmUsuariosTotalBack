
namespace HumanManagement.CrossCutting.Utils
{
    public class Constants
    {
        public class Token
        {
            public const int INDEX_START_OF_TOKEN = 7;
        }
        public class LoginUser
        {
            public const int NUMBER_ATTEMPT = 3;
        }
        public class StateCodeResult
        {
            public const int STATE_CODE_OK = 200;
            public const int BAD_REQUEST = 400;
            public const int UNAUTHORIZED_ACCESS = 401;
            public const int FILE_NOT_FOUND = 404;
            public const int ERROR_EXCEPTION = 500;
            public const int VALIDATION = 100;
        }

        public class PathTemplateHtml
        {
            public const string PATH_TEMPLATE_HTML_MAIL_USER = "C:\\FilesHumanManagement\\TemplateHtml\\MailNewUser.html";
          
        }

        public class HumanManagemen
        {
            public const string ApplicationName = "HUMANMANAGEMENT";
            public const string ModuleCommon = "SERVICE_COMMON";
            public class Keys
            {
                public const string FrequencyProcDay = "FEQPROCESODIA";
                public const string FrequencyProcVH = "FEQPROCESOVH";
                public const string HoraInicio = "HI";
                public const string HoraFin = "HF";
            }
        }

        public class NotifyImportedUser
        {
            public const string Module = "SEND_MAIL_IMPORTED_USER";
        }

       
        public class Images
        {
            public const string FOLDER_USER = "Imagenes//Usuario//";
        }

        public class StaffRequestAttachedDocument
        {
            public const string FOLDER_PERMIT = "StaffRequest\\Permit\\";
            public const string FOLDER_ABSENCE = "StaffRequest\\Ansence\\";
            public const string FOLDER_JUSTIFICATION_TARDINESS = "StaffRequest\\JustificationTardiness\\";
            public const string FOLDER_LOAN = "StaffRequest\\Loan\\";
            public const string FOLDER_ACCOUNT_CHANGE_CTS = "StaffRequest\\AccountChangeCts\\";
        }
    
    }
}
