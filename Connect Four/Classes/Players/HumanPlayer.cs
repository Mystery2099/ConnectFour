using static System.Console;

namespace Connect_Four.Classes.Players;

internal class HumanPlayer : Player
{
    public HumanPlayer(string name, byte playerNumber) : base(name, playerNumber)
    {
    }
    
    public override void MakeMove(ref Boards.Board board)
    {
        int column;
        while (true)
        {
            Write($"{Name}, enter a column number: ");
            var input = ReadLine();
            string errorTxt;
            if (!int.TryParse(input, out column))
            {
                errorTxt = $"Invalid input. Please enter a number between 0 and {board.Columns - 1}.";
            }
            else if (!board.IsMoveValid(column))
            {
                errorTxt = "Invalid move. Please choose a different column.";
            }
            else break;
            WriteLine(errorTxt);
        }
        
        board.MakeMove(column, this.Id);
    }
}