using Connect_Four.Classes.Boards;
using Connect_Four.Classes.Strategies;

namespace Connect_Four.Classes.Players;

internal abstract class Player : IPlayer
{
    public string Name { get; }
    public byte Id { get; }

    protected Player(string name, byte id)
    {
        Name = name;
        Id = id;
    }
    
    /*
     * prompts the player to make a move & returns the column number(short) where the player wants to place their piece
     */
    public abstract void MakeMove(ref Board board);

    public static Player Create(byte playerId, bool playable)
    {
        var name = $"Player {playerId}";
        return playable ? new HumanPlayer(name, playerId) : new ComputerPlayer(name, playerId, new RandomStrategy());
    }
}