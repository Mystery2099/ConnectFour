using Connect_Four.Classes.GameBoard;

namespace Connect_Four.Classes.Strategies;

internal interface IStrategy
{
    short GetMove(Board.Board board, short playerNumber);
}