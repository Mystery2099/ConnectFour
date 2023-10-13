namespace Connect_Four.Classes.Strategies;

internal class RandomStrategy : IStrategy
{
    private readonly Random _random = new();

    public short GetMove(Boards.Board board, short playerNumber)
    {
        while (true)
        {
            var column = (short)_random.Next(board.Columns);

            if (board.IsMoveValid(column))
            {
                return column;
            }
        }
    }
}