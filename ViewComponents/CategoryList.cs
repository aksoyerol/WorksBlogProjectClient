using Microsoft.AspNetCore.Mvc;
using WorksBlogProjectClient.ApiServices.Interfaces;

namespace WorksBlogProjectClient.ViewComponents
{
    public class CategoryList : ViewComponent
    {
        private readonly ICategoryApiService _categoryApiService;
        public CategoryList(ICategoryApiService categoryApiService)
        {
            _categoryApiService = categoryApiService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_categoryApiService.GetAllWithBlogsCount().Result);
        }

    }
}