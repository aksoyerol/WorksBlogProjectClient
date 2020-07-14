using System.ComponentModel.DataAnnotations;

namespace WorksBlogProjectClient.Models
{
    public class CategoryUpdateModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Category name area is required")]
        public string Name { get; set; }
    }
}