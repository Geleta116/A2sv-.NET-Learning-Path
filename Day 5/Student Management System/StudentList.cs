using System;
using System.Text.Json;

public class StudentList<T> where T : Student
{
    private List<T> studentList = new List<T>();

    public async Task AddStudent(T student)
    {
        try{
        
        int? rollnumber = student.RollNumber;
        
        
        if (rollnumber != null)
        {
            Student? studentExists = await GetStudentByRollNumber((int)rollnumber);
            if (studentExists != null)
            {
                Console.WriteLine();
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>");
                Console.WriteLine("Student already exists");
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>");
            }
            else
            {
                try
                {
                    studentList.Add(student);
                    await SaveStudentsToFile();
                    Console.WriteLine("...............................");
                    Console.WriteLine("Student registered successfully");
                    Console.WriteLine("...............................");
                }
                catch (Exception)
                {
                    Console.WriteLine("An error occurred while adding the student");
                }
            }
        }
        else
        {
            Console.WriteLine("INVALID ROLLNUMBER");
        }
        }
        catch(Exception e){
            Console.WriteLine(e);
        }
    }
    public async Task<List<T>> GetAllStudents()
    {
        await ReadStudentsToList();
        return studentList;
    }
    public async Task<T?> GetStudentByName(string name)
    {
        await ReadStudentsToList();

        T? student = (from s in studentList
                     where s.Name == name
                     select s).FirstOrDefault();
        return student;
    }
    public async Task<T?> GetStudentByRollNumber(int rollNumber)
    {
        try{
        await ReadStudentsToList();

        T? student = (from s in studentList
                     where s.RollNumber == rollNumber
                     select s).FirstOrDefault();
        return student;
        }
        catch(Exception e){
            Console.WriteLine(e);
            return null;
        }
    }
    public async Task DeleteStudent(int? rollNumber)
    {
        await ReadStudentsToList();

        if (rollNumber != null)
        {
            if (await GetStudentByRollNumber((int)rollNumber) is Student foundStudent)
            {
                T studentToRemove = (T)(object)foundStudent;
                studentList.Remove(studentToRemove);
                await SaveStudentsToFile();
                Console.WriteLine("Student removed successfully");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
        else
        {
            Console.WriteLine("INVALID ROLLNUMBER");
        }
    }
    private async Task SaveStudentsToFile()
    {
        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string fileName = "student.data.json";
            var jsonList = studentList.Select(student => new
            {
                student.Name,
                student.Age,
                RollNumber = student.RollNumber,
                student.Grade
            });
            string jsonString = JsonSerializer.Serialize(jsonList, options);
            await File.WriteAllTextAsync(fileName, jsonString);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error occurred while saving the student: " + ex.Message);
            
        }
    }
    private async Task ReadStudentsToList()
    {
        try
        {
            var text = await File.ReadAllTextAsync("student.data.json");
            var jsonDocument = JsonDocument.Parse(text);
            studentList.Clear();

            foreach (var jsonElement in jsonDocument.RootElement.EnumerateArray())
            {
                var name = jsonElement.GetProperty("Name").GetString();
                var age = jsonElement.GetProperty("Age").GetInt32();
                var rollNumber = jsonElement.GetProperty("RollNumber").GetInt32();
                var grade = jsonElement.GetProperty("Grade").GetString();

                var student = new Student
                (
                    name : name,
                    age : age,
                    rollNumber : rollNumber,
                    grade : char.Parse(grade)
                );
                
                studentList.Add((T)student);
            }
        }
        catch (Exception ex)
        {
            
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
   