using System.Net.Http.Headers;

namespace LeetCodeLib.Dungeon;

public class Dungeons
{
    private int _cols;
    private int _rows;

    public int CalculateMinimumHP(int[][] dungeon)
    {
        _cols = (byte)dungeon.Length;
        _rows = (byte)dungeon[0].Length;

        DungeonCell cell = CreateCells(dungeon, 0, 0);

        return Math.Max((short)1, cell.CellhHpNeed);
    }

    private DungeonCell CreateCells(int[][] dungeon, byte x, byte y)
    {
        var root = new DungeonCell(x, y, (short)dungeon[x][y], null, 0);

        var list = new LinkedList<DungeonCell>();
        var cellsArray = new CellsPair[_cols, _rows];
        cellsArray[0, 0] = new (root, root);
        list.AddFirst(root);

        while (list.Count > 0)
        {
            var cell = list.Pop();

            if (cell.X + 1 < _cols)
            {
                var right = new DungeonCell((byte)(cell.X + 1), cell.Y, (short)dungeon[cell.X + 1][cell.Y], cell, (byte)(cell.Depth + 1));

                cell.Right = right;
                if (ReplaceInArray(cellsArray, right, out var oldCell))
                {
                    if (oldCell != null)
                    {
                        list.Remove(oldCell);
                        ReplaceAsChild(right);
                    }
                    InsertToList(list, right);
                }
            }

            if (cell.Y + 1 < _rows)
            {
                var down = new DungeonCell(cell.X, (byte)(cell.Y + 1), (short)dungeon[cell.X][cell.Y + 1], cell, (byte)(cell.Depth + 1));

                if (ReplaceInArray(cellsArray, down, out var oldCell))
                {
                    if (oldCell != null)
                    {
                        list.Remove(oldCell);
                        ReplaceAsChild(down);
                    }
                    InsertToList(list, down);
                }

                cell.Down = down;
            }

            if (cell.Down == null && cell.Right == null)
            {
                var stopper = 0;
                //   return cell;
            }
        }

        return cellsArray[_cols - 1, _rows - 1].minHpNeed;
    }

    private static void InsertToList(LinkedList<DungeonCell> list, DungeonCell cell)
    {
        list.InsertBefore(cell, (newV, oldV) =>
        {
            if (newV.CellhHpNeed == oldV.CellhHpNeed)
            {
                return newV.Depth < oldV.Depth;
            }

            if (newV.CellhHpNeed > oldV.CellhHpNeed)
                return true;

            return false;
        });
    }

    private void ReplaceAsChild(DungeonCell cell)
    {
        var p = cell.Parent;
        if (p == null)
            return;

        if (p.X + 1 == cell.X)
        {
            var oldRight = cell.Right;
            if (oldRight != null)
            {
                oldRight.Parent = null;
                oldRight.Down = null;
                oldRight.Right = null;
            }
        }

        if (p.Y + 1 == cell.Y)
        {
            var oldDown = cell.Down;
            if (oldDown != null)
            {
                oldDown.Parent = null;
                oldDown.Down = null;
                oldDown.Right = null;
            }
        }
    }

    private bool ReplaceInArray(CellsPair[,] array, DungeonCell cell, out DungeonCell oldCell)
    {
        var res = ReplaceByMaxHp(array, cell, out oldCell);

        return ReplaceByMinHpNeeded(array, cell, out oldCell) || res;

    }

    private static bool ReplaceByMaxHp(CellsPair[,] array, DungeonCell cell, out DungeonCell oldCell)
    {

        oldCell = array[cell.X, cell.Y]?.maxHp;
        if (oldCell == null)
        {
            array[cell.X, cell.Y] = new (cell, cell);
            return true;
        }

        if (cell.Hp < oldCell.Hp)
        //if (cell.CellhHpNeed >= oldCell.CellhHpNeed)
        {
            //oldCell.Parent = null;
            return false;
        }

        array[cell.X, cell.Y].maxHp = cell;
        //array[cell.X, cell.Y] = cell;

        oldCell.Parent = null;
        oldCell.Right = null;
        oldCell.Down = null;

        return true;

    }

    private static bool ReplaceByMinHpNeeded(CellsPair[,] array, DungeonCell cell, out DungeonCell oldCell)
    {
        oldCell = array[cell.X, cell.Y]?.minHpNeed;
        if (oldCell == null)
        {
            array[cell.X, cell.Y] = new (cell, cell);
            return true;
        }

        //if (cell.Hp < oldCell.Hp)
        if (cell.CellhHpNeed >= oldCell.CellhHpNeed)
        {
            //oldCell.Parent = null;
            return false;
        }

        array[cell.X, cell.Y].minHpNeed = cell;
        //array[cell.X, cell.Y] = cell;

        oldCell.Parent = null;
        oldCell.Right = null;
        oldCell.Down = null;

        return true;
    }
}