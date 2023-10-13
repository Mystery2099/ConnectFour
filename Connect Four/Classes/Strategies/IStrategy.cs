namespace Connect_Four.Classes.Strategies;

internal interface IStrategy
{
    short GetMove(Boards.Board board, short playerNumber);
}