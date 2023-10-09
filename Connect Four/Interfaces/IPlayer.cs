using Connect_Four.Classes.GameBoard;

namespace Connect_Four.Interfaces;

public interface IPlayer
{
    short MakeMove(Board board);
}