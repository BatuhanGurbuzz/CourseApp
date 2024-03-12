using System.ComponentModel.DataAnnotations;

namespace CourseApp.Data{
    public class Course{
        [Key]
        [Display(Name = "Kurs ID")]
        public int courseID { get; set; }

        [Display(Name = "Kurs Adı")]
        public string? courseName { get; set; }
    }
}