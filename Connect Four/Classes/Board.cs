namespace Connect_Four.Classes;

public class Board
{
    public Board(int rows, int cols)
    {
        _board = new int[rows, cols];
        Rows = rows;
        Columns = cols;
    }

    private int[,] _board;
    public int Rows { get; }
    public int Columns { get; }

    public bool IsFull
    {
        get {
            for (var col = 0; col < Columns; col++)
            {
                if (_board[0, col] != 0) continue;
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
                for (var col = 0; col < Columns - 3; col++)
                {
                    if (_board[row, col] != 0 &&
                        _board[row, col] == _board[row, col + 1] &&
                        _board[row, col] == _board[row, col + 2] &&
                        _board[row, col] == _board[row, col + 3])
                    {
                        return true;
                    }
                }
            }

            // Check columns for a winner
            for (var row = 0; row < Rows - 3; row++)
            {
                for (var col = 0; col < Columns; col++)
                {
                    if (_board[row, col] != 0 &&
                        _board[row, col] == _board[row + 1, col] &&
                        _board[row, col] == _board[row + 2, col] &&
                        _board[row, col] == _board[row + 3, col])
                    {
                        return true;
                    }
                }
            }

            // Check diagonals for a winner
            for (var row = 0; row < Rows - 3; row++)
            {
                for (var col = 0; col < Columns - 3; col++)
                {
                    if (_board[row, col] != 0 &&
                        _board[row, col] == _board[row + 1, col + 1] &&
                        _board[row, col] == _board[row + 2, col + 2] &&
                        _board[row, col] == _board[row + 3, col + 3])
                    {
                        return true;
                    }
                }
            }

            for (var row = 3; row < Rows; row++)
            {
                for (var col = 0; col < Columns - 3; col++)
                {
                    if (_board[row, col] != 0 &&
                        _board[row, col] == _board[row - 1, col + 1] &&
                        _board[row, col] == _board[row - 2, col + 2] &&
                        _board[row, col] == _board[row - 3, col + 3])
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
    
    public bool IsValidMove(int col)
    {
        return col >= 0 && col < Columns && _board[0, col] == 0;
    }
    
    public void MakeMove(int col, int player)
    {
        for (var row = Rows - 1; row >= 0; row--)
        {
            if (_board[row, col] != 0) continue;
            _board[row, col] = player;
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

                switch (_board[row,col])
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
            Console.Write($" {col} ");
        }

        Console.WriteLine();
    }

}