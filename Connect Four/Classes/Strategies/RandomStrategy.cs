using Connect_Four.Interfaces;

namespace Connect_Four.Classes.Strategies;

public class RandomStrategy : IStrategy
{
    public Random Random { get; } = new();

    public int GetMove(Board board, int playerNumber)
    {
        while (true)
        {
            var column = Random.Next(board.Columns);

            if (board.IsValidMove(column))
            {
                return column;
            }
        }
    }
}