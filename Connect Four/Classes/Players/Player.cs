using System.Dynamic;
using Connect_Four.Interfaces;

namespace Connect_Four.Classes.Players;

public abstract class Player : IPlayer
{
    public string Name { get; set; }
    public int PlayerNumber { get; set; }

    protected Player(string name, int playerNumber)
    {
        Name = name;
        PlayerNumber = playerNumber;
    }
    
    public abstract int MakeMove(Board board);
}