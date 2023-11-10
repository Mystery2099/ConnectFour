namespace Connect_Four.Classes.Players;

internal interface IPlayer
{
    string Name { get; }
    byte Id { get; }
    void MakeMove(ref Boards.Board board);
}