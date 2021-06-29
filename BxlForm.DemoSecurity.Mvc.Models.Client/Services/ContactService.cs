using BxlForm.DemoSecurity.Mvc.Models.Client.Data;
using BxlForm.DemoSecurity.Mvc.Models.Client.Mappers;
using BxlForm.DemoSecurity.Mvc.Models.Client.Repositories;
using GR = BxlForm.DemoSecurity.Mvc.Models.Global.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BxlForm.DemoSecurity.Mvc.Models.Client.Services
{
    public class ContactService : IContactRepository
    {
        private readonly GR.IContactRepository _globalRepository;

        public ContactService(GR.IContactRepository globalRepository)
        {
            _globalRepository = globalRepository;
        }

        public IEnumerable<Contact> Get()
        {
            return _globalRepository.Get().Select(c => c.ToClient());
        }

        public Contact Get(int id)
        {
            return _globalRepository.Get(id)?.ToClient();
        }

        public void Insert(Contact contact)
        {
            _globalRepository.Insert(contact.ToGlobal());
        }

        public void Update(int id, Contact contact)
        {
            _globalRepository.Update(id, contact.ToGlobal());
        }

        public void Delete(int id)
        {
            _globalRepository.Delete(id);
        }
    }
}
