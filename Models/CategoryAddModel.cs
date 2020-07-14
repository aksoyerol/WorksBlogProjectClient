using System.ComponentModel.DataAnnotations;

namespace WorksBlogProjectClient.Models
{
    public class CategoryAddModel
    {
        [Required(ErrorMessage = "Category Name area be required")]
        public string Name { get; set; }
    }
}