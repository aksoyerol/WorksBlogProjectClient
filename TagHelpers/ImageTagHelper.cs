using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using WorksBlogProjectClient.ApiServices.Interfaces;
using WorksBlogProjectClient.Enums;

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
        public ImageShowMode ImageShowMode { get; set; } = ImageShowMode.Home;
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var blob = await _imageApiService.GetBlogByImageId(Id);
            string html = string.Empty;
            if (ImageShowMode == ImageShowMode.Detail)
            {
                html = $"<img class='img-fluid rounded' src='{blob}' >";
            }
            else
            {
                html = $"<img class='card-img-top' src='{blob}' >";
            }

            output.Content.SetHtmlContent(html);
        }
    }
}