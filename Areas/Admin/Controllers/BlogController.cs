using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorksBlogProjectClient.ApiServices.Interfaces;
using WorksBlogProjectClient.Filters;
using WorksBlogProjectClient.Models;

namespace WorksBlogProjectClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {

        private readonly IBlogApiService _blogApiService;
        public BlogController(IBlogApiService blogApiService)
        {
            _blogApiService = blogApiService;
        }

        [JwtAuthorize]
        public async Task<IActionResult> Index()
        {
            ViewData["Active"] = "blog";
            return View(await _blogApiService.GetAllAsync());
        }

        public IActionResult Create()
        {
            ViewData["Active"] = "blog";
            return View(new BlogAddModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogAddModel blogAddModel)
        {
            if (ModelState.IsValid)
            {
                await _blogApiService.InsertAsync(blogAddModel);
                return RedirectToAction("Index", "Blog");
            }
            return View(blogAddModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var updatedBlog = await _blogApiService.GetByIdAsync(id);
            if (updatedBlog != null)
            {
                BlogUpdateModel blogModel = new BlogUpdateModel
                {
                    ShortDescription = updatedBlog.ShortDescription,
                    Title = updatedBlog.Title,
                    Description = updatedBlog.Description,
                    Id = updatedBlog.Id
                };
                return View(blogModel);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BlogUpdateModel blogUpdateModel)
        {
            if (ModelState.IsValid)
            {
                await _blogApiService.UpdateAsync(blogUpdateModel);
                return RedirectToAction("Index", "Blog");
            }
            return View(blogUpdateModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _blogApiService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}