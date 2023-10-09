using Connect_Four.Classes.GameBoard;
using Connect_Four.Interfaces;

namespace Connect_Four.Classes.Strategies;

public class DefensiveStrategy : IStrategy
{
    public short GetMove(Board board, short playerNumber)
    {
        for (short col = 0; col < board.Columns; col++)
        {
            if (board.IsValidMove(col))
            {
                board.MakeMove(col, playerNumber);

                if (board.HasWinner)
                {
                    board.UndoMove(col);
                    return col;
                }

                board.UndoMove(col);
            }
        }

        return new RandomStrategy().GetMove(board, playerNumber);
    }
}