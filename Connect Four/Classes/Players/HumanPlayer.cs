using static System.Console;

namespace Connect_Four.Classes.Players;

internal class HumanPlayer : Player
{
    public HumanPlayer(string name, byte playerNumber) : base(name, playerNumber)
    {
    }
    
    public override void MakeMove(ref Boards.Board board)
    {
        short column;
        while (true)
        {
            Write($"{Name}, enter a column number: ");
            var input = ReadLine();

            if (!short.TryParse(input, out column))
            {
                WriteLine($"Invalid input. Please enter a number between 0 and {board.Columns - 1}.");
            }
            else if (!board.IsMoveValid(column))
            {
                WriteLine("Invalid move. Please choose a different column.");
            }
            else break;
        }
        board.MakeMove(column, PlayerNumber);
    }
}