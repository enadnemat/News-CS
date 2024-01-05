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
                return RedirectToAction("Index");
            }
            return View();

        }

    }
}
