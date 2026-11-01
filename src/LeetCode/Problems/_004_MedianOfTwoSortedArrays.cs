// Problem 4: Median of Two Sorted Arrays (Hard)

// 🔗 https://leetcode.com/problems/median-of-two-sorted-arrays/

// 📖 The question

// You get two sorted arrays. Find the median of all the numbers together.

// Median is the middle number after sorting:

// Odd count: the middle one
// Even count: the average of the 2 middle ones

// Examples:

// [1,3] + [2]    → [1,2,3]   → median = 2
// [1,2] + [3,4]  → [1,2,3,4] → (2+3)/2 = 2.5
// 🧠 The idea: merge, like two queues 🧍🧍

// Two sorted queues of people, ordered by height. Each time, pick the shorter of the two front people and put them in one new queue. The result is one sorted array, and you take the middle.

// 4. Median of Two Sorted Arrays (Hard)
// https://leetcode.com/problems/median-of-two-sorted-arrays/
// Time: O(m+n)  Space: O(m+n)



// 4. Median of Two Sorted Arrays (Hard)
// https://leetcode.com/problems/median-of-two-sorted-arrays/
// Time: O(m+n)  Space: O(m+n)

namespace LeetCode.Problems
{
    public class _004_MedianOfTwoSortedArrays
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int total = nums1.Length + nums2.Length;
            int[] merged = new int[total];
            int i = 0, j = 0, k = 0;

            // pick the smaller front element each time
            while (i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] <= nums2[j]) merged[k++] = nums1[i++];
                else merged[k++] = nums2[j++];
            }

            // copy leftovers
            while (i < nums1.Length) merged[k++] = nums1[i++];
            while (j < nums2.Length) merged[k++] = nums2[j++];

            if (total % 2 == 1)
                return merged[total / 2];                                // odd

            return (merged[total / 2 - 1] + merged[total / 2]) / 2.0;   // even
        }

        public static void Run()
        {
            Console.WriteLine("4. Median of Two Sorted Arrays");
            var s = new _004_MedianOfTwoSortedArrays();
            Console.WriteLine(s.FindMedianSortedArrays(new[] { 1, 3 }, new[] { 2 }));       // 2
            Console.WriteLine(s.FindMedianSortedArrays(new[] { 1, 2 }, new[] { 3, 4 }));    // 2.5
            Console.WriteLine(s.FindMedianSortedArrays(new int[] { }, new[] { 1 }));        // 1
        }
    }
}