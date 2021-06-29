using BxlForm.DemoSecurity.Mvc.Models.Global.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BxlForm.DemoSecurity.Mvc.Models.Global.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Get();
        Category Get(int id);
        bool Insert(Category category);
        bool Update(int id, Category category);
        bool Delete(int id);
    }
}
