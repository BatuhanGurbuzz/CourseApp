using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CourseApp.Data
{
    public class Student{
        [Key]
        [Display(Name = "Öğrenci ID")]
        public int studentID{ get; set; }

        [Display(Name = "Öğrenci Adı")]
        public string? studentName { get; set; }

        [Display(Name = "Öğrenci Soyadı")]
        public string? studentSurname { get; set; }

        [Display(Name = "Öğrenci E Posta Adresi")]
        public string? studentMail { get; set; }

        [Display(Name = "Öğrenci Telefon Numarası")]
        public string? studentPhone { get; set; }
    }
}