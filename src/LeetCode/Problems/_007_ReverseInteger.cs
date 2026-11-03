// Problem 7: Reverse Integer (Medium)

// 🔗 https://leetcode.com/problems/reverse-integer/

// 📖 The question

// Reverse the digits of a 32-bit integer.
// If the reversed number goes outside the int range, return 0.

// Examples:

// 123  → 321
// -123 → -321
// 120  → 21
// 1534236469 → 0   (reversed = 9646324351, too big for int)

// 🧠 The idea: pop and push digits 🔢

// Like moving coins from one stack to another:
// take the LAST digit off x, and add it to the END of result.

// Pop the last digit: digit = x % 10
// Remove it from x:   x = x / 10
// Push it to result:  result = result * 10 + digit

// Before pushing, check for overflow:
// if result is already bigger than int.MaxValue / 10,
// then result * 10 would overflow, so return 0.

// Walkthrough for x = 123:

// x = 123 → digit 3 → result = 0*10 + 3   = 3
// x = 12  → digit 2 → result = 3*10 + 2   = 32
// x = 1   → digit 1 → result = 32*10 + 1  = 321
// x = 0   → stop
// Answer = 321

// Negative numbers work automatically:
// -123 % 10 = -3, so the result builds up as -3 → -32 → -321

// 7. Reverse Integer (Medium)
// https://leetcode.com/problems/reverse-integer/
// Time: O(log n)  Space: O(1)




namespace LeetCode.Problems
{
    public class _007_ReverseInteger
    {
        public int Reverse(int x)
        {
           int result =0;
           int positiveOverflow=int.MaxValue/10;
           int negativeOverflow=int.MinValue/10;

           while(x!=0)
            {
                
                if(result>positiveOverflow || result<negativeOverflow)
                    return 0;

                result = result*10 + x%10;
                x/=10;
            }
            return result;
        }

        public static void Run()
        {
            Console.WriteLine("07 Reverse Integer");
            var s = new _007_ReverseInteger();
            Console.WriteLine(s.Reverse(123)); // Output: 321
            Console.WriteLine(s.Reverse(-123)); // Output: -321
            Console.WriteLine(s.Reverse(120)); // Output: 21
        }
    }
}