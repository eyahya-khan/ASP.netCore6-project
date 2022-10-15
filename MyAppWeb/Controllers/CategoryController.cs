using Microsoft.AspNetCore.Mvc;
using MyApp.DataAccessLayer;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyAppModels;

namespace MyAppWeb.Controllers
{
    public class CategoryController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = _unitOfWork.Category.GetAll();
            
            return View(categories);
        }
        
        //create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(category);
                _unitOfWork.Save();
                TempData["success"] = "Category created successfully.";
                return RedirectToAction("Index");
            }
            return View();
        }

        //edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null || id==0)
            {
                return NotFound();
            }
            var category = _unitOfWork.Category.GetT(x=>x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(category);
                _unitOfWork.Save();
                TempData["success"] = "Category updated successfully.";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        //delete
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _unitOfWork.Category.GetT(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteData(int? id)
        {
            var category = _unitOfWork.Category.GetT(x => x.Id == id);
            if(category == null)
            {   
               return NotFound();
            }
            _unitOfWork.Category.Delete(category);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
