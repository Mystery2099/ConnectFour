using Connect_Four.Classes;
using Connect_Four.Classes.GameBoard;

namespace Connect_Four.Interfaces;

public interface IStrategy
{
    short GetMove(Board board, short playerNumber);
}