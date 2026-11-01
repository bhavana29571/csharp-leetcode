// Problem 5: Longest Palindromic Substring (Medium)

// 🔗 https://leetcode.com/problems/longest-palindromic-substring/

// 📖 The question

// Find the longest part of the string that reads the same forwards and backwards (a palindrome).

// Examples:

// "babad" → "bab"   ("aba" is also correct)
// "cbbd"  → "bb"
// "a"     → "a"
// 🧠 The idea: expand from the middle 🪞

// Every palindrome is a mirror around its center. So stand at each position and stretch outwards to the left and right, as long as both sides match.

// The center can be:

// One letter (odd length): "aba", center = b
// Between two letters (even length): "abba", center = between the two bs

// So we try both at every position.

// Walkthrough for "babad", at index 1 (a):

// a          → match
// b a b      → b == b ✅ expand
// ? bab d    → left side ends → stop
// Palindrome = "bab" (length 3)

// 5. Longest Palindromic Substring (Medium)
// https://leetcode.com/problems/longest-palindromic-substring/
// Time: O(n^2)  Space: O(1)

namespace LeetCode.Problems
{
    public class  _005_LongestPalindromicSubstring
    {
        public string LongestPalindrome(string s)
        {
            if (s.Length <2) return s;

            int start =0 , maxLen=1;


            for(int i=0; i<s.Length; i++)
            {
                int odd = Expand(s ,i, i);       // odd length
                int even = Expand(s,i,i+1);    // even length
                int len  = Math . Max (odd,even);


                if (len > maxLen)
                {
                    maxLen=len;
                    start =i - (len-1)/2;
                }
            }
            return s.Substring(start,maxLen);
        }


        private int Expand(string s , int left , int right)
        {
            while(left >=0 && right < s.Length && s[left]== s[right])
            {
                left--;
                right++;
            }
            return right -left -1;
        }

        public static void Run()
        {
            Console.WriteLine("5. Longest Palindromic Substring");
            var s = new _005_LongestPalindromicSubstring();
            Console.WriteLine(s.LongestPalindrome("babad"));
            Console.WriteLine(s.LongestPalindrome("cbbd"));
            Console.WriteLine(s.LongestPalindrome("a"));
        }
    }
}