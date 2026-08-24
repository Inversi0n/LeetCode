namespace LeetCodeLib.Dungeon;

public class Solution
{
    private byte _cols;
    private byte _rows;

    public int CalculateMinimumHP(int[][] dungeon)
    {
        _cols = (byte)dungeon.Length;
        _rows = (byte)dungeon[0].Length;

        var cell = CreateCells(dungeon);

        return cell;
    }
    private short CreateCells(int[][] dungeon)
    {
        var cellsArray = new short[_cols * _rows];

        for (int x = _cols - 1; x >= 0; x--)
        {
            for (int y = _rows - 1; y >= 0; y--)
            {
                var parentValue = Math.Min(
                    x + 1 >= _cols ? short.MaxValue : cellsArray[x + 1 + y * _cols],
                     y + 1 >= _rows ? short.MaxValue : cellsArray[x + (y + 1) * _cols]);

                parentValue = parentValue == short.MaxValue ?
                    (short)1 : parentValue;

                cellsArray[x + y * _cols] = (short)Math.Max(1, (parentValue - dungeon[x][y]));
            }
        }

        return cellsArray[0];
    }


    //correct but slow (timeout)
    //private short CreateCells(int[][] dungeon)
    //{
    //    var cellsArray = new short?[_cols * _rows];

    //    var startValue = (short)Math.Max(1, (1 - dungeon[0][0]));
    //    cellsArray[0] = startValue;

    //    var rootHp = (short)(dungeon[0][0]);
    //    var rootReq = rootHp > 0 ? 1 : -rootHp + 1;
    //    var root = new Cell(0, 0, (short)rootReq, rootHp);
    //    SortedSet<Cell> sortedSet = new SortedSet<Cell>();

    //    sortedSet.Add(root);

    //    short? res = null;

    //    while (true)
    //    {
    //        if (!sortedSet.Any())
    //            //if (linkedList.First == null)
    //            return res.Value;

    //        //var cell = linkedList.Pop();

    //        var cell = sortedSet.Min;
    //        sortedSet.Remove(cell);


    //        if (cell.y == _rows - 1 && cell.x == _cols - 1)
    //        {
    //            res = Math.Min(res.HasValue ? res.Value : short.MaxValue, cell.hpReq);

    //            sortedSet.RemoveWhere(c => c.hpReq > res.Value);
    //            //linkedList.RemoveEnds(c => c.hpReq > res.Value);
    //        }

    //        if (cell.x + 1 < _cols)
    //        {
    //            var newHp = (short)(cell.curHp + dungeon[cell.x + 1][cell.y]);
    //            var req = Math.Max(newHp > 0 ? 1 : -newHp + 1, cell.hpReq);
    //            var newCell = new Cell(cell.x + 1, cell.y, (short)req, newHp);

    //            sortedSet.Add(newCell);
    //            //linkedList.InsertBefore(newCell, (newEl, curEl) => curEl.hpReq < newEl.hpReq);
    //        }
    //        if (cell.y + 1 < _rows)
    //        {
    //            var newHp = (short)(cell.curHp + dungeon[cell.x][cell.y + 1]);
    //            var req = Math.Max(newHp > 0 ? 1 : -newHp + 1, cell.hpReq);

    //            var newCell = new Cell(cell.x, cell.y + 1, (short)req, newHp);

    //            //var newV = (short)Math.Max(1, (cell.hpReq - dungeon[cell.x][cell.y - 1]));
    //            //var newCell = new Cell(cell.x, cell.y - 1, newV);

    //            sortedSet.Add(newCell);
    //            //linkedList.InsertBefore(newCell, (newEl, curEl) => curEl.hpReq < newEl.hpReq);
    //        }
    //    }
    //}
}