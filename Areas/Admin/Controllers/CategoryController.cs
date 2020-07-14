using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorksBlogProjectClient.ApiServices.Interfaces;
using WorksBlogProjectClient.Filters;
using WorksBlogProjectClient.Models;

namespace WorksBlogProjectClient.Areas.Admin.Controllers
{
    [JwtAuthorize]
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryApiService _categoryApiService;
        public CategoryController(ICategoryApiService categoryApiService)
        {
            _categoryApiService = categoryApiService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Active"] = "category";
            return View(await _categoryApiService.GetAllAsync());
        }

        public IActionResult Create()
        {
            ViewData["Active"] = "category";
            return View(new CategoryAddModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryAddModel categoryAddModel)
        {
            if (ModelState.IsValid)
            {
                await _categoryApiService.InsertAsync(categoryAddModel);
                return RedirectToAction("Index");
            }
            return View(categoryAddModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Active"] = "category";
            var updatedCategory = await _categoryApiService.GetByIdAsync(id);
            if (updatedCategory != null)
            {
                CategoryUpdateModel categoryUpdateModel = new CategoryUpdateModel
                {
                    Id = updatedCategory.Id,
                    Name = updatedCategory.Name
                };
                return View(categoryUpdateModel);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryUpdateModel categoryUpdateModel)
        {
            if (ModelState.IsValid)
            {
                await _categoryApiService.UpdateAsync(categoryUpdateModel);
                return RedirectToAction("Index");
            }
            return View(categoryUpdateModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var deletedCategory = await _categoryApiService.GetByIdAsync(id);
            if (deletedCategory != null)
                await _categoryApiService.DeleteAsync(deletedCategory.Id);

            return RedirectToAction("Index");
        }
    }
}