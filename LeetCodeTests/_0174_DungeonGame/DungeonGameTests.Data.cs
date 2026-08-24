
namespace LeetCodeTests._0174_DungeonGame;

public partial class DungeonGameTests
{
    public static TheoryData<int[][], int> DangeonGameData => new()
    {
        {
            new int[][]
            {
                new[] {-2, -3, 3},
                new[] {-5, -10, 1},
                new[] {10, 30, -5}
            },
            7
        },
        {
             new int[][]
            {
                new[] {1,-3,3},
                new[] {0,-2,0},
                new[] { -3, -3, -3 }
            },
            3
        },

        {
             new int[][]
            {
                new[] {1,2,1},
                new[] {-2,-3,-3},
                new[] { 3, 2, -2 }
            },
            1
        },

        {
            new int[][] { new[] {0} },
            1
        },

        {
            new int[][]
            {
                new[] {2},
                new[] {1},
            },
            1
        },

        {
             new int[][]
            {
                new[] {1,-3,3},
                new[] {0,-2,0},
                new[] { -3, -3, -3 }
            },
            3
        },

          {
            new int[][]
            {
                new[] {19,14,-25,-20,-36},
                new[] {-46,-72,-74,25,-24},
                new[] { -38, -57, -38, -73, -23 },
                new[] {-12,1,-70,44,-98},
            },
            115
        },

            {
            new int[][]
            {
                new[] {-5, 27},
                new[] {-95,13},
                new[] {-86,11},
                new[] {-84,-4},
                new[] {4,-4},
                new[] {-7,25},
                new[] {-14,25},
                new[] {24,-67},
                new[] {12,-1},
                new[] {-66,-73},
                new[] {-87,24},
                new[] {-25,-96},
                new[] {-53,-95},
                new[] {-60,-98},
                new[] {-24,-3},
                new[] {5,-20},
                new[] {36,-96},
                new[] {-32,-97},
                new[] {-20,12},
                new[] {22,13},
                new[] {-42,-66},
                new[] {12,18},
                new[] {48,27},
                new[] {-69,25},
                new[] {-13,-17},
                new[] {8,4},
                new[] {22,11},
                new[] {11,-39},
                new[] {12,1},
            },
            576
        },
    };
}