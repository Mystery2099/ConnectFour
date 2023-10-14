using static System.Console;

namespace Connect_Four.Classes.Boards;

internal class Board : IBoard
{
    private Board(short rows, short columns)
    {
        Cells = new short[rows, columns];
        Rows = rows;
        Columns = columns;
    }

    public short[,] Cells { get; }
    public short Rows { get; }
    public short Columns { get; }
    
    public bool IsFull()
    {
        for (var column = 0; column < Columns; column++)
        {
            if (Cells[0, column] != 0) continue;
            return false;
        }

        return true;
    }

    public bool HasWinner()
    {
        // Check rows for a winner
        for (var row = 0; row < Rows; row++)
        {
            for (var column = 0; column < Columns - 3; column++)
            {
                if (Cells[row, column] != 0 &&
                    Cells[row, column] == Cells[row, column + 1] &&
                    Cells[row, column] == Cells[row, column + 2] &&
                    Cells[row, column] == Cells[row, column + 3])
                {
                    return true;
                }
            }
        }


        for (var row = 0; row < Rows - 3; row++)
        {
            // Check columns for a winner
            for (var column = 0; column < Columns; column++)
            {
                if (Cells[row, column] != 0 &&
                    Cells[row, column] == Cells[row + 1, column] &&
                    Cells[row, column] == Cells[row + 2, column] &&
                    Cells[row, column] == Cells[row + 3, column])
                {
                    return true;
                }
            }

            // Check diagonals for a winner
            for (var column = 0; column < Columns - 3; column++)
            {
                if (Cells[row, column] != 0 &&
                    Cells[row, column] == Cells[row + 1, column + 1] &&
                    Cells[row, column] == Cells[row + 2, column + 2] &&
                    Cells[row, column] == Cells[row + 3, column + 3])
                {
                    return true;
                }
            }
        }

        for (var row = 3; row < Rows; row++)
        {
            for (var col = 0; col < Columns - 3; col++)
            {
                if (Cells[row, col] != 0 &&
                    Cells[row, col] == Cells[row - 1, col + 1] &&
                    Cells[row, col] == Cells[row - 2, col + 2] &&
                    Cells[row, col] == Cells[row - 3, col + 3])
                {
                    return true;
                }
            }
        }

        return false;
    }

    public bool IsMoveValid(int col) => col >= 0 && col < Columns && Cells[0, col] is 0;

    /*
     * attempts to make a move for the specified player in the specified column.
     */
    public void MakeMove(short col, short player)
    {
        for (var row = Rows - 1; row >= 0; row--)
        {
            if (Cells[row, col] != 0) continue;
            Cells[row, col] = player;
            break;
        }
    }
    
    /*
     * Prints the current state of the board to the console
     */
    public void Print()
    {
        Clear();

        for (var row = 0; row < Rows; row++)
        {
            for (var col = 0; col < Columns; col++)
            {
                Write("|");
                
                switch (Cells[row, col])
                {
                    case 0:
                        Write(" ");
                        break;
                    case 1:
                        ForegroundColor = ConsoleColor.Red;
                        Write("O");
                        ResetColor();
                        break;
                    case 2:
                        ForegroundColor = ConsoleColor.Yellow;
                        Write("O");
                        ResetColor();
                        break;
                }
            }

            WriteLine("|");
        }

        for (var col = 0; col < Columns; col++)
        {
            Write($" {col}");
        }

        WriteLine();
    }

    internal static BoardSize AskForSize()
    {
        while (true)
        {
            var output = "Enter";
            var options = Enum.GetValues(typeof(BoardSize));
            for (var i = 0; i < options.Length; i++)
            {
                output += i > 0 ? ",\n" : ' ';
                output += $"'{i}' for a {options.GetValue(i)} board";
            }
            
            WriteLine(output);
            var input = ReadLine();

            if (byte.TryParse(input, out var inputNum) && inputNum < options.Length)
            {
                return (BoardSize)(options.GetValue(inputNum) ?? BoardSize.Normal);
            }

            Clear();
            WriteLine("You must enter a number within the given range!");
        }
    }

    internal static Board Create() => Create(AskForSize());
    internal static Board Create(BoardSize boardSize) => boardSize switch
    {
        BoardSize.Small => new Board(4, 5),
        BoardSize.Normal => new Board(6, 7),
        BoardSize.Large => new Board(8, 9),
        _ => new Board(6, 7)
    };
}