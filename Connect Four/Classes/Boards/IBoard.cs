namespace Connect_Four.Classes.Boards;

internal interface IBoard
{
    short[,] Cells { get; }
    short Rows { get; }
    short Columns { get; }
    bool IsFull();
    bool HasWinner();
    bool IsMoveValid(short column);
    void MakeMove(short column, byte player);
    void Print();
}