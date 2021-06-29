using BxlForm.DemoSecurity.Mvc.Models.Client.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BxlForm.DemoSecurity.Mvc.Models.Client.Repositories
{
    public interface IContactRepository
    {
        IEnumerable<Contact> Get();
        Contact Get(int id);
        void Insert(Contact contact);
        void Update(int id, Contact contact);
        void Delete(int id);
    }
}
