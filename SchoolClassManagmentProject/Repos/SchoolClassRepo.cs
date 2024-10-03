using SchoolClassManagmentProject.Models.Entities;

namespace SchoolClassManagmentProject.Repos
{
    public partial class SchoolClassRepo
    {
        private List<SchoolClass> _schoolClasses;
        public SchoolClassRepo()
        {
            _schoolClasses = new List<SchoolClass>();
        }
        public void Add(SchoolClass schoolClass)
        {
            _schoolClasses.Add(schoolClass);
        }

        public void Remove(int grade, char gradeLetter)
        {
            SchoolClass? schoolClassToRemove = _schoolClasses.Find(schoolClass => schoolClass.Grade == grade && schoolClass.GradeLetter == gradeLetter);
            if (schoolClassToRemove is not null)
            {
                _schoolClasses.Remove(schoolClassToRemove);
            }
        }

        
    }
}
