// 1. Two Sum (Easy)
// https://leetcode.com/problems/two-sum/
//You get an array of numbers and a target number. Find the two numbers that add up to the target, and return their positions (indexes).
// Time: O(n)  Space: O(n)



namespace LeetCode.Problems
{
    public class _001_TwoSum
    {
        public int[] TwoSum(int[] nums,int target)
        {
            var seen =new Dictionary<int,int>(); //index 
            for (int i=0 ; i<nums.Length; i++)
            {
                int need = target - nums[i];
                if (seen.TryGetValue(need, out int j))
                {
                    return new[] { j, i };
                }
                seen[nums[i]] = i;
            }
            return new int[] { };
        }
        

        public static void Run()
        {
            var s= new _001_TwoSum();
            Console.WriteLine(string.Join(",", s.TwoSum(new int[] { 2, 7, 11, 15 }, 9)));
            Console.WriteLine(string.Join(",", s.TwoSum(new int[] { 3, 2, 4 }, 6)));
        }
    }
}