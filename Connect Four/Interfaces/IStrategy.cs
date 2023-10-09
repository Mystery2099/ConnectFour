using Connect_Four.Classes;

namespace Connect_Four.Interfaces;

public interface IStrategy
{
    int GetMove(Board board, int playerNumber);
}