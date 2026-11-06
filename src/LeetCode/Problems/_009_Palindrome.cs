// Problem 9: Palindrome Number (Easy)

// 🔗 https://leetcode.com/problems/palindrome-number/

// 📖 The question

// Return true if the number reads the same forwards and backwards.

// Examples:

// 121  → true
// -121 → false   (backwards it's "121-")
// 10   → false   (backwards it's "01")
// 7    → true    (a single digit is always a palindrome)

// 🧠 The idea: reverse it and compare 🪞

// Like holding a number up to a mirror:
// reverse the digits, and if the reverse equals the original, it's a palindrome.

// Reverse using the same pop/push trick from Problem 7:
// digit = temp % 10        (pop the last digit)
// reversed = reversed * 10 + digit   (push it)
// temp = temp / 10         (remove it)

// Quick rules first:
// negative → false (the '-' sign can't match at the end)
// 0 to 9   → true

// Walkthrough for x = 121:

// temp = 121 → digit 1 → reversed = 1
// temp = 12  → digit 2 → reversed = 12
// temp = 1   → digit 1 → reversed = 121
// temp = 0   → stop
// 121 == 121 → true

// 9. Palindrome Number (Easy)
// https://leetcode.com/problems/palindrome-number/
// Time: O(log n)  Space: O(1)



namespace LeetCode.Problems
{
    public class _009_PalindromeNumber
    {
        public bool IsPalindrome(int x)
        {
            if (x<0) return false;
            if (x<10) return true;

            int temp =x;
            long reversed =0;

            while (temp != 0)
            {
                int digit = temp%10;
                reversed = reversed*10 + digit;
                temp /=10;
            }
            return x == reversed;   
            
        }

        public static void Run()
        {
          Console.WriteLine("_009_PalindromeNumber");
            var s = new _009_PalindromeNumber();
            Console.WriteLine(s.IsPalindrome(121));  // Output: true
            Console.WriteLine(s.IsPalindrome(-121)); // Output: false
            Console.WriteLine(s.IsPalindrome(10));   // Output: false
            Console.WriteLine(s.IsPalindrome(7));    // Output: true
        }


    }
}