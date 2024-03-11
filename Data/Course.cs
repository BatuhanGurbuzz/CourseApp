using System.ComponentModel.DataAnnotations;

namespace CourseApp.Data{
    public class Course{
        [Key]
        public int courseID { get; set; }

        public string? courseName { get; set; }
    }
}