using LeetCode.Problems;

string choice = args.Length > 0 ? args[0] : "2";   // default = latest

switch (choice)
{
    case "1": _001_TwoSum.Run(); break;
    case "2": _002_AddTwoNumbers.Run(); break;
    case "3": _003_LongestSubstringWithoutRepeatingCharacters.Run(); break;
    case "4": _004_MedianOfTwoSortedArrays.Run(); break;
    case "5": _005_LongestPalindromicSubstring.Run(); break;
    case "6": _006_ZigZagConversion.Run(); break;
    case "7": _007_ReverseInteger.Run(); break;
    case "8": _008_StringToInteger.Run(); break;
    case "9": _009_PalindromeNumber.Run(); break;
    case "10": _010_RegularExpressionMatching.Run(); break;

    default: Console.WriteLine("Problem not found"); break;
}