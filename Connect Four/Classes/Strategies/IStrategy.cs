using Connect_Four.Classes.Boards;

namespace Connect_Four.Classes.Strategies;

internal interface IStrategy
{
    void GetMove(ref Board board, byte playerNumber);
}