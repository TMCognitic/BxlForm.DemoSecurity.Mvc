using BxlForm.DemoSecurity.Mvc.Areas.Admin.Infrastructure.Security;
using BxlForm.DemoSecurity.Mvc.Areas.Admin.Models.Forms;
using BxlForm.DemoSecurity.Mvc.Models.Client.Data;
using BxlForm.DemoSecurity.Mvc.Models.Client.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BxlForm.DemoSecurity.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminRequired]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryService;

        public CategoryController(ICategoryRepository categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: CategoryController
        public ActionResult Index()
        {
            IEnumerable<DisplayCategory> categories = _categoryService.Get().Select(c => new DisplayCategory() { Id = c.Id, Name = c.Name });

            return View(categories);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCategoryForm form)
        {
            if (!ModelState.IsValid)
                return View(form);

            _categoryService.Insert(new Category(form.Name));
            return RedirectToAction("Index");
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            Category category = _categoryService.Get(id);

            if(category is null)
            {
                return RedirectToAction("Index");
            }

            return View(new EditCategoryForm() { Id = category.Id, Name = category.Name });
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditCategoryForm form)
        {
            if (!ModelState.IsValid)
                return View(form);

            _categoryService.Update(id, new Category(form.Name));
            return RedirectToAction("Index");
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            Category category = _categoryService.Get(id);

            if (category is null)
            {
                return RedirectToAction("Index");
            }

            return View(new DisplayCategory() { Id = category.Id, Name = category.Name });
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _categoryService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
