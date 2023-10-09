﻿namespace Connect_Four.Classes.GameBoard;

public class Board
{
    private Board(short rows, short columns)
    {
        _cells = new short[rows, columns];
        Rows = rows;
        Columns = columns;
    }

    private readonly short[,] _cells;
    public short Rows { get; }
    public short Columns { get; }

    public bool IsFull
    {
        get {
            for (var col = 0; col < Columns; col++)
            {
                if (_cells[0, col] != 0) continue;
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
                    if (_cells[row, col] != 0 &&
                        _cells[row, col] == _cells[row, col + 1] &&
                        _cells[row, col] == _cells[row, col + 2] &&
                        _cells[row, col] == _cells[row, col + 3])
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
                    if (_cells[row, col] != 0 &&
                        _cells[row, col] == _cells[row + 1, col] &&
                        _cells[row, col] == _cells[row + 2, col] &&
                        _cells[row, col] == _cells[row + 3, col])
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
                    if (_cells[row, col] != 0 &&
                        _cells[row, col] == _cells[row + 1, col + 1] &&
                        _cells[row, col] == _cells[row + 2, col + 2] &&
                        _cells[row, col] == _cells[row + 3, col + 3])
                    {
                        return true;
                    }
                }
            }

            for (var row = 3; row < Rows; row++)
            {
                for (var col = 0; col < Columns - 3; col++)
                {
                    if (_cells[row, col] != 0 &&
                        _cells[row, col] == _cells[row - 1, col + 1] &&
                        _cells[row, col] == _cells[row - 2, col + 2] &&
                        _cells[row, col] == _cells[row - 3, col + 3])
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
        return col >= 0 && col < Columns && _cells[0, col] == 0;
    }
    
    public void MakeMove(short col, short player)
    {
        for (var row = Rows - 1; row >= 0; row--)
        {
            if (_cells[row, col] != 0) continue;
            _cells[row, col] = player;
            break;
        }
    }
    public void UndoMove(int column, int playerNumber)
    {
        for (var row = Rows - 1; row >= 0; row--)
        {
            if (_cells[row, column] != playerNumber) continue;
            _cells[row, column] = 0;
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

                switch (_cells[row,col])
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

    public static Board Create(BoardSize boardSize) => boardSize switch
    {
        BoardSize.Normal => new Board(4, 4),
        BoardSize.Large => new Board(8, 8),
        _ => throw new ArgumentOutOfRangeException(nameof(boardSize), boardSize, null)
    };
}