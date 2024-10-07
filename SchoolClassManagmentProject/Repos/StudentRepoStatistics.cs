namespace SchoolClassManagmentProject.Repos
{
    public partial class StudentRepo
    {
        public int NumberOfStudentsWithoutEmail => StudentsWithoutEmail.Count;
        public int NumberOfAdultStudents => AdultStudents.Count;
    }
}
