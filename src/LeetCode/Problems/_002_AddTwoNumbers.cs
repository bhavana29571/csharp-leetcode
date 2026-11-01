//Problem 2: Add Two Numbers (Medium)

//🔗 https://leetcode.com/problems/add-two-numbers/

//📖 The question

//You get two numbers, but each one is stored as a linked list, with the digits
//  in reverse order. Add the two numbers and return the sum as a linked list, also reversed.

//Example:

//l1 = [2,4,3]   →  means 342
//l2 = [5,6,4]   →  means 465
//342 + 465 = 807 → reversed → [7,0,8]


// 2. Add Two Numbers (Medium)
// https://leetcode.com/problems/add-two-numbers/
// Time: O(max(m,n))  Space: O(max(m,n))

namespace LeetCode.Problems
{
    public class _002_AddTwoNumbers
    {
        public ListNode? AddTwoNumbers(ListNode? l1, ListNode? l2)
        {
            var dummy = new ListNode();
            var cur = dummy;
            int carry = 0;

            while (l1 != null || l2 != null || carry != 0)
            {
                int sum = carry;
                if (l1 != null) { sum += l1.val; l1 = l1.next; }
                if (l2 != null) { sum += l2.val; l2 = l2.next; }

                carry = sum / 10;
                cur.next = new ListNode(sum % 10);
                cur = cur.next;
            }

            return dummy.next;
        }

        public static void Run()
        {
            Console.WriteLine("2. Add Two Numbers");
            var s = new _002_AddTwoNumbers();
            Console.WriteLine(ListNode.Print(s.AddTwoNumbers(ListNode.Build(new[] { 2, 4, 3 }), ListNode.Build(new[] { 5, 6, 4 }))));
            Console.WriteLine(ListNode.Print(s.AddTwoNumbers(ListNode.Build(new[] { 0 }), ListNode.Build(new[] { 0 }))));
            Console.WriteLine(ListNode.Print(s.AddTwoNumbers(ListNode.Build(new[] { 9, 9, 9, 9, 9, 9, 9 }), ListNode.Build(new[] { 9, 9, 9, 9 }))));
        }
    }
}