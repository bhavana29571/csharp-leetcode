// Problem 8: String to Integer (atoi) (Medium)

// 🔗 https://leetcode.com/problems/string-to-integer-atoi/

// 📖 The question

// Convert a string to a 32-bit integer, step by step:
// 1. Skip the leading spaces
// 2. Read an optional sign: '+' or '-'
// 3. Read digits until a non-digit appears (or the string ends)
// 4. If the number goes outside the int range, clamp it:
//    too big   → int.MaxValue ( 2147483647)
//    too small → int.MinValue (-2147483648)
// If no digits are found, return 0.

// Examples:

// "42"              → 42
// "   -42"          → -42
// "4193 with words" → 4193      (stops at the space)
// "words and 987"   → 0         (the first character isn't a digit)
// "-91283472332"    → -2147483648 (too small, clamped)

// 🧠 The idea: read it like a cashier 🧾

// A cashier reading a messy receipt:
// skips the blank space, notes whether it's minus or plus,
// reads digits one by one, and stops at the first letter.
// If the amount is too big for the machine, it shows the max.

// Building the number from digits:
// result = result * 10 + digit

// Overflow check BEFORE adding a digit:
// int.MaxValue = 2147483647
// head = 214748364 (MaxValue / 10), tail = 7 (MaxValue % 10)
// if result > head, OR result == head and digit > 7 → overflow

// Walkthrough for "   -42":

// "   "  → skip the spaces
// "-"    → negative = true
// "4"    → result = 0*10 + 4  = 4
// "2"    → result = 4*10 + 2  = 42
// end    → return -42

// 8. String to Integer (atoi) (Medium)
// https://leetcode.com/problems/string-to-integer-atoi/
// Time: O(n)  Space: O(1)






namespace LeetCode.Problems
{
    public class _008_StringToInteger
    {
        public int MyAtoi(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return 0;

            bool negative = false;
            int index = 0;

            // 1. Skip the spaces
            while (index < str.Length && str[index] == ' ')
                index++;

            // 2. Read the sign
            if (str[index] == '-')
            {
                negative = true;
                index++;
            }
            else if (str[index] == '+')
            {
                index++;
            }

            int overflowHead = int.MaxValue / 10;   // 214748364
            int overflowTail = int.MaxValue % 10;   // 7

            int result = 0;

            // 3. Read the digits
            while (index < str.Length)
            {
                int digit = str[index] - '0';
                if (digit < 0 || digit > 9) break;   // not a digit → stop

                // 4. Overflow check
                if (result > overflowHead ||
                    (result == overflowHead && digit > overflowTail))
                {
                    return negative ? int.MinValue : int.MaxValue;
                }

                result = result * 10 + digit;
                index++;
            }

            return negative ? -result : result;
        }

        public static void Run()
        {
            Console.WriteLine("8. String to Integer (atoi)");
            var s = new _008_StringToInteger();
            Console.WriteLine(s.MyAtoi("42"));               // Output: 42
            Console.WriteLine(s.MyAtoi("   -42"));           // Output: -42
            Console.WriteLine(s.MyAtoi("4193 with words"));  // Output: 4193
            Console.WriteLine(s.MyAtoi("words and 987"));    // Output: 0
            Console.WriteLine(s.MyAtoi("-91283472332"));     // Output: -2147483648
        }
    }
}