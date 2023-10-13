using Connect_Four.Classes.GameBoard;

namespace Connect_Four.Interfaces;

internal interface IStrategy
{
    short GetMove(Board board, short playerNumber);
}