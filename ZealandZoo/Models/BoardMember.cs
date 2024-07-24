using System.ComponentModel.DataAnnotations;

namespace ZealandZoo.Models
{
    public class BoardMember
    {
        public int BoardMemberId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Description { get; set; } = " ";

        public string AreaOfResponsibility { get; set; } = " ";

        [Required]
        public string StudyProgramme { get; set; }

        [Required]
        public int Semester { get; set; }

        public string ImageFileName { get; set; } = "/images/Flamingo.jpg";

    }
}
