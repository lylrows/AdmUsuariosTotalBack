using HumanManagement.Domain.Postulant.Security.Dto;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SitePostulant.Application.Helpers
{
    public class SessionManager
    {
        private readonly ISession session;
        private const string USER_KEY = "USER";
        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            session = httpContextAccessor.HttpContext == null ? null : httpContextAccessor.HttpContext.Session;
        }

        public UserSessionDto User
        {
            get
            {
                var value = session == null ? null : session.GetString(USER_KEY);
                if (value!= null)
                {
                    return JsonConvert.DeserializeObject<UserSessionDto>(value);
                }
                else
                {
                    return null;
                }
            }
            set
            {
                session.SetString(USER_KEY, JsonConvert.SerializeObject(value));
            }
        }
    }
}
