namespace Connect_Four.Classes.Strategies;

internal class RandomStrategy : IStrategy
{
    private readonly Random _random = new();

    public short GetMove(Boards.Board board, byte playerNumber)
    {
        while (true)
        {
            //putting in a short as the max value, therefore casting to a short should not through an error
            var column = (short)_random.Next(board.Columns);

            if (board.IsMoveValid(column)) return column;
        }
    }
}