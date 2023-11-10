using Connect_Four.Classes.Boards;
using Connect_Four.Classes.Strategies;

namespace Connect_Four.Classes.Players;

internal class ComputerPlayer : Player
{
    private IStrategy Strategy { get; }
    
    public ComputerPlayer(string name, byte id, IStrategy strategy) : base(name, id)
    {
        Strategy = strategy;
    }

    public override void MakeMove(ref Board board) => Strategy.GetMove(ref board, Id);
}