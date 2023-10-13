namespace Connect_Four.Classes.Players;

internal interface IPlayer
{
    short MakeMove(Boards.Board board);
}