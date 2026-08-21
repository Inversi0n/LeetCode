namespace LeetCodeLib.Dungeon;

public class CellsPair
{
    public CellsPair(DungeonCell maxHpCell, DungeonCell minHpNeed)
    {
        this.maxHp = maxHpCell;
        this.minHpNeed = minHpNeed;
    }

    public DungeonCell maxHp { get; set; }
    public DungeonCell minHpNeed { get; set; }
}
public class DungeonCell
{
    public byte X { get; set; }
    public byte Y { get; set; }
    public short Hp { get; set; }
    public short CellhHpNeed { get; set; }
    public byte  Depth { get; set; }

    public DungeonCell Parent { get; set; }
    public DungeonCell Right { get; set; }
    public DungeonCell Down { get; set; }

    public DungeonCell(byte x, byte y, short cellValue, DungeonCell parent, byte depth)
    {
        Depth = depth;
        X = x;
        Y = y;

        Hp = (short)((parent?.Hp ?? 0) + cellValue);

        CellhHpNeed = (short)(-Hp + 1);
        if (parent != null && parent.CellhHpNeed > CellhHpNeed)
            CellhHpNeed = parent.CellhHpNeed;

        Parent = parent;

        Right = null;
        Down = null;
    }
}
