using Connect_Four.Classes.GameBoard;
using Connect_Four.Interfaces;

namespace Connect_Four.Classes.Players;

internal class ComputerPlayer : Player
{
    private IStrategy Strategy { get; }
    
    public ComputerPlayer(string name, byte playerNumber, IStrategy strategy) : base(name, playerNumber)
    {
        Strategy = strategy;
    }

    public override short MakeMove(Board board) => Strategy.GetMove(board, PlayerNumber);
}