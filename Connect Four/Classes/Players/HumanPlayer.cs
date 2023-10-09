using Connect_Four.Classes.GameBoard;
using Connect_Four.Interfaces;
using static System.Console;

namespace Connect_Four.Classes.Players;

public class HumanPlayer : Player
{
    public HumanPlayer(string name, short playerNumber) : base(name, playerNumber)
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