using Connect_Four.Classes.Boards;

namespace Connect_Four.Classes.Strategies;

internal class RandomStrategy : IStrategy
{
    private readonly Random _random = new();

    public void GetMove(ref Board board, byte playerNumber)
    {
        short column;
        while (true)
        {
            //putting in a short as the max value, therefore casting to a short should not through an error
            column = (short)_random.Next(board.Columns);

            if (board.IsMoveValid(column)) break;
        }
        board.MakeMove(column, playerNumber);
    }
}