using Connect_Four.Classes.Strategies;

namespace Connect_Four.Classes.Players;

internal class ComputerPlayer : Player
{
    private IStrategy Strategy { get; }
    
    public ComputerPlayer(string name, byte playerNumber, IStrategy strategy) : base(name, playerNumber)
    {
        Strategy = strategy;
    }

    public override void MakeMove(ref Boards.Board board) => Strategy.GetMove(ref board, PlayerNumber);
}