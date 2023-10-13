using Connect_Four.Classes.GameBoard;
using Connect_Four.Classes.Strategies;
using Connect_Four.Interfaces;

namespace Connect_Four.Classes.Players;

internal abstract class Player : IPlayer
{
    public string Name { get; }
    public byte PlayerNumber { get; }

    protected Player(string name, byte playerNumber)
    {
        Name = name;
        PlayerNumber = playerNumber;
    }
    
    public abstract short MakeMove(Board board);

    public static Player Create(byte playerNum, bool playable)
    {
        var name = $"Player {playerNum}";
        return playable ? new HumanPlayer(name, playerNum) : new ComputerPlayer(name, playerNum, new RandomStrategy());
    }
}