using LeetCodeLib._0174_DungeonGame;

namespace LeetCodeTests._0174_DungeonGame;

public partial class DungeonGameTests
{
    [Theory]
    [MemberData(nameof(DangeonGameData))]
    public void DungeonTest(int[][] input, int expected)
    {
        var dung = new Solution();

        var result = dung.CalculateMinimumHP(input);
        Assert.Equal(expected, result);
    }
}
