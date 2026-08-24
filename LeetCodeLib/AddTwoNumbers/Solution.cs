namespace LeetCodeLib.AddTwoNumbers;

public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode resNode = null;
        ListNode lastNode = null;
        byte inMind = 0;
        while ((l1 != null || l2 != null) || inMind > 0)
        {
            var val = (l1?.val ?? 0) + (l2?.val ?? 0) + inMind;
            if (val >= 10)
            {
                val -= 10;
                inMind = 1;
            }
            else
                inMind = 0;

            if (resNode == null)
            {
                lastNode = resNode = new ListNode(val);

            }
            else
            {

                lastNode.next = new ListNode(val);
                lastNode = lastNode.next;
            }
            l1 = l1?.next;
            l2 = l2?.next;
        }
        return resNode;
    }
}