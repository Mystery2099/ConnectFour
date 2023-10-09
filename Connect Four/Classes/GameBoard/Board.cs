namespace Connect_Four.Classes.GameBoard;

//Probably replace using columns and rows with a single size number when creating new board
//because boards should always be squares
public class Board
{
    private Board(short rows, short columns)
    {
        Cells = new short[rows, columns];
        Rows = rows;
        Columns = columns;
    }

    public short[,] Cells { get; set; }
    public short Rows { get; }
    public short Columns { get; }

    public bool IsFull
    {
        get {
            for (var column = 0; column < Columns; column++)
            {
                if (Cells[0, column] != 0) continue;
                return false;
            }
            return true;
            }
    }
    
    public bool HasWinner
    {
        get
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

            // Check columns for a winner
            for (var row = 0; row < Rows - 3; row++)
            {
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

            // Check diagonals for a winner
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
    }
    
    public bool IsValidMove(int col) => col >= 0 && col < Columns && Cells[0, col] is 0;

    public void MakeMove(short col, short player)
    {
        for (var row = Rows - 1; row >= 0; row--)
        {
            if (Cells[row, col] != 0) continue;
            Cells[row, col] = player;
            break;
        }
    }
    
    public void Print()
    {
        Console.Clear();

        for (var row = 0; row < Rows; row++)
        {
            for (var col = 0; col < Columns; col++)
            {
                Console.Write("|");

                switch (Cells[row,col])
                {
                    case 0:
                        Console.Write(" ");
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("O");
                        Console.ResetColor();
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("O");
                        Console.ResetColor();
                        break;
                }
            }

            Console.WriteLine("|");
        }

        for (var col = 0; col < Columns; col++)
        {
            Console.Write($" {col}");
        }

        Console.WriteLine();
    }

    public static Board Create(BoardSize boardSize) => boardSize switch
    {
        //Needs to be worked on because connecting 4 still works on larger sizes
        //however if it is 8x8, 8 matches should be required
        BoardSize.Normal => new Board(4, 4),
        BoardSize.Large => new Board(8, 8),
        _ => throw new ArgumentOutOfRangeException(nameof(boardSize), boardSize, null)
    };
}