using Connect_Four.Classes.GameBoard;
using Connect_Four.Interfaces;

namespace Connect_Four.Classes.Strategies;

internal class RandomStrategy : IStrategy
{
    private Random Random { get; } = new();

    public short GetMove(Board board, short playerNumber)
    {
        while (true)
        {
            var column = (short)Random.Next(board.Columns);

            if (board.IsValidMove(column))
            {
                return column;
            }
        }
    }
}