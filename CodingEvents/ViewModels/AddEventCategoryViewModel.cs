using System.ComponentModel.DataAnnotations;

namespace CodingEvents.ViewModels
{
    public class AddEventCategoryViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage ="Category name must be between 3 and 20 characters")]
        public string? Name { get; set; }
    }
}
