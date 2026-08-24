using LeetCodeLib._0002_AddTwoNumbers;

namespace LeetCodeTests.AddTwoNumbers;

public partial class AddTwoNumbersTests
{

    //public static TheoryData<ListNode, ListNode, ListNode> SumAsLists => new()
    //{
    //    { ListNode.FromNumber(342), ListNode.FromNumber(465), ListNode.FromNumber(807) },
    //    { ListNode.FromNumber(0), ListNode.FromNumber(0), ListNode.FromNumber(0) },
    //    { ListNode.FromNumber(9999999), ListNode.FromNumber(9999), ListNode.FromNumber(10009998) },
    //};

    public static TheoryData<ListNode, ListNode, int> SumAsInts => new()
    {
        { ListNode.FromNumber(342), ListNode.FromNumber(465), 807 },
        { ListNode.FromNumber(0), ListNode.FromNumber(0), 0 },
        { ListNode.FromNumber(9999999), ListNode.FromNumber(9999), 10009998 },
    };
}
