﻿namespace Connect_Four.Classes.Board;

internal interface IBoard
{
    short[,] Cells { get; }
    short Rows { get; }
    short Columns { get; }
    bool IsFull();
    bool HasWinner();
    bool IsMoveValid(int col);
    void MakeMove(short col, short player);
    void Print();
}