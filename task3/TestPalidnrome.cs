using NUnit.Framework;
using PalindromeNamespace;

public class TestPalindrome
{
    [Test]
    public void TestIsPalindrome_ValidPalindromes()
    {
        Assert.IsTrue(PalindromeChecker.IsPalindrome("aba"));
        Assert.IsTrue(PalindromeChecker.IsPalindrome("A man a plan a canal Panama"));
        Assert.IsTrue(PalindromeChecker.IsPalindrome("Was it a car or a cat I saw?"));
    }

    [Test]
    public void TestIsPalindrome_InvalidPalindromes()
    {
        Assert.IsFalse(PalindromeChecker.IsPalindrome("hello"));
        Assert.IsFalse(PalindromeChecker.IsPalindrome("racecar1"));
        Assert.IsFalse(PalindromeChecker.IsPalindrome("not a palindrome"));
    }
}
