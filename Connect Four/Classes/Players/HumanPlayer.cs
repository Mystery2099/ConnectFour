using Connect_Four.Classes.GameBoard;
using static System.Console;

namespace Connect_Four.Classes.Players;

internal class HumanPlayer : Player
{
    public HumanPlayer(string name, byte playerNumber) : base(name, playerNumber)
    {
    }
    
    public override short MakeMove(Board board)
    {
        while (true)
        {
            Write($"{Name}, enter a column number: ");
            var input = ReadLine();

            if (!short.TryParse(input, out var column))
            {
                WriteLine($"Invalid input. Please enter a number between 0 and {board.Columns - 1}.");
            }
            else if (!board.IsValidMove(column))
            {
                WriteLine("Invalid move. Please choose a different column.");
            }
            else return column;
        }
    }
}