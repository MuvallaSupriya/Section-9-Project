using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Data
{
    public class Person
    {
        public string Name { get; set; }
        public string ClassAndSection { get; set; }
    }

    public class Student : Person { }

    public class Teacher : Person { }

    public class Subject
    {
        public string Name { get; set; }
        public string SubjectCode { get; set; }
        public Teacher Teacher { get; set; }
    }
    public static class SchoolDatabase
    {
        public static System.Collections.Generic.List<Student> Students { get; } = new System.Collections.Generic.List<Student>();
        public static System.Collections.Generic.List<Teacher> Teachers { get; } = new System.Collections.Generic.List<Teacher>();
        public static System.Collections.Generic.List<Subject> Subjects { get; } = new System.Collections.Generic.List<Subject>();
    }
    class Program
    {

        static void Main()
        {
            SchoolDatabase.Students.Add(new Student { Name = "Student1", ClassAndSection = "ClassA" });
            SchoolDatabase.Students.Add(new Student { Name = "Student2", ClassAndSection = "ClassB" });

            SchoolDatabase.Teachers.Add(new Teacher { Name = "Teacher1", ClassAndSection = "ClassA" });
            SchoolDatabase.Teachers.Add(new Teacher { Name = "Teacher2", ClassAndSection = "ClassB" });
            SchoolDatabase.Subjects.Add(new Subject
            {
                Name = "Math",
                SubjectCode = "M101",
                Teacher = SchoolDatabase.Teachers[0]
            });
            SchoolDatabase.Subjects.Add(new Subject
            {
                Name = "English",
                SubjectCode = "E101",
                Teacher = SchoolDatabase.Teachers[1]
            });

            DisplayStudentsInClass("ClassA");
            DisplaySubjectsTaughtByTeacher(SchoolDatabase.Teachers[0]);

            Console.ReadLine();

        }
        static void DisplayStudentsInClass(string className)
        {
            Console.WriteLine($"Students in {className}:");
            var studentsInClass = SchoolDatabase.Students.Where(s => s.ClassAndSection == className);
            foreach (var student in studentsInClass)
            {
                Console.WriteLine($"{student.Name}");
            }
            Console.WriteLine();
        }
        static void DisplaySubjectsTaughtByTeacher(Teacher teacher)
        {
            Console.WriteLine($"Subjects taught by {teacher.Name} in {teacher.ClassAndSection}:");
            var subjectsTaught = SchoolDatabase.Subjects.Where(s => s.Teacher == teacher);
            foreach (var subject in subjectsTaught)
            {
                Console.WriteLine($"{subject.Name} ({subject.SubjectCode})");
            }
            Console.WriteLine();
        }
    }
}
