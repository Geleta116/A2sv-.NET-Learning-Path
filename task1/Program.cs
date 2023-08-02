using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace StudentScoreNamespace
{
    public class StudentScoreCalculator
    {
        public static bool StringValidator(string? currString)
        {
            if (currString != null)
            {
                return Regex.IsMatch(currString, @"^[a-zA-Z]+$");
            }
            else
            {
                return false;
            }
        }

        public static double AverageCalculator(object[,] scores)
        {
            double totalScore = 0;
            for (int i = 0; i < scores.GetLength(0); i++)
            {
                totalScore += (double)scores[i, 1];
            }
            return totalScore / scores.GetLength(0);
        }

        public static bool ScoreValidator(string? currScore)
        {
            bool isScoreDouble = double.TryParse(currScore, out double score);
            if (isScoreDouble)
            {
                if (score >= 0 && score <= 100)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter your name? ");
            string? studentName = Console.ReadLine();

            bool foundError = false;

            if (StringValidator(studentName))
            {
                Console.WriteLine($"Hi {studentName}, Please Enter the number of subjects that you have taken? ");
                string? numberOfSubjectsEntered = Console.ReadLine();
                if (int.TryParse(numberOfSubjectsEntered, out int numberOfSubjects))
                {
                    object[,] scores = new object[numberOfSubjects, 2];
                    for (int subjectId = 0; subjectId < numberOfSubjects; subjectId++)
                    {
                        Console.WriteLine("Please Enter the course name: ");
                        string? courseName = Console.ReadLine();
                        if (StringValidator(courseName))
                        {
                            Console.WriteLine($"Please Enter your score for {courseName}: ");
                            string? courseScoreEntered = Console.ReadLine();

                            if (ScoreValidator(courseScoreEntered))
                            {

                                scores[subjectId, 0] = courseName;
                                scores[subjectId, 1] = double.Parse(courseScoreEntered);
                            }
                            else
                            {
                                Console.WriteLine("Invalid Course Score");
                                foundError = true;
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid course name");
                            foundError = true;
                            break;
                        }
                    }
                    if (!foundError)
                    {
                        double studentAverage = AverageCalculator(scores);
                        Console.WriteLine($"{studentName}, You  have taken {scores.GetLength(0)} courses");
                        Console.WriteLine($"The courses name are as follows: ");
                        for (int i = 0; i < scores.GetLength(0); i++)
                        {
                            Console.WriteLine($"{scores[i, 0]}: {scores[i, 1]}");

                        }
                        Console.WriteLine($"Your average score is {studentAverage}");

                    }
                }
                else
                {
                    Console.WriteLine("Invalid number of subjects");
                }
            }
            else
            {
                Console.WriteLine("Invalid Name");
            }
        }
    }
}
