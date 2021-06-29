using BxlForm.DemoSecurity.Mvc.Models.Global.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BxlForm.DemoSecurity.Mvc.Models.Global.Repositories
{
    public interface IAuthRepository
    {
        User Login(string email, string passwd);
        void Register(User user);
    }
}
