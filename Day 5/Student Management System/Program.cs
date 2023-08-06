using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UserManagementSystem
{
    class Program
    {
        static async Task Main(string[] args)
        {
            StudentList<Student> studentList = new StudentList<Student>();
            bool running = true;
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("WELCOME TO THE STUDENT MANAGEMENT SYSTEM");
            Console.WriteLine("----------------------------------------");

            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("*********");
                Console.WriteLine("MAIN MENU");
                Console.WriteLine("*********");
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine("Please Enter The appropriate Number from the following");
                Console.WriteLine("1.Add Student");
                Console.WriteLine("2.Get All Students");
                Console.WriteLine("3.Get Student By Roll Number");
                Console.WriteLine("4.Get Student By Name");
                Console.WriteLine("5.Delete Student");
                Console.WriteLine("6.Exit");
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine("Enter your choice");
                
                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 0)
                {
                    Console.WriteLine(">>>>>>>>>>>>>>>>>>>>");
                    Console.WriteLine("Invalid Entry");
                    Console.WriteLine(">>>>>>>>>>>>>>>>>>>>");
                    
                }

                switch (choice)
                {
                    case 1:
                        await AddStudentMenu(studentList);
                        break;

                    case 2:
                        await GetAllStudentsMenu(studentList);
                        break;

                    case 3:
                        await GetStudentByRollNumberMenu();
                        break;
                       
                    case 4:
                        await GetStudentByNameMenu();
                        break;

                    case 5:
                        await DeleteStudentMenu();
                        break;
                    case 6:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Please choose again");
                        break;
                }
            }
        }

        private static async Task AddStudentMenu(StudentList<Student> studentList)
        {
            Console.WriteLine();
            Console.WriteLine("Enter Student Name");
            string? name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name) || !Regex.IsMatch(name, @"^[a-zA-Z\s]+$"))
            {
                Console.WriteLine(">>>>>>>>>>>>>");
                Console.WriteLine("Invalid Name");
                Console.WriteLine(">>>>>>>>>>>>>");
                return;
            }
            Console.WriteLine();
            Console.WriteLine("Enter Student Age");
            if (!int.TryParse(Console.ReadLine(), out int age) || age < 0 || age > 100)
            {
                Console.WriteLine(">>>>>>>>>>>>>");
                Console.WriteLine("Invalid Age");
                Console.WriteLine(">>>>>>>>>>>>>");
                return;
            }
            Console.WriteLine();
            Console.WriteLine("Enter Student Roll Number");
            if (!int.TryParse(Console.ReadLine(), out int rollNumber) || rollNumber < 0)
            {
                Console.WriteLine(">>>>>>>>>>>>>");
                Console.WriteLine("Invalid Roll Number");
                Console.WriteLine(">>>>>>>>>>>>>");
                return;
            }
            Console.WriteLine();
            Console.WriteLine("Enter Student Grade");
            if (!char.TryParse(Console.ReadLine(), out char grade))
            {
                Console.WriteLine(">>>>>>>>>>>>>");
                Console.WriteLine("Invalid Grade");
                Console.WriteLine(">>>>>>>>>>>>>");
                return;
            }
            Console.WriteLine();
            Student student = new Student(name: name, age: age,rollNumber: rollNumber, grade: grade);
            await studentList.AddStudent(student);
            

        }

        private static async Task GetAllStudentsMenu(StudentList<Student> studentList)
        {
            Console.WriteLine("************");
            Console.WriteLine("All Students");
            Console.WriteLine("************");
            var students = await studentList.GetAllStudents();
            foreach (var student in students)
            {
                Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Roll Number: {student.RollNumber}, Grade: {student.Grade}");
            }
        }

        private static async Task GetStudentByRollNumberMenu()
        {
            Console.WriteLine("Enter Student Roll Number");
            if (!int.TryParse(Console.ReadLine(), out int rollNumber) || rollNumber < 0)
            {
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>");
                Console.WriteLine("Invalid Roll Number");
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>");
                return;
            }

            StudentList<Student> studentList = new StudentList<Student>();
            Student? student = await studentList.GetStudentByRollNumber(rollNumber);
            if (student != null)
            {
                Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Roll Number: {student.RollNumber}, Grade: {student.Grade}");
            }
            else
            {
                Console.WriteLine("...................");
                Console.WriteLine("Student not found");
                Console.WriteLine("...................");
            }
        }

        private static async Task GetStudentByNameMenu()
        {
            Console.WriteLine("Enter Student Name");
            string? name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name) || !Regex.IsMatch(name, @"^[a-zA-Z\s]+$"))
            {
                Console.WriteLine(">>>>>>>>>>>>>");
                Console.WriteLine("Invalid Name");
                Console.WriteLine(">>>>>>>>>>>>>");
                return;
            }

            StudentList<Student> studentList = new StudentList<Student>();
            Student? student = await studentList.GetStudentByName(name);
            if (student != null)
            {
                Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Roll Number: {student.RollNumber}, Grade: {student.Grade}");
            }
            else
            {
                Console.WriteLine(".................");
                Console.WriteLine("Student not found");
                Console.WriteLine(".................");
            }
        }

        private static async Task DeleteStudentMenu()
        {
            Console.WriteLine("Enter Student Roll Number");
            if (!int.TryParse(Console.ReadLine(), out int rollNumber) || rollNumber < 0)
            {
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>");
                Console.WriteLine("Invalid Roll Number");
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>");
                return;
            }

            StudentList<Student> studentList = new StudentList<Student>();
            await studentList.DeleteStudent(rollNumber);
        }



    }

}
