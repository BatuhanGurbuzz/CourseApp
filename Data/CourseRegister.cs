using System.ComponentModel.DataAnnotations;

namespace CourseApp.Data{
    public class CourseRegister{

        [Key]
        public int courseRegisterID { get; set; }

        public int studentID { get; set; }

        public int courseID { get; set; }

        public DateTime courseRegisterDate { get; set; }
    }
}