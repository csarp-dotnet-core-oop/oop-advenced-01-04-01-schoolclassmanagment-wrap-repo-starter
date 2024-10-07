using SchoolClassManagmentProject.Models.Entities;

namespace SchoolClassManagmentProject.Repos
{
    public partial class StudentRepo
    {
        private List<Student> _students;

        public StudentRepo()
        {
            _students = new List<Student>();
        }

        public void Add(Student student) => _students.Add(student);
        public void Remove(Student student) => _students.Remove(student);
        public void Modify(Student student) {
            Student? studentToModify = _students.Find(s => s.FirstName == student.FirstName && s.LastName == student.LastName);

            if (studentToModify is not null)
            {
                studentToModify.SetEmail(student.Email);
                studentToModify.SetPhone(student.Phone);
                studentToModify.Gender = student.Gender;
            }
        }
        

        public void SetFirstName(string firstName, string lastName, string newFirstName)
        {
            Student? studentToModify = _students.Find(s => s.FirstName == firstName && s.LastName == lastName);

            if (studentToModify is not null)
                studentToModify.FirstName = newFirstName;
        }

        public void RemoveStudentWithMatchingName(string firstName, string lastName)
        {
            Student? studentToRemove = _students.Find(s => s.FirstName == firstName && s.LastName == lastName);
            Remove(studentToRemove);
        }
    }
}
