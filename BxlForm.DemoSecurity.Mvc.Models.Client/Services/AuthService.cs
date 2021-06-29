using BxlForm.DemoSecurity.Mvc.Models.Client.Data;
using BxlForm.DemoSecurity.Mvc.Models.Client.Mappers;
using BxlForm.DemoSecurity.Mvc.Models.Client.Repositories;
using GR = BxlForm.DemoSecurity.Mvc.Models.Global.Repositories;

namespace BxlForm.DemoSecurity.Mvc.Models.Client.Services
{
    public class AuthService : IAuthRepository
    {
        public readonly GR.IAuthRepository _globalRepository;

        public AuthService(GR.IAuthRepository globalRepository)
        {
            _globalRepository = globalRepository;
        }

        public User Login(string email, string passwd)
        {
            return _globalRepository.Login(email, passwd)?.ToClient();
        }

        public void Register(User user)
        {
            _globalRepository.Register(user.ToGlobal());
        }
    }
}
