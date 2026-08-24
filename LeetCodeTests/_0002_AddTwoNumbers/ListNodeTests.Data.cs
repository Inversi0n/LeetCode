using LeetCodeLib._0002_AddTwoNumbers;
using Xunit;

namespace LeetCodeTests.AddTwoNumbers;

public partial class ListNodeTests
{
    public static TheoryData<int, ListNode> FromNumberCases => new()
    {
        { 352, new ListNode(2, new ListNode(5, new ListNode(3))) },
        { 9, new ListNode(9) },
        {
            10009998,
            new ListNode(8, new ListNode(9, new ListNode(9, new ListNode(9,
                new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(1))))))))
        },
    };

    public static TheoryData<ListNode, ListNode, bool> StructuralEqualityCases => new()
    {
        { ListNode.FromNumber(352), ListNode.FromNumber(352), true },
        { ListNode.FromNumber(352), ListNode.FromNumber(353), false },

        // одно и то же число (35), но разная структура списка (лишний узел с 0) —
        // Equals(ListNode) сравнивает именно структуру, а не значение
        { new ListNode(5, new ListNode(3)), new ListNode(5, new ListNode(3, new ListNode(0))), false },
        { new ListNode(0), null, false },
    };

    public static TheoryData<ListNode, int, bool> NumberEqualityCases => new()
    {
        { ListNode.FromNumber(352), 352, true },
        { ListNode.FromNumber(352), 999, false },
    };
}
