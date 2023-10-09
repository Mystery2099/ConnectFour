using Connect_Four.Classes.GameBoard;
using Connect_Four.Interfaces;

namespace Connect_Four.Classes.Players;

public abstract class Player : IPlayer
{
    public string Name { get; set; }
    public short PlayerNumber { get; set; }

    protected Player(string name, short playerNumber)
    {
        Name = name;
        PlayerNumber = playerNumber;
    }
    
    public abstract short MakeMove(Board board);
}