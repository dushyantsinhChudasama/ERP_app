using System.ComponentModel.DataAnnotations;

namespace ERP_Demo.Models
{
    public class Student
    {
        [Key]
        public int Student_roll { get; set; }

        [Required(ErrorMessage ="Name is required")]
        public string Student_name { get; set; }

        [Required(ErrorMessage ="Enter the date of birth")]
        public DateOnly DOB { get; set; }

        [Required(ErrorMessage = "Enter the date of birth")]
        public string gender { get; set; }

        [Required(ErrorMessage ="Enter age")]
        [Range(18,45)]
        public int Age { get;set; }
    }
}
