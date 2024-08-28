using Studentportal.Models.Entities;

namespace Studentportal.Models
{
    public class AddStudentViewModel
    {
        public AddStudentViewModel StudentForm { get; set; }
        public List<Student> StudentList { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public bool Subscribed { get; set; }
    }
}
