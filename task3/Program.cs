using System.Text.RegularExpressions;

namespace PalindromeNamespace
{
    public static class PalindromeChecker
    {
        public static bool IsPalindrome(string checkedString)
        {
            string cleanString = checkedString.ToUpper();
            cleanString = cleanString.Replace(" ", string.Empty);
            cleanString = Regex.Replace(cleanString, @"\W", "");
            int start = 0;
            int end = cleanString.Length - 1;
            while (start < end)
            {
                if (cleanString[start] == cleanString[end])
                {
                    start++;
                    end--;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
