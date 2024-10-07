using SchoolClassManagmentProject.Models.AppExceptions;
using SchoolClassManagmentProject.Models.Entities;
using SchoolClassManagmentProject.Repos;

SchoolClass schoolClass9a = new SchoolClass(9, 'a',12);
SchoolClass schoolClass9b = new SchoolClass(9, 'b',13);
SchoolClass schoolClass10a = new SchoolClass(10, 'a', 12);
SchoolClass schoolClass10b = new SchoolClass(10, 'b', 12);

SchoolClass schoolClass12a = new SchoolClass(12, 'a', 12);
SchoolClass schoolClass12b = new SchoolClass(12, 'b', 12);

SchoolClass schoolClass13a = new SchoolClass(13, 'a',13);
SchoolClass schoolClass13b = new SchoolClass(13, 'b',13);

try
{
    schoolClass9a.SetLastGrade(1);
}
catch (LastGradeModificationErrorException lastGradeModificationError)
{
    Console.WriteLine(lastGradeModificationError.ParamName);
    Console.WriteLine(lastGradeModificationError.Message);
}

schoolClass9a.AdvanceGrade();
Console.WriteLine(schoolClass9a.Name);

SchoolClassRepo schoolClassRepo = new SchoolClassRepo();
schoolClass10b.SetClassMoney(1500);
schoolClassRepo.Add(schoolClass9a);
schoolClassRepo.Add(schoolClass9b);
schoolClassRepo.Add(schoolClass10a);
schoolClassRepo.Add(schoolClass10b);
schoolClassRepo.Add(schoolClass12a);
schoolClassRepo.Add(schoolClass12b);
schoolClassRepo.Add(schoolClass13a);
schoolClassRepo.Add(schoolClass13b);

Console.WriteLine($"Iskolában az osztályok száma: {schoolClassRepo.NumberOfSchoolClasses}");
Console.WriteLine($"Iskolában a végzős osztályok száma: {schoolClassRepo.NumberOfGraduateClasses}");

Console.WriteLine("Végzős osztályok:");
List<SchoolClass> gradeteClasses=schoolClassRepo.GetGraduateClasses();
foreach(SchoolClass graduateClass in gradeteClasses)
    Console.WriteLine(graduateClass);



int exsistingClassClassMoneyPerStudentInOneYear = schoolClassRepo.GetClassMoneyPerStudentInOneYear(10, 'b');
Console.WriteLine($"10.a osztáybevétele egy évben egy diák által:{exsistingClassClassMoneyPerStudentInOneYear}");

int nonExsistingClassClassMoneyPerStudentInOneYear = schoolClassRepo.GetClassMoneyPerStudentInOneYear(-1, 'z');
Console.WriteLine($"10.a osztáybevétele egy évben egy diák által:{nonExsistingClassClassMoneyPerStudentInOneYear}");

Console.WriteLine("Diákok osztályonként");
Dictionary<byte, int> gradeCount = schoolClassRepo.GetSchoolClassCountByGrade();

// kulcsokon végigmenni
// foreach (byte grade in gradeCount.Keys) ;

// értékeken végigmennei
// foreach(int count in gradeCount.Values)

/*
foreach(KeyValuePair<byte,int> grade in gradeCount)
    Console.WriteLine($"{grade.Key} évfolyamon {grade.Value} osztály van.");
*/
foreach (var grade in gradeCount)
    Console.WriteLine($"{grade.Key} évfolyamon {grade.Value} osztály van.");

// (StudentRepo)
StudentRepo studentRepo = new();
studentRepo.Add(new("Alma", "Piros", "1@mail.org", "123", DateTime.Now.AddYears(-21).AddMonths(11), true));
studentRepo.Add(new("Körte", "Sárga", "2@mail.org", "456", DateTime.Now.AddYears(-14).AddMonths(9), false));
studentRepo.Add(new("Szilva", "Lila", "3@mail.org", "789", DateTime.Now.AddYears(-8).AddMonths(8), false));
studentRepo.Add(new("Lajos", "Mari", null, "101", DateTime.Now.AddYears(-12).AddMonths(7), true));
studentRepo.Add(new("Nagy", "Melinda", "5@mail.org", "121", DateTime.Now.AddYears(-10).AddMonths(1), true));
studentRepo.Add(new("Dél", "Panni", "6@mail.org", "131", DateTime.Now.AddYears(-13).AddMonths(2), false));
studentRepo.Add(new("Magyar", "Péter", "7@mail.org", "141", DateTime.Now.AddYears(-14).AddMonths(3), true));
studentRepo.Add(new("Németh", "Márton", null, "151", DateTime.Now.AddYears(-17).AddMonths(4), true));
studentRepo.Add(new("Lila", "Virág", "9@mail.org", "161", DateTime.Now.AddYears(-14).AddMonths(10), false));
studentRepo.Add(new("Szép", "Dália", "10@mail.org", "171", DateTime.Now.AddYears(-18).AddMonths(11), false));

Console.WriteLine("E-mail címmel nem rendelkező diákok: ");
foreach (var s in studentRepo.StudentsWithoutEmail)
    Console.WriteLine(" - " + s.HungarianFullName);
Console.WriteLine("E-mail címmel nem rendelkező diákok száma: " + studentRepo.NumberOfStudentsWithoutEmail);
Console.WriteLine("Fiúk: " + studentRepo.NumberOfMalesAndFemales()["males"]);
Console.WriteLine("Lányok: " + studentRepo.NumberOfMalesAndFemales()["females"]);
Console.WriteLine("Felnőtt diákok:");
foreach (var s in studentRepo.AdultStudents)
    Console.WriteLine(" - " + s.HungarianFullName);
Console.WriteLine("Felnőtt diákok száma: " + studentRepo.NumberOfAdultStudents);
Console.WriteLine("2024-ben született diákok:");
foreach (var s in studentRepo.StudentsBornInYear(2024))
    Console.WriteLine(" - " + s.HungarianFullName);
Console.WriteLine("Ebben a hónapban született diákok:");
foreach (var s in studentRepo.StudentsBornInMonth(DateTime.Now.Month))
    Console.WriteLine(" - " + s.HungarianFullName);

Student newStudent = new("Negye", "Dóra", "dorika@mail.org", "987", new DateTime(2001, 5, 2), false);
studentRepo.Add(newStudent);
Console.WriteLine(newStudent.HungarianFullName);
studentRepo.SetFirstName("Dóra", "Negye", "Reide");
Console.WriteLine(newStudent.HungarianFullName);

Console.WriteLine(studentRepo.StudentsBornInMonth(5).Count);
studentRepo.RemoveStudentWithMatchingName("Reide", "Negye"); // Törlés
Console.WriteLine(studentRepo.StudentsBornInMonth(5).Count); 
