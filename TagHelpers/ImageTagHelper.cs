using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using WorksBlogProjectClient.ApiServices.Interfaces;

namespace WorksBlogProjectClient.TagHelpers
{
    [HtmlTargetElement("getblogimage")]
    public class ImageTagHelper : TagHelper
    {
        private readonly IImageApiService _imageApiService;
        public ImageTagHelper(IImageApiService imageApiService)
        {
            _imageApiService = imageApiService;
        }
        public int Id { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var blob = await _imageApiService.GetBlogByImageId(Id);
            var html = $"<img class='card-img-top' src='{blob}' >";
            output.Content.SetHtmlContent(html);
        }
    }
}