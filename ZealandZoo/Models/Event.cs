using System.ComponentModel.DataAnnotations;

namespace ZealandZoo.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public string Subject { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "The date is required")]
        [Range(typeof(DateTime), "23/7/2024", "30/6/2026", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime Start { get; set; }

        [Required(ErrorMessage = "The date is required")]
        [Range(typeof(DateTime), "24/7/2024", "30/6/2026", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime End { get; set; }

        public string ThemeColor { get; set; }

        public bool IsFullDay { get; set; }
    }
}
