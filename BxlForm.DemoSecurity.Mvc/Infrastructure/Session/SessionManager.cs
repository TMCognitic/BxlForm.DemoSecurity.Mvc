using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace BxlForm.DemoSecurity.Mvc.Infrastructure.Session
{
    public class SessionManager : ISessionManager
    {
        private readonly ISession _session;

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }

        public UserSession User
        {
            set { _session.SetString(nameof(User), JsonSerializer.Serialize(value)); }
            get
            {
                string json = _session.GetString(nameof(User));
                return (json is null) ? null : JsonSerializer.Deserialize<UserSession>(json);                
            }
        }

        public void Clear()
        {
            _session.Clear();
        }
    }
}
