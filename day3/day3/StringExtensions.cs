//Create a set of extension methods for the string type that perform common string manipulations. The task is to create the following methods as extension methods:
//ToTitleCase(): Converts a string to title case (capitalizes the first letter of each word).
//ReverseString(): Reverses the characters of the string.
//IsPalindrome(): Checks if the string is a palindrome (reads the same forwards and backwards).
//WordCount(): Counts the number of words in the string (words are separated by spaces). 

using System.Text;

namespace StringExtensions // Replace with your actual namespace
{
    public static class StringExtensions
    {
        public static string ToTitleCase(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;

            StringBuilder result = new StringBuilder();

            for(int i = 0; i < str.Length; i++)
            {
                if (char.IsWhiteSpace(str[i]))
                {
                    result.Append(str[i]);
                    try
                    {
                        result.Append(char.ToUpper(str[++i]));
                    }
                    catch (IndexOutOfRangeException)
                    {
                        break;
                    }
                }
                else if(i == 0)
                {
                    result.Append(char.ToUpper(str[i]));
                }
                else
                {
                    result.Append(char.ToLower(str[i]));
                }
            }

            return result.ToString();
        }

        public static string ReverseString(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;

            StringBuilder result = new StringBuilder();

            for (int i = str.Length - 1; i >= 0; i--)
            {
                result.Append(str[i]);
            }

            return result.ToString();
        }

        public static bool IsPalindrome(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return true;

            str =  str.ToLower();

            int i = 0, j = str.Length - 1;
            while (i < j)
            {
                if (str[i] != str[j])
                {
                    return false;
                }
                i++;
                j--;
            }
            return true;
        }
        public static int WordCount(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return 0;

            str.Trim();
            int WhiteSpaceCount = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsWhiteSpace(str[i]))
                {
                    WhiteSpaceCount++;
                }
            }

            return ++WhiteSpaceCount;
        }
    }
}
