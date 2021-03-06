using System;
using System.Collections.Generic;
using System.Text;

namespace BxlForm.DemoSecurity.Mvc.Models.Global.Data
{
    public class User
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Passwd { get; set; }
        public bool IsAdmin { get; set; }
        public string Token { get; set; }
    }
}
