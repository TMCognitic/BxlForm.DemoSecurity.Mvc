using BxlForm.DemoSecurity.Mvc.Models.Client.Data;
using System.Collections.Generic;

namespace BxlForm.DemoSecurity.Mvc.Models.Client.Repositories
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
