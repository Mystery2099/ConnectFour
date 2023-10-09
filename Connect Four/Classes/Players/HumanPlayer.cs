using Connect_Four.Interfaces;
using static System.Console;

namespace Connect_Four.Classes.Players;

public class HumanPlayer : Player
{
    public HumanPlayer(string name, int playerNumber) : base(name, playerNumber)
    {
    }
    
    public override int MakeMove(Board board)
    {
        while (true)
        {
            Write($"{Name}, enter a column number: ");
            var input = ReadLine();

            if (!int.TryParse(input, out var column))
            {
                WriteLine("Invalid input. Please enter a number.");
            }
            else if (!board.IsValidMove(column))
            {
                WriteLine("Invalid move. Please choose a different column.");
            }
            else
            {
                return column;
            }
        }
    }
}