using Microsoft.AspNetCore.Mvc;
using News.DataAccess.Data;
using News.DataAccess.Repository.IRepository;
using News.Models;

namespace News.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _category;
        public CategoryController(ICategoryRepository bd)
        {
            _category = bd;
        }

        public IActionResult Index()
        {
                List<Category> objCategoryList = _category.GetAll().ToList();
                return View(objCategoryList);
        }

        public IActionResult Create ()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _category.Add(obj);
                _category.Save();
                TempData["success"] = "Category has been created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null) 
            { 
                return NotFound();
            }
            Category? category = _category.Get(u => u.Id == id);
           // Category? category2 = _db.Categories.FirstOrDefault(c => c.Id == id);
           // Category? category3 = _db.Categories.Where(c => c.Id == id).FirstOrDefault();

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _category.Update(obj);
                _category.Save();
                TempData["success"] = "Category has been updated successfully";

                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Category? category = _category.Get(u=> u.Id == id);
     

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? category = _category.Get(u => u.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            _category.Delete(category);
            _category.Save();
            TempData["success"] = "Category has been deleted successfully";

            return RedirectToAction("Index");
        }
    }
}
