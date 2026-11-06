// Problem 11: Container With Most Water (Medium)

// 🔗 https://leetcode.com/problems/container-with-most-water/

// I can’t run code in this chat, so test it on your side. The expected outputs below are worked out by hand.

// 📖 The question

// You get an array of heights, like vertical walls. Pick 2 walls that hold the most water between them. Return that amount.

// height = [1,8,6,2,5,4,8,3,7]
// Best pair = the wall of height 8 (index 1) and the wall of height 7 (index 8)
// Width = 8 - 1 = 7,  height = min(8, 7) = 7
// Water = 7 × 7 = 49

// Water = width × the shorter wall. Water spills over the shorter wall, so the shorter one decides the height.

// 🧠 The idea: two pointers 👈👉
// Start with the widest container, with one pointer at each end.
// Work out the water and keep the best so far.
// Move the pointer on the shorter wall inward.

// Why move the shorter wall? The shorter wall limits the water. If you moved the taller one, the width shrinks and the height can’t improve, so the water can only get worse. Moving the shorter one is the only way to find a better result.

// 🛠 Steps
// Step 1: Create Problems/_011_ContainerWithMostWater.cs
// csharp
// // 11. Container With Most Water (Medium)
// // https://leetcode.com/problems/container-with-most-water/
// // Time: O(n)  Space: O(1)



namespace LeetCode.Problems

{
    public class _011_ContainerWithMostWater
    {
        public int MaxArea(int[] height)
        {
            int left =0, right = height.Length - 1;
            int best =0;

            while(left < right)
            {
                int width = right - left;
                int area = Math.Min(height[left],height[right])* width;
                best = Math.Max(best,area);

                if(height[left] < height[right])

                left++;

                else
                  right--;
            }
            return best;
        }
        public static void Run()
        {
             Console.WriteLine("11. Container With Most Water");
            var s = new _011_ContainerWithMostWater();
            Console.WriteLine(s.MaxArea(new[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 })); // 49
            Console.WriteLine(s.MaxArea(new[] { 1, 1 }));                      // 1
            Console.WriteLine(s.MaxArea(new[] { 4, 3, 2, 1, 4 }));             // 16
            Console.WriteLine(s.MaxArea(new[] { 1, 2, 1 }));                   // 2
        }
    }

}