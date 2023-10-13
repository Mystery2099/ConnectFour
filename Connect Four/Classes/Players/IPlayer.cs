using Connect_Four.Classes.GameBoard;

namespace Connect_Four.Classes.Players;

internal interface IPlayer
{
    short MakeMove(Board board);
}