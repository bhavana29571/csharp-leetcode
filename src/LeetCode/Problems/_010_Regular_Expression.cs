// Problem 10: Regular Expression Matching (Hard)

// The question: Check if the string s fully matches the pattern p. Two special characters:

// . matches any one letter
// * means zero or more of the letter before it
// s="aa"   p="a"     → false  (pattern is too short)
// s="aa"   p="a*"    → true   (a* = "aa")
// s="ab"   p=".*"    → true   (.* = anything)
// s="aab"  p="c*a*b" → true   (c* = zero c's, a* = "aa", then b)
// How your DP code works

// The table is a notebook 📒. dp[i, j] answers: “Does s from position i match p from position j?”

// Start: dp[s.Length, p.Length] = true, because both are finished, which is a match.

// Why loop backwards? Each answer depends on later positions, so we fill from the end and those answers are already in the table.

// For each cell, look at the current letters:

// csharp
// var match = i < s.Length && (s[i] == p[j] || p[j] == '.');

// Do the letters match, or is the pattern letter .?

// Case 1: next pattern char is * (like a*). Two choices:

// dp[i, j + 2]: use a* as zero a’s, so skip 2 in the pattern
// match && dp[i + 1, j]: use one a, move s forward, and stay on a*

// If either is true, this cell is true.

// Case 2: no *

// csharp
// dp[i, j] = match && dp[i + 1, j + 1];

// Letters must match, and the rest must match too.

// Answer: dp[0, 0], the start of both strings.

// Small example: s = "aa", p = "a*"
//          j=0 (a)   j=1 (*)   j=2 (end)
// i=0 (a)     T         F          F
// i=1 (a)     T         F          F
// i=2 (end)   T         F          T

// dp[0,0] = true, so it matches ✅

// Reading dp[0,0]: skip a* (needs dp[0,2], false) or use one a and go to dp[1,0] (true). Same story at dp[1,0], which uses dp[2,0] (true), and dp[2,0] is true by skipping a* to reach dp[2,2].

// Repo-ready file with comments

// Problems/_010_RegularExpressionMatching.cs

// csharp
// // 10. Regular Expression Matching (Hard)
// // https://leetcode.com/problems/regular-expression-matching/
// // Time: O(m*n)  Space: O(m*n)



namespace LeetCode.Problems
{
    public class  _010_RegularExpressionMatching
    {
        public bool IsMatch(string s , string p)
        {
            var dp = new bool[s.Length +1 , p.Length +1];

            dp[s.Length,p.Length]=true;

            for(var i=s.Length; i>=0; i--)
                                for (var j = p.Length - 1; j >= 0; j--)

            {
                var match = i<s.Length && (s[i] == p[j] || p[j] == '.');

                if(j+1<p.Length && p[j+1] == '*')

                dp[i,j]=dp[i,j+2] || (match && dp[i+1,j]);

                else

                dp[i,j]=match && dp[i+1,j+1];
            }
            return dp[0,0];
        }
        public static void Run()
        {
            Console.WriteLine("10. Regular Expression matching");

            var s= new _010_RegularExpressionMatching();
             Console.WriteLine(s.IsMatch("aa", "a"));                    // False
            Console.WriteLine(s.IsMatch("aa", "a*"));                   // True
            Console.WriteLine(s.IsMatch("ab", ".*"));                   // True
            Console.WriteLine(s.IsMatch("aab", "c*a*b"));               // True
            Console.WriteLine(s.IsMatch("mississippi", "mis*is*p*."));  // False
        }
    }
}