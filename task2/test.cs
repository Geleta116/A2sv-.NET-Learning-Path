using System.Collections.Generic;
using NUnit.Framework;
using WordFrequencyNamespace;

public class TestWordFrequency
{
    [Test]
    public void TestCountFrequency_ValidPhrase()
    {
        WordFrequencyCounter counter = new WordFrequencyCounter();
        string phrase = "hey hey hey";
        Dictionary<string, int> result = counter.CountFrequency(phrase);

        Assert.AreEqual(1, result["HEY"]);
        Assert.AreEqual(2, result.Count);
    }

    [Test]
    public void TestCountFrequency_EmptyPhrase()
    {
        WordFrequencyCounter counter = new WordFrequencyCounter();
        string phrase = "";
        Dictionary<string, int> result = counter.CountFrequency(phrase);

        Assert.IsEmpty(result);
    }

 
}
