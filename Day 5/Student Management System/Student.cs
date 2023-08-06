using System.Text.Json.Serialization;

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }

    [JsonPropertyName("RollNumber")]
    public readonly int RollNumber;
    
    public char Grade { get; set; }

    [JsonConstructor]
    public Student(string name, int age, int rollNumber, char grade)
    {
        Name = name;
        Age = age;
        RollNumber = rollNumber; 
        Grade = grade;
    }

  
}
