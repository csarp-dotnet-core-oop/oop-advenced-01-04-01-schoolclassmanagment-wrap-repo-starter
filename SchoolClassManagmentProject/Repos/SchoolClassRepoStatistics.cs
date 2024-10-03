using SchoolClassManagmentProject.Models.Entities;

namespace SchoolClassManagmentProject.Repos
{
    public partial class SchoolClassRepo
    {
        // egy osztály különböző fájlokban
        public int NumberOfSchoolClasses => _schoolClasses.Count;
        public int NumberOfGraduateClasses => _schoolClasses.Count(schoolClass => schoolClass.IsGraduate);
        public int GetNumberOfSchoolClassesPerGrade(int grade)
        {
            return GetSchoolClassesPerGrade(grade).Count;
        }
        public int GetClassMoneyPerStudentInOneYear(int grade, char gradeLetter)
        {
            return 10 * _schoolClasses.Find(schoolClass => schoolClass.Grade == grade && schoolClass.GradeLetter == gradeLetter)?.ClassMoney ?? -1; // default(int);
        }

        public Dictionary<byte, int> GetSchoolClassCountByGrade()
        {
            Dictionary<byte, int> gradeCount = new Dictionary<byte, int>();
            /*
            foreach(SchoolClass schoolClass in _schoolClasses )
            {
                if (gradeCount.ContainsKey(schoolClass.Grade))
                    gradeCount[schoolClass.Grade]++;
                else
                    //gradeCount[schoolClass.Grade] = 1;
                    gradeCount.Add(schoolClass.Grade, 1);
            }
            return gradeCount;
            */
            return _schoolClasses
                .GroupBy(schoolClass => schoolClass.Grade)
                .ToDictionary(g => g.Key,g=>g.Count());

        }
    }
}
