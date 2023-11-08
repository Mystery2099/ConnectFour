namespace Connect_Four.Classes.Players;

internal interface IPlayer
{
    void MakeMove(ref Boards.Board board);
}