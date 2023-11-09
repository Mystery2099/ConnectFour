namespace Connect_Four.Classes.Boards;

internal interface IBoard
{
    int[,] Cells { get; }
    int Rows { get; }
    int Columns { get; }
    bool IsFull();
    bool HasWinner();
    bool IsMoveValid(int column);
    void MakeMove(int column, byte player);
    void Print();
}