using LeetCodeLib._0002_AddTwoNumbers;

namespace LeetCodeTests.AddTwoNumbers;

public partial class AddTwoNumbersTests
{   

    //[Theory]
    //[MemberData(nameof(SumAsLists))]
    //public void AddTwoNumbers_ReturnsExpectedList(ListNode l1, ListNode l2, ListNode expected)
    //{
    //    var solution = new Solution();

    //    var result = solution.AddTwoNumbers(l1, l2);

    //    Assert.Equal(expected, result);
    //}

    [Theory]
    [MemberData(nameof(SumAsInts))]
    public void AddTwoNumbers_ReturnsExpectedNumber(ListNode l1, ListNode l2, int expected)
    {
        var solution = new Solution();

        var result = solution.AddTwoNumbers(l1, l2);

        Assert.Equal(expected, result);
    }
}
