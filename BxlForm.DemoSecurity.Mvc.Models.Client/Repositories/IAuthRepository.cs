using BxlForm.DemoSecurity.Mvc.Models.Client.Data;

namespace BxlForm.DemoSecurity.Mvc.Models.Client.Repositories
{
    public interface IAuthRepository
    {
        User Login(string email, string passwd);
        void Register(User user);
    }
}
