using Connect_Four.Classes.GameBoard;

namespace Connect_Four.Interfaces;

internal interface IPlayer
{
    short MakeMove(Board board);
}