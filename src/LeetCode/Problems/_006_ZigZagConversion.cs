// Problem 6: Zigzag Conversion (Medium)

// 🔗 https://leetcode.com/problems/zigzag-conversion/

// 📖 The question

// Write the string in a zigzag on numRows rows, then read it row by row.

// Example: s = "PAYPALISHIRING", numRows = 3

// P   A   H   N
// A P L S I I G
// Y   I   R

// Reading row by row gives "PAHNAPLSIIGYIR"

// 🧠 The idea: bounce like a ball ⚽

// Imagine 3 baskets (rows). Drop letters in them one by one:

// Go down: row 0 → 1 → 2
// Hit the bottom, so go up: 2 → 1 → 0
// Hit the top, so go down again...

// At the end, join basket 0, then basket 1, then basket 2.

// P → row 0 ↓
// A → row 1 ↓
// Y → row 2 (bottom, turn ↑)
// P → row 1 ↑
// A → row 0 (top, turn ↓)
// L → row 1 ↓ ...

// 6. Zigzag Conversion (Medium)
// https://leetcode.com/problems/zigzag-conversion/
// Time: O(n)  Space: O(n)


using System.Text;

namespace LeetCode.Problems
{
    using System.Text;
    public class _006_ZigZagConversion
    {
        public string Convert(string s , int numRows)
        {
            if(numRows ==1 || numRows >= s.Length)
                return s;

            var rows = new StringBuilder[numRows];
            
            for(int i = 0; i < numRows; i++)
                rows[i] = new StringBuilder();


            int row=0;
            bool goingDown= false;

            foreach(var c in s)
            {
                rows[row].Append(c);
                if(row == 0 || row == numRows -1)
                    goingDown = !goingDown;

                row += goingDown ? 1 : -1;
            }

            var result = new StringBuilder();
            foreach(var rowBuilder in rows)
                result.Append(rowBuilder);

            return result.ToString();
        }

        public static void Run()
        {
            Console.WriteLine("ZigZag Conversion");
            var s = new _006_ZigZagConversion();
            Console.WriteLine(s.Convert("PAYPALISHIRING", 3)); // Output:
            Console.WriteLine(s.Convert("PAYPALISHIRING", 4)); // Output: "PINALSIGYAHRPI"
            Console.WriteLine(s.Convert("A", 1)); // Output: "A"

        }
    }
}