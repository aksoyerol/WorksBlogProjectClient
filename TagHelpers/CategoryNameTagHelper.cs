using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using WorksBlogProjectClient.ApiServices.Interfaces;

namespace WorksBlogProjectClient.TagHelpers
{
    [HtmlTargetElement("getcategoryname")]
    public class CategoryNameTagHelper : TagHelper
    {
        private readonly ICategoryApiService _categoryApiService;
        public CategoryNameTagHelper(ICategoryApiService categoryApiService)
        {
            _categoryApiService = categoryApiService;
        }
        public int CategoryId { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var category = await _categoryApiService.GetByIdAsync(CategoryId);
            var htmlContent = $"{category.Name}";
            output.Content.SetContent(htmlContent);
        }
    }
}