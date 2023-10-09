using Connect_Four.Classes.Strategies;
using Connect_Four.Interfaces;

namespace Connect_Four.Classes.Players;

public class ComputerPlayer : Player
{
    public IStrategy Strategy { get; }

    public ComputerPlayer(string name, int playerNumber) : this(name, playerNumber, new RandomStrategy()){}
    public ComputerPlayer(string name, int playerNumber, IStrategy strategy) : base(name, playerNumber)
    {
        Strategy = strategy;
    }

    public override int MakeMove(Board board)
    {
        return Strategy.GetMove(board, PlayerNumber);
    }
}