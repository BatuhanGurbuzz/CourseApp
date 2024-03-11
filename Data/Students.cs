using System.ComponentModel.DataAnnotations;

namespace CourseApp.Data
{
    public class Student{
        [Key]
        public int studentID{ get; set; }

        public string? studentName { get; set; }
        public string? studentSurname { get; set; }
        public string? studentMail { get; set; }
        public string? studentPhone { get; set; }
    }
}