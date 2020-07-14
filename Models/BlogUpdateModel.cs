using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace WorksBlogProjectClient.Models{
    public class BlogUpdateModel{
        public int Id {get;set;}
        public int AppUserId { get; set; }

        [Required(ErrorMessage="Blog Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage="Short description is required")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage="Description is required")]
        public string Description { get; set; }
        public IFormFile FormFile { get; set; }
    }
}