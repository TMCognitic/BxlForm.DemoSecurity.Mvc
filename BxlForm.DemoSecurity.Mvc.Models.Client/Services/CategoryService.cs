using BxlForm.DemoSecurity.Mvc.Models.Client.Data;
using BxlForm.DemoSecurity.Mvc.Models.Client.Mappers;
using BxlForm.DemoSecurity.Mvc.Models.Client.Repositories;
using GR = BxlForm.DemoSecurity.Mvc.Models.Global.Repositories;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;


namespace BxlForm.DemoSecurity.Mvc.Models.Client.Services
{
    public class CategoryService : ICategoryRepository
    {
        private readonly GR.ICategoryRepository _categoryRepository;

        public CategoryService(GR.ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }        

        public IEnumerable<Category> Get()
        {
            return _categoryRepository.Get().Select(c => c.ToClient());
        }

        public Category Get(int id)
        {
            return _categoryRepository.Get(id)?.ToClient();
        }

        public bool Insert(Category category)
        {
            return _categoryRepository.Insert(category.ToGlobal());
        }

        public bool Update(int id, Category category)
        {
            return _categoryRepository.Update(id, category.ToGlobal());
        }

        public bool Delete(int id)
        {
            return _categoryRepository.Delete(id);
        }
    }
}
