namespace BxlForm.DemoSecurity.Mvc.Infrastructure.Session
{
    public interface ISessionManager
    {
        UserSession User { get; set; }
        void Clear();
    }
}