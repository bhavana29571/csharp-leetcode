namespace LeetCode.Problems
{
    public class ListNode
    {
        public int val;
        public ListNode? next;

        public ListNode(int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }

        public static ListNode? Build(int[] values)
        {
            var dummy = new ListNode();
            var cur = dummy;
            foreach (int v in values)
            {
                cur.next = new ListNode(v);
                cur = cur.next;
            }
            return dummy.next;
        }

        public static string Print(ListNode? head)
        {
            var parts = new List<int>();
            while (head != null)
            {
                parts.Add(head.val);
                head = head.next;
            }
            return "[" + string.Join(",", parts) + "]";
        }
    }
}