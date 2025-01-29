using StringExtensions; 

string text = "This is a sample text.";
string TitleCaseText = text.ToTitleCase();
string ReverseStringText = TitleCaseText.ReverseString();
bool IsPalindromeText = ReverseStringText.IsPalindrome();
int WordCountText = ReverseStringText.WordCount();


Console.WriteLine(TitleCaseText);
Console.WriteLine(ReverseStringText);
Console.WriteLine(IsPalindromeText);
Console.WriteLine(WordCountText);

string palindromeText = "racecar";
IsPalindromeText = palindromeText.IsPalindrome();
Console.WriteLine(IsPalindromeText);