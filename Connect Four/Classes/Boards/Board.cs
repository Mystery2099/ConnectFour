using static System.Console;

namespace Connect_Four.Classes.Boards;

internal class Board : IBoard
{
    private Board(int rows, int columns)
    {
        Cells = new int[rows, columns];
        Rows = rows;
        Columns = columns;
    }

    private Board(int[,] boardSize)
    {
        Cells = boardSize;
        Rows = boardSize.GetLength(0);
        Columns = boardSize.GetLength(1);
    }

    public int[,] Cells { get; }
    public int Rows { get; }
    public int Columns { get; }
    
    public bool IsFull()
    {
        for (var column = 0; column < Columns; column++)
        {
            if (Cells[0, column] != 0) continue;
            return false;
        }

        return true;
    }


    public bool HasWinner() => HasRowWinner() || HasColumnWinner() || HasDiagonalLeftToRightWinner() || HasDiagonalRightToLeftWinner();

    private bool HasRowWinner()
    {
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

        return false;
    }
    private bool HasColumnWinner()
    {
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
        }

        return false;
    }

    private bool HasDiagonalRightToLeftWinner()
    {
        for (var row = 0; row < Rows - 3; row++)
        {
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
        

        return false;
    }

    private bool HasDiagonalLeftToRightWinner()
    {
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

    public bool IsMoveValid(int column) => column >= 0 && column < Columns && Cells[0, column] is 0;

    /*
     * attempts to make a move for the specified player in the specified column
     */
    public void MakeMove(int column, byte player)
    {
        for (var row = Rows - 1; row >= 0; row--)
        {
            if (Cells[row, column] != 0) continue;
            Cells[row, column] = player;
            break;
        }
    }
    
    //The Clone() method that returns a deep copy of the Board
    public Board Clone() {
        //Create a new two-dimensional array with the same size as the current board
        var newBoard = new int[Rows, Columns];
        //Copy each element from the Board to the newBoard
        for (var i = 0; i < Rows; i++) {
            for (var j = 0; j < Columns; j++) {
                newBoard[i, j] = Cells[i, j];
            }
        }
        //Return a new Board object with the newBoard as a parameter
        return new Board(newBoard);
    }
    
    /*
     * Prints the current state of the board to the console
     */
    public void Print()
    {

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

        for (var col = 0; col < Columns; col++) Write($" {col}");

        WriteLine();
    }

    private static int AskForSize(string prompt)
    {
        while (true)
        {
            WriteLine($"Please enter the number of {prompt} you would like your board to have:");
            var input = ReadLine();

            if (int.TryParse(input, out var inputNum) && inputNum is < 10 and > 3) return inputNum;

            Clear();
            WriteLine("You must enter a number which is less than 10 and greater than 3");
        }
    }

    /*
     * Creates a new Board using user input from AskForSize()
     */
    internal static Board Create() => Create(AskForSize("rows"), AskForSize("columns"));

    /*
     * Creates a new board of the given rowCount and columnCount
     */
    internal static Board Create(int rowCount, int columnCount) => new(rowCount, columnCount);
}