using SchoolClassManagmentProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClassManagmentProject.Repos
{
    public partial class StudentRepo
    {
        public List<Student> StudentsWithoutEmail => _students.Where(s => s.Email == null)?.ToList() ?? new List<Student>();
        public Dictionary<string, int> NumberOfMalesAndFemales() =>
            new Dictionary<string, int>() {
                { "males", _students.Where(s => s.Gender).Count() },
                { "females", _students.Where(s => !s.Gender).Count() }
            };
        public List<Student> AdultStudents => _students.Where(s => s.Age >= 18).ToList();
        public List<Student> StudentsBornInYear(int year) => _students.Where(s => s.BirthDate.Year == year).ToList();
        public List<Student> StudentsBornInMonth(int month) => _students.Where(s => s.BirthDate.Month == month).ToList();
        public Dictionary<int, List<Student>> GetStudentsByBirthYear(int year)
        {
            Dictionary<int, List<Student>> result = new Dictionary<int, List<Student>>();
            foreach (var s in _students)
            {
                int birthYear = s.BirthDate.Year;
                if (result.Keys.Contains(birthYear))
                    result[birthYear].Add(s);
                else
                    result[birthYear] = new List<Student>();
            }

            return result;
        }
    }
}
