// Problem 3: Longest Substring Without Repeating Characters (Medium)

// 🔗 https://leetcode.com/problems/longest-substring-without-repeating-characters/

// 📖 The question

// You get a string. Find the length of the longest part (substring) with no repeated letters.

// A substring has to be continuous, with no skipping letters.

// Examples:

// "abcabcbb" → "abc"  → 3
// "bbbbb"    → "b"    → 1
// "pwwkew"   → "wke"  → 3   ("pwke" is not continuous ❌)
// ""         → 0
// 🧠 The idea: sliding window 🪟

// Picture a window sliding over the string:

// The right edge moves forward one letter at a time
// If the new letter is already inside the window, move the left edge just past its old position
// Keep track of the biggest window size you’ve seen

// A dictionary remembers where each letter was last seen.

// Walkthrough for "abcabcbb":

// a       → window "a"    size 1
// ab      → window "ab"   size 2
// abc     → window "abc"  size 3 ⭐
// abca    → 'a' repeats → left jumps → "bca"  size 3
// ...
// Answer = 3

// 3. Longest Substring Without Repeating Characters (Medium)
// https://leetcode.com/problems/longest-substring-without-repeating-characters/
// Time: O(n)  Space: O(k)  k = number of unique characters


namespace LeetCode.Problems
{
    public class _003_LongestSubstringWithoutRepeatingCharacters
    {
        public int LengthofLongestSubstring(string s)
        {
            var lastseen = new Dictionary<char, int>();
            int left = 0, best = 0;

            for (int right = 0; right < s.Length; right++)
            {
                char c = s[right];
                // letter alrady inside the window ? move left pass it 

                if (lastseen.TryGetValue(c, out int prev) && prev >= left)
                {
                    left = prev + 1;
                }

                lastseen[c] = right;
                best = Math.Max(best, right - left + 1);
            }

            return best;
        }

            public static void Run()
            {
                var s = new _003_LongestSubstringWithoutRepeatingCharacters();
                Console.WriteLine(s.LengthofLongestSubstring("abcabcbb"));
                Console.WriteLine(s.LengthofLongestSubstring("bbbbb"));
                Console.WriteLine(s.LengthofLongestSubstring("pwwkew"));
                Console.WriteLine(s.LengthofLongestSubstring(""));
            }
        }
    }








