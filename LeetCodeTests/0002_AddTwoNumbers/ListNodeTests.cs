using LeetCodeLib.AddTwoNumbers;

namespace LeetCodeTests.AddTwoNumbers;

public partial class ListNodeTests
{
    [Theory]
    [MemberData(nameof(FromNumberCases))]
    public void FromNumber_BuildsExpectedChain(int number, ListNode expected)
    {
        var result = ListNode.FromNumber(number);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void FromNumber_Zero_ReturnsSingleZeroNode()
    {
        var result = ListNode.FromNumber(0);

        Assert.Equal(new ListNode(0), result);
        Assert.Null(result.next);
    }

    [Fact]
    public void FromNumber_NegativeNumber_Throws()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => ListNode.FromNumber(-5));
    }

    [Theory]
    [MemberData(nameof(StructuralEqualityCases))]
    public void Equals_ListNode_ComparesStructurally(ListNode left, ListNode right, bool expected)
    {
        Assert.Equal(expected, left.Equals(right));
        Assert.Equal(expected, left == right);
    }

    [Theory]
    [MemberData(nameof(NumberEqualityCases))]
    public void Equals_Int_ComparesAsNumber(ListNode node, int number, bool expected)
    {
        Assert.Equal(expected, node.Equals(number));
        Assert.Equal(expected, node == number);
    }

    [Fact]
    public void ImplicitConversion_ToInt_ReturnsRepresentedNumber()
    {
        var node = ListNode.FromNumber(352);

        int asInt = node;

        Assert.Equal(352, asInt);
    }

    [Fact]
    public void ToString_ReadableRepresentation()
    {
        var node = new ListNode(2, new ListNode(5, new ListNode(3)));

        Assert.Equal("[2, 5, 3]", node.ToString());
    }
}
