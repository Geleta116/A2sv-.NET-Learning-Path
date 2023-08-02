using NUnit.Framework;
using StudentScoreNamespace;

public class TestStudentScore
{
    [Test]
    public void TestStringValidator_ValidStrings()
    {
        Assert.IsTrue(StudentScoreCalculator.StringValidator("JohnDoe"));
        Assert.IsTrue(StudentScoreCalculator.StringValidator("Alice"));
    }

    // Add more test cases for StringValidator

    [Test]
    public void TestAverageCalculator_ValidScores()
    {
        
        object[,] scores = { { "Math", 90 }, { "English", 85 }, { "Science", 78 } };

        double expectedAverage = (90 + 85 + 78) / 3.0;
        Assert.AreEqual(expectedAverage,StudentScoreCalculator.AverageCalculator(scores));
    }

        // Add more test cases for AverageCalculator

        [Test]
        public void TestScoreValidator_ValidScores()
        {

            Assert.IsTrue(StudentScoreCalculator.ScoreValidator("90"));
            Assert.IsTrue(StudentScoreCalculator.ScoreValidator("50.5"));
        }

        // Add more test cases for ScoreValidator
    }
