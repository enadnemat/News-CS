using Microsoft.AspNetCore.Mvc;
using News.Data;
using News.Models;

namespace News.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _db;  
        public CategoryController(ApplicationDBContext bd)
        {
            _db = bd;
        }

        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
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
                _db.Categories.Add(obj);
                _db.SaveChanges();
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
            Category? category = _db.Categories.Find(id);
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
                _db.Categories.Update(obj);
                _db.SaveChanges();
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
            Category? category = _db.Categories.Find(id);
    

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? category = _db.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }   

            _db.Categories.Remove(category);
            _db.SaveChanges();
            TempData["success"] = "Category has been deleted successfully";

            return RedirectToAction("Index");
        }
    }
}
