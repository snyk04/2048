using NUnit.Framework;
using TwentyFortyEight.PlayField.Logic;

public class TileMoverTest
{
    private const int AmountOfRows = 4;
    private const int AmountOfColumns = 4;
    
    private static Direction[] _directions =
    {
        Direction.Up, 
        Direction.Right, 
        Direction.Down, 
        Direction.Left
    };

    private static (int, int)[] _moveFrom =
    {
        (3, 0),
        (0, 0),
        (0, 0),
        (0, 3)
    };
    private static (int, int)[] _moveTo =
    {
        (0, 0),
        (0, 3),
        (3, 0),
        (0, 0)
    };
    
    [Test, Sequential]
    public void MakeMove([ValueSource(nameof(_directions))] Direction direction,
        [ValueSource(nameof(_moveFrom))] (int, int) moveFrom,
        [ValueSource(nameof(_moveTo))] (int, int) moveTo)
    {
        var board = new Board(AmountOfRows, AmountOfColumns);
        board[moveFrom.Item1, moveFrom.Item2].Value = new Tile(2);

        var tileMover = new TileMover();
        tileMover.Move(direction, board);

        var boardToCompare = new Board(AmountOfRows, AmountOfColumns);
        boardToCompare[moveTo.Item1, moveTo.Item2].Value = new Tile(2);
        
        Assert.AreEqual(board[moveTo.Item1, moveTo.Item2].Value.Value,
            boardToCompare[moveTo.Item1, moveTo.Item2].Value.Value);
    }
}