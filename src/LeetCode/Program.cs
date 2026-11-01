using LeetCode.Problems;

string choice = args.Length > 0 ? args[0] : "2";   // default = latest

switch (choice)
{
    case "1": _001_TwoSum.Run(); break;
    case "2": _002_AddTwoNumbers.Run(); break;
    case "3": _003_LongestSubstringWithoutRepeatingCharacters.Run(); break;
    case "4": _004_MedianOfTwoSortedArrays.Run(); break;
    default: Console.WriteLine("Problem not found"); break;
}